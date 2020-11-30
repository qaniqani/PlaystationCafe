using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class FirmaKaydi : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string url = "firma-kaydi-ve-download";
            this.IcerikCek(url);
        }
    }

    private void IcerikCek(string URL)
    {
        ICERIK ic = db.ICERIKs.FirstOrDefault(a => a.ICERIKURL == URL && a.ICERIKDURUM == true);
        if (ic != null)
        {
            ltAltBaslik.Text = ic.ICERIKBASLIK;
            ltBaslik.Text = ic.ICERIKBASLIK;
            ltIcerik.Text = ic.ICERIKDETAY;
            Title = ic.ICERIKTITLE;
            MetaDescription = ic.ICERIKDES;
            MetaKeywords = ic.ICERIKKEY;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtTCNR.Text.Trim()) &&
            !string.IsNullOrEmpty(txtCity.Text.Trim()) &&
            !string.IsNullOrEmpty(txtCustomerName.Text.Trim()) &&
            !string.IsNullOrEmpty(txtEmail.Text.Trim()) &&
            !string.IsNullOrEmpty(txtGsmNo.Text.Trim()) &&
            !string.IsNullOrEmpty(txtName.Text.Trim()) &&
            !string.IsNullOrEmpty(txtRegion.Text.Trim()))
        {
            string licencekey = Genel.CreateLicence();

            LISANSLAMALAR l = new LISANSLAMALAR();
            l.FIRADRES = txtAddress.Text.Trim();
            l.FIRADSOYAD = txtName.Text.Trim();
            l.FIRAKTIF = true;
            l.FIRDEMOMU = true;
            l.FIRDOGUMTARIHI = txtTCNR.Text.Trim();
            l.FIREMAIL = txtEmail.Text.Trim();
            l.FIRFIRMAADI = txtCustomerName.Text.Trim();
            l.FIRGSMNO = txtGsmNo.Text.Trim();
            l.FIRGUNCELLEMESIKLIGI = 15;
            l.FIRIL = txtCity.Text.Trim();
            l.FIRILCE = txtRegion.Text.Trim();
            l.FIRKAYITTARIHI = DateTime.Now;
            l.FIRKULLANICISAYISI = 1;
            l.FIRLISANSBASTARIH = DateTime.Now;
            l.FIRLISANSBITTARIH = DateTime.Now.AddMonths(1);
            l.FIRLISANSKEY = licencekey;
            l.FIRVERGIDAIRESI = txtTaxOffice.Text.Trim();
            l.FIRVERGINO = txtTaxNR.Text.Trim();

            db.AddToLISANSLAMALARs(l);
            db.SaveChanges();

            string HTMLMail = "Yetkili: <strong>" + txtName.Text.Trim() + "</strong><br />";
            HTMLMail = "Kayıt Tarihi: <strong>" + string.Format("{0:dd MMMM yyyy - HH:mm:ss}", DateTime.Now) + "</strong><br />";
            HTMLMail = "Lisans Key: <strong>" + licencekey + "</strong><br />";
            HTMLMail = "Program Adı: <strong>Console Plus</strong><br />";
            HTMLMail = "Site Adresi: <strong>http://www.nvisionsoft.net</strong><br /><br /><br />Destek için bizimle irtibata geçiniz.";

            Genel.MailKullanicilaraGonder(txtEmail.Text.Trim(), HTMLMail, "Console Plus Lisans Bilgileri");

            ltLicenceKey.Text = licencekey;

            pnlError.Visible = false;
            pnlFirmSave.Visible = false;
            pnlSuccess.Visible = true;
        }
        else
        {
            pnlError.Visible = true;
            pnlFirmSave.Visible = true;
            pnlSuccess.Visible = false;

            ltError.Text = "Lütfen zorunlu alanların tümünü doldurunuz.";
        }
    }
}