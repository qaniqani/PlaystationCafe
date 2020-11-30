using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_IletisimEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "İletişim Güncelle";



            AyarGetir();
        }
    }



    private void AyarGetir()
    {
        int dil = Convert.ToInt32(1);
        var a = (from x in db.ILETISIMs where x.DILID == dil orderby x.ILETISIMID descending select x).Take(1);

        foreach (var item in a)
        {

            tbadres.Text = item.ADRES;
            tbbaslik.Text = item.BASLIK;
            tbeposta.Text = item.EMAIL;
            tbfaks.Text = item.FAKS;
            tbmaps.Text = item.MAPS;
            tbtel.Text = item.TEL;
            tbtel2.Text = item.TEL2;
            Tbgsm.Text = item.GSM;
            tbgoogle.Text = item.GOOGLE;
            tbtwitter.Text = item.TWITTER;
            tbfacebook.Text = item.FACEBOOK;
            tblinkedin.Text = item.LINKEDIN;
            tbyenibiris.Text = item.YENIBIRIS;

        }
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {

        ILETISIM aya = null;
        int dil = Convert.ToInt32(1);
        var a = (from x in db.ILETISIMs where x.DILID == dil orderby x.ILETISIMID descending select x).Take(1);
        if (a.Count() > 0)
        {
            aya = a.FirstOrDefault();
        }
        else
        {
            aya = new ILETISIM();
        }
        aya.ADRES = tbadres.Text;
        aya.BASLIK = tbbaslik.Text;
        aya.DILID = Convert.ToInt32(1);
        aya.EMAIL = tbeposta.Text;
        aya.FAKS = tbfaks.Text;
        aya.GSM = Tbgsm.Text;
        aya.GSM2 = "";
        aya.LINK = "";
        aya.LOGO = "";
        aya.MAPS = tbmaps.Text;
        aya.MAPSDURUM = true;
        aya.TEL = tbtel.Text;
        aya.TEL2 = tbtel2.Text;
        aya.GOOGLE = "http://" + (tbgoogle.Text.Replace("http://", ""));
        aya.FACEBOOK = "http://" + (tbfacebook.Text.Replace("http://", ""));
        aya.TWITTER = "http://" + (tbtwitter.Text.Replace("http://", ""));
        aya.LINKEDIN = "http://" + (tblinkedin.Text.Replace("http://", ""));
        aya.YENIBIRIS = "http://" + (tbyenibiris.Text.Replace("http://", ""));
        if (a.Count() > 0)
        {
            db.SaveChanges();
            lbkaydedildi.Text = "Güncellendi...";
        }
        else
        {
            db.AddToILETISIMs(aya);
            db.SaveChanges();
            lbkaydedildi.Text = "Kaydedildi...";
        }
        divkaydet.Visible = true;
    }



    protected void DrpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        AyarGetir();
    }
}