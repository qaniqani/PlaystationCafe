using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_ReklamListesi : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.GetAllAdver();
    }

    private void GetAllAdver()
    {
        var all = from x in db.REKLAMs select x;
        Repeatericerik.DataSource = all;
        Repeatericerik.DataBind();
    }
    protected void Repeatericerik_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}