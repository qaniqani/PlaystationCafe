using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class _Default : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.IcerikCek();
            this.SliderCek();
        }
        Response.Write(Genel.CreateLicence());
    }

    private void IcerikCek()
    {
        int katid = 4;
        ICERIK i = db.ICERIKs.FirstOrDefault(a => a.ICERIKKATID == katid);
        if (i != null)
        {
            Title = i.ICERIKTITLE;
            MetaDescription = i.ICERIKDES;
            MetaKeywords = i.ICERIKKEY;
            ltIcerik.Text = i.ICERIKDETAY;
        }
    }

    private void SliderCek()
    {
        var slider = from x in db.SLIDERs where x.SLIDERTUR == "1" && x.SLIDERDURUM == true select x;
        rptSlid.DataSource = slider;
        rptSlid.DataBind();
    }
}