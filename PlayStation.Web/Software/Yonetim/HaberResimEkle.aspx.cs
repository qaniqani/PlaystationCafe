using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;
using System.IO;

public partial class Yonetim_HaberResimEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Haber-Duyuru Resim Ekle";
            
            HaberDuyuruGetir();
            FotoGetir();
        }
    }

    private void HaberDuyuruGetir()
    {
        int dil = Convert.ToInt32(1);
        var Haberler = from d in db.HABERMAKALEs where d.HABERDIL == dil orderby (d.HABERSIRA) select d;
        drpUrun.Items.Clear();
        foreach (var item in Haberler)
        {
            drpUrun.Items.Add(new ListItem(item.HABERBASLIK, item.HABERID.ToString()));
        }
    }

  
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            HABERRESIM u = db.HABERRESIMs.FirstOrDefault(b => b.RESID == id);
            try
            {
                File.Delete(MapPath("../images/Haber/" + u.RESIM));
            }
            catch
            {

            }

            db.HABERRESIMs.DeleteObject(u);
            db.SaveChanges();
            FotoGetir();
            divhata.Visible = true;
            divkaydet.Visible = false;
            lbhatamesaj.Text = "Silindi...";

        }
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (FileUploadResim.HasFile)
        {


            Genel g = new Genel();
            string a = g.FotoIslemi(FileUploadResim, "../images/sahte", "../images/Haber/", 1000);
            HABERRESIM u = new HABERRESIM();
            u.DURUM = true;
            u.RESIM = a;
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text);
            }
            catch
            {

            }
            u.SIRA = sira;
            u.TARIH = DateTime.Now;
            int urid = Convert.ToInt32(drpUrun.SelectedValue);
            u.URID = urid;
            u.TEMSIL = chktemsili.Checked;
            db.AddToHABERRESIMs(u);
            db.SaveChanges();
            FotoGetir();
            tbsira.Text = "9999";
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Kaydedildi...";

            divhata.Visible = false;
        }
        else
        {
            divhata.Visible = true;
            lbhatamesaj.Text = "Lütfen resim seçiniz...";
        }
    }
    protected void drpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        HaberDuyuruGetir();
        FotoGetir();
    }
    protected void drpUrun_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        FotoGetir();
    }

    private void FotoGetir()
    {
        if (drpUrun.SelectedIndex!=-1)
        {
            int haberid = Convert.ToInt32(drpUrun.SelectedValue);
            var haberler = from d in db.HABERRESIMs where d.URID == haberid orderby (d.SIRA) select d;
            RepeaterUrun.DataSource = haberler;
            RepeaterUrun.DataBind();
        }
      
    }
}