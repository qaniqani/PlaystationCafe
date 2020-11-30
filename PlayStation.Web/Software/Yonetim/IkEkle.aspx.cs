using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_IkEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "IK Pozisyon Ekle";

            if (Request.QueryString["id"] != null)
            {
                BtnKaydet.Visible = false;
                BtnUpdate.Visible = true;
                HamberDetayGetir();
            }
         
        }
    }
    private void HamberDetayGetir()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        IK hm = db.IKs.FirstOrDefault(a => a.ID == id);
        if (hm != null)
        {
            tbad.Text = hm.BASLIK;
            tbdetay.Text = hm.DETAY;
            tbreferans.Text = hm.KOD;
            tbsira.Text = hm.SIRA.ToString();
            chkAktif.Checked = Convert.ToBoolean(hm.DURUM);
           
        }
    }

   

    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbad.Text) != true && string.IsNullOrEmpty(tbdetay.Text) != true)
        {
            IK hm = new IK();
            hm.BASLIK = tbad.Text;
            hm.DETAY = tbdetay.Text;
            hm.DURUM = chkAktif.Checked;
            hm.KOD = tbreferans.Text;
            hm.DIL = Convert.ToInt32(1);
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text.Trim());
            }
            catch
            {

            }

            hm.SIRA = sira;
            hm.TARIH = DateTime.Now;
            db.AddToIKs(hm);
            db.SaveChanges();
            divkaydet.Visible = true;
            tbad.Text = "";
            tbdetay.Text = "";
            tbsira.Text = "9999";
            chkAktif.Checked = false;

        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbad.Text) != true && string.IsNullOrEmpty(tbdetay.Text) != true)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            IK hm = db.IKs.FirstOrDefault(a => a.ID == id);
            hm.BASLIK = tbad.Text;
            hm.DETAY = tbdetay.Text;
            hm.DURUM = chkAktif.Checked;
            hm.KOD = tbreferans.Text;
            hm.DIL = 1;
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text.Trim());
            }
            catch
            {

            }

            hm.SIRA = sira;

            db.SaveChanges();
            divduzen.Visible = true;
        }
    }
    protected void drptur_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void drpdil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
    }
}