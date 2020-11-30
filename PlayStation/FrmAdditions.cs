using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PlayStation
{
    public partial class FrmAdditions : DevExpress.XtraEditors.XtraForm
    {
        private readonly Data.Additions _a = new Data.Additions();
        private readonly Data.Products _p = new Data.Products();

        private readonly Model.Machine _machine;
        private readonly Model.Base.AdditionFormType _add;

        private List<Model.Addition> _listAdds;
        private List<Model.Products> _listProd;

        decimal _addsTotal;

        public FrmAdditions(Model.Machine mac, Model.Base.AdditionFormType aft)
        {
            InitializeComponent();
            _machine = mac;
            _add = aft;
        }

        private void FrmAdditions_Load(object sender, EventArgs e)
        {
            if (_machine != null)
            {
                if (_add == Model.Base.AdditionFormType.HesapAdisyonlari)
                {
                    btnSave.Enabled = false;
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                }

                _listAdds = new List<Model.Addition>();
                lblMachineName.Text = Global.CurrentSettings.MACHINETAGNAME + " " + _machine.NR;
                GetProductsList();
                GetMachineAdditionList();
            }
            else
            {
                MessageBox.Show("Lütfen önce adisyon eklenecek " + Global.CurrentSettings.MACHINETAGNAME + " seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetProductsList()
        {
            if(_listProd == null)
                _listProd = _p.Select().OrderBy(s=> s.UNITPRICE).ToList();
            
            lvStock.Items.Clear();
            foreach (var item in _listProd)
            {
                var lvi = new ListViewItem
                {
                    Tag = item.LREF,
                    Text = item.NAME
                };
                lvi.SubItems.Add(item.STOCK.ToString());
                lvi.SubItems.Add(string.Format("{0:n} TL", item.UNITPRICE));
                lvStock.Items.Add(lvi);
            }
        }

        private void GetMachineAdditionList()
        {
            if(_listAdds.Count < 1)
                _listAdds = _a.NotPaidSelect(_machine.NR).OrderBy(d=> d.PRODUCTSUNIT).ToList();

            lvMachineAddition.Items.Clear();
            foreach (var item in _listAdds)
            {
                var lvi = new ListViewItem
                {
                    Tag = item.LREF,
                    Text = item.PRODUCTNAME
                };

                lvi.SubItems.Add(string.Format("{0:n}", (item.PRODUCTSUNIT == 0 ? "0" : item.PRODUCTSUNIT.ToString())));
                lvi.SubItems[0].Tag = item.PRODUCTREF;
                lvi.SubItems.Add(string.Format("{0:n} TL", ((item.PRODUCTSPRICES * item.PRODUCTSUNIT) == 0 ? "0" : (item.PRODUCTSPRICES * item.PRODUCTSUNIT).ToString())));
                lvi.SubItems.Add(string.Format("{0:dd.MM.yyyy - HH:mm}", item.DATETIME));
                _addsTotal += (item.PRODUCTSPRICES * item.PRODUCTSUNIT);
                lvMachineAddition.Items.Add(lvi);
            }
            SetTotalPrice();
            Process.LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + _machine.NR + " --> adisyonları görüntülendi.", Model.Base.TransactionType.Goruntule);
        }

        private void SetTotalPrice()
        {
            dgAdditionTotal.Text = string.Format("{0:#.###,##} TL", (_addsTotal == 0 ? "0" : _addsTotal.ToString()));
        }

        private void lvMachineAddition_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                cmsRightClick.Show(lvMachineAddition, e.X, e.Y);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvStock.SelectedItems[0] == null) return;

                _addsTotal = 0;
                var index = lvStock.SelectedItems[0].Index;
                var p = _listProd.FirstOrDefault(a => a.LREF == (int)lvStock.SelectedItems[0].Tag);

                if (p != null && p.STOCK <= 0) return;
                {
                    p.STOCK--;
                    _listProd.Remove(p);
                    _listProd.Insert(index, p);
                    var a = _listAdds.FirstOrDefault(s => s.PRODUCTREF == p.LREF);
                    if (a != null)
                    {
                        _listAdds.Remove(a);
                        a.PRODUCTSUNIT++;
                        _listAdds.Add(a);
                        lvMachineAddition.Items.Clear();
                    }
                    else
                    {
                        var adds = new Model.Addition
                        {
                            DATETIME = DateTime.Now,
                            MACHINENAME = Global.CurrentSettings.MACHINETAGNAME + " " + _machine.NR,
                            MACHINENR = _machine.NR,
                            MACHINEREF = _machine.LREF,
                            NOTE = txtNote.Text,
                            PRODUCTNAME = p.NAME,
                            PRODUCTREF = p.LREF,
                            PRODUCTSPRICES = p.UNITPRICE,
                            PRODUCTSUNIT = 1,
                            STATUS = (int) Model.Base.AdditionStatus.Odenmedi
                        };
                        _listAdds.Add(adds);
                        lvMachineAddition.Items.Clear();
                    }
                    _listAdds = _listAdds.OrderBy(d => d.PRODUCTSPRICES).ToList();
                    _listProd = _listProd.OrderBy(w => w.UNITPRICE).ToList();
                    GetMachineAdditionList();
                    GetProductsList();
                    SetTotalPrice();
                }
            }
            catch { MessageBox.Show("Önce ürün seçimi yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvMachineAddition.SelectedItems[0] == null) return;

                _addsTotal = 0;
                var a = _listAdds.FirstOrDefault(s => s.LREF == Convert.ToInt32(lvMachineAddition.SelectedItems[0].Tag));

                if (a != null && a.PRODUCTSUNIT <= 0) return;

                _listAdds.Remove(a);
                a.PRODUCTSUNIT--;
                _listAdds.Add(a);

                var p = _listProd.FirstOrDefault(d => d.LREF == (int)lvMachineAddition.SelectedItems[0].SubItems[0].Tag);
                if (p != null)
                {
                    p.STOCK++;
                    _listProd.Remove(p);
                    _listProd.Add(p);
                    foreach (var item in _listProd)
                    {
                        var lvi = new ListViewItem
                        {
                            Tag = item.LREF,
                            Text = item.NAME
                        };
                        lvi.SubItems.Add(item.STOCK.ToString());
                        lvi.SubItems.Add(string.Format("{0:#.###,##} TL", item.UNITPRICE));
                        lvStock.Items.Add(lvi);
                    }
                }
                _listAdds = _listAdds.OrderBy(d => d.PRODUCTSUNIT).ToList();
                _listProd = _listProd.OrderBy(w => w.UNITPRICE).ToList();

                GetMachineAdditionList();
                GetProductsList();
            }
            catch { MessageBox.Show("Önce ürün seçimi yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lvMachineAddition.Items.Count > 0)
            {
                var li = _a.NotPaidSelect(_machine.NR);
                string message;
                foreach (var item in li)
                    _a.Delete(item.LREF, out message);

                var addsCount = 0;
                foreach (var item in _listAdds)
                {
                    item.NOTE = txtNote.Text.Trim();
                    _a.Insert(item, out message);
                    addsCount = item.PRODUCTSUNIT;
                }

                foreach (var item in _listProd)
                    _p.Update(item, out message);

                Process.LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + _machine.NR + " --> adisyon durumu güncellendi. Kayıtlı adisyon sayısı: " + addsCount, Model.Base.TransactionType.Duzenle);

                DialogResult = DialogResult.Yes;

                Close();
            }
            else
                MessageBox.Show("Lütfen önce adisyon ekleyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void lvStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                Close();

            if (e.KeyValue == 13)
                btnSave_Click(null, null);
        }
    }
}