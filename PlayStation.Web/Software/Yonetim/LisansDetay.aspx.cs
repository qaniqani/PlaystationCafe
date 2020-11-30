using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_LisansDetay : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = -1;
            if (Request.QueryString["gid"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["gid"].ToString());
                this.BtnKaydet.Visible = false;
                this.BtnUpdate.Visible = false;
            }
            else if (Request.QueryString["did"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["did"].ToString());
            }
            else
            {
                Response.Redirect("Lisanslar.aspx", false);
            }

            if (id != -1)
            {
                LISANSLAMALAR l = db.LISANSLAMALARs.FirstOrDefault(a => a.FIRID == id);
                txtAddressDetail.Text = l.FIRADRES;
                txtBoardSerialNR.Text = l.FIRBOARDSERIALNO;
                txtCity.Text = l.FIRIL;
                txtCPUSerialNR.Text = l.FIRCPUSERIALNO;
                txtCustomerName.Text = l.FIRFIRMAADI;
                txtGSM.Text = l.FIRGSMNO;
                txtHDDSerialNR.Text = l.FIRHDDSERIALNO;
                txtLicenceEndDate.Text = l.FIRLISANSBITTARIH.Value.ToShortDateString();
                txtLicenceKey.Text = l.FIRLISANSKEY;
                txtLicenceStartDate.Text = l.FIRLISANSBASTARIH.Value.ToShortDateString();
                txtMail.Text = l.FIREMAIL;
                txtNameSurname.Text = l.FIRADSOYAD;
                txtRegion.Text = l.FIRILCE;
                txtSaveDate.Text = l.FIRKAYITTARIHI.ToString();
                txtTaxNR.Text = l.FIRVERGINO;
                txtTaxOffice.Text = l.FIRVERGIDAIRESI;
                txtTCNr.Text = l.FIRDOGUMTARIHI;
                txtUpdateDayCount.Text = l.FIRGUNCELLEMESIKLIGI.ToString();
                txtUserCount.Text = l.FIRKULLANICISAYISI.ToString();
                cbActive.Checked = Convert.ToBoolean(l.FIRAKTIF);
                cbDemo.Checked = Convert.ToBoolean(l.FIRDEMOMU);
            }
        }
    }

    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(Request.QueryString["did"].ToString());

            LISANSLAMALAR l = db.LISANSLAMALARs.FirstOrDefault(a => a.FIRID == id);

            l.FIRADRES = txtAddressDetail.Text;
            l.FIRADSOYAD = txtNameSurname.Text;
            l.FIRAKTIF = cbActive.Checked;
            l.FIRBOARDSERIALNO = txtBoardSerialNR.Text;
            l.FIRCPUSERIALNO = txtCPUSerialNR.Text;
            l.FIRDEMOMU = cbDemo.Checked;
            l.FIRDOGUMTARIHI = txtTCNr.Text;
            l.FIREMAIL = txtMail.Text;
            l.FIRFIRMAADI = txtCustomerName.Text;
            l.FIRGSMNO = txtGSM.Text;
            l.FIRGUNCELLEMESIKLIGI = txtUpdateDayCount.Text.ToInt32();
            l.FIRHDDSERIALNO = txtHDDSerialNR.Text;
            l.FIRIL = txtCity.Text;
            l.FIRILCE = txtRegion.Text;
            l.FIRKAYITTARIHI = Convert.ToDateTime(txtSaveDate.Text);
            l.FIRKULLANICISAYISI = txtUserCount.Text.ToInt32();
            l.FIRLISANSBASTARIH = Convert.ToDateTime(txtLicenceStartDate.Text);
            l.FIRLISANSBITTARIH = Convert.ToDateTime(txtLicenceEndDate.Text);
            l.FIRLISANSKEY = txtLicenceKey.Text;
            l.FIRVERGIDAIRESI = txtTaxOffice.Text;
            l.FIRVERGINO = txtTaxNR.Text;
            db.SaveChanges();

            divhata.Visible = false;
            divkaydet.Visible = true;
            lbkaydedildi.Text = "Değişiklikler başarıyla kaydedildi.";
        }
        catch (Exception ex)
        {
            divkaydet.Visible = false;
            divhata.Visible = true;
            lbhatamesaj.Text = "Kaydedilme aşamasında bir hata oluştu. Hata kodu: " + ex.Message;
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {

    }
}