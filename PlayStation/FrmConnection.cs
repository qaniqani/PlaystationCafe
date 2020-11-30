using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmConnection : XtraForm
    {
        public FrmConnection()
        {
            InitializeComponent();
        }

        private void btnDBSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDBName.Text) && !string.IsNullOrEmpty(txtDBPassword.Text) && !string.IsNullOrEmpty(txtDBServerName.Text) && !string.IsNullOrEmpty(txtDBUserName.Text))
            {
                Data.DataAccessLayer.InitialCatalog = txtDBName.Text;
                Data.DataAccessLayer.Password = txtDBPassword.Text;
                //Data.DataAccessLayer.ServerName = txtDBServerName.Text;
                Data.DataAccessLayer.UserName = txtDBUserName.Text;

                if (Data.DataAccessLayer.ConnectionTest())
                {
                    Functions.Function.WriteRegistry("ServerName", Functions.Function.EncryptIt(txtDBServerName.Text.Trim()));
                    Functions.Function.WriteRegistry("DatabaseName", Functions.Function.EncryptIt(txtDBName.Text.Trim()));
                    Functions.Function.WriteRegistry("UserName", Functions.Function.EncryptIt(txtDBUserName.Text.Trim()));
                    Functions.Function.WriteRegistry("Password", Functions.Function.EncryptIt(txtDBPassword.Text.Trim()));
                    Process.LogInsert("Database ayarları yapıldı.", Model.Base.TransactionType.Ekle);
                    DialogResult = DialogResult.Yes;
                }
                else
                    MessageBox.Show("Bağlantı bilgileri hatalı. Lütfen tekrar giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Lütfen database ayarlarını tam giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDBClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}