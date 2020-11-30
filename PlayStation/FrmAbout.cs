using System;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmAbout : XtraForm
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            lblEndDate.Text = string.Format("{0:dd.MM.yyyy}", Global.LicenseDetail.LicenceEndDate);
            lblKey.Text = Global.LicenseDetail.LicenceKey;
            lblLicenceStatus.Text = Global.LicenseDetail.ResultMessage;
        }
    }
}