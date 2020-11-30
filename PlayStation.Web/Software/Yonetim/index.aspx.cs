using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class index : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            divhata.Visible = false;
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        string kullanici = username.Value.Trim();
        string sifre = password.Value.Trim();
        ADMIN Ad = db.ADMINs.Where(a => a.ADMINKULLANICI == kullanici && a.ADMINPAROLA == sifre).FirstOrDefault();
        if (Ad != null)
        {
            if (Ad.ADMINKULLANICI == kullanici && sifre == Ad.ADMINPAROLA)
            {
                Session["uyeGiris"] = Ad.ADMINID;
                Session["uyeTarih"] = DateTime.Now;
                if (drpdil.SelectedValue == "1")
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Redirect("eng/Default.aspx");
                }
                
            }
        }
        else
        {
            divhata.Visible = true;
            lbhatamesaj.Text = "Kullanıcı adı veya şifre hatalı...";
        }
    }
}