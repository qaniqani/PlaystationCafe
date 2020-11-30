using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class _Default : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
        lt.Text = "Anasayfa";
        if (!IsPostBack)
        {
            VeriGetir();
        }
    }

    private void VeriGetir()
    {
        try
        {
            var formlar = db.FORMs.OrderByDescending(f => f.FORMID).Take(10).ToList();
            RepeaterForm.DataSource = formlar;
            RepeaterForm.DataBind();


            //var yorumlar = db.YORUMs.OrderByDescending(y => y.UYEID).Take(10).ToList();
            //RepeaterYorum.DataSource = yorumlar;
            //RepeaterYorum.DataBind();


            string a = "";

            var icerikler = db.ICERIKs.ToList();
            a += "<li><a href='icerikListesi.aspx'><span>" + icerikler.Count.ToString() + "</span>Adet İçerik</a></li>";

            var anakategori = db.KATEGORIs.ToList();
            a += "<li><a href='KategoriEkle.aspx'><span>" + anakategori.Count.ToString() + "</span>Adet Kategori</a></li>";



            //var urunler = db.URUNs.ToList();
            //a += "<li><a href='urunListesi.aspx'><span>" + urunler.Count.ToString() + "</span>Adet Ürün</a></li>";
            //var Albumler = db.ALBUMRESIMs.ToList();
            //a += "<li><a href='AlbumResimEkle.aspx'><span>" + Albumler.Count.ToString() + "</span>Adet Referans</a></li>";
            //var yorumlarr = db.YORUMs.ToList();
            //a += "<li><a href='YorumListesi.aspx'><span>" + yorumlarr.Count.ToString() + "</span>Adet Yorum</a></li>";
            var formlarr = db.FORMs.ToList();
            a += "<li><a href='formlar.aspx'><span>" + formlarr.Count.ToString() + "</span>Adet Form</a></li>";
            //var uyeler = db.UYEs.Where(u => u.UYEAKTIVASYONDURUM != false || u.UYEDURUM != false).ToList();
            //a += "<li><a href='UyeListesi.aspx'><span>" + uyeler.Count.ToString() + "</span>Adet Üye</a></li>";
            var haberduyuru = db.HABERMAKALEs.ToList();
            a += "<li><a href='HaberveDuyuruListesi.aspx'><span>" + haberduyuru.Count.ToString() + "</span>Adet Haber ve Duyuru</a></li>";

            LiteralIstatistik.Text = a;
        }
        catch
        {
        }
    }
}