using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class iletisim : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string url = "iletisim-bilgileri";
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
            Title = ic.ICERIKTITLE;
            MetaDescription = ic.ICERIKDES;
            MetaKeywords = ic.ICERIKKEY;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtDetail.Text) &&
            !string.IsNullOrEmpty(txtGSMNo.Text) &&
            !string.IsNullOrEmpty(txtSubject.Text) &&
            !string.IsNullOrEmpty(txtUserName.Text))
        {
            FORM f = new FORM();
            f.FORMKONU = txtSubject.Text.Trim();
            f.FORMGSM = txtGSMNo.Text.Trim();
            f.FORMMESAJ = txtDetail.Text.Trim();
            f.FORMADI = txtUserName.Text.Trim();
            f.FORMYAYIN = "0";
            f.FORMIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            f.FORMTARIH = DateTime.Now;
            f.FORMTUR = "2";
            db.AddToFORMs(f);
            db.SaveChanges();

            txtDetail.Text = "";
            txtGSMNo.Text = "";
            txtSubject.Text = "";
            txtUserName.Text = "";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Formunuz başarıyla iletilmiştir. En kısa sürede sizinle irtibata geçilecektir.' );</script>", false);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Lütfen tüm alanları doldurunuz.' );</script>", false);
        }
    }
}