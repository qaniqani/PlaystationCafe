using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_urunListesi : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Ürün Listesi";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = true;
            hpyeni.Text = "Yeni Ürün";
            hpyeni.NavigateUrl = "urunEkle.aspx";
            urunGetir();
        }
    }

    private void urunGetir()
    {
        var urunler = db.URUNs.Where(a=>a.URUNDIL==1).OrderBy(u => u.URUNSIRA).ToList();
        //Literal1.Text = "";
        //foreach (var item in urunler)
        //{
        //    //<th>Başlık</th><th>Kategori</th><th>İçerik Url</th><th>Tarih</th><th>Durum</th>
        //    Literal1.Text += "  ";
        //}
        RepeaterUrun.DataSource = urunler;
        RepeaterUrun.DataBind();
    }
    public string kategorigetir(int p)
    {
        string Kategori = "";
        try
        {
            Kategori = db.KATEGORIs.FirstOrDefault(a => a.KATID == p).KATADI;
        }
        catch
        {

        }

        return Kategori;
    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            URUN u = db.URUNs.FirstOrDefault(a => a.URUNID == id);
            db.URUNs.DeleteObject(u);
            db.SaveChanges();
            urunGetir();

        }
    }
}