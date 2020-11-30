using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;


public partial class Yonetim_KategoriEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Menü Kategori Ekle";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = true;
            hpyeni.Text = "Yeni Kategori";
            hpyeni.NavigateUrl = "KategoriEkle.aspx";
            KategoriGetir();
            if (Request.QueryString["duzen"] != null)
            {
                KategoriDetayGetir();
            }
            if (Request.QueryString["Id"] != null)
            {
                int kat = 0;
                if (Request.QueryString["duzen"] != null)
                {
                    kat = Convert.ToInt32(Request.QueryString["duzen"].ToString());
                }
                else
                {
                    kat = Convert.ToInt32(Request.QueryString["id"].ToString());
                    if (kat != 0)
                    {
                        lbkat.Text = db.KATEGORIs.FirstOrDefault(a => a.KATID == kat).KATADI;
                        KategoriGetir();
                    }
                    else
                    {
                        AnaKategoriGetir();
                        lbkat.Text = "Ana Kategori";
                    }
                }
            }
            else
            {
                AnaKategoriGetir();
                lbkat.Text = "Menü";
            }
        }
    }

    private void KategoriDetayGetir()
    {
        int kat = Convert.ToInt32(Request.QueryString["duzen"]);
        KATEGORI k = db.KATEGORIs.FirstOrDefault(a => a.KATID == kat);
        tbad.Text = k.KATADI;
        tbdess.Text = k.KATDES;
        if (k.KATUSTID != 0)
        {
            lbkat.Text = db.KATEGORIs.FirstOrDefault(a => a.KATID == k.KATUSTID).KATADI;
        }
        else
        {
            lbkat.Text = "Ana Kategori";
        }
        if (k.KATDURUM == true)
        {
            chkAktif.Checked = true;
        }
        else
        {
            chkAktif.Checked = false;
        }
        tbkey.Text = k.KATKEY;
        imgsrc.Src = "../PhotoResize.aspx?Tur=Fix&genislik=100&yukseklik=100&src=images/Kategori/" + k.KATLOGO;
        lbres.Text = k.KATLOGO;
        lbres.Visible = true;
        tbsira.Text = k.KATSIRA.ToString();
        tbtitle.Text = k.KATTITLE;
        TbOzet.Text = k.KATOZET;
        drpKattur.SelectedValue = k.KATTUR.ToString();
        BtnKaydet.Visible = false;
        BtnUpdate.Visible = true;
        trres.Visible = false;
    }
    private void KategoriGetir()
    {
        int katID =0;
        if (Request.QueryString["id"] != null)
        {
            katID = Convert.ToInt32(Request.QueryString["id"]);
        }
        int Dil = Convert.ToInt32(1);
        var Kategoriler = from k in db.KATEGORIs where k.KATUSTID == katID && k.KATDIL == Dil orderby (k.KATSIRA) select k;
        RepaterKategori.DataSource = Kategoriler;
        RepaterKategori.DataBind();
        //Literal1.Text = "";
        //foreach (var item in Kategoriler)
        //{
        //    Literal1.Text += "<div><a href='KategoriEkle.aspx?id=" + item.KATID + "' class='list' >" + item.KATADI + "</a><div>";
        //}
    }
    private void AnaKategoriGetir()
    {
        int katID = Convert.ToInt32(Request.QueryString["id"]);
        int Dil = 1;
        var Kategoriler = from k in db.KATEGORIs where k.KATUSTID == 0 && k.KATDIL == Dil orderby (k.KATSIRA) select k;
        RepaterKategori.DataSource = Kategoriler;
        RepaterKategori.DataBind();
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbad.Text) != true)
        {
            KATEGORI k = new KATEGORI();
            int kat = 0;
            bool Aktifdurum = false;
            if (Request.QueryString["Id"] != null)
            {
                kat = Convert.ToInt32(Request.QueryString["Id"]);
            }
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text.Trim());
            }
            catch
            {
            }
            if (chkAktif.Checked)
            {
                Aktifdurum = true;
            }
            Genel g = new Genel();
            string resim = "";
            if (FileUpload1.HasFile)
            {

                string gec1 = FileUpload1.PostedFile.FileName;
                string deneme = System.IO.Path.GetExtension(gec1);
                resim = Genel.UrlSeo(gec1.Replace(deneme, "")); ;
                int sayi1 = 1;
                for (int i = 0; i < sayi1; i++)
                {
                    if (System.IO.File.Exists(Server.MapPath("/images/Kategori") + "\\" + resim) == true)
                    {
                        string a = resim.Replace(deneme, "");
                        resim = a + "(" + sayi1.ToString() + ")";
                        sayi1++;
                    }
                }
                resim += deneme;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("/images/Kategori") + "/" + resim);
                k.KATLOGO = resim;
            }
            else
            {
                k.KATLOGO = "";
            }
            k.KATADI = tbad.Text.Trim();
            k.KATDES = tbdess.Text.Trim();
            k.KATDIL = Convert.ToInt32(1);
            k.KATDURUM = Aktifdurum;
            k.KATKEY = tbkey.Text.Trim();
            k.KATOZET = TbOzet.Text;
            k.KATDES = tbdess.Text;
            k.KATDEGIS = 1;
            k.KATTUR = Convert.ToInt32(drpKattur.SelectedValue);
            k.KATSIRA = sira;
            k.KATTARIH = DateTime.Now;
            k.KATTITLE = tbtitle.Text.Trim();
            k.KATURL = urlKontrol(Genel.UrlSeo(tbad.Text.Trim()));
            k.KATUSTID = kat;
            db.AddToKATEGORIs(k);
            db.SaveChanges();
            KategoriGetir();
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Kaydedildi...";
            // BtnKaydet.Enabled = false;
        }
    }
    private string urlKontrol(string url)
    {
        var ur = from x in db.KATEGORIs where x.KATURL == url select x.KATID;
        if (ur.Count() > 0 && ur != null)
        {
            int sayi = ur.Count();
            url += "-" + sayi++;
            urlKontrol(url);
        }
        return url;
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbad.Text) != true)
        {
            int kat = 4;
            bool Aktifdurum = false;
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text.Trim());
            }
            catch
            {
            }
            if (Request.QueryString["duzen"] != null)
            {
                kat = Convert.ToInt32(Request.QueryString["duzen"]);
            }
            if (chkAktif.Checked)
            {
                Aktifdurum = true;
            }
            Genel g = new Genel();
            //string resim = lbres.Text;
            //if (FileUpload1.HasFile)
            //    resim = g.FotoIslemi(FileUpload1, "../images/sahte", "../images/Kategori/", 1000);
            KATEGORI k = db.KATEGORIs.FirstOrDefault(a => a.KATID == kat);
            string resim = "";
            if (FileUpload1.HasFile)
            {
                string gec1 = FileUpload1.PostedFile.FileName;
                string deneme = System.IO.Path.GetExtension(gec1);
                resim = Genel.UrlSeo(gec1.Replace(deneme, "")); ;
                int sayi1 = 1;
                for (int i = 0; i < sayi1; i++)
                {
                    if (System.IO.File.Exists(Server.MapPath("/images/Kategori") + "\\" + resim) == true)
                    {
                        string a = resim.Replace(deneme, "");
                        resim = a + "(" + sayi1.ToString() + ")";
                        sayi1++;
                    }
                }
                resim += deneme;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("/images/Kategori") + "/" + resim);
                k.KATLOGO = resim;
            }
            k.KATADI = tbad.Text.Trim();
            k.KATDES = tbdess.Text.Trim();
            k.KATDIL = Convert.ToInt32(1);
            k.KATDURUM = Aktifdurum;
            k.KATKEY = tbkey.Text.Trim();
            k.KATSIRA = sira;
            k.KATTARIH = DateTime.Now;
            k.KATTITLE = tbtitle.Text.Trim();
            k.KATOZET = TbOzet.Text;
            k.KATTUR = Convert.ToInt32(drpKattur.SelectedValue);
            db.SaveChanges();
            KategoriGetir();
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Düzenlendi...";
            BtnUpdate.Enabled = false;
            divhata.Visible = false;
        }
    }
    protected void RepaterKategori_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "s")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            KATEGORI k = db.KATEGORIs.FirstOrDefault(a => a.KATID == id);
            //if (k.KATUSTID != 0)
            //{
            db.KATEGORIs.DeleteObject(k);
            db.SaveChanges();
            KategoriGetir();
            //}
            //else
            //{
            divhata.Visible = true;
            lbhatamesaj.Text = "Kategori Silindi...";
            //}

        }
    }
    protected void DrpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        KategoriGetir();
        divhata.Visible = false;
        divkaydet.Visible = false;
    }
    protected void chkdurum_CheckedChanged(object sender, EventArgs e)
    {

    }
}