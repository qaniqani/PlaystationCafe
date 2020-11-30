using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;
using System.IO;

public partial class Yonetim_UrunDosyaEkle2 : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Broşür Dosya Ekle";

            UrunGetir();
            DosyaGetir();
        }
    }

    private void UrunGetir()
    {
        int dil = Convert.ToInt32(1);
        var urunler = from d in db.URUNs where d.URUNDIL == dil select d;
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
            URUNDOSYA u = db.URUNDOSYAs.FirstOrDefault(b => b.DOSID == id);
            try
            {
                File.Delete(MapPath("../images/Dosya/" + u.DOSYA));
            }
            catch
            {


            }

            db.URUNDOSYAs.DeleteObject(u);
            db.SaveChanges();
            DosyaGetir();
        }
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (FileUploadResim.HasFile)
        {
            Genel g = new Genel();
            string resim = "";



            string gec1 = FileUploadResim.PostedFile.FileName;
            string deneme = System.IO.Path.GetExtension(gec1);
            resim = Genel.UrlSeo(gec1.Replace(deneme, ""));
            int sayi1 = 1;
            for (int i = 0; i < sayi1; i++)
            {
                if (System.IO.File.Exists(Server.MapPath("../images/Dosya") + "\\" + resim) == true)
                {
                    string a = resim.Replace(deneme, "");
                    resim = a + "(" + sayi1.ToString() + ")";
                    sayi1++;
                }
            }
            resim = resim + deneme;

            FileUploadResim.PostedFile.SaveAs(Server.MapPath("../images/Dosya") + "/" + resim);
            URUNDOSYA u = new URUNDOSYA();
            u.TIP = 2;
            u.BASLIK = tbbaslik.Text;
            u.DURUM = true;
            u.DOSYA = resim;
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

            db.AddToURUNDOSYAs(u);
            db.SaveChanges();
            DosyaGetir();
            tbsira.Text = "9999";
            divkaydet.Visible = true;
            divhata.Visible = false;
            lbkaydedildi.Text = "Kaydedildi...";
        }
        else
        {
            divhata.Visible = true;
            divkaydet.Visible = false;
            lbhatamesaj.Text = "Lüften Dosya seçiniz...";
        }
    }
    protected void drpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        UrunGetir();
        DosyaGetir();
    }
    protected void drpUrun_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        DosyaGetir();
    }

    private void DosyaGetir()
    {
        int urunid = 0;
        try
        {
            urunid = Convert.ToInt32(drpUrun.SelectedValue);
        }
        catch
        {


        }

        var urundosya = from d in db.URUNDOSYAs where d.URID == urunid && d.TIP == 2 select d;
        RepeaterUrun.DataSource = urundosya;
        RepeaterUrun.DataBind();
    }
}