using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_reklam : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    Genel g = new Genel();

    protected void Page_Load(object sender, EventArgs e)
    {
        Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
        lt.Text = "Reklamlar";
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                REKLAM r = db.REKLAMs.FirstOrDefault(a => a.REKID == id);
                ddlAdverType.SelectedValue = r.REKTIPI;
                txtAdverCode.Text = r.REKKODU;
                txtAdverGuid.Text = r.REKGUID;
                txtAdverName.Text = r.REKADI;
                txtAdverLink.Text = r.REKYOLU;
                ltLnk.Text = "<a href='/images/" + r.REKYOLU + "' target='_blank'>Reklam Yolu</a>";
            }
            else
                txtAdverGuid.Text = Guid.NewGuid().ToString();
        }
    }

    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtAdverGuid.Text) && !string.IsNullOrEmpty(txtAdverName.Text))
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                REKLAM r = db.REKLAMs.FirstOrDefault(a => a.REKID == id);
                r.REKADI = txtAdverName.Text.Trim();
                r.REKAKTIF = cbActive.Checked;
                r.REKGUID = txtAdverGuid.Text.Trim();
                r.REKKODU = txtAdverCode.Text.Trim();
                r.REKTIPI = ddlAdverType.SelectedValue;
                r.REKLINK = txtAdverLink.Text.Trim();

                if (txtAdverUpload.HasFile)
                {
                    string filename = g.StringSayiEkle(txtAdverUpload.FileName);
                    txtAdverUpload.SaveAs(Server.MapPath("~/images/" + filename));
                    r.REKYOLU = filename;
                }
                db.SaveChanges();
                Response.Redirect("ReklamListesi.aspx", false);
            }
            else
            {
                REKLAM r = new REKLAM();
                r.REKADI = txtAdverName.Text.Trim();
                r.REKAKTIF = cbActive.Checked;
                r.REKGUID = txtAdverGuid.Text.Trim();
                r.REKHIT = 0;
                r.REKKODU = txtAdverCode.Text.Trim();
                r.REKTIK = 0;
                r.REKTIPI = ddlAdverType.SelectedValue;
                r.REKLINK = txtAdverLink.Text.Trim();

                if (txtAdverUpload.HasFile)
                {
                    string filename = g.StringSayiEkle(txtAdverUpload.FileName);
                    txtAdverUpload.SaveAs(Server.MapPath("~/images/" + filename));
                    r.REKYOLU = filename;
                }

                db.AddToREKLAMs(r);
                db.SaveChanges();
            }

            txtAdverCode.Text = "";
            txtAdverGuid.Text = Guid.NewGuid().ToString();
            txtAdverName.Text = "";
            ddlAdverType.SelectedIndex = 0;
            cbActive.Checked = true;
        }
    }
}