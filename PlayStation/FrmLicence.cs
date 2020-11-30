using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PlayStation.Functions;

namespace PlayStation
{
    public partial class FrmLicence : XtraForm
    {
        private readonly Licence _licence = new Licence();

        public FrmLicence()
        {
            InitializeComponent();
        }

        private void FrmLicence_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Function.ReadRegistry("LicenceKey")))
            {
                txtLicenseKey.Enabled = false;
                btnLicenceUpdate.Enabled = false;
            }

            if (_licence.DbRowCount() > 0)
            {
                var licence = _licence.DbLicenceRow();
                txtLicenseKey.Text = licence.LicenceKey;
                lblLicenceStartDate.Text = licence.LicenceStartDate.ToString("dd.MM.yyyy");
                lblLicenceEndDate.Text = licence.LicenceEndDate.ToString("dd.MM.yyyy");
                lblMessage.Text = licence.ResultMessage;
                lblUserCount.Text = "Limitsiz";

                Global.LicenseDetail = licence;
            }

            if (Global.LicenseDetail.Demo)
            {
                txtLicenseKey.Enabled = true;
                btnLicenceUpdate.Enabled = true;
            }

            if (!Global.LicenseDetail.Demo && !Global.LicenseDetail.Active)
            {
                txtLicenseKey.Enabled = true;
                btnLicenceUpdate.Enabled = true;
            }

            //if (lr.DBRowCount() > 0)
            //{
            //    Global.LicenseDetail = lr.DBLicenceRow();
            //    txtLicenseKey.Text = Global.LicenseDetail.LicenceKey;

            //    Functions.Function.WriteRegistry("LicenceKey", Global.LicenseDetail.LicenceKey);
            //    txtLicenseKey.Enabled = false;
            //    btnNewRegisterUser.Visible = false;

            //    lblLicenceEndDate.Text = string.Format("{0:dd.MM.yyyy}", Global.LicenseDetail.LicenceEndDate);
            //    lblLicenceRefreshDate.Text = string.Format("{0:dd.MM.yyyy}", Global.LicenseDetail.BeforeCheckDate);
            //    lblUserCount.Text = Global.LicenseDetail.UserCount.ToString();
            //    lblMessage.Text = Global.LicenseDetail.ResultMessage;

            //    if (!string.IsNullOrEmpty(Functions.Function.ReadRegistry("CheckIsComputer")))
            //    {
            //        btnNewRegisterUser.Visible = false;
            //        txtLicenseKey.Text = Functions.Function.ReadRegistry("LicenceKey");
            //        txtLicenseKey.Enabled = false;
            //    }

            //    if (!Global.LicenseDetail.Active || !Global.LicenseDetail.ResultCode)
            //        MessageBox.Show(Global.LicenseDetail.ResultMessage, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    if (!string.IsNullOrEmpty(Functions.Function.ReadRegistry("CheckIsComputer")))
            //    {
            //        btnNewRegisterUser.Visible = false;
            //        txtLicenseKey.Text = Functions.Function.ReadRegistry("LicenceKey");
            //        txtLicenseKey.Enabled = false;
            //    }
            //    this.GetServiceLicence();
            //}
        }

        private void btnLicenceUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseKey.Text))
            {
                MessageBox.Show("Lisans keyinizi giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var licence = txtLicenseKey.Text;
                var deCryptLicence = Function.DecryptIt(licence);
                if (deCryptLicence.Contains("CONSOLE"))
                {
                    var newLicence = _licence.ActiveLicence(licence, "Aktif lisans kullanicisi.");
                    Global.LicenseDetail = newLicence;
                    MessageBox.Show("Lisansınız aktif olmuştur. Lütfen programı yeniden başlatınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Hatalı lisans kodu.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu, lisans keyi ayrıştırılamadı. Hata kodu: " + ex.Message);
            }
            //Function.WriteRegistry("LicenceKey", txtLicenseKey.Text);
            //this.GetServiceLicence();
        }

        //private void GetServiceLicence()
        //{
        //    if (!string.IsNullOrEmpty(txtLicenseKey.Text))
        //    {
        //        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(FrmWait), true, true, false);
        //        bool InternetTest = Functions.Function.InternetConnTest();

        //        if (InternetTest)
        //        {
        //            string LicenceString = cl.WebServiceLicenceCheck(txtLicenseKey.Text);

        //            lr.DBLicenceInsert(LicenceString);
        //            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        //        }
        //        else
        //        {
        //            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        //            MessageBox.Show("Servise erişilemiyor, lütfen internet bağlantınızı kontrol ediniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //        Global.LicenseDetail = cl.LicenceControl(txtLicenseKey.Text);

        //        if (!string.IsNullOrEmpty(Global.LicenseDetail.LicenceKey)) ;
        //            btnNewRegisterUser.Visible = false;

        //        txtLicenseKey.Text = Global.LicenseDetail.LicenceKey;

        //        lblLicenceEndDate.Text = string.Format("{0:dd.MM.yyyy}", Global.LicenseDetail.LicenceEndDate);
        //        lblLicenceRefreshDate.Text = string.Format("{0:dd.MM.yyyy}", Global.LicenseDetail.BeforeCheckDate);
        //        lblUserCount.Text = Global.LicenseDetail.UserCount.ToString();
        //        lblMessage.Text = Global.LicenseDetail.ResultMessage;

        //        MessageBox.Show(Global.LicenseDetail.ResultMessage, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Lütfen keyinizi giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNewRegisterUser_Click(object sender, EventArgs e)
        {
            //var rc = new FrmRegisterComp();
            //var dr = rc.ShowDialog();
            //if (string.IsNullOrEmpty(ReturnLicenceKey)) return;
            
            //btnNewRegisterUser.Visible = false;
            //txtLicenseKey.Text = ReturnLicenceKey;
            //MessageBox.Show("Lisanlama işleminizi tamamlayabilirsiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(FrmWait), true, true, false);
            System.Threading.Thread.Sleep(3000);
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nvisionsoft.net");
        }
    }
}