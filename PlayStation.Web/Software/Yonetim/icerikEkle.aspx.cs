using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;
using System.Web.UI.HtmlControls;

public partial class Yonetim_icerikEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "İçerik Ekle";
            HyperLink hpyeni = Master.FindControl("hpyeni") as HyperLink;
            hpyeni.Visible = false;
            hpyeni.Text = "Yeni İçerik";
            hpyeni.NavigateUrl = "icerikEkle.aspx";
            KategoriGetir(0);
            // lbhatamesaj.Text = "Lütfen sağ taraftan kategori seçiniz.";
            // divhata.Visible = true;
            TblIcerik.Visible = false;
            if (Request.QueryString["id"] != null)
            {
                int icerikid = Convert.ToInt32(Request.QueryString["id"]);
                divicerik.Visible = true;
                lt.Text = "İçerik Düzenle";
                BtnKaydet.Visible = false;
                BtnUpdate.Visible = true;
                icerikGetir(icerikid);
                hrfkat.Visible = true;
            }
            else
                hrfkat.Visible = false;
        }
    }

    private void icerikGetir(int p)
    {
        divicerik.Attributes.Add("class", "g12");
        int kat = p;
        divhata.Visible = false;
        TblIcerik.Visible = true;
        divkategori.Visible = true;
        ICERIK i = db.ICERIKs.FirstOrDefault(x => x.ICERIKID == p);
        if (i != null)
        {
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
            trres.Visible = false;
            try
            {
                imgsrc.Src = "../PhotoResize.aspx?Tur=Fix&genislik=100&yukseklik=100&src=images/Icerik/" + i.ICERIKRESIM;
            }
            catch
            {
            }
            lbres.Text = i.ICERIKRESIM;
            CKEditorControl1.Text = i.ICERIKDETAY;
        }
    }
    private void KategoriGetir(int p)
    {
        int Dil = Convert.ToInt32(1);
        var Kategoriler = from k in db.KATEGORIs where k.KATUSTID == p && k.KATDIL == Dil select k;
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
            int kat = Convert.ToInt32(rdkat.SelectedValue);
            bool Aktifdurum = false;
            if (chkAktif.Checked)
            {
                Aktifdurum = true;
            }
            Genel g = new Genel();
            ICERIK ic = new ICERIK();
            ic.ICERIKBASLIK = tbad.Text.Trim();
            ic.ICERIKDES = tbdess.Text.Trim();
            ic.ICERIKDIL = Convert.ToInt32(1);
            ic.ICERIKDURUM = Aktifdurum;
            #region 
            //string resim = "";
            //if (FileUploadImg.HasFile)
            //{
            //    resim = g.FotoIslemi(FileUploadImg, "../images/sahte", "../images/Icerik/", 1000);
            //    ic.ICERIKRESIM = resim;
            //}
            //int sira = 9999;
            //try
            //{
            //    sira = Convert.ToInt32(tbsira.Text.Trim());
            //}
            //catch
            //{
            //}
            //string dosya = "";
            //if (FileUpload.HasFile)
            //{
            //    string gec1 = FileUpload.PostedFile.FileName;
            //    string deneme = System.IO.Path.GetExtension(gec1);
            //    dosya = Genel.UrlSeo(gec1.Replace(deneme, "")); ;
            //    int sayi1 = 1;
            //    for (int i = 0; i < sayi1; i++)
            //    {
            //        if (System.IO.File.Exists(Server.MapPath("../images/Dosya") + "\\" + dosya) == true)
            //        {
            //            string a = dosya.Replace(deneme, "");
            //            dosya = a + "(" + sayi1.ToString() + ")";
            //            sayi1++;
            //        }
            //    }
            //    dosya += deneme;
            //    FileUpload.PostedFile.SaveAs(Server.MapPath("../images/Dosya") + "/" + dosya);
            //    ic.ICERIKDOSYA = dosya;
            //}
            //else
            //{
            //    ic.ICERIKDOSYA = "";
            //}
            #endregion
            int sira = 9999;
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
            //KategoriGetir(0);
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
            int id = Convert.ToInt32(Request.QueryString["id"]);
            bool Aktifdurum = false;
            if (chkAktif.Checked)
            {
                Aktifdurum = true;
            }
            Genel g = new Genel();
            ICERIK ic = db.ICERIKs.FirstOrDefault(x => x.ICERIKID == id);

            //ICERIK ic = db.ICERIKs.FirstOrDefault(x => x.ICERIKKATID == 2);
            if (ic!= null)
            {
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
                ic.ICERIKOZET = TbAciklama.Text.Trim();
                ic.ICERIKKEY = tbkey.Text.Trim();
                ic.ICERIKTITLE = tbtitle.Text.Trim();
                ic.ICERIKSIRA = sira;
                ic.ICERIKDETAY = CKEditorControl1.Text;
                ic.ICERIKTARIH = DateTime.Now;
                //ic.ICERIKURL = urlKontrol(Genel.UrlSeo(tbad.Text.Trim()));
                db.SaveChanges();
                lbkaydedildi.Text = "Kaydedildi...";
                divkaydet.Visible = true;
                icerikGetir(id);
            }
            else
            {
                ic = new ICERIK();
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
                ic.ICERIKOZET = TbAciklama.Text.Trim();
                ic.ICERIKKEY = tbkey.Text.Trim();
                ic.ICERIKTITLE = tbtitle.Text.Trim();
                ic.ICERIKSIRA = sira;
                ic.ICERIKDETAY = CKEditorControl1.Text;
                ic.ICERIKTARIH = DateTime.Now;
                ic.ICERIKKATID = 2;
                ic.ICERIKURL = urlKontrol(Genel.UrlSeo(tbad.Text.Trim()));
                db.AddToICERIKs(ic);
                db.SaveChanges();
                lbkaydedildi.Text = "Kaydedildi...";
                divkaydet.Visible = true;
                icerikGetir(id);
            }


            //string dosya = "";
            //if (FileUpload.HasFile)
            //{
            //    string gec1 = FileUpload.PostedFile.FileName;
            //    string deneme = System.IO.Path.GetExtension(gec1);
            //    dosya = Genel.UrlSeo(gec1.Replace(deneme, "")); ;
            //    int sayi1 = 1;
            //    for (int i = 0; i < sayi1; i++)
            //    {
            //        if (System.IO.File.Exists(Server.MapPath("../images/Dosya") + "\\" + dosya) == true)
            //        {
            //            string a = dosya.Replace(deneme, "");
            //            dosya = a + "(" + sayi1.ToString() + ")";
            //            sayi1++;
            //        }
            //    }
            //    dosya += deneme;
            //    FileUpload.PostedFile.SaveAs(Server.MapPath("../images/Dosya") + "/" + dosya);
            //    ic.ICERIKDOSYA = dosya;
            //}
            //else
            //{
            //}
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
            if (rdkat.SelectedItem.Value != "3")
            {
                divicerik.Visible = true;
                int kat = Convert.ToInt32(rdkat.SelectedItem.Value);
                divhata.Visible = false;
                trdosya.Visible = false;
                TblIcerik.Visible = true;
                lbkat.Text = db.KATEGORIs.FirstOrDefault(a => a.KATID == kat).KATADI;
                divkategori.Visible = false;
            }
            else
            {
                divicerik.Visible = true;
                trdosya.Visible = true;
                int kat = Convert.ToInt32(rdkat.SelectedItem.Value);
                divhata.Visible = false;
                TblIcerik.Visible = true;
                lbkat.Text = db.KATEGORIs.FirstOrDefault(a => a.KATID == kat).KATADI;
                divkategori.Visible = false;
            }
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
        KategoriGetir(0);
        divhata.Visible = false;
        divkaydet.Visible = false;
    }
}