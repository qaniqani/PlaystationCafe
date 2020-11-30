using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmLogin : XtraForm
    {
        private readonly Data.Users _u = new Data.Users();
        private readonly Process _p = new Process();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //string dbName = Functions.Function.DecryptIt(Functions.Function.ReadRegistry("DatabaseName"));
            //string dbServer = Functions.Function.DecryptIt(Functions.Function.ReadRegistry("ServerName"));
            var dbUser = Functions.Function.DecryptIt(Functions.Function.ReadRegistry("UserName"));
            var dbPass = Functions.Function.DecryptIt(Functions.Function.ReadRegistry("Password"));

            if (string.IsNullOrEmpty(dbUser) &&
                string.IsNullOrEmpty(dbPass))
            {
                _p.WriteDatabaseSetting();
                _p.SetDatabaseSetting();
            }
            else
                _p.SetDatabaseSetting();

            ActiveControl = txtPassword;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text.Trim()) && !string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                var user = _u.SelectUser(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (!string.IsNullOrEmpty(user.NAME))
                {
                    Global.CurrentUser = user;
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    txtPassword.Text = "";
                    MessageBox.Show("Kullanıcı adı veya parola hatalı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Kullanıcı adı ve parola boş bırakılamaz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtPassword.Focus();

            if (e.KeyValue == 27)
                Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnLogin_Click(null, null);

            if (e.KeyValue == 27)
                Close();
        }
    }
}