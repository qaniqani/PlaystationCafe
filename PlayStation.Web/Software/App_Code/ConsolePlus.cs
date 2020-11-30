using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using InPlusYonetimModel;

/// <summary>
/// Summary description for ConsolePlus
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ConsolePlus : System.Web.Services.WebService {

    YonetimEntities db = new YonetimEntities();

    public ConsolePlus () {}

    [WebMethod]
    public LicenceDetail GetLicenceCheck(string LicenceKey, string AuthenticationKey, string MotherBoardSerial, string CPUSerial, string HDDSerial)
    {
        LicenceDetail ld = new LicenceDetail();

        string authKey = System.Web.Configuration.WebConfigurationManager.AppSettings["ServiceKey"].ToString();

        if (AuthenticationKey == authKey)
        {
            try
            {
                string Key = LicenceKey;
                string Board = Genel.DecryptIt(MotherBoardSerial);
                string CPU = Genel.DecryptIt(CPUSerial);
                string HDD = Genel.DecryptIt(HDDSerial);

                LISANSLAMALAR l = db.LISANSLAMALARs.FirstOrDefault(a => a.FIRLISANSKEY == LicenceKey);

                if (l != null)
                {
                    if (Convert.ToBoolean(l.FIRAKTIF))
                    {
                        if (l.FIRLISANSBITTARIH > DateTime.Now)
                        {
                            if ((string.IsNullOrEmpty(l.FIRBOARDSERIALNO) &&
                                string.IsNullOrEmpty(l.FIRHDDSERIALNO) &&
                                string.IsNullOrEmpty(l.FIRCPUSERIALNO)) ||
                                (l.FIRBOARDSERIALNO.Length < 1 &&
                                l.FIRCPUSERIALNO.Length < 1 &&
                                l.FIRHDDSERIALNO.Length < 1))
                            {
                                l.FIRBOARDSERIALNO = Board;
                                l.FIRCPUSERIALNO = CPU;
                                l.FIRHDDSERIALNO = HDD;

                                if (Convert.ToBoolean(l.FIRDEMOMU) && Convert.ToBoolean(l.FIRAKTIF))
                                {
                                    ld = this.SetLicenceDetail(l, "Demo lisansınız aktif olmuştur.", true, true);
                                    db.SaveChanges();
                                }
                                else if (Convert.ToBoolean(l.FIRAKTIF) && !Convert.ToBoolean(l.FIRDEMOMU))
                                {
                                    ld = this.SetLicenceDetail(l, "Full lisansınız aktif olmuştur.", false, true);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    ld = this.SetLicenceDetail(l, "Demo veya aktif lisansınız bulunmamaktadır.", false, false);
                                    db.SaveChanges();
                                }
                            }
                            else if (l.FIRBOARDSERIALNO == Board)
                            {
                                if (Convert.ToBoolean(l.FIRDEMOMU) && Convert.ToBoolean(l.FIRAKTIF))
                                {
                                    ld = this.SetLicenceDetail(l, "Demo lisansınız aktif durumda.", true, true);
                                }
                                else if (Convert.ToBoolean(l.FIRAKTIF) && !Convert.ToBoolean(l.FIRDEMOMU))
                                {
                                    ld = this.SetLicenceDetail(l, "Full lisansınız aktif durumda.", false, true);
                                }
                                else
                                {
                                    ld = this.SetLicenceDetail(l, "Demo veya aktif lisansınız bulunmamaktadır.", false, false);
                                }
                            }
                            else
                            {
                                ld = this.SetEndLicence(LicenceKey, DateTime.Now, "Lisanslanan bilgisayarın donanım bilgisi uyuşmuyor. Lütfen firmamızla irtibata geçiniz.");
                            }
                        }
                        else
                        {
                            ld = this.SetEndLicence(LicenceKey, Convert.ToDateTime(l.FIRLISANSBITTARIH), string.Format("{0:dd.MM.yyyy}", l.FIRLISANSBITTARIH) + " tarihinda lisansınızın süresi dolmuştur. Lisans sürenizi uzatmak için lütfen firmamızla irtibata geçiniz.");
                        }
                    }
                    else
                    {
                        ld = this.SetEndLicence(LicenceKey, Convert.ToDateTime(l.FIRLISANSBITTARIH), "Aktif bir lisansınız bulunmamaktadır. Lütfen firmamızla irtibata geçiniz.");
                    }
                }
                else
                {
                    ld = this.SetEndLicence(LicenceKey, DateTime.Now, "Girmiş olduğunuz lisansa keye ait kayıt bulunmamaktadır. Lütfen firmamızla irtibata geçiniz.");
                }
            }
            catch (Exception ex)
            {
                ld = this.SetEndLicence(LicenceKey, DateTime.Now, "Bir hata oluştu. Hata Kodu: " + ex.Message);
            }
        }
        else
        {
            ld.ResultMessage = "Kullanıcı doğrulamasından geçemediniz. Tüm işlemleriniz kayıt altına alınmaktadır, servisimizi daha fazla meşgul etmeyiniz. Hakkınızda yasal süreç başlatılabilir.";

            ld.ResultCode = false;
        }

        return ld;
    }

    private LicenceDetail SetLicenceDetail(LISANSLAMALAR lisans, string Msg, bool demo, bool active)
    {
        LicenceDetail ld = new LicenceDetail();

        ld.Active = active;
        ld.BeforeCheckDate = DateTime.Now.AddDays(lisans.FIRGUNCELLEMESIKLIGI.ToInt32());
        ld.Demo = demo;
        ld.LicenceEndDate = Convert.ToDateTime(lisans.FIRLISANSBITTARIH);
        ld.LicenceKey = lisans.FIRLISANSKEY;
        ld.LicenceStartDate = Convert.ToDateTime(lisans.FIRLISANSBASTARIH);
        ld.ResultCode = true;
        ld.ResultMessage = Msg;
        ld.UpdateDayCount = lisans.FIRGUNCELLEMESIKLIGI.ToInt32();
        ld.UserCount = lisans.FIRKULLANICISAYISI.ToInt32();

        return ld;
    }

    private LicenceDetail SetEndLicence(string LicenceKey, DateTime EndDate, string Msg)
    {
        LicenceDetail ld = new LicenceDetail();

        ld.Active = false;
        ld.BeforeCheckDate = DateTime.Now.AddHours(1);
        ld.Demo = false;
        ld.LicenceEndDate = EndDate;
        ld.LicenceKey = LicenceKey;
        ld.LicenceStartDate = EndDate;
        ld.ResultCode = false;
        ld.ResultMessage = Msg;
        ld.UpdateDayCount = 0;
        ld.UserCount = 0;

        return ld;
    }
}
