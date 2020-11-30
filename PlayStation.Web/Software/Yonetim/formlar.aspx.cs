using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_formlar : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Formlar";
            FormGetir();
        }
    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            FORM frm = db.FORMs.FirstOrDefault(f => f.FORMID == id);
            db.FORMs.DeleteObject(frm);
            db.SaveChanges();
            FormGetir();
        }
    }

    private void FormGetir()
    {
        string durum = drpdil.SelectedValue;
        var formlar = db.FORMs.Where(f => f.FORMYAYIN == durum && f.FORMTUR =="2");
        RepeaterUrun.DataSource = formlar;
        RepeaterUrun.DataBind();
    }
    protected void drpdil_SelectedIndexChanged(object sender, EventArgs e)
    {
        FormGetir();
    }
}