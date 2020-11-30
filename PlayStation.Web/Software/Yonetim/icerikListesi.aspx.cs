using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_icerikListesi : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "İçerik Listesi";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = true;
            hpyeni.Text = "Yeni İçerik";
            hpyeni.NavigateUrl = "icerikEkle.aspx";
            IcerikGetir();
        }

    }

    private void IcerikGetir()
    {
        // from k in db.KATEGORIs where k.KATUSTID == katID && k.KATDIL == Dil select k;
        var icerikler = from i in db.ICERIKs where i.ICERIKDIL == 1 && i.ICERIKKATID != 23 && i.ICERIKKATID != 3 && i.ICERIKKATID != 22 && i.ICERIKKATID != 5 orderby (i.ICERIKSIRA) select i;
        Repeatericerik.DataSource = icerikler;
        Repeatericerik.DataBind();
    }

    public string kategorigetir(int p)
    {
        string Kategori = "";
        try
        {
            Kategori = db.KATEGORIs.FirstOrDefault(a => a.KATID == p ).KATADI;
        }
        catch
        {
            Kategori = "Silinmiş";
        }
        return Kategori;
    }
    protected void Repeatericerik_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "s")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            db.ICERIKs.DeleteObject(db.ICERIKs.Where(i => i.ICERIKID == id).FirstOrDefault());
            db.SaveChanges();
            IcerikGetir();

        }
    }
}