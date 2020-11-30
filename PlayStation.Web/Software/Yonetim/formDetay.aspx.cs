using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_formDetay : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
        lt.Text = "Form Detay";
        if (Request.QueryString["id"] != null)
        {
            YorumDetayGetir();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            var frm = db.FORMs.FirstOrDefault(f => f.FORMID == id);
            if (frm != null)
            {
                frm.FORMYAYIN = "1";

            }
            db.SaveChanges();
        }
    }

    private void YorumDetayGetir()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        var frm = db.FORMs.FirstOrDefault(f => f.FORMID == id);
        if (frm != null)
        {
            tbadres.Text = frm.FORMADRES;
            TbAdSoyad.Text = frm.FORMADI + " " + frm.FORMSOYADI;
            TbEposta.Text = frm.FORMMAIL;
            //  Tbformtur.Text = frm.FORMTUR;
            TbGsm.Text = frm.FORMGSM;
            tbipadres.Text = frm.FORMIP;
            tbkonu.Text = frm.FORMKONU;
            tbmesaj.Text = frm.FORMMESAJ;
            tbtarih.Text = frm.FORMTARIH.ToString();
            TbTel.Text = frm.FORMTEL;
            tbfirma.Text = frm.FORMFIRMA;
            tbkisitur.Text = frm.FORMKISITUR;
            tbpostakodu.Text = frm.FORMPOSTAKODU;
            tbsehir.Text = frm.FORMSEHIR;





        }

    }
}