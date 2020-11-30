using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_AnketSoruEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Anket Soru Ekle";
          
            SoruGetir();
            CevapGetir();
        }
    }

    private void CevapGetir()
    {
        int anketid = Convert.ToInt32(DrpSoru.SelectedValue);
        var cevaplar = db.ANKETCEVAPs.Where(cvp => cvp.CEVAPSORUID == anketid);
        RepeaterSoru.DataSource = cevaplar;
        RepeaterSoru.DataBind();
    }

    private void SoruGetir()
    {
        int dil = Convert.ToInt32(1);
        var anketler = db.ANKETs.Where(ank => ank.DIL == dil);
        foreach (var item in anketler)
        {
            DrpSoru.Items.Add(new ListItem(item.ANKETSORU, item.ANKETID.ToString()));
        }
    }

  
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        ANKETCEVAP ac = new ANKETCEVAP();
        int cevap = 0;
        try
        {
            cevap = Convert.ToInt32(tbcevapsayi.Text);
        }
        catch
        {
        }
        int sira = 0;
        try
        {
            sira = Convert.ToInt32(tbsira.Text);
        }
        catch
        {
        }
        ac.CEVAPSAY = cevap;
        ac.CEVAP = tbad.Text;
        ac.CEVAPSIRA = sira;
        ac.CEVAPSORUID = Convert.ToInt32(DrpSoru.SelectedValue);
        ac.DURUM = chkAktif.Checked;
        ac.TARIH = DateTime.Now;
       
        db.AddToANKETCEVAPs(ac);
        db.SaveChanges();
        CevapGetir();
        divkaydet.Visible = true;
        lbkaydedildi.Text = "Kaydedildi...";
        divhata.Visible = false;
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            int id = Convert.ToInt32(Session["id"]);
            ANKETCEVAP ac = db.ANKETCEVAPs.Where(an => an.CEVAPID == id).FirstOrDefault();
            int cevap = 0;
            try
            {
                cevap = Convert.ToInt32(tbcevapsayi.Text);
            }
            catch
            {
            }
            int sira = 0;
            try
            {
                sira = Convert.ToInt32(tbsira.Text);
            }
            catch
            {
            }

            ac.CEVAPSAY = cevap;
            ac.CEVAPSIRA = sira;
            ac.CEVAP = tbad.Text;
            ac.DURUM = chkAktif.Checked;
            db.SaveChanges();
            CevapGetir();
            Session["id"] = null;
            BtnKaydet.Visible = true;
            BtnUpdate.Visible = false;
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Güncellendi...";
            divhata.Visible = false;
        }

    }
    protected void DrpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        SoruGetir();
        CevapGetir();
    }
    protected void RepaterKategori_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "s")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            db.DeleteObject(db.ANKETCEVAPs.Where(aa => aa.CEVAPID == id).FirstOrDefault());
            db.SaveChanges();
            divhata.Visible = true;
            divkaydet.Visible = false;
            lbhatamesaj.Text = "Silindi...";
            CevapGetir();
        }
        else if (e.CommandName == "d")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ANKETCEVAP ac = db.ANKETCEVAPs.Where(aa => aa.CEVAPID == id).FirstOrDefault();
            tbad.Text = ac.CEVAP;
            tbcevapsayi.Text = ac.CEVAPSAY.ToString();
            tbsira.Text = ac.CEVAPSIRA.ToString();
            chkAktif.Checked = Convert.ToBoolean(ac.DURUM);
            BtnUpdate.Visible = true;
            BtnKaydet.Visible = false;
            Session["id"] = id;
        }
    }
    protected void tbsira_TextChanged(object sender, EventArgs e)
    {

    }
}