using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;
using System.IO;

public partial class Yonetim_AlbumEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Yeni Albüm Ekle";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = true;
            hpyeni.Text = "Yeni Ekle";
            hpyeni.NavigateUrl = "AlbumEkle.aspx";
            DilGetir();
            GaleriGetir();

            if (Request.QueryString["id"] != null)
            {
                GaleriDetayGetir();
            }
            else
            {
                BtnKaydet.Visible = true;
                BtnUpdate.Visible = false;
                trres.Visible = false;
            }
        }
    }

    private void GaleriDetayGetir()
    {
        int AlbumId = Convert.ToInt32(Request.QueryString["id"]);
        BtnKaydet.Visible = false;
        BtnUpdate.Visible = true;
        trres.Visible = false;
        ALBUM a = db.ALBUMs.Where(al => al.ALBUMID == AlbumId).FirstOrDefault();
        tbad.Text = a.ALBUMBASLIK;
        tbsira.Text = a.ALBUMSIRA.ToString();
        lbres.Text = a.ALBUMLOGO;
        imgsrc.Src = "../PhotoResize.aspx?Tur=Fix&genislik=100&yukseklik=100&src=images/Album/" + a.ALBUMLOGO;
        chkAktif.Checked = Convert.ToBoolean(a.ALBUMDURUM);



    }

    private void GaleriGetir()
    {
        int dil = Convert.ToInt32(1);
        var albumler = from a in db.ALBUMs where a.ALBUMDIL == dil orderby (a.ALBUMSIRA) select a;
        RepeaterAlbum.DataSource = albumler;
        RepeaterAlbum.DataBind();
    }

    private void DilGetir()
    {
        //var diller = from d in db.DILs where d.Durum == true select d;
        //DrpDil.Items.Clear();
        //foreach (var item in diller)
        //{
        //    DrpDil.Items.Add(new ListItem(item.DILAD, item.DILID.ToString()));
        //}
        //DrpDil.DataBind();
    }
    protected void RepaterKategori_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "s")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            db.ALBUMs.DeleteObject(db.ALBUMs.Where(a => a.ALBUMID == id).First());
            db.SaveChanges();
            GaleriGetir();
        }
    }
    protected void DrpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        GaleriGetir();
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbad.Text) != true)
        {
            ALBUM a = new ALBUM();
            a.ALBUMBASLIK = tbad.Text;
            a.ALBUMDIL = Convert.ToInt32(1);


            a.ALBUMDURUM = chkAktif.Checked;
            Genel g = new Genel();
            string resim = "";
            if (FileUpload1.HasFile)
                resim = g.FotoIslemi(FileUpload1, "../images/sahte", "../images/Album/", 1000);
            a.ALBUMLOGO = resim;

            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text);
            }
            catch
            {

            }
            a.ALBUMSIRA = sira;
            a.ALBUMTARIH = DateTime.Now;
            a.ALBUMURL = urlKontrol(Genel.UrlSeo(tbad.Text.Trim()));
            db.AddToALBUMs(a);
            db.SaveChanges();
            GaleriGetir();
            tbad.Text = "";
            tbsira.Text = "";
            chkAktif.Checked = false;
            lbkaydedildi.Text = "Kaydedildi...";
            divkaydet.Visible = true;
            GaleriGetir();

        }
    }
    private string urlKontrol(string url)
    {
        var ur = from x in db.ALBUMs where x.ALBUMURL == url select x.ALBUMID;
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
            int albumid = Convert.ToInt32(Request.QueryString["id"]);
            ALBUM a = db.ALBUMs.Where(al => al.ALBUMID == albumid).FirstOrDefault();
            a.ALBUMBASLIK = tbad.Text;
            a.ALBUMDIL = Convert.ToInt32(1);
            a.ALBUMDURUM = chkAktif.Checked;
            Genel g = new Genel();
            string resim = "";
            if (FileUpload1.HasFile)
            {
                try
                {
                    File.Delete(MapPath("../images/Album/" + lbres.Text));
                }
                catch
                {

                }

                resim = g.FotoIslemi(FileUpload1, "../images/sahte", "../images/Album/", 1000);
            }
            else
            {
                resim = lbres.Text;
            }
            a.ALBUMLOGO = resim;

            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text);
            }
            catch
            {

            }
            a.ALBUMSIRA = sira;
            a.ALBUMTARIH = DateTime.Now;
            db.SaveChanges();

            lbkaydedildi.Text = "Güncellendi...";
            tbsira.Text = "";
            tbad.Text = "";
            trres.Visible = false;
            chkAktif.Checked = false;
            divkaydet.Visible = true;
            BtnUpdate.Visible = false;
            BtnKaydet.Visible = true;
            GaleriGetir();
        }
    }
}