using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmLoging : XtraForm
    {
        private readonly Data.Logs _log = new Data.Logs();

        public FrmLoging()
        {
            InitializeComponent();
        }

        private void FrmLoging_Load(object sender, EventArgs e)
        {
            dtFirstDate.EditValue = DateTime.Now.AddDays(-2);
            dtLastDate.EditValue = DateTime.Now;
            GetLoging();
        }

        private void GetLoging()
        {
            string message;
            var logview = _log.SelectDateBetween(Convert.ToDateTime(dtFirstDate.EditValue), Convert.ToDateTime(dtLastDate.EditValue), out message);

            lvLogs.Items.Clear();
            foreach (var item in logview)
            {
                var lvi = new ListViewItem
                {
                    Tag = item,
                    Text = item.LREF.ToString()
                };
                lvi.SubItems.Add(item.TRANSACTIONNAME);
                lvi.SubItems.Add(item.TRANSACTIONDETAIL);
                lvi.SubItems.Add(item.NAME + " " + item.SURNAME + " / " + item.USERNAME);
                lvi.SubItems.Add(string.Format("{0:dd.MM.yyyy - HH:mm:ss}", item.DATETIME));
                lvLogs.Items.Add(lvi);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetLoging();
        }
    }
}