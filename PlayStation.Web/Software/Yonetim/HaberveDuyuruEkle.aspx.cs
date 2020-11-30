using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_HaberveDuyuruEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Haber ve Duyuru Ekle ";

            if (Request.QueryString["id"] != null)
            {
                BtnKaydet.Visible = false;
                BtnUpdate.Visible = true;
                HamberDetayGetir();
            }
        }
    }
    private void HamberDetayGetir()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        HABERMAKALE hm = db.HABERMAKALEs.FirstOrDefault(a => a.HABERID == id);
        tbad.Text = hm.HABERBASLIK;
        tbdess.Text = hm.HABERDES;
        tbkey.Text = hm.HABERKEY;
        tbozet.Text = hm.HABEROZET;
        tbsira.Text = hm.HABERSIRA.ToString();
        tbtitle.Text = hm.HABERTITLE;
        CKEditorControl1.Text = hm.HABERDETAY;
        chkAktif.Checked = Convert.ToBoolean(hm.HABERDURUM);
        drptur.SelectedValue = hm.HABERTUR.ToString();
    }

    
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbad.Text) != true && string.IsNullOrEmpty(tbozet.Text) != true && string.IsNullOrEmpty(CKEditorControl1.Text) != true)
        {
            HABERMAKALE hm = new HABERMAKALE();
            hm.HABERBASLIK = tbad.Text.Trim();
            hm.HABERDES = tbdess.Text.Trim();
            hm.HABERDETAY = CKEditorControl1.Text.Trim();
            hm.HABERDIL = Convert.ToInt32(1);
            hm.HABERDURUM = chkAktif.Checked;
            hm.HABERKEY = tbkey.Text.Trim();
            hm.HABEROZET = tbozet.Text.Trim();
            hm.HABERICERIKTUR = Convert.ToInt32(DrpHaberTur.SelectedValue);
            hm.HABERRESIM = "";
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text.Trim());
            }
            catch
            {

            }

            hm.HABERSIRA = sira;
            hm.HABERTARIH = DateTime.Now;
            hm.HABERTITLE = tbtitle.Text.Trim();

            //hm.HABERTUR = drptur.SelectedValue;//drptur ile değiştirildi.
            hm.HABERTUR = "1";
            hm.HABERURL = urlKontrol(Genel.UrlSeo(tbad.Text.Trim()));
            db.AddToHABERMAKALEs(hm);
            db.SaveChanges();
            divkaydet.Visible = true;
            tbad.Text = "";
            tbdess.Text = "";
            tbkey.Text = "";
            tbozet.Text = "";
            tbsira.Text = "9999";
            tbtitle.Text = "";
            chkAktif.Checked = false;

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
        if (string.IsNullOrEmpty(tbad.Text) != true && string.IsNullOrEmpty(tbozet.Text) != true && string.IsNullOrEmpty(CKEditorControl1.Text) != true)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            HABERMAKALE hm = db.HABERMAKALEs.FirstOrDefault(a => a.HABERID == id);
            hm.HABERBASLIK = tbad.Text.Trim();
            hm.HABERDES = tbdess.Text.Trim();
            hm.HABERDETAY = CKEditorControl1.Text.Trim();
            hm.HABERDIL = Convert.ToInt32(1);
            hm.HABERDURUM = chkAktif.Checked;
            hm.HABERKEY = tbkey.Text.Trim();
            hm.HABEROZET = tbozet.Text.Trim();
            //hm.HABERICERIKTUR = Convert.ToInt32(DrpHaberTur.SelectedValue);
            hm.HABERICERIKTUR =1;
            hm.HABERRESIM = "";
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text.Trim());
            }
            catch
            {
            }
            hm.HABERSIRA = sira;
            hm.HABERTARIH = DateTime.Now;
            hm.HABERTITLE = tbtitle.Text.Trim();
            hm.HABERTUR = drptur.SelectedValue;
            hm.HABERURL = urlKontrol(Genel.UrlSeo(tbad.Text.Trim()));
            db.SaveChanges();
            divduzen.Visible = true;
        }
    }
    protected void drptur_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void drpdil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
    }
}