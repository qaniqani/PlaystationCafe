using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;


public partial class reklam : System.Web.UI.Page
{
    public static string Reklam = string.Empty;

    YonetimEntities db = new YonetimEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.GetOneAdver();
    }

    private void GetOneAdver()
    {
        REKLAM r = db.REKLAMs.OrderBy(a=> Guid.NewGuid()).FirstOrDefault(a=> a.REKAKTIF == true);
        if (r != null)
        {
            if (r.REKTIPI == "Google")
                Reklam = r.REKKODU;
            else if (r.REKTIPI == "Ozel")
                Reklam = "<a href='" + r.REKLINK + "?guid=" + r.REKGUID + "' title='" + r.REKADI + "' target='_blank' ><img src='/images/" + r.REKYOLU + "' alt='" + r.REKADI + "'/></a>";

            r.REKHIT++;
            db.SaveChanges();
        }
    }
}