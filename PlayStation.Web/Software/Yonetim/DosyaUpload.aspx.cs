using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;
using System.IO;

public partial class Yonetim_DosyaUpload : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Dosya Ekle";

            DosyaGetir();
        }
    }



    private void DosyaGetir()
    {
        int dil = Convert.ToInt32(1);
        var dosyalar = db.DOSYAUPLOADs.Where(d => d.DIL == dil && d.DOSYATUR == 1).ToList();
        RepeaterUrun.DataSource = dosyalar;
        RepeaterUrun.DataBind();
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        string resim = "";
        if (FileUploadResim.HasFile)
        {
            if (FileUploadResim.HasFile)
            {
                string gec1 = FileUploadResim.PostedFile.FileName;
                string deneme = System.IO.Path.GetExtension(gec1);
                resim = Genel.UrlSeo(gec1.Replace(deneme, "")); ;
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
                resim += deneme;
                FileUploadResim.PostedFile.SaveAs(Server.MapPath("../images/Dosya") + "/" + resim);
            }
            DOSYAUPLOAD du = new DOSYAUPLOAD();
            du.DOSYAADI = tbad.Text;
            du.DIL = Convert.ToInt32(1);
            du.DOSYAYOLU = "/images/Dosya/" + resim;
            du.DOSYATUR = 1;
            db.AddToDOSYAUPLOADs(du);
            db.SaveChanges();
            DosyaGetir();
            divhata.Visible = false;
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Kaydedildi...";

        }
        else
        {
            divhata.Visible = true;
            divkaydet.Visible = false;
            lbhatamesaj.Text = "Upload edicek dosya bulunamadı...";
        }


    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            DOSYAUPLOAD du = db.DOSYAUPLOADs.Where(d => d.DOSYAID == id).FirstOrDefault();
            try
            {
                File.Delete(MapPath(".." + du.DOSYAYOLU));
            }
            catch
            {


            }
            db.DOSYAUPLOADs.DeleteObject(du);
            db.SaveChanges();
            DosyaGetir();
            divkaydet.Visible = false;
            divhata.Visible = true;
            lbhatamesaj.Text = "Silindi...";
        }
    }
    protected void drpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;

    }
}