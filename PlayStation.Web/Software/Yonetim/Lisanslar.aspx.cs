using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_Lisanslar : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Lisanslar";
            this.GetLicence();
        }
    }

    private void GetLicence()
    {
        var allLicence = from x in db.LISANSLAMALARs orderby x.FIRID descending select x;
        Repeatericerik.DataSource = allLicence;
        Repeatericerik.DataBind();
    }

    protected void Repeatericerik_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "s")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            LISANSLAMALAR l = db.LISANSLAMALARs.FirstOrDefault(a => a.FIRID == id);
            db.LISANSLAMALARs.DeleteObject(l);
            db.SaveChanges();
            this.GetLicence();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertMsg", "<script language='javascript'>alert('İlgili lisans silinmiştir.' );</script>", false);
        }
    }
}