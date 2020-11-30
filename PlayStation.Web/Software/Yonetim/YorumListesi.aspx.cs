using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_YorumListesi : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Yorumlar";
            // DilGetir();
            YorumGetir();

        }
    }
    public string IcerikGetir(object o)
    {
        int id = Convert.ToInt32(o.ToString());
        string baslik = "";
        var icerik = db.ICERIKs.FirstOrDefault(i => i.ICERIKID == id);
        if (icerik != null)
        {
            baslik = icerik.ICERIKBASLIK;

        }
        return baslik;
    }
    private void YorumGetir()
    {
        int tur = Convert.ToInt32(drpYorumTur.SelectedValue);
        var yorumlar = db.YORUMs.Where(y => y.YORUMDURUM == tur && y.YORUMDIL != 0).ToList();
        RepeaterUrun.DataSource = yorumlar;
        RepeaterUrun.DataBind();
        if (yorumlar.Count > 0)
        {
            KontrolEt();
        }
        else
        {
            BtnOnayKaldir.Visible = false;
            BtnOnayla.Visible = false;
        }
    }


    protected void drpdil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;

        YorumGetir();
    }
    protected void drpYorumTur_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;

        YorumGetir();

    }

    private void KontrolEt()
    {
        if (drpYorumTur.SelectedValue == "0")
        {
            BtnOnayla.Visible = true;
            BtnOnayKaldir.Visible = true;
        }
        else if (drpYorumTur.SelectedValue == "1")
        {
            BtnOnayla.Visible = false;
            BtnOnayKaldir.Visible = true;
        }
        else
        {
            BtnOnayla.Visible = true;
            BtnOnayKaldir.Visible = false;
        }
    }
    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            YORUM y = db.YORUMs.FirstOrDefault(a => a.YORUMID == id);
            db.YORUMs.DeleteObject(y);
            db.SaveChanges();
            YorumGetir();
            divhata.Visible = true;
            UYE u = new UYE();

            lbhatamesaj.Text = "Silindi...";
        }
    }
    protected void BtnOnayla_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < RepeaterUrun.Items.Count; i++)
        {
            CheckBox chk1 = RepeaterUrun.Items[i].FindControl("chksec") as CheckBox;
            if (chk1.Checked)
            {
                int id = Convert.ToInt32(chk1.ToolTip);
                YORUM y = db.YORUMs.FirstOrDefault(a => a.YORUMID == id);
                y.YORUMDURUM = 1;
                db.SaveChanges();
            }
        }
        YorumGetir();
    }
    protected void BtnOnayKaldir_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < RepeaterUrun.Items.Count; i++)
        {
            CheckBox chk1 = RepeaterUrun.Items[i].FindControl("chksec") as CheckBox;
            if (chk1.Checked)
            {
                int id = Convert.ToInt32(chk1.ToolTip);
                YORUM y = db.YORUMs.FirstOrDefault(a => a.YORUMID == id);
                y.YORUMDURUM = 2;
                db.SaveChanges();
            }
        }
        YorumGetir();
    }
}