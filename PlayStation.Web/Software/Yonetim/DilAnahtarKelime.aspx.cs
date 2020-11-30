using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_DilAnahtarKelime : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Dil Key Ekle";
            BtnDuzen.Visible = false;
            BtnKaydet.Visible = true;
            divhata.Visible = false;
            divkaydet.Visible = false;
            KeyGetir();
        }

    }

    private void KeyGetir()
    {
        var dilkey = db.DILKEYs.ToList();
        RepeaterUrun.DataSource = dilkey;
        RepeaterUrun.DataBind();
    }



    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            DILKEY dk = db.DILKEYs.Where(aa => aa.KEYID == id).FirstOrDefault();
            dk.DURUM = false;
            db.SaveChanges();
            divhata.Visible = true;
            divkaydet.Visible = false;
            lbhatamesaj.Text = "Pasif Edildi...";
            KeyGetir();
        }
        else if (e.CommandName == "Duzen")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            DILKEY dk = db.DILKEYs.Where(aa => aa.KEYID == id).FirstOrDefault();
            TbAd.Text = dk.KEYNAME;
            Session["id"] = dk.KEYID;
            chkaktif.Checked = Convert.ToBoolean(dk.DURUM);
            BtnDuzen.Visible = true;
            BtnKaydet.Visible = false;
        }
    }
    protected void BtnKaydet_Click1(object sender, EventArgs e)
    {
        DILKEY dk = new DILKEY();
        if (string.IsNullOrEmpty(TbAd.Text.Trim()) != true)
        {
            dk.KEYNAME = TbAd.Text;
            dk.DURUM = chkaktif.Checked;
            db.AddToDILKEYs(dk);
            db.SaveChanges();
            KeyGetir();
            BtnKaydet.Visible = true;
            BtnDuzen.Visible = false;
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Kaydedildi...";
            divhata.Visible = false;

        }
    }
    protected void BtnDuzen_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            int id = Convert.ToInt32(Session["id"]);
            DILKEY dk = db.DILKEYs.Where(aa => aa.KEYID == id).FirstOrDefault();
            dk.KEYNAME = TbAd.Text;
            dk.DURUM = chkaktif.Checked;
            db.SaveChanges();
            KeyGetir();
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Düzenlendi...";
            divhata.Visible = false;
            Session["id"] = null;


        }
    }
}