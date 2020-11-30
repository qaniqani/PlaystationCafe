using System;
using System.Text;

namespace PlayStation.Data
{
    public class RegisterComp
    {
        public static string SecurityKey = string.Empty;

        public static string Register(
            string nameSurname, 
            string tcNr, 
            string eMail, 
            string gsmNr, 
            string firmName, 
            string city, 
            string region, 
            string address, 
            string taxName, 
            string taxNr)
        {
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                wc.Headers.Add("Accept-Encoding", "");
                var u = new Uri(string.Format("http://nvisionsoft.net/RegisterComp.aspx?NameSurname={0}&TCNr={1}&EMail={2}&GSMNr={3}&FirmName={4}&City={5}&Region={6}&Address={7}&TaxName={8}&TaxNr={9}&SecurityKey={10}", 
                    nameSurname, 
                    tcNr, 
                    eMail, 
                    gsmNr, 
                    firmName, 
                    city, 
                    region, 
                    address, 
                    taxName, 
                    taxNr,
                    SecurityKey));
                try
                {
                    wc.Encoding = Encoding.UTF8;
                    var asd = wc.DownloadString(u);
                    return asd;
                }
                catch (Exception ex)
                {
                    return "Bir hata oluştu. Hata Kodu: " + ex.Message;
                }
            }
        }
    }
}
