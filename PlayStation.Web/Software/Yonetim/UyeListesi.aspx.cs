using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_UyeListesi : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Üye Listesi";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = true;
            hpyeni.Text = "Yeni Üye";
            hpyeni.NavigateUrl = "UyeGuncelle.aspx";
            UyeGetir();
        }
    }

    private void UyeGetir()
    {
        var uyeler = db.UYEs.Where(u => u.UYEAKTIVASYONDURUM != false || u.UYEDURUM != false).ToList();
        RepeaterUrun.DataSource = uyeler;
        RepeaterUrun.DataBind();
    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int uyeid = Convert.ToInt32(e.CommandArgument);
            UYE u = db.UYEs.Where(a => a.UYEID == uyeid).FirstOrDefault();
            u.UYEDURUM = false;
            u.UYEAKTIVASYONDURUM = false;
            db.SaveChanges();
            UyeGetir();

        }
    }
}