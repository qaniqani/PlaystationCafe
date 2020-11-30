using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_KullaniciEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Kullanıcı Ekle";
            if (Request.QueryString["id"] != null)
            {
                KullaniciDetayGetir();
            }
        }
    }

    private void KullaniciDetayGetir()
    {
        int id=Convert.ToInt32(Request.QueryString["id"].ToString());
        ADMIN ad = db.ADMINs.Where(a => a.ADMINID == id).FirstOrDefault();
        TbAd.Text = ad.ADMINADI;
        TbKullanici.Text = ad.ADMINKULLANICI;
        TbParola.Text = ad.ADMINPAROLA;
        chkaktivasyondurum.Checked = Convert.ToBoolean(ad.DURUM);
        BtnKaydet.Visible = false;
        BtnUpdate.Visible = true;
        divkaydet.Visible = false;
        divduzen.Visible = false;
        divhata.Visible = false;
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        ADMIN ad = new ADMIN();
        ad.ADMINADI = TbAd.Text;
        ad.ADMINKULLANICI = TbKullanici.Text;
        ad.ADMINPAROLA = TbParola.Text;
        ad.DURUM = chkaktivasyondurum.Checked;
        ad.TARIH = DateTime.Now;
        db.AddToADMINs(ad);
        db.SaveChanges();
        divkaydet.Visible = true;
        divduzen.Visible = false;
        divhata.Visible = false;
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            ADMIN ad = db.ADMINs.Where(a => a.ADMINID == id).FirstOrDefault();
            ad.ADMINADI = TbAd.Text;
            ad.ADMINKULLANICI = TbKullanici.Text;
            ad.ADMINPAROLA = TbParola.Text;
            ad.DURUM = chkaktivasyondurum.Checked;
            ad.TARIH = DateTime.Now;
            db.SaveChanges();
            divduzen.Visible = true;
            divkaydet.Visible = false;
            divhata.Visible = false;
        }
        
    }
}