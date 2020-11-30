using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmRegisterComp : XtraForm
    {
        public FrmRegisterComp()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNameSurname.Text.Trim()) &&
                !string.IsNullOrEmpty(txtTCNr.Text.Trim()) &&
                !string.IsNullOrEmpty(txtEMail.Text.Trim()) &&
                !string.IsNullOrEmpty(txtGSMNr.Text.Trim()) &&
                !string.IsNullOrEmpty(txtFirmName.Text.Trim()) &&
                !string.IsNullOrEmpty(txtCity.Text.Trim()) &&
                !string.IsNullOrEmpty(txtRegion.Text.Trim()))
            {
                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(FrmWait), true, true, false);
                //RegisterComp.SecurityKey = PlayStation.Licence.CheckLicence.AuthenticationKey;
                //string register = RegisterComp.Register(
                //    txtNameSurname.Text.Trim(),
                //    txtTCNr.Text.Trim(),
                //    txtEMail.Text.Trim(),
                //    txtGSMNr.Text.Trim(),
                //    txtFirmName.Text.Trim(),
                //    txtCity.Text.Trim(),
                //    txtRegion.Text.Trim(),
                //    txtAddress.Text.Trim(),
                //    txtTaxName.Text.Trim(),
                //    txtTaxNr.Text.Trim());

                //if (register.Contains("Licence"))
                //{
                //    string[] licenceKey = register.Split('~');
                //    FrmLicence.ReturnLicenceKey = licenceKey[1];
                //    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                //    DialogResult = System.Windows.Forms.DialogResult.Yes;
                //    this.Close();
                //}
                //else
                //{
                //    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                //    MessageBox.Show(register, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            else
                MessageBox.Show("Lütfen yıldızlı (*) alanları boş bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}