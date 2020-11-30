using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;
using System.IO;

public partial class Yonetim_AlbumResimEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Galeri Resim Ekle";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = true;
            hpyeni.Text = "Yeni Ekle";
            hpyeni.NavigateUrl = "AlbumResimEkle.aspx";
            KontrolEt();
            AlbumGetir();
            AlbumResimGetir();
        }
    }


    protected void drpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        KontrolEt();
        divhata.Visible = false;
        divkaydet.Visible = false;
        AlbumGetir();
        AlbumResimGetir();

    }

    private void KontrolEt()
    {

    }

    private void AlbumResimGetir()
    {
        try
        {


            int albumid = Convert.ToInt32(drpAlbum.SelectedValue);
            var aResim = db.ALBUMRESIMs.Where(a => a.ALBUMID == albumid).OrderBy(a => a.RESSIRA);
            RepeaterResim.DataSource = aResim;
            RepeaterResim.DataBind();
        }
        catch
        {


        }
    }

    private void AlbumGetir()
    {
        int dil = Convert.ToInt32(1);
        var albumler = from d in db.ALBUMs where d.ALBUMDIL == dil orderby (d.ALBUMSIRA) select d;
        drpAlbum.Items.Clear();
        foreach (var item in albumler)
        {
            drpAlbum.Items.Add(new ListItem(item.ALBUMBASLIK, item.ALBUMID.ToString()));
        }
    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            try
            {
                File.Delete(Server.MapPath("~/images/Album/" + db.ALBUMRESIMs.Where(a => a.RESID == id).FirstOrDefault().RESYOL));
            }
            catch
            {

            }

            db.ALBUMRESIMs.DeleteObject(db.ALBUMRESIMs.Where(a => a.RESID == id).First());
            db.SaveChanges();
            AlbumResimGetir();
            divhata.Visible = true;
            lbhatamesaj.Text = "Silindi...";
        }
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        ALBUMRESIM aresim = new ALBUMRESIM();
        aresim.RESDIL = 1;

        aresim.RESDURUM = chkdurum.Checked;
        string resim = "";

        if (FileUploadResim.HasFile)
        {
            Genel g = new Genel();
            resim = g.FotoIslemi(FileUploadResim, "~/images/sahte", "~/images/Album/", 1000);
        }
        else
        {
            divhata.Visible = true;
            divkaydet.Visible = false;
            lbhatamesaj.Text = "Lütfen resim seçiniz...";
            return;
        }
        aresim.RESIMURL = urlKontrol(Genel.UrlSeo(tbbaslik.Text));
        int sira = 9999;
        try
        {
            sira = Convert.ToInt32(tbsira.Text);
        }
        catch
        {
        }
        aresim.RESBASLIK = tbbaslik.Text;
        aresim.RESICERIK = "http://" + tblink.Text.Replace("http://", "");
        aresim.RESSIRA = sira;
        aresim.RESTARIH = DateTime.Now;
        aresim.RESYOL = resim;
        aresim.ALBUMID = Convert.ToInt32(drpAlbum.SelectedValue);
        db.AddToALBUMRESIMs(aresim);
        db.SaveChanges();
        AlbumResimGetir();
        divkaydet.Visible = true;
        divhata.Visible = false;
        lbkaydedildi.Text = "Kaydedildi";
        tbsira.Text = "";
        chkdurum.Checked = true;


    }
    private string urlKontrol(string url)
    {
        var ur = from x in db.ALBUMRESIMs where x.RESIMURL == url select x.RESID;
        if (ur.Count() > 0 && ur != null)
        {
            int sayi = ur.Count();
            url += "-" + sayi++;
            urlKontrol(url);
        }
        return url;
    }
    protected void drpUrun_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        AlbumResimGetir();
    }
}