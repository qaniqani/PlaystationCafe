using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_Secenekler : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Seçenek Ekle";
           
            KategoriGetir();
            if (Request.QueryString["duzen"] != null)
            {
                KategoriDetayGetir();
            }


            if (Request.QueryString["Id"] != null)
            {
                int kat = 0;
                if (Request.QueryString["duzen"] != null)
                {
                    kat = Convert.ToInt32(Request.QueryString["duzen"].ToString());
                }
                else
                {
                    kat = Convert.ToInt32(Request.QueryString["id"].ToString());
                    if (kat != 0)
                    {
                        lbkat.Text = db.URUNOZELLIKs.FirstOrDefault(a => a.OZELLIKID == kat).OZELLIKBASLIK;
                        KategoriGetir();
                    }
                    else
                    {
                        AnaKategoriGetir();
                        lbkat.Text = "Ana Seçenek";
                    }
                }

            }
            else
            {

                AnaKategoriGetir();
                lbkat.Text = "Ana Seçenek";
            }
        }
    }

    private void KategoriDetayGetir()
    {
        int id = Convert.ToInt32(Request.QueryString["duzen"]);
        URUNOZELLIK k = db.URUNOZELLIKs.FirstOrDefault(a => a.OZELLIKID == id);
        tbad.Text = k.OZELLIKBASLIK;

        if (k.OZELLIKUSTID != 0)
        {
            lbkat.Text = db.URUNOZELLIKs.FirstOrDefault(a => a.OZELLIKID == k.OZELLIKUSTID).OZELLIKBASLIK;
        }
        else
        {
            lbkat.Text = "Ana Seçenek";
        }
       
        if (k.OZELLIKDURUM == true)
        {
            chkAktif.Checked = true;
        }
        else
        {
            chkAktif.Checked = false;
        }

        tbsira.Text = k.OZELLIKSIRA.ToString();


        BtnKaydet.Visible = false;
        BtnUpdate.Visible = true;
    }

   

    private void KategoriGetir()
    {
        int SecenekId = Convert.ToInt32(Request.QueryString["id"]);
        int Dil = Convert.ToInt32(1);
        var Secenekler = from k in db.URUNOZELLIKs where k.OZELLIKUSTID == SecenekId && k.OZELLIKDIL == Dil select k;

        RepaterKategori.DataSource = Secenekler;
        RepaterKategori.DataBind();
        //Literal1.Text = "";
        //foreach (var item in Kategoriler)
        //{
        //    Literal1.Text += "<div><a href='KategoriEkle.aspx?id=" + item.KATID + "' class='list' >" + item.KATADI + "</a><div>";
        //}
    }
    private void AnaKategoriGetir()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        int Dil = Convert.ToInt32(1);
        var secenekler = from k in db.URUNOZELLIKs where k.OZELLIKUSTID == 0 && k.OZELLIKDIL == Dil select k;
        RepaterKategori.DataSource = secenekler;
        RepaterKategori.DataBind();
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbad.Text) != null)
        {
            int kat = 0;
            bool Aktifdurum = false;
            if (Request.QueryString["Id"] != null)
            {
                kat = Convert.ToInt32(Request.QueryString["Id"]);
            }
            if (chkAktif.Checked)
            {
                Aktifdurum = true;
            }
            Genel g = new Genel();


            URUNOZELLIK k = new URUNOZELLIK();
            k.OZELLIKBASLIK = tbad.Text.Trim();

            k.OZELLIKDIL = Convert.ToInt32(1);
            k.OZELLIKDURUM = Aktifdurum;


            k.OZELLIKSIRA = Convert.ToInt32(tbsira.Text);
            k.OZELLIKTARIH = DateTime.Now;


            k.OZELLIKUSTID = kat;
            db.AddToURUNOZELLIKs(k);
            db.SaveChanges();
            KategoriGetir();
            
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Kaydedildi...";
        }
    }
    private string urlKontrol(string url)
    {
        var ur = from x in db.KATEGORIs where x.KATURL == url select x.KATID;
        if (ur.Count() > 0 && ur != null)
        {
            int sayi = ur.Count();
            url += "-" + sayi++;
            urlKontrol(url);
        }
        return url;
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbad.Text) != null)
        {

            int kat = 0;
            bool Aktifdurum = false;
            if (Request.QueryString["duzen"] != null)
            {
                kat = Convert.ToInt32(Request.QueryString["duzen"]);
            }
            if (chkAktif.Checked)
            {
                Aktifdurum = true;
            }
            Genel g = new Genel();

            URUNOZELLIK k = db.URUNOZELLIKs.FirstOrDefault(a => a.OZELLIKID == kat);
            k.OZELLIKBASLIK = tbad.Text.Trim();
            k.OZELLIKDIL = Convert.ToInt32(1);
            k.OZELLIKDURUM = Aktifdurum;
            k.OZELLIKSIRA = Convert.ToInt32(tbsira.Text);
            k.OZELLIKTARIH = DateTime.Now;

            db.SaveChanges();
            KategoriGetir();
            BtnUpdate.Enabled = false;
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Güncellendi...";
           // Response.Redirect("Secenekler.aspx?id=" + Request.QueryString["id"].ToString());
        }
    }
    protected void RepaterKategori_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "s")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            URUNOZELLIK k = db.URUNOZELLIKs.FirstOrDefault(a => a.OZELLIKID == id);
            db.URUNOZELLIKs.DeleteObject(k);
            db.SaveChanges();
            KategoriGetir();
        }
    }
    protected void DrpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        KategoriGetir();
    }
}