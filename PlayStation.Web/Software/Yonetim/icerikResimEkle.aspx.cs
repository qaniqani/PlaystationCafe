using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;
using System.IO;

public partial class Yonetim_icerikResimEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Hakkımızda Resim Ekle";
            //IcerikGetir();
            FotoGetir();
        }
    }

    //private void IcerikGetir()
    //{
    //    int dil = Convert.ToInt32(1);
    //    var icerikler = (from d in db.ICERIKs where d.ICERIKDIL == dil && d.ICERIKKATID != 23 && d.ICERIKKATID != 3 && d.ICERIKKATID != 22 && d.ICERIKKATID != 5 select d).OrderBy(s => s.ICERIKSIRA);
    //    drpUrun.Items.Clear();
    //    foreach (var item in icerikler)
    //    {
    //        drpUrun.Items.Add(new ListItem(item.ICERIKBASLIK, item.ICERIKID.ToString()));
    //    }
    //    drpUrun.Items.Insert(0, new ListItem("Seçiniz", "0"));
    //}


    protected void RepeaterUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ICERIKRESIM u = db.ICERIKRESIMs.FirstOrDefault(b => b.RESID == id);
            try
            {
                File.Delete(MapPath("~/images/Icerik/" + u.RESIM));
            }
            catch
            {
            }
            db.ICERIKRESIMs.DeleteObject(u);
            db.SaveChanges();
            FotoGetir();
            divhata.Visible = true;
            divkaydet.Visible = false;
            lbhatamesaj.Text = "Silindi...";
        }
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (FileUploadResim.HasFile)
        {
            Genel g = new Genel();
            string a = g.FotoIslemi(FileUploadResim, "~/images/sahte", "~/images/Icerik/", 1000);
            ICERIKRESIM u = new ICERIKRESIM();
            u.DURUM = true;
            u.RESIM = a;
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text);
            }
            catch
            {
            }
            u.SIRA = sira;
            u.TARIH = DateTime.Now;
            ICERIK i = db.ICERIKs.FirstOrDefault(x => x.ICERIKKATID == 2);
            u.ICERIKID = i.ICERIKID;
            u.TEMSIL = chktemsili.Checked;
            db.AddToICERIKRESIMs(u);
            db.SaveChanges();
            FotoGetir();
            tbsira.Text = "9999";
            divkaydet.Visible = true;
            divhata.Visible = false;
            lbkaydedildi.Text = "Kaydedildi...";
        }
        else
        {
            divhata.Visible = true;
            lbhatamesaj.Text = "Lütfen resim seçiniz...";
        }
    }
    protected void drpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        //IcerikGetir();
        FotoGetir();
    }
    protected void drpUrun_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        FotoGetir();
    }

    private void FotoGetir()
    {
        //int icerikid = Convert.ToInt32(drpUrun.SelectedValue);
        ICERIK ic = db.ICERIKs.FirstOrDefault(x => x.ICERIKKATID == 2);
        if (ic != null)
        {
            var icerikler = from d in db.ICERIKRESIMs where d.ICERIKID == ic.ICERIKID orderby (d.SIRA) select d;
            RepeaterUrun.DataSource = icerikler;
            RepeaterUrun.DataBind();
        }
    }
}