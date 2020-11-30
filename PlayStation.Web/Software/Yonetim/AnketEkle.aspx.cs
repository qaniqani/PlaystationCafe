using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_AnketEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Anket Ekle";
            
            SoruGetir();
        }
    }

    private void SoruGetir()
    {
        int dil = Convert.ToInt32(1);
        var Sorular = db.ANKETs.Where(a => a.DIL == dil);
        RepeaterSoru.DataSource = Sorular;
        RepeaterSoru.DataBind();
    }
  
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        ANKET a = new ANKET();
        a.ANKETSORU = tbad.Text;
        a.DIL = Convert.ToInt32(1);
        a.DURUM = chkAktif.Checked;
        a.TARIH = DateTime.Now;
        db.AddToANKETs(a);
        db.SaveChanges();
        SoruGetir();

        tbad.Text = "";
        chkAktif.Checked = false;
        divkaydet.Visible = true;
        lbkaydedildi.Text = "Kaydedildi...";
        divhata.Visible = false;
    }
    protected void chkAktif_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void DrpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        SoruGetir();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            int id = Convert.ToInt32(Session["id"]);
            ANKET a = db.ANKETs.Where(an => an.ANKETID == id).FirstOrDefault();
            a.ANKETSORU=tbad.Text;
            a.DURUM = chkAktif.Checked;
            a.DIL = 1;
            a.TARIH = DateTime.Now;
            db.SaveChanges();
            Session["id"] = null;
            SoruGetir();
            tbad.Text = "";
            chkAktif.Checked = false;
            BtnKaydet.Visible = true;
            BtnUpdate.Visible = false;
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Güncellendi...";
            divhata.Visible = false;

        }
    }
    protected void RepaterKategori_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "s")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ANKET ankt = db.ANKETs.FirstOrDefault(an => an.ANKETID == id);
            db.ANKETs.DeleteObject(ankt);
            db.SaveChanges();
            SoruGetir();
            divhata.Visible = true;
            lbhatamesaj.Text = "Silindi...";
            divkaydet.Visible = false;

        }
        else if (e.CommandName == "d")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Session["id"] = id;
            BtnKaydet.Visible = false;
            BtnUpdate.Visible = true;
            var anket = db.ANKETs.Where(an => an.ANKETID == id).FirstOrDefault();
            tbad.Text = anket.ANKETSORU;
            chkAktif.Checked = Convert.ToBoolean(anket.DURUM);
        }
    }
}