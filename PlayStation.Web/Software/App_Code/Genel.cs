using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;
using System.Drawing;
using InPlusYonetimModel;
using System.Net.Mail;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Genel
/// </summary>
public class Genel
{
    public string FotoIslemi(FileUpload fu, string SahteKayitYolu, string GercekKayitYolu, int BoyutPx)
    {
        string uzanti = "";
        string resimadi = StringDuzenle(fu.FileName);
        resimadi = this.StringSayiEkle(resimadi);
        uzanti = Path.GetExtension(fu.PostedFile.FileName);
        fu.SaveAs(HttpContext.Current.Server.MapPath(SahteKayitYolu) + uzanti);

        int Donusturme = BoyutPx;

        Bitmap bmp = new Bitmap(HttpContext.Current.Server.MapPath(SahteKayitYolu) + uzanti);
        using (Bitmap OrjinalResim = bmp)
        {
            double ResYukseklik = OrjinalResim.Height;
            double ResGenislik = OrjinalResim.Width;
            double oran = 0;
            if (ResGenislik >= ResYukseklik | ResYukseklik >= ResGenislik)
            {
                if (ResGenislik >= ResYukseklik)
                {
                    if (ResGenislik >= Donusturme)
                    {
                        oran = ResGenislik / ResYukseklik;
                        ResGenislik = Donusturme;
                        ResYukseklik = Donusturme / oran;

                        Size yenidegerler = new Size(Convert.ToInt32(ResGenislik), Convert.ToInt32(ResYukseklik));

                        Bitmap yeniresim = new Bitmap(OrjinalResim, yenidegerler);
                        yeniresim.Save(HttpContext.Current.Server.MapPath(GercekKayitYolu) + resimadi);

                        yeniresim.Dispose();
                        OrjinalResim.Dispose();
                        bmp.Dispose();
                    }
                    else
                    {
                        fu.SaveAs(HttpContext.Current.Server.MapPath(GercekKayitYolu) + resimadi);
                    }
                }
                else if (ResYukseklik >= ResGenislik)
                {
                    if (ResYukseklik >= Donusturme)
                    {
                        oran = ResYukseklik / ResGenislik;
                        ResYukseklik = Donusturme;
                        ResGenislik = Donusturme / oran;

                        Size yenidegerler = new Size(Convert.ToInt32(ResGenislik), Convert.ToInt32(ResYukseklik));

                        Bitmap yeniresim = new Bitmap(OrjinalResim, yenidegerler);
                        yeniresim.Save(HttpContext.Current.Server.MapPath(GercekKayitYolu) + resimadi);

                        yeniresim.Dispose();
                        OrjinalResim.Dispose();
                        bmp.Dispose();
                    }
                    else
                    {
                        fu.SaveAs(HttpContext.Current.Server.MapPath(GercekKayitYolu) + resimadi);
                    }
                }
            }
            else
            {
                fu.SaveAs(HttpContext.Current.Server.MapPath(GercekKayitYolu) + resimadi);
            }
        }
        FileInfo fiSahte = new FileInfo(HttpContext.Current.Server.MapPath(SahteKayitYolu) + uzanti);
        fiSahte.Delete();
        bmp.Dispose();
        return resimadi;
    }
    public string FotoIslemiAd(FileUpload fu, string SahteKayitYolu, string GercekKayitYolu, int BoyutPx, string ad)
    {
        string uzanti = "";
        string resimadi = StringDuzenle(fu.FileName);
        resimadi = this.StringSayiEkle(resimadi);
        uzanti = Path.GetExtension(fu.PostedFile.FileName);
        fu.SaveAs(HttpContext.Current.Server.MapPath(SahteKayitYolu) + uzanti);
        int Donusturme = BoyutPx;
        Bitmap bmp = new Bitmap(HttpContext.Current.Server.MapPath(SahteKayitYolu) + uzanti);
        using (Bitmap OrjinalResim = bmp)
        {
            double ResYukseklik = OrjinalResim.Height;
            double ResGenislik = OrjinalResim.Width;
            double oran = 0;
            if (ResGenislik >= ResYukseklik | ResYukseklik >= ResGenislik)
            {
                if (ResGenislik >= ResYukseklik)
                {
                    if (ResGenislik >= Donusturme)
                    {
                        oran = ResGenislik / ResYukseklik;
                        ResGenislik = Donusturme;
                        ResYukseklik = Donusturme / oran;
                        Size yenidegerler = new Size(Convert.ToInt32(ResGenislik), Convert.ToInt32(ResYukseklik));
                        Bitmap yeniresim = new Bitmap(OrjinalResim, yenidegerler);
                        yeniresim.Save(HttpContext.Current.Server.MapPath(GercekKayitYolu) + resimadi);
                        yeniresim.Dispose();
                        OrjinalResim.Dispose();
                        bmp.Dispose();
                    }
                    else
                    {
                        fu.SaveAs(HttpContext.Current.Server.MapPath(GercekKayitYolu) + ad);
                    }
                }
                else if (ResYukseklik >= ResGenislik)
                {
                    if (ResYukseklik >= Donusturme)
                    {
                        oran = ResYukseklik / ResGenislik;
                        ResYukseklik = Donusturme;
                        ResGenislik = Donusturme / oran;
                        Size yenidegerler = new Size(Convert.ToInt32(ResGenislik), Convert.ToInt32(ResYukseklik));
                        Bitmap yeniresim = new Bitmap(OrjinalResim, yenidegerler);
                        yeniresim.Save(HttpContext.Current.Server.MapPath(GercekKayitYolu) + ad);

                        yeniresim.Dispose();
                        OrjinalResim.Dispose();
                        bmp.Dispose();
                    }
                    else
                    {
                        fu.SaveAs(HttpContext.Current.Server.MapPath(GercekKayitYolu) + ad);
                    }
                }
            }
            else
            {
                fu.SaveAs(HttpContext.Current.Server.MapPath(GercekKayitYolu) + ad);
            }
        }
        FileInfo fiSahte = new FileInfo(HttpContext.Current.Server.MapPath(SahteKayitYolu) + uzanti);
        fiSahte.Delete();
        bmp.Dispose();
        return resimadi;
    }
    public static string HarfDuzelt(string kelime)
    {
        CultureInfo ci = new CultureInfo("tr-TR");
        string gelen = kelime.ToLower(ci);
        string[] kelimeler = gelen.Split(' ');
        gelen = "";
        int sira = 0;
        foreach (var item in kelimeler)
        {
            if (sira == 0)
            {
                gelen += char.ToUpper(item[0]) + item.Substring(1);
                sira = 1;
            }
            else
            {
                gelen += " " + char.ToUpper(item[0]) + item.Substring(1);
            }

        }


        return gelen;
    }
    public string StringSayiEkle(string isim)
    {
        CultureInfo ci = new CultureInfo("tr-TR");
        isim = StringDuzenle(isim.ToString(ci));
        isim = isim.Insert(isim.IndexOf('.'), "-" + Guid.NewGuid());
        return isim;
    }
    public static string StringDuzenle(string Metin)
    {
        CultureInfo ci = new CultureInfo("tr-TR");
        string deger = Metin.ToLower(ci);
        deger = deger.Replace("'", "");
        deger = deger.Replace("#8217;", "");
        deger = deger.Replace("#", "");
        deger = deger.Replace(";", "");
        deger = deger.Replace(",", "");
        deger = deger.Replace("/", "-");
        deger = deger.Replace(@"\", "-");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("+", "-");
        deger = deger.Replace("*", "-");
        deger = deger.Replace("(", "");
        deger = deger.Replace(")", "");
        deger = deger.Replace("$", "");
        deger = deger.Replace("=", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("€", "");
        deger = deger.Replace("ı", "i");
        deger = deger.Replace("ö", "o");
        deger = deger.Replace("ü", "u");
        deger = deger.Replace("ş", "s");
        deger = deger.Replace("ç", "c");
        deger = deger.Replace("ğ", "g");
        deger = deger.Replace("İ", "i");
        deger = deger.Replace("Ö", "o");
        deger = deger.Replace("Ü", "u");
        deger = deger.Replace("Ş", "s");
        deger = deger.Replace("Ç", "c");
        deger = deger.Replace("Ğ", "g");
        deger = deger.Replace("I", "i");
        deger = deger.Replace("!", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("\"", "-");
        return deger;
    }
    public static string StringDuzenleArama(string Metin)
    {
        CultureInfo ci = new CultureInfo("tr-TR");
        string deger = Metin.ToLower(ci);
        deger = deger.Replace("'", "");
        deger = deger.Replace("#8217;", "");
        deger = deger.Replace("#", "");
        deger = deger.Replace(";", "");
        deger = deger.Replace(",", "");
        deger = deger.Replace("/", "-");
        deger = deger.Replace(@"\", "-");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("+", "-");
        deger = deger.Replace("*", "-");
        deger = deger.Replace("(", "");
        deger = deger.Replace(")", "");
        deger = deger.Replace("$", "");
        deger = deger.Replace("=", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("€", "");
        deger = deger.Replace("!", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("\"", "-");
        return deger;
    }
    public static string UrlSeo(string Metin)
    {
        CultureInfo ci = new CultureInfo("tr-TR");
        string deger = Metin.ToLower(ci);
        deger = deger.Replace(" ", "-");
        deger = deger.Replace("'", "");
        deger = deger.Replace(".", "");
        deger = deger.Replace(":", "");
        deger = deger.Replace(",", "");
        deger = deger.Replace(";", "");
        deger = deger.Replace("#", "");
        deger = deger.Replace("#8217;", "");
        deger = deger.Replace("/", "-");
        deger = deger.Replace(@"\", "-");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("+", "-");
        deger = deger.Replace("*", "-");
        deger = deger.Replace("(", "");
        deger = deger.Replace(")", "");
        deger = deger.Replace("$", "");
        deger = deger.Replace("=", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("€", "");
        deger = deger.Replace("ı", "i");
        deger = deger.Replace("ö", "o");
        deger = deger.Replace("ü", "u");
        deger = deger.Replace("ş", "s");
        deger = deger.Replace("ç", "c");
        deger = deger.Replace("ğ", "g");
        deger = deger.Replace("İ", "i");
        deger = deger.Replace("Ö", "o");
        deger = deger.Replace("Ü", "u");
        deger = deger.Replace("Ş", "s");
        deger = deger.Replace("Ç", "c");
        deger = deger.Replace("Ğ", "g");
        deger = deger.Replace("I", "i");
        deger = deger.Replace("!", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("\"", "-");
        return deger;
    }
    public string ImageCropSave(string resim, string KayitYolu, int yukseklik, int genislik)
    {
        byte[] pBuffer = ImageResize.imgCrop(HttpContext.Current.Server.MapPath(KayitYolu + resim), genislik, yukseklik);

        using (MemoryStream ms = new MemoryStream(pBuffer))
        {
            Bitmap b = Bitmap.FromStream(ms) as Bitmap;

            string path = HttpContext.Current.Server.MapPath(KayitYolu) + yukseklik + "x" + genislik + resim;

            b.Save(path);
        }
        return resim;
    }
    public string ImageCropFileSave(FileUpload fu, string KayitYolu, string SahteKayitYolu, int yukseklik, int genislik)
    {
        string resadi = fu.FileName;

        resadi = this.StringSayiEkle(resadi);

        string uzanti = Path.GetExtension(fu.PostedFile.FileName);
        fu.SaveAs(HttpContext.Current.Server.MapPath(KayitYolu) + resadi);

        byte[] pBuffer = ImageResize.FixedSize(HttpContext.Current.Server.MapPath(KayitYolu + resadi), genislik, yukseklik);

        using (MemoryStream ms = new MemoryStream(pBuffer))
        {
            Bitmap b = Bitmap.FromStream(ms) as Bitmap;

            string path = HttpContext.Current.Server.MapPath(KayitYolu) + yukseklik + "x" + genislik + resadi;

            b.Save(path);
        }

        return resadi;
    }


    public string HTMLCiktisi(Control kontrol)
    {
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        kontrol.RenderControl(htw);
        string giden = sw.ToString();
        htw.Dispose();
        sw.Dispose();
        return giden;
    }

    public static void MailKullanicilaraGonder(string email, string mesaj, string baslik)
    {
        try
        {
            string mail = string.Empty;
            string sifre = string.Empty;
            string host = string.Empty;
            int port = 0;
            using (YonetimEntities db = new YonetimEntities())
            {
                var ayar = (from x in db.AYARs orderby x.AYARID descending select x).Take(1);
                foreach (var item in ayar)
                {
                    mail = item.EPOSTA;
                    sifre = item.EPOSTAPAROLA;
                    port = Convert.ToInt32(item.EPOSTAPORT);
                    host = item.EPOSTASMTP;
                }
            }

            MailMessage ePosta = new MailMessage(mail, email);
            ePosta.Subject = baslik;
            ePosta.IsBodyHtml = true;
            ePosta.Body = mesaj;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(mail, sifre);
            smtp.Port = port;
            smtp.Host = host;
            try
            {
                smtp.Send(ePosta);
            }
            catch
            {
                smtp.Dispose();
            }
        }
        catch
        { }
    }

    public static string CreateLicence()
    {
        Random r = new Random();
        int rand = r.Next(100000, 999999);
        string key = DateTime.Now.ToString().Replace(":", "").Replace(" ", "").Replace("-", "").Replace("/", "");

        Random rn = new Random();
        string charsToUse = "A789azZBbyV5678YCcX5435xDd78986sdgwW12gfsd3EvvFuGg98067fgds8tHseIr12dsf3456JqSKp7dfg90LogdgMGnFNdmsOlPkQjRiShTgUfVeWdXcYbZa12345";

        MatchEvaluator RandomChar = delegate(Match m)
        {
            return charsToUse[rn.Next(charsToUse.Length)].ToString();
        };

        var a = Regex.Replace("XXXX-XXXX-XXXX", "X", RandomChar); // Lv2U-jHsa-TUep-NqKa-jlBx-ELIFT
        //a = a + "-CONSOLE";

        return a;// Genel.EncryptIt(a);
    }

    public static string EncryptIt(string toEnrypt)
    {
        if (!string.IsNullOrEmpty(toEnrypt))
        {
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(toEnrypt);
            byte[] rgbKey = System.Text.ASCIIEncoding.ASCII.GetBytes("09121988");
            byte[] rgbIV = System.Text.ASCIIEncoding.ASCII.GetBytes("88912190");

            //1024-bit encryption
            MemoryStream memoryStream = new MemoryStream(1024);
            DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();

            CryptoStream cryptoStream = new CryptoStream(memoryStream,
            desCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV),
            CryptoStreamMode.Write);

            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();

            byte[] result = new byte[(int)memoryStream.Position];
            memoryStream.Position = 0;
            memoryStream.Read(result, 0, result.Length);

            cryptoStream.Close();
            return System.Convert.ToBase64String(result);
        }
        return "";

    }

    public static string DecryptIt(string toDecrypt)
    {
        string decrypted = string.Empty;
        if (!string.IsNullOrEmpty(toDecrypt))
        {
            try
            {
                byte[] data = System.Convert.FromBase64String(toDecrypt);
                byte[] rgbKey = System.Text.ASCIIEncoding.ASCII.GetBytes("09121988");
                byte[] rgbIV = System.Text.ASCIIEncoding.ASCII.GetBytes("88912190");

                MemoryStream memoryStream = new MemoryStream(data.Length);

                DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                desCryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV),
                CryptoStreamMode.Read);

                memoryStream.Write(data, 0, data.Length);
                memoryStream.Position = 0;

                decrypted = new StreamReader(cryptoStream).ReadToEnd();

                cryptoStream.Close();
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
        }
        return decrypted;
    }

    public Genel()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}