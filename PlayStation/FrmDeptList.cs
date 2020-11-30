using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmDeptList : XtraForm
    {
        private readonly Data.DebtList _dl = new Data.DebtList();

        public FrmDeptList()
        {
            InitializeComponent();
        }

        private void FrmDeptList_Load(object sender, EventArgs e)
        {
            dtDebtDate.EditValue = DateTime.Now;
            ActiveControl = txtName;
            GetDebtList();
            Process.LogInsert("Borç listesi görüntülendi.", Model.Base.TransactionType.Goruntule);
        }

        private void GetDebtList()
        {
            var li = _dl.Select();
            lvDebtList.Items.Clear();
            foreach (var item in li)
            {
                var lvi = new ListViewItem
                {
                    Tag = item,
                    Text = item.NAME
                };
                lvi.SubItems.Add(item.GSMNR);
                lvi.SubItems.Add(string.Format("{0:n} TL", item.DEBTAMOUNT));
                lvi.SubItems.Add(string.Format("{0:dd.MM.yyyy}", item.DEBTDATE));
                lvi.SubItems.Add(string.Format("{0:dd.MM.yyyy - HH:mm}", item.CREATEDATE));
                lvDebtList.Items.Add(lvi);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text.Trim()) && !string.IsNullOrEmpty(txtGsmNr.Text.Trim()) && !string.IsNullOrEmpty(txtDebtAmount.Text.Trim()))
            {
                var debt = new Model.DebtList
                {
                    CREATEDATE = DateTime.Now,
                    DEBTAMOUNT = Convert.ToDecimal(txtDebtAmount.Text),
                    DEBTDATE = Convert.ToDateTime(dtDebtDate.EditValue),
                    GSMNR = txtGsmNr.Text,
                    NAME = txtName.Text
                };
                string result;
                _dl.Insert(debt, out result);

                Process.LogInsert(string.Format("{0} adına {1} TL borç eklendi.", txtName.Text, string.Format("{0:n}", txtDebtAmount.Text)), Model.Base.TransactionType.Duzenle);

                txtDebtAmount.Text = "";
                txtGsmNr.Text = "";
                txtName.Text = "";

                GetDebtList();
            }
            else
                MessageBox.Show("Borçlunun bilgilerini tam olarak giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvDebtList.SelectedItems[0] == null) return;

                var debt = lvDebtList.SelectedItems[0].Tag as Model.DebtList;

                var dr = MessageBox.Show(debt.NAME + " adındaki borculunun borcunu silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr != DialogResult.Yes) return;

                Process.LogInsert(string.Format("{0} adında ki kişinin {1} TL borcu silindi.", debt.NAME, string.Format("{0:n}", debt.DEBTAMOUNT)), Model.Base.TransactionType.Duzenle);
                _dl.Delete(debt.LREF);
                GetDebtList();
            }
            catch
            {
                // ignored
            }
        }
    }
}