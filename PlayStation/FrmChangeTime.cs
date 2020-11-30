using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmChangeTime : XtraForm
    {
        private readonly Model.Machine _m;
        private readonly Data.Machine _mac = new Data.Machine();
        private string _time2;
        public string Time1;

        public FrmChangeTime(Model.Machine machine)
        {
            InitializeComponent();
            _m = machine;
        }

        private void FrmChangeTime_Load(object sender, EventArgs e)
        {
            if (Global.CurrentUser.CHANGESTARTTIME)
            {
                if (_m.MACHINESTATUS != (int)Model.Base.MachineType.Kapali)
                {
                    txtTime.EditValue = _m.STARTDATETIME.ToShortTimeString();
                    Time1 = _m.STARTDATETIME.ToShortTimeString();
                }
                else
                    Close();
            }
            else
                Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TimeSpan ts;
            TimeSpan.TryParse(txtTime.Text.Trim(), out ts);
            var dt = _m.STARTDATETIME.Date;
            _time2 = txtTime.Text;
            _m.STARTDATETIME = dt.Add(ts);

            if (_m.STARTDATETIME > DateTime.Now)
                MessageBox.Show("Başlangıç saati şu anki saatten ileri olamaz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Process.LogInsert(_m.NAME + " başlangıç saati değiştirildi. " + _m.STARTDATETIME + " yapıldı. " + Time1 + " iken " + _time2 + " yapıldı.", Model.Base.TransactionType.Duzenle);

                string message;
                _mac.Update(_m, out message);
                Close();
            }
        }
    }
}