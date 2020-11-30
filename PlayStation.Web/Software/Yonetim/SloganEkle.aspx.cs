using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_SloganEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divkaydet.Visible = false;

            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Link Ekle";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = true;
            hpyeni.Text = "Yeni Link";
            hpyeni.NavigateUrl = "SloganEkle.aspx";

            if (Request.QueryString["Sln"] != null)
            {
                BtnKaydet.Visible = false;
                BtnUpdate.Visible = true;
                SloganDetay();
            }
            else
            {
                BtnKaydet.Visible = true;
                BtnUpdate.Visible = false;
            }
            SloganGetir();
        }
    }

    private void SloganDetay()
    {
        int id = Convert.ToInt32(Request.QueryString["Sln"]);
        SLOGAN s = db.SLOGANs.FirstOrDefault(sl => sl.SLOGANID == id);
        tbbaslik.Text = s.SLOGANTEXT;
        tblink.Text = s.SLOGANLINK;
        tbsira.Text = s.SLOGANSIRA.ToString();
        chkdurum.Checked = Convert.ToBoolean(s.SLOGANDURUM);
    }

    private void SloganGetir()
    {
        int dil = Convert.ToInt32(1);
        var sloganlar = db.SLOGANs.Where(d => d.SLOGANDIL == dil).ToList();
        RepeaterUrun.DataSource = sloganlar;
        RepeaterUrun.DataBind();
    }

    protected void BtnKaydet_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(tbbaslik.Text) != true && string.IsNullOrEmpty(tbsira.Text) != true)
        {
            SLOGAN s = new SLOGAN();
            s.SLOGANDURUM = chkdurum.Checked;
            int sira = 999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text);
            }
            catch
            {

            }
            int dil = Convert.ToInt32(1);
            s.SLOGANDIL = dil;
            s.SLOGANSIRA = sira;
            s.SLOGANTARIH = DateTime.Now;
            s.SLOGANLINK = "http://" + tblink.Text.Replace("http://", "");
            s.SLOGANTEXT = tbbaslik.Text;
            db.AddToSLOGANs(s);
            db.SaveChanges();
            SloganGetir();
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Kaydedildi";
            divhata.Visible = false;
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbbaslik.Text) != true && string.IsNullOrEmpty(tbsira.Text) != true)
        {
            int id = Convert.ToInt32(Request.QueryString["Sln"]);
            SLOGAN s = db.SLOGANs.FirstOrDefault(sl => sl.SLOGANID == id);
            s.SLOGANDURUM = chkdurum.Checked;
            int sira = 999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text);
            }
            catch
            {

            }
            int dil = Convert.ToInt32(1);
            s.SLOGANDIL = dil;
            s.SLOGANSIRA = sira;
            s.SLOGANTARIH = DateTime.Now;
            s.SLOGANTEXT = tbbaslik.Text;
            s.SLOGANLINK = "http://" + tblink.Text.Replace("http://", "");
            db.SaveChanges();
            SloganGetir();
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Güncellendi";
            divhata.Visible = false;
        }
    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            SLOGAN sa = db.SLOGANs.FirstOrDefault(s => s.SLOGANID == id);
            db.DeleteObject(sa);
            db.SaveChanges();
            SloganGetir();
            divkaydet.Visible = false;
            divhata.Visible = true;
            lbhatamesaj.Text = "Silindi...";
        }
    }
    protected void drpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        SloganGetir();
    }
}