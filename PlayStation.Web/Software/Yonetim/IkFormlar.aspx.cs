using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_IkFormlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PozisyonGetir();
            FormGetir();
        }
    }

    private void FormGetir()
    {
        using (YonetimEntities db = new YonetimEntities())
        {
            string id = drppozisyonlar.SelectedValue;
            var ikform = db.IKFORMLARs.Where(a => a.IKREFERANS == id).OrderByDescending(a => a.ID);
            RepeaterUrun.DataSource = ikform;
            RepeaterUrun.DataBind();
        }

    }

    private void PozisyonGetir()
    {
        using (YonetimEntities db = new YonetimEntities())
        {
            var liste = db.VW_IK.ToList();
            drppozisyonlar.DataSource = liste;
            drppozisyonlar.DataValueField = "ID";
            drppozisyonlar.DataTextField = "BASLIK";
            drppozisyonlar.DataBind();
            drppozisyonlar.Items.Insert(0, new ListItem("Seçiniz", "0"));

        }
    }
    protected void drpdil_SelectedIndexChanged(object sender, EventArgs e)
    {
        FormGetir();
    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            using (YonetimEntities db = new YonetimEntities())
            {
                int id = Convert.ToInt32(e.CommandArgument);
                db.IKFORMLARs.DeleteObject(db.IKFORMLARs.Where(a => a.ID == id).FirstOrDefault());
                db.SaveChanges();
                FormGetir();
            }
        }
    }
}