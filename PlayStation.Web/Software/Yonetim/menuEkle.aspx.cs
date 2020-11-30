using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;
using System.Web.UI.HtmlControls;

public partial class Yonetim_menuEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Menü Ekle";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = true;
            hpyeni.Text = "Yeni Menü";
            hpyeni.NavigateUrl = "menuEkle.aspx";
            KategoriGetir(4);
            lbhatamesaj.Text = "Lütfen sağ taraftan kategori seçiniz.";
            divhata.Visible = true;
            TblIcerik.Visible = false;
            if (Request.QueryString["id"] != null)
            {
                divicerik.Visible = true;
                lt.Text = "Menü Düzenle";
                BtnKaydet.Visible = false;
                BtnUpdate.Visible = true;
                icerikGetir(Convert.ToInt32(Request.QueryString["id"]));
                hrfkat.Visible = true;
            }
            else
                hrfkat.Visible = false;
        }
    }

    private void icerikGetir(int p)
    {
        divicerik.Attributes.Add("class", "g12");
        int kat = Convert.ToInt32(Request.QueryString["id"]);
        divhata.Visible = false;
        TblIcerik.Visible = true;
        divkategori.Visible = false;
        ICERIK i = db.ICERIKs.FirstOrDefault(x => x.ICERIKID == p);
        try
        {
            lbkat.Text = db.KATEGORIs.FirstOrDefault(a => a.KATID == i.ICERIKKATID).KATADI;
        }
        catch
        {
            lbkat.Text = "Silinmiş";
        }
        HtmlGenericControl b = Master.FindControl("body") as HtmlGenericControl;
        b.Attributes.Add("onunload", "opener.location=('" + HttpContext.Current.Request.Url.ToString() + "')");

        // hrfkat.HRef = HttpContext.Current.Request.Url.ToString();
        hrfkat.Attributes.Add("onclick", "return popitup('katdegistir.aspx?tip=1&id=" + i.ICERIKID + "&katid=" + i.ICERIKKATID + "'); ");
        tbad.Text = i.ICERIKBASLIK;
        tbdess.Text = i.ICERIKDES;
        tbkey.Text = i.ICERIKKEY;
        TbAciklama.Text = i.ICERIKOZET;
        tbsira.Text = i.ICERIKSIRA.ToString();
        tbtitle.Text = i.ICERIKTITLE;
        chkAktif.Checked = Convert.ToBoolean(i.ICERIKDURUM);
        CKEditorControl1.Text = i.ICERIKDETAY;
        try
        {
            imgsrc.Src = "../PhotoResize.aspx?Tur=Fix&genislik=100&yukseklik=100&src=images/Icerik/" + i.ICERIKRESIM;
            lbres.Text = i.ICERIKRESIM;
        }
        catch
        {
        }
      
    }
    private void KategoriGetir(int p)
    {
        int Dil = Convert.ToInt32(1);
        var Kategoriler = from k in db.KATEGORIs where k.KATUSTID == p &&  k.KATDIL == Dil  select k;
        //RepaterKategori.DataSource = Kategoriler;
        //RepaterKategori.DataBind();
        if (Kategoriler.Count() != 0)
        {
            rdkat.Items.Clear();
            foreach (var item in Kategoriler)
            {
                rdkat.Items.Add(new ListItem(item.KATADI, item.KATID.ToString()));
            }
        }
        else
        {
            divhata.Visible = true;
            lbhatamesaj.Text = "Seçili kategorinin alt kategorisi yoktur...";
        }
    }
    private void icerikDuzenle()
    {
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbad.Text.Trim()) != true && string.IsNullOrEmpty(CKEditorControl1.Text.Trim()) != true)
        {
            string a = "";
            if (FileUploadResim.HasFile)
            {
                Genel g = new Genel();
                 a = g.FotoIslemi(FileUploadResim, "~/images/sahte", "~/images/Icerik/", 1000);
            }
            int kat = Convert.ToInt32(rdkat.SelectedValue);
            bool Aktifdurum = false;
            if (chkAktif.Checked)
            {
                Aktifdurum = true;
            }
       
            ICERIK ic = new ICERIK();
            ic.ICERIKBASLIK = tbad.Text.Trim();
            ic.ICERIKDES = tbdess.Text.Trim();
            ic.ICERIKDIL = Convert.ToInt32(1);
            ic.ICERIKDURUM = Aktifdurum;
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text.Trim());
            }
            catch
            {
            }
            ic.ICERIKRESIM=a;
            ic.ICERIKOZET = TbAciklama.Text.Trim();
            ic.ICERIKKEY = tbkey.Text.Trim();
            ic.ICERIKTITLE = tbtitle.Text.Trim();
            ic.ICERIKSIRA = sira;
            ic.ICERIKDETAY = CKEditorControl1.Text;
            ic.ICERIKTARIH = DateTime.Now;
            ic.ICERIKURL = urlKontrol(Genel.UrlSeo(tbad.Text.Trim()));
            ic.ICERIKKATID = kat;
            ic.ICERIKOKUNDU = 0;
            db.AddToICERIKs(ic);
            db.SaveChanges();
            KategoriGetir(4);
            lbkaydedildi.Text = "Kaydedildi...";
            divkaydet.Visible = true;
            tbad.Text = "";
            tbdess.Text = "";
            tbkey.Text = "";
            tbsira.Text = "";
            tbtitle.Text = "";
            CKEditorControl1.Text = "";
        }
    }

    private string urlKontrol(string url)
    {
        var ur = from x in db.ICERIKs where x.ICERIKURL == url select x.ICERIKID;
        if (ur.Count() > 0 && ur != null)
        {
            int sayi = ur.Count();
            url += "-" + sayi++;
            urlKontrol(url);
        }
        return url;
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbad.Text.Trim()) != true && string.IsNullOrEmpty(CKEditorControl1.Text.Trim()) != true)
        {
            string a = "";
            if (FileUploadResim.HasFile)
            {
                Genel g = new Genel();
                a = g.FotoIslemi(FileUploadResim, "~/images/sahte", "~/images/Icerik/", 1000);
            }
            int id = Convert.ToInt32(Request.QueryString["id"]);
            bool Aktifdurum = false;
            if (chkAktif.Checked)
            {
                Aktifdurum = true;
            }
            ICERIK ic = db.ICERIKs.FirstOrDefault(x => x.ICERIKID == id);
            ic.ICERIKBASLIK = tbad.Text.Trim();
            ic.ICERIKDES = tbdess.Text.Trim();
            ic.ICERIKDIL = Convert.ToInt32(1);
            ic.ICERIKDURUM = Aktifdurum;
            ic.ICERIKRESIM = a;
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text.Trim());
            }
            catch
            {
            }
            ic.ICERIKOZET = TbAciklama.Text.Trim();
            ic.ICERIKKEY = tbkey.Text.Trim();
            ic.ICERIKTITLE = tbtitle.Text.Trim();
            ic.ICERIKSIRA = sira;
            ic.ICERIKDETAY = CKEditorControl1.Text;
            ic.ICERIKTARIH = DateTime.Now;
            //ic.ICERIKURL = urlKontrol(Genel.UrlSeo(tbad.Text.Trim()));
            db.SaveChanges();
            KategoriGetir(4);
            lbkaydedildi.Text = "Kaydedildi...";
            divkaydet.Visible = true;

            //chkAktif.Checked = false;
            //BtnUpdate.Enabled = false;
        }
    }
    protected void Btnileri_Click(object sender, EventArgs e)
    {
        try
        {
            int kat = Convert.ToInt32(rdkat.SelectedItem.Value);
            KategoriGetir(kat);
        }
        catch
        {
            divhata.Visible = true;
            lbhatamesaj.Text = "Lütfen kategori seçiniz";
        }
    }
    protected void BtnSec_Click(object sender, EventArgs e)
    {
        if (rdkat.SelectedItem != null)
        {
            divicerik.Visible = true;
            int kat = Convert.ToInt32(rdkat.SelectedItem.Value);
            divhata.Visible = false;
            TblIcerik.Visible = true;
            lbkat.Text = db.KATEGORIs.FirstOrDefault(a => a.KATID == kat).KATADI;
            divkategori.Visible = false;
        }
        else
        {
            divhata.Visible = true;
            lbhatamesaj.Text = "Lütfen kategori seçiniz";
        }
    }
    protected void chkAktif_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void DrpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        KategoriGetir(4);
        divhata.Visible = false;
        divkaydet.Visible = false;
    }
}