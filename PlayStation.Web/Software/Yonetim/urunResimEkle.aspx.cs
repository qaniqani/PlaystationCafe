using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;
using System.IO;

public partial class Yonetim_urunResimEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Ürün Resim Ekle";
    
            UrunGetir();
            FotoGetir();
        }
    }
    private void UrunGetir()
    {
        int dil = 1;
        var urunler = from d in db.URUNs where d.URUNDIL == dil orderby (d.URUNSIRA) select d;
        drpUrun.Items.Clear();
        foreach (var item in urunler)
        {
            drpUrun.Items.Add(new ListItem(item.URUNADI, item.URUNID.ToString()));
        }
    }
   
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            URUNRESIM u = db.URUNRESIMs.FirstOrDefault(b => b.RESID == id);
            try
            {
                File.Delete(MapPath("../images/Urun/" + u.RESIM));
            }
            catch
            {
            }
            db.URUNRESIMs.DeleteObject(u);
            db.SaveChanges();
            FotoGetir();
        }
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (FileUploadResim.HasFile)
        {
            Genel g = new Genel();
            string a = "";
            if (FileUploadResim.HasFile)
            {
                a = g.ImageCropFileSave(FileUploadResim, "../images/Urun/", "../images/sahte", 150, 200);
            }
            URUNRESIM u = new URUNRESIM();
            u.DURUM = true;
            u.RESIM = a;
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text);
            }
            catch
            {}
            u.SIRA = sira;
            u.TARIH = DateTime.Now;
            int urid = Convert.ToInt32(drpUrun.SelectedValue);
            u.URID = urid;
           
            u.TEMSIL = chktemsili.Checked;
            db.AddToURUNRESIMs(u);
            db.SaveChanges();
            FotoGetir();
            tbsira.Text = "9999";
            divkaydet.Visible = true;
            divhata.Visible = false;
            lbkaydedildi.Text = "Kaydedildi...";
        }
        else
        {
            divhata.Visible = true;
            divkaydet.Visible = false;
            lbhatamesaj.Text = "Lüften resim seçiniz...";
        }
    }
    protected void drpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        UrunGetir();
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
        int urunid = 0;
        try
        {
            urunid = Convert.ToInt32(drpUrun.SelectedValue);
        }
        catch
        {
        }
        var urunresim = from d in db.URUNRESIMs where d.URID == urunid orderby (d.SIRA) select d;
        RepeaterUrun.DataSource = urunresim;
        RepeaterUrun.DataBind();
    }
}