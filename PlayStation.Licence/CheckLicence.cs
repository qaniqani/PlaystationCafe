using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace PlayStation.Licence
{
    public class CheckLicence
    {
        public static string AuthenticationKey = "EFW+rwefawef454t3frsdf2rfesSDF==";
        
        LicenceService.LicenceDetail ld = null;

        LicenceRow DBLicenceProcess = new LicenceRow();

        public LicenceService.LicenceDetail LicenceControl(string Key)
        {
            if (DBLicenceProcess.DBRowCount() > 0)
            {
                ld = DBLicenceProcess.DBLicenceRow();
                if (ld.LicenceEndDate < DateTime.Now)
                {
                    if (!ld.Active || !ld.ResultCode)
                        this.LicenceClearing();
                }
                else if (!ld.Active || !ld.ResultCode)
                {
                    this.LicenceClearing();
                }
                else if (ld.Active && ld.LicenceEndDate >= DateTime.Now && ld.BeforeCheckDate > DateTime.Now && ld.ResultCode)
                {

                }
                else
                    this.LicenceClearing();
            }
            else
            {
                if (Functions.Function.InternetConnTest())
                {
                    string LicenceString = this.WebServiceLicenceCheck(Key);

                    DBLicenceProcess.DBLicenceInsert(LicenceString);

                    if (!ld.Active || !ld.ResultCode)
                        this.LicenceClearing();
                }
                else
                    this.LicenceClearing();
            }

            return ld;
        }

        public string ServiceLicenceCheck1(string Key)
        {
            using (LicenceService.ConsolePlus service = new LicenceService.ConsolePlus())
            {
                ld = service.GetLicenceCheck(
                    Key,
                    AuthenticationKey,
                    Functions.Function.GetBIOSSerialNumber(),
                    Functions.Function.GetCPUSerialNumber(),
                    Functions.Function.GetHDDSerialNumber());

                string LicenceString = ld.Active.ToString() + "~" +
                        ld.BeforeCheckDate.ToString() + "~" +
                        ld.Demo.ToString() + "~" +
                        ld.LicenceEndDate.ToString() + "~" +
                        ld.LicenceKey + "~" +
                        ld.LicenceStartDate.ToString() + "~" +
                        ld.ResultCode.ToString() + "~" +
                        ld.ResultMessage + "~" +
                        ld.UpdateDayCount.ToString() + "~" +
                        ld.UserCount.ToString();

                return LicenceString;
            }
        }

        public string WebServiceLicenceCheck(string Key)
        {
            ld = new LicenceService.LicenceDetail();
            WebClient wc = new WebClient();
            wc.Headers.Add("Accept-Encoding", "");
            Uri u = new Uri(
                string.Format("http://www.nvisionsoft.net/LicenceService.aspx?LicenceKey={0}&AuthenticationKey={1}&MotherBoardSerial={2}&CPUSerial={3}&HDDSerial={4}",
                Key,
                AuthenticationKey,
                Functions.Function.GetBIOSSerialNumber(),
                Functions.Function.GetCPUSerialNumber(),
                Functions.Function.GetHDDSerialNumber()));
            wc.Encoding = Encoding.UTF8;
            string asd = wc.DownloadString(u);
            XElement xe = XElement.Parse(asd);
            XDocument xd = XDocument.Parse(asd);
            //MessageBox.Show(xe.Element("Demo").Value.ToString());
            try
            {
                
                ld.Active = xe.Element("Active").Value == "0" ? false : true;
                ld.BeforeCheckDate = Convert.ToDateTime(xe.Element("BeforeCheckDate").Value.ToString());
                ld.Demo = xe.Element("Demo").Value == "0" ? false : true;
                ld.LicenceEndDate = Convert.ToDateTime(xe.Element("LicenceEndDate").Value.ToString());
                ld.LicenceKey = Convert.ToString(xe.Element("LicenceKey").Value);
                ld.LicenceStartDate = Convert.ToDateTime(xe.Element("LicenceStartDate").Value.ToString());
                ld.ResultCode = xe.Element("ResultCode").Value == "0" ? false : true;
                ld.ResultMessage = xe.Element("ResultMessage").Value.ToString();
                ld.UpdateDayCount = Convert.ToInt32(xe.Element("UpdateDayCount").Value.ToString());
                //ld.UserCount = Convert.ToInt32(xe.Element("UserCount").Value.ToString());
            }
            catch (Exception ex)
            {
                ld.ResultMessage = ex.Message;
            }

            string LicenceString = ld.Active.ToString() + "~" +
                        ld.BeforeCheckDate.ToString() + "~" +
                        ld.Demo.ToString() + "~" +
                        ld.LicenceEndDate.ToString() + "~" +
                        ld.LicenceKey + "~" +
                        ld.LicenceStartDate.ToString() + "~" +
                        ld.ResultCode.ToString() + "~" +
                        ld.ResultMessage + "~" +
                        ld.UpdateDayCount.ToString() + "~" +
                        ld.UserCount.ToString();

            return LicenceString;
        }

        private void LicenceClearing()
        {
            ld.Active = false;
            ld.BeforeCheckDate = DateTime.Today;
            ld.Demo = false;
            ld.LicenceEndDate = DateTime.Today;
            ld.LicenceStartDate = DateTime.Today;
            ld.ResultCode = false;
            ld.ResultMessage = "Lisans servisine erişilemiyor. Lütfen internet bağlantınızı kontrol ederek tekrar deneyiniz.";
            ld.UpdateDayCount = 0;
            ld.UserCount = 1;
        }
    }
}
