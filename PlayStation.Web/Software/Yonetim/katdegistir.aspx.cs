using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_katdegistir : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["katid"] != null)
            {

                KategoriGetir(Convert.ToInt32(Request.QueryString["katid"]));
            }
        }
    }
    private void KategoriGetir(int p)
    {
        KATEGORI kat = db.KATEGORIs.FirstOrDefault(k => k.KATID == p);
        int Dil = 1;

        if (kat != null)
        {
            Dil = Convert.ToInt32(kat.KATDIL);
        }

        var Kategoriler = from k in db.KATEGORIs where k.KATUSTID == kat.KATUSTID && k.KATDIL == Dil select k;
        //RepaterKategori.DataSource = Kategoriler;
        //RepaterKategori.DataBind();

        if (Kategoriler.Count() != 0)
        {


            rdkat.Items.Clear();
            foreach (var item in Kategoriler)
            {
                rdkat.Items.Add(new ListItem(item.KATADI, item.KATID.ToString()));
            }

            rdkat.SelectedValue = kat.KATID.ToString();
        }
        else
        {
            //divhata.Visible = true;
            //lbhatamesaj.Text = "Seçili kategorinin alt kategorisi yoktur...";
        }
    }
    protected void Btnileri_Click(object sender, EventArgs e)
    {

        try
        {
            int kat = Convert.ToInt32(rdkat.SelectedItem.Value);
            KategoriGetir(kat);
        }
        catch
        {

        }
    }
    protected void BtnGetir_Click(object sender, EventArgs e)
    {
        try
        {
            int kat = Convert.ToInt32(rdkat.SelectedItem.Value);
            KATEGORI k = db.KATEGORIs.FirstOrDefault(kk => kk.KATID == kat);
            KategoriGetir(Convert.ToInt32(k.KATUSTID));
        }
        catch
        {

        }
    }
    protected void BtnSec_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            if (Request.QueryString["tip"] != null)
            {
                if (Request.QueryString["tip"].ToString() == "1")
                {
                    icerikduzenle(Convert.ToInt32(Request.QueryString["id"]));
                }
                else if (Request.QueryString["tip"].ToString() == "2")
                {
                    urunduzenle(Convert.ToInt32(Request.QueryString["id"]));
                }

            }
        }
    }

    private void urunduzenle(int p)
    {
        if (rdkat.SelectedValue != null)
        {
            URUN i = db.URUNs.FirstOrDefault(ic => ic.URUNID == p);
            if (i != null)
            {
                i.KATID = Convert.ToInt32(rdkat.SelectedValue);
                db.SaveChanges();
            }

        }
    }

    private void icerikduzenle(int p)
    {
        if (rdkat.SelectedValue != null)
        {
            ICERIK i = db.ICERIKs.FirstOrDefault(ic => ic.ICERIKID == p);
            if (i != null)
            {
                i.ICERIKKATID = Convert.ToInt32(rdkat.SelectedValue);
                db.SaveChanges();
            }

        }

    }
}