using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;
using System.IO;

public partial class Yonetim_SliderEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Slider";
            if (Session["id"] != null)
            {
                BtnUpdate.Visible = true;
                BtnKaydet.Visible = false;
            }
            else
            {
                BtnUpdate.Visible = false;
                BtnKaydet.Visible = true;
            }
            trresim.Visible = false;
           
            SliderGetir();
        }

    }

    private void SliderGetir()
    {
        int dil = Convert.ToInt32(1);
        string tur = DrpTur.SelectedValue;
        var Sliders = db.SLIDERs.Where(s => s.SLIDERDIL == dil && s.SLIDERTUR == tur).OrderBy(s => s.SLIDERSIRA).ToList();
        RepeaterUrun.DataSource = Sliders;
        RepeaterUrun.DataBind();
    }

   
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        Genel g = new Genel();
        string resim = "";
        if (FileUploadResim.HasFile)
        {



            string gec1 = FileUploadResim.PostedFile.FileName;
            string deneme = System.IO.Path.GetExtension(gec1);
            resim = Genel.UrlSeo(gec1.Replace(deneme, ""));
            int sayi1 = 1;
            for (int i = 0; i < sayi1; i++)
            {
                if (System.IO.File.Exists(Server.MapPath("../images/Slider") + "\\" + resim + deneme) == true)
                {

                    resim = resim + "(" + sayi1.ToString() + ")";
                    sayi1++;
                }
            }
            resim = resim + "." + deneme.Replace(".", "");

            FileUploadResim.PostedFile.SaveAs(Server.MapPath("../images/Slider") + "/" + resim);

        }
        else
        {
         
        }

        try
        {

        

        SLIDER s = new SLIDER();
        s.SLIDERBASLIK = tbad.Text;
        s.SLIDERDIL = Convert.ToInt32(1);
        s.SLIDERDURUM = chkdurum.Checked;
        s.SLIDERLINK = tblink.Text;
        s.SLIDEROZET = tbozet.Text;
        s.SLIDERSLOGAN = tbaciklama.Text;
        int sira = 9999;
        try
        {
            sira = Convert.ToInt32(tbsira.Text);
        }
        catch
        {

        }
        s.SLIDERSIRA = sira;
        s.SLIDERTARIH = DateTime.Now;
        s.SLIDERTUR = DrpTur.SelectedValue;
        s.SLIDERRESIM = resim;
        db.AddToSLIDERs(s);
        db.SaveChanges();
        SliderGetir();
        divkaydet.Visible = true;
        divhata.Visible = false;
        lbkaydedildi.Text = "Kaydedildi...";
        trresim.Visible = false;
        }
        catch (Exception)
        {

            divhata.Visible = true;
            divkaydet.Visible = false;
            lbhatamesaj.Text = "Hata Oluştu...";
        }

    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            SLIDER s = db.SLIDERs.FirstOrDefault(ss => ss.SLIDERID == id);
            try
            {
                File.Delete(MapPath("../images/Slider/" + s.SLIDERRESIM));
            }
            catch
            {
            }
            db.SLIDERs.DeleteObject(s);
            db.SaveChanges();
            SliderGetir();
            divhata.Visible = true;
            lbhatamesaj.Text = "Silindi...";
            divkaydet.Visible = false;


        }
        else if (e.CommandName == "Duzen")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            SLIDER s = db.SLIDERs.FirstOrDefault(ss => ss.SLIDERID == id);
            BtnKaydet.Visible = false;
            BtnUpdate.Visible = true;
            Session["id"] = id;
            tbaciklama.Text = s.SLIDERSLOGAN;
            tbad.Text = s.SLIDERBASLIK;
           
            chkdurum.Checked = Convert.ToBoolean(s.SLIDERDURUM);
            tblink.Text = s.SLIDERLINK;
            tbozet.Text = s.SLIDEROZET;
            trresim.Visible = true;
            DrpTur.SelectedValue = s.SLIDERTUR;
            tbsira.Text = s.SLIDERSIRA.ToString();
            imgsrc.Src = "../images/Slider/" + s.SLIDERRESIM;

            //db.SaveChanges();
            //SliderGetir();
            //divkaydet.Visible = true;
            //divhata.Visible = false;
            //lbkaydedildi.Text = "Güncellendi...";
        }
    }
    protected void drpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        SliderGetir();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {

            int id = Convert.ToInt32(Session["id"]);
            SLIDER s = db.SLIDERs.FirstOrDefault(ss => ss.SLIDERID == id);
            string resim = s.SLIDERRESIM;
            if (FileUploadResim.HasFile)
            {
                try
                {
                    File.Delete(MapPath("../images/Slider/" + s.SLIDERRESIM));
                }
                catch (Exception)
                {
                }
                string gec1 = FileUploadResim.PostedFile.FileName;
                string deneme = System.IO.Path.GetExtension(gec1);
                resim = Genel.UrlSeo(gec1.Replace(deneme, ""));
                int sayi1 = 1;
                for (int i = 0; i < sayi1; i++)
                {
                    if (System.IO.File.Exists(Server.MapPath("../images/Slider") + "\\" + resim) == true)
                    {

                        resim = resim + "(" + sayi1.ToString() + ")";
                        sayi1++;
                    }
                }
                resim = resim + "." + deneme.Replace(".", "");


                FileUploadResim.PostedFile.SaveAs(Server.MapPath("../images/Slider") + "/" + resim);
            }

            s.SLIDERSLOGAN = tbaciklama.Text;
            s.SLIDERBASLIK = tbad.Text;
            s.SLIDERDIL = Convert.ToInt32(1);
            s.SLIDERDURUM = chkdurum.Checked;
            s.SLIDERTUR = DrpTur.SelectedValue;
            s.SLIDERLINK = tblink.Text;
            s.SLIDEROZET = tbozet.Text;
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text);
            }
            catch
            {

            }
            s.SLIDERSIRA = sira;
            s.SLIDERTARIH = DateTime.Now;

            s.SLIDERRESIM = resim;
            db.SaveChanges();
            SliderGetir();
            divkaydet.Visible = true;
            divhata.Visible = false;
            lbkaydedildi.Text = "Güncellendi...";
            BtnKaydet.Visible = true;
            BtnUpdate.Visible = false;
            trresim.Visible = false;
            Session["id"] = null;

        }
    }
    protected void chkdurum_CheckedChanged(object sender, EventArgs e)
    {

    }
}