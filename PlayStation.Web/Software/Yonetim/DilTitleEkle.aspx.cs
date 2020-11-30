using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_DilTitleEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DilGetir();
            DilKeyGetir();
        }
    }

    private void DilGetir()
    {
        var diller = db.DILs.Where(d => d.Durum == true);
        drpdil.Items.Clear();
        foreach (var item in diller)
        {
            drpdil.Items.Add(new ListItem(item.DILAD, item.DILID.ToString()));
        }
    }
    public string KeyGetir(object o)
    {
        string key = "";
        int dilkeyid = Convert.ToInt32(o);
        int dil = Convert.ToInt32(drpdil.SelectedValue);
        DILTITLE dt = db.DILTITLEs.Where(d => d.DILKEYID == dilkeyid && d.DILID == dil).FirstOrDefault();
        if (dt != null)
            key = dt.DILKEYTITLE;
        else
            key = db.DILKEYs.FirstOrDefault(dk => dk.KEYID == dilkeyid).KEYNAME;
        return key;
    }
    private void DilKeyGetir()
    {
        var dilkeys = db.DILKEYs.ToList();
        RepeaterUrun.DataSource = dilkeys;
        RepeaterUrun.DataBind();
    }
    protected void BtnKaydet_Click1(object sender, EventArgs e)
    {
        db.DilTitleSil(Convert.ToInt32(drpdil.SelectedValue));
        db.SaveChanges();
        for (int i = 0; i < RepeaterUrun.Items.Count; i++)
        {
            //TextBox tb = RepeaterUrun.Items[i].FindControl("tbtitle") as TextBox;
            TextBox tbaaaa = RepeaterUrun.Items[i].FindControl("tbdeneme") as TextBox;
            int keyid = Convert.ToInt32(tbaaaa.ToolTip);
            int dil = Convert.ToInt32(drpdil.SelectedValue);
            DILTITLE dt = new DILTITLE();
            dt.DILID = dil;
            dt.DILKEYID = keyid;
            dt.DILKEYTITLE = tbaaaa.Text;

            db.AddToDILTITLEs(dt);
            db.SaveChanges();


        }
    }
    protected void drpdil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        DilKeyGetir();
    }
}