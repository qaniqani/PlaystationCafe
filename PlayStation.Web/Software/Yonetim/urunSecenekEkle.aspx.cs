using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;
using System.Collections;

public partial class Yonetim_urunSecenekEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Ürün Seçenek Ekle";
            UrunGetir();
            AnaSecenekGetir();
            if (Request.QueryString["urunid"] != null)
            {
                tblsecenekler.Visible = true;
                urundetaygetir();
                KontrolEt();
            }
            else
            {
                tblsecenekler.Visible = false;
            }
        }
    }

    private void urundetaygetir()
    {
        int urunId = Convert.ToInt32(Request.QueryString["urunid"]);
        URUN u = db.URUNs.FirstOrDefault(ur => ur.URUNID == urunId);
        if (u != null)
        {
            ltrurun.Text = u.URUNADI;
        }
    }

    private void KontrolEt()
    {
        int urunId = Convert.ToInt32(Request.QueryString["urunid"]);
        for (int i = 0; i < RepeaterSecenekler.Items.Count; i++)
        {
            CheckBoxList rdl = RepeaterSecenekler.Items[i].FindControl("ChkList") as CheckBoxList;
            foreach (ListItem item in rdl.Items)
            {
                item.Selected = OzellikVarmi(urunId, Convert.ToInt32(item.Value));
            }
        }
    }
    private bool OzellikVarmi(int urunid, int ozellikid)
    {
        bool varmi = false;
        URUNOZELLIKILISKI uoi = new URUNOZELLIKILISKI();
        var a = (from i in db.URUNOZELLIKILISKIs where i.OZELLIKID == ozellikid && i.URUNID == urunid select i).FirstOrDefault();
        if (a != null)
        {
            varmi = true;
        }
        return varmi;
    }

    private void UrunGetir()
    {

        var urunler = from u in db.URUNs where u.URUNDURUM == true && u.URUNDIL == 1 select u;
        RepeaterUrun.DataSource = urunler;
        RepeaterUrun.DataBind();
    }



    private void AnaSecenekGetir()
    {
        RepeaterSecenekler.DataSource = AltSecenekGetir(0);
        RepeaterSecenekler.DataBind();
    }

    public List<URUNOZELLIK> AltSecenekGetir(object o)
    {

        ArrayList liste = new ArrayList();
        int id = Convert.ToInt32(o.ToString());
        int dil = 1;
        var a = from k in db.URUNOZELLIKs where k.OZELLIKUSTID == id && k.OZELLIKDIL == dil select k;
        return a.ToList();

    }
    protected void drpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        AnaSecenekGetir();
    }

    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["urunid"] != null)
        {
            int urunId = Convert.ToInt32(Request.QueryString["urunid"]);
            db.sp_UrunOzellikSil(urunId);
            db.SaveChanges();
            for (int i = 0; i < RepeaterSecenekler.Items.Count; i++)
            {
                CheckBoxList rdl = RepeaterSecenekler.Items[i].FindControl("ChkList") as CheckBoxList;
                foreach (ListItem item in rdl.Items)
                {
                    if (item.Selected == true)
                    {

                        URUNOZELLIKILISKI uo = new URUNOZELLIKILISKI();
                        uo.OZELLIKID = Convert.ToInt32(item.Value);
                        uo.URUNID = urunId;
                        uo.TARIH = DateTime.Now;
                        db.AddToURUNOZELLIKILISKIs(uo);
                        db.SaveChanges();
                    }
                }
            }
            divkaydet.Visible = true;
            divhata.Visible = false;
            lbkaydedildi.Text = "Kaydedildi...";
        }
        else
        {
            divkaydet.Visible = false;
            divhata.Visible = true;
            lbhatamesaj.Text = "Lütfen ürün seçiniz";
        }

    }
    protected void RepeaterUrun_Init(object sender, EventArgs e)
    {

    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}