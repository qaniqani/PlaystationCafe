using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class KullaniciBelirle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Kullanıcı Listesi";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = true;
            hpyeni.Text = "Yeni Kullanıcı";
            hpyeni.NavigateUrl = "KullaniciEkle.aspx";
            divhata.Visible = false;
            KullaniciGetir();
        }
    }

    private void KullaniciGetir()
    {
        var kullanicilar = db.ADMINs.ToList();
        RepeaterUrun.DataSource = kullanicilar;
        RepeaterUrun.DataBind();
    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            db.ADMINs.DeleteObject(db.ADMINs.Where(a => a.ADMINID == id).FirstOrDefault());
            db.SaveChanges();
            KullaniciGetir();
            divhata.Visible = true;
            lbhatamesaj.Text = "Silindi...";
            
        }
    }
}