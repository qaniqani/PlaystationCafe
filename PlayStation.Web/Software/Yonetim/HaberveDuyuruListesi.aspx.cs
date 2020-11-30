using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_HaberveDuyuruListesi : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Haber-Duyuru Listesi";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = true;
            hpyeni.Text = "Yeni içerik";
            hpyeni.NavigateUrl = "HaberveDuyuruEkle.aspx";

            HaberDuyuruGetir();
        }
    }


    private void HaberDuyuruGetir()
    {
        int dil = Convert.ToInt32(1);
        string tur = drpTur.SelectedValue;
        dynamic haberler = db.HABERMAKALEs.Where(a => a.HABERDIL == dil && a.HABERTUR == tur).OrderBy(a => a.HABERSIRA);
        RepeaterUrun.DataSource = haberler;
        RepeaterUrun.DataBind();
    }
    protected void drpdil_SelectedIndexChanged(object sender, EventArgs e)
    {
        HaberDuyuruGetir();
    }
    protected void drpTur_SelectedIndexChanged(object sender, EventArgs e)
    {
        HaberDuyuruGetir();
    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            db.HABERMAKALEs.DeleteObject(db.HABERMAKALEs.Where(a => a.HABERID == id).FirstOrDefault());
            db.SaveChanges();
            HaberDuyuruGetir();
        }
    }
}