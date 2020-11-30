using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmReportDay : XtraForm
    {
        private readonly Data.Calculates _cal = new Data.Calculates();

        public FrmReportDay()
        {
            InitializeComponent();
        }

        private void FrmReportDay_Load(object sender, EventArgs e)
        {
            Text = "Günlük Rapor - " + DateTime.Today.ToShortDateString();

            GetDayCalculate();
        }

        private void GetDayCalculate()
        {
            var li = _cal.GetDayCalculates();
            lvCalc.Items.Clear();
            decimal totalAmount = 0, additionTotalAmount = 0, cancelTotalAmount = 0, cancelAdditionTotalAmount = 0;
            var dtUsedTime = new DateTime();
            try
            {
                foreach (var item in li)
                {
                    var tur = (
                        item.MACHINECLOSESTATUS == (int)Model.Base.MachineType.IptalEdildi ? "İptal Edildi" :
                        item.MACHINECLOSESTATUS == (int)Model.Base.MachineType.Kapali ? "Kapalı" :
                        item.MACHINECLOSESTATUS == (int)Model.Base.MachineType.SureliAcik ? "Süreli Hesap" :
                        item.MACHINECLOSESTATUS == (int)Model.Base.MachineType.SuresizAcik ? "Açık Hesap" :
                        item.MACHINECLOSESTATUS == (int)Model.Base.MachineType.Durduruldu ? "Hesap Durduruldu" : "-");

                    var islemTipi = (
                        item.STATUS == (int)Model.Base.MachineType.IptalEdildi ? "İptal Edildi" :
                        item.STATUS == (int)Model.Base.MachineType.Kapali ? "Kapalı" :
                        item.STATUS == (int)Model.Base.MachineType.SureliAcik ? "Süreli Hesap" :
                        item.STATUS == (int)Model.Base.MachineType.SuresizAcik ? "Açık Hesap" :
                        item.STATUS == (int)Model.Base.MachineType.Durduruldu ? "Hesap Durduruldu" : "-");

                    if (item.STATUS == (int)Model.Base.MachineType.IptalEdildi)
                    {
                        cancelAdditionTotalAmount += item.ADDITIONTOTAL;
                        cancelTotalAmount += item.MACHINETOTAL;
                    }
                    else
                    {
                        totalAmount += item.MACHINETOTAL;
                        additionTotalAmount += item.ADDITIONTOTAL;
                    }

                    var ts = new TimeSpan(item.USEDTIME.Value.Ticks);
                    dtUsedTime = dtUsedTime.Add(ts);

                    var lvi = new ListViewItem
                    {
                        Tag = item,
                        Text = item.LREF.ToString()
                    };
                    lvi.SubItems.Add(item.MACHINENAME);
                    lvi.SubItems.Add(tur);
                    lvi.SubItems.Add(islemTipi);
                    lvi.SubItems.Add(item.TARRIFNAME);
                    lvi.SubItems.Add(string.Format("{0:dd.MM.yyyy - HH:mm:ss}", item.STARTDATETIME));
                    lvi.SubItems.Add(string.Format("{0:dd.MM.yyyy - HH:mm:ss}", item.STARTENDDATETIME));
                    lvi.SubItems.Add(string.Format("{0:HH:mm:ss}", item.USEDTIME));
                    lvi.SubItems.Add(item.ADDITIONNAME);
                    lvi.SubItems.Add(string.Format("{0:n} TL", (item.ADDITIONTOTAL)));
                    lvi.SubItems.Add(string.Format("{0:n} TL", item.MACHINETOTAL));
                    lvi.SubItems.Add(string.Format("{0:n} TL", (item.MACHINETOTAL + (item.ADDITIONTOTAL))));
                    lvi.SubItems.Add(item.DETAILS);

                    if (item.STATUS == (int)Model.Base.MachineType.IptalEdildi)
                    {
                        lvi.BackColor = Color.LightGray;
                        lvi.SubItems.Add(item.CANCELREASON);
                    }
                    else
                        lvi.SubItems.Add("-");

                    lvCalc.Items.Add(lvi);
                }

                var day = dtUsedTime.Day - 1;

                lblCancelAdditionAmount.Text = string.Format("{0:n} TL", cancelAdditionTotalAmount);
                lblCancelAmount.Text = string.Format("{0:n} TL", cancelTotalAmount);

                lblTotalAddition.Text = string.Format("{0:n} TL", additionTotalAmount);
                lblTotalAmount.Text = string.Format("{0:n} TL", totalAmount);
                lblTotalUsedTime.Text = string.Format("{0} Gün - {1:HH:mm:ss}", day, dtUsedTime);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}