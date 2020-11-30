using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmCalculateCancelNote : XtraForm
    {
        private readonly Model.Machine _m;
        private readonly Data.Calculates _cal = new Data.Calculates();
        private readonly Data.Additions _add = new Data.Additions();
        private readonly Process _pro = new Process();

        public FrmCalculateCancelNote(Model.Machine machine)
        {
            InitializeComponent();
            _m = machine;
        }

        private void FrmCalculateCancelNote_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("Hesabı iptal etmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(txtNote.Text.Trim()) && !string.IsNullOrWhiteSpace(txtNote.Text.Trim()) && txtNote.Text.Length > 0)
                {
                    var c = _cal.MachineCalc(_m.NR);
                    var cdv = _pro.DetailView(_m);
                    var adds = _add.NotPaidSelect(_m.NR);

                    #region //Adisyon İptali
                    if (adds != null)
                    {
                        string asd;
                        foreach (var item2 in adds)
                        {
                            c.ADDITIONNAME += item2.PRODUCTNAME + " - ";
                            c.ADDITIONTOTAL += (item2.PRODUCTSPRICES * item2.PRODUCTSUNIT);
                            c.ADDITIONUNIT += item2.PRODUCTSUNIT;
                            item2.STATUS = (int)Model.Base.AdditionStatus.IptalEdildi;
                            _add.Update(item2, out asd);
                        }
                    }
                    #endregion

                    #region // Hesap İptali
                    c.CANCELREASON = txtNote.Text.Trim();
                    c.DETAILS = Global.CurrentUser.NAME + " tarafından hesap iptal edildi. Hesap tutarı " + string.Format("{0:n}", cdv.TotalPrice) + " TL. Adisyon tutarı " + string.Format("{0:n}", cdv.AdditionTotal) + " TL.";

                    c.MACHINETOTAL = cdv.TotalPrice;
                    c.MODIFIEDDATETIME = DateTime.Now;
                    c.MODIFIEDUSER = Global.CurrentUser.LREF;
                    c.STARTDATETIME = cdv.StartTime;
                    c.STARTENDDATETIME = DateTime.Now;
                    c.STATUS = (int)Model.Base.MachineType.IptalEdildi;
                    c.TARRIFSREF = _m.TARRIFSREF;
                    c.USEDTIME = DateTime.MinValue.Add(cdv.UsedTime);
                    c.MACHINECLOSESTATUS = _m.MACHINESTATUS;
                    string message;

                    _cal.Update(c, out message);
                    #endregion

                    _pro.MachineClosed(_m);
                    Process.LogInsert(_m.NAME + " --> adisyonlarıyla birlikte (varsa), hesap iptal edildi. İptal sebebi: " + txtNote.Text + " Hesap tutarı: " + string.Format("{0:n} TL", cdv.TotalPrice), Model.Base.TransactionType.Duzenle);

                    DialogResult = DialogResult.Yes;
                    Close();
                }
                else
                    MessageBox.Show("İptal sebebi yazmadan hesap kapatılamaz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                Close();
        }
    }
}