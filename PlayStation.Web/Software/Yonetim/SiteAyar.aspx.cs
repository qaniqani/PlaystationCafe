using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_SiteAyar : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Genel Ayarlar";


            AyarGetir();
        }
    }

    
    private void AyarGetir()
    {
        var a = (from x in db.AYARs orderby x.AYARID descending select x).Take(1);

        foreach (var item in a)
        {

            tbanalytics.Text = item.ANALYTICSKODU;
            tbdess.Text = item.ANASAYFADES;
            Tbeposta.Text = item.EPOSTA;
            tbkey.Text = item.ANASAYFAKEY;
            tbport.Text = item.EPOSTAPORT;
            tbsifre.Text = item.EPOSTAPAROLA;
            tbsmtp.Text = item.EPOSTASMTP;
            tbtitle.Text = item.ANASAYFATITLE;
            tbport.Text = item.EPOSTAPORT;
        }
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
		AYAR aya = null;
		var a = (from x in db.AYARs orderby x.AYARID descending select x).Take(1);
		if (a.Count() > 0)
		{
			aya = a.FirstOrDefault();
		}
		else
		{
			aya = new AYAR();
		}
		aya.ANALYTICSKODU = tbanalytics.Text;
		aya.ANASAYFADES = tbdess.Text;
		aya.ANASAYFAKEY = tbkey.Text;
		aya.ANASAYFATITLE = tbtitle.Text;
		aya.DEFAULTDIL = dpvarsayilan.SelectedValue;
		aya.DIL = Convert.ToInt32(1);
		aya.DURUM = true;
		aya.EPOSTA = Tbeposta.Text;
		aya.EPOSTAPAROLA = tbsifre.Text;
		aya.EPOSTAPORT = tbport.Text;
		aya.EPOSTASMTP = tbsmtp.Text;
		aya.TARIH = DateTime.Now;
		if (a.Count() > 0)
		{
			try
			{
				db.SaveChanges();
				lbkaydedildi.Text = "Güncellendi...";
				divkaydet.Visible = true;
				divhata.Visible = false;
			}
			catch
			{
				divhata.Visible = true;
				divkaydet.Visible = false;
				lbhatamesaj.Text = "Kayıt işlemi gerçekleşemedi lütfen bilgilerinizi kontrol ediniz";
			}

		}
		else
		{
			try
			{
				db.AddToAYARs(aya);
				db.SaveChanges();
				lbkaydedildi.Text = "Kaydedildi...";
				divkaydet.Visible = true;
				divhata.Visible = false;
			}
			catch
			{
				divkaydet.Visible = false;
				divhata.Visible = true;
				lbhatamesaj.Text = "Kayıt işlemi gerçekleşemedi lütfen bilgilerinizi kontrol ediniz";
			}
		}
    }

    protected void DrpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        AyarGetir();
    }
}