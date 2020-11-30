using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class IcerikDetaylar : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (RouteData.Values["IcURL"] != null)
        {
            string url = RouteData.Values["IcURL"].ToString();
            this.IcerikCek(url);
        }
    }

    private void IcerikCek(string URL)
    {
        ICERIK ic = db.ICERIKs.FirstOrDefault(a => a.ICERIKURL == URL && a.ICERIKDURUM == true);
        if (ic != null)
        {
            ltAltBaslik.Text = ic.ICERIKBASLIK;
            ltBaslik.Text = ic.ICERIKBASLIK;
            ltIcerikler.Text = ic.ICERIKDETAY;
            Title = ic.ICERIKTITLE;
            MetaDescription = ic.ICERIKDES;
            MetaKeywords = ic.ICERIKKEY;
        }
    }
}