using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_IkListe : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Ik Pozisyon Listesi";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = true;
            hpyeni.Text = "Yeni Pozisyon";
            hpyeni.NavigateUrl = "IkEkle.aspx";

            HaberDuyuruGetir();
        }
    }


    private void HaberDuyuruGetir()
    {
        int dil = Convert.ToInt32(1);
        var ikliste = db.IKs.Where(a => a.DIL == dil).OrderBy(a => a.SIRA);
        RepeaterUrun.DataSource = ikliste;
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
            db.IKs.DeleteObject(db.IKs.Where(a => a.ID == id).FirstOrDefault());
            db.SaveChanges();
            HaberDuyuruGetir();
        }
    }
}