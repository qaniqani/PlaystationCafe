using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_EbultenListesi : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "E-Bülten Listesi";
            EbultenGetir();
        }
    }

    private void EbultenGetir()
    {
        var ebulten = db.EBULTENs.ToList();
        RepeaterUrun.DataSource = ebulten;
        RepeaterUrun.DataBind();
    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        { 
            int id=Convert.ToInt32(e.CommandArgument);
            EBULTEN eb = db.EBULTENs.FirstOrDefault(a => a.BULTENID == id);
            db.EBULTENs.DeleteObject(eb);
            db.SaveChanges();
            EbultenGetir();
            divhata.Visible = true;
            lbhatamesaj.Text = "Silindi...";
           
        }
    }
}