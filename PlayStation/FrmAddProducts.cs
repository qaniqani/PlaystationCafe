using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmAddProducts : XtraForm
    {
        private readonly Data.Products _p = new Data.Products();
        private int _productLref;

        public FrmAddProducts()
        {
            InitializeComponent();
        }

        private void FrmAddProducts_Load(object sender, EventArgs e)
        {
            GetProductsList();
            Process.LogInsert("Ürün listesi görüntülendi.", Model.Base.TransactionType.Goruntule);
        }

        private void GetProductsList()
        {
            var li = _p.Select();
            lvProductList.Items.Clear();
            foreach (var item in li)
            {
                var lvi = new ListViewItem
                {
                    Tag = item.LREF,
                    Text = item.NAME
                };
                lvi.SubItems.Add(item.STOCK.ToString());
                lvi.SubItems.Add(string.Format("{0:n} TL", item.UNITPRICE));
                lvProductList.Items.Add(lvi);
                Application.DoEvents();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtStock.Text) && !string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                if (_productLref == 0)
                {
                    var pro = new Model.Products
                    {
                        CREATEUSER = Global.CurrentUser.LREF,
                        DATETIME = DateTime.Now,
                        MODIFIEDDATETIME = DateTime.Now,
                        MODIFIEDUSER = Global.CurrentUser.LREF,
                        NAME = txtProductName.Text,
                        STOCK = Convert.ToInt32(txtStock.Text),
                        UNITPRICE = Convert.ToDecimal(txtUnitPrice.Text.Replace(".", ","))
                    };
                    string message;
                    _p.Insert(pro, out message);

                    if (!string.IsNullOrEmpty(message))
                        MessageBox.Show(message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Process.LogInsert(txtProductName.Text + " adında ürün eklendi. Ürün sayısı: " + txtStock.Text + ", birim fiyatı: " + txtUnitPrice.Text, Model.Base.TransactionType.Ekle);
                        GetProductsList();
                        txtProductName.Text = "";
                        txtStock.Text = "0";
                        txtUnitPrice.Text = "0";
                    }
                }
                else
                {
                    var pro = new Model.Products
                    {
                        CREATEUSER = Global.CurrentUser.LREF,
                        DATETIME = DateTime.Now,
                        MODIFIEDDATETIME = DateTime.Now,
                        MODIFIEDUSER = Global.CurrentUser.LREF,
                        NAME = txtProductName.Text,
                        STOCK = Convert.ToInt32(txtStock.Text),
                        UNITPRICE = Convert.ToDecimal(txtUnitPrice.Text.Replace(".", ",")),
                        LREF = _productLref
                    };
                    string message;
                    _p.Update(pro, out message);

                    if (!string.IsNullOrEmpty(message))
                        MessageBox.Show(message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Process.LogInsert(txtProductName.Text + " adında ki ürün güncellendi. Ürün sayısı: " + txtStock.Text + ", birim fiyatı: " + txtUnitPrice.Text, Model.Base.TransactionType.Duzenle);
                        GetProductsList();
                        txtProductName.Text = "";
                        txtStock.Text = "0";
                        txtUnitPrice.Text = "0";
                    }
                }
                _productLref = 0;
            }
            else
                MessageBox.Show("Ürün adı, stok sayısı ve birim fiyatını boş bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lvProductList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                cmsRightClick.Show(lvProductList, e.X, e.Y);
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvProductList.SelectedItems[0] == null) return;

                _productLref = Convert.ToInt32(lvProductList.SelectedItems[0].Tag);
                Process.LogInsert(lvProductList.SelectedItems[0].Text + " adındaki ürün düzenleme moduna alındı.", Model.Base.TransactionType.Duzenle);

                var pro = _p.Select(_productLref);
                txtProductName.Text = pro.NAME;
                txtStock.Text = pro.STOCK.ToString();
                txtUnitPrice.Text = pro.UNITPRICE.ToString();
            }catch{}
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("Ürünü silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes) return;

            try
            {
                if (lvProductList.SelectedItems[0] == null) return;

                _productLref = Convert.ToInt32(lvProductList.SelectedItems[0].Tag);
                Process.LogInsert(lvProductList.SelectedItems[0].Text + " adında ki ürün silindi.", Model.Base.TransactionType.Sil);

                string message;
                var result = _p.Delete(_productLref, out message);

                if (result < 1)
                    MessageBox.Show(message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    GetProductsList();

                _productLref = 0;
            }
            catch
            {
                // ignored
            }
        }
    }
}