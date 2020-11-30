using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_urunEkle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Ürün Ekle";

            KontrolEt();
            //else if (Request.QueryString["katid"] != null)
            //{
            //    KategoriGetir(Convert.ToInt32(Request.QueryString["katid"]));
            //    tblkategorisec.Visible = false;
            //    TblIcerik.Visible = true;
            //    int kat = Convert.ToInt32(Request.QueryString["katid"].ToString());
            //    lbkat.Text = db.KATEGORIs.FirstOrDefault(a => a.KATID == kat).KATADI;
            //}
            //else
            //{
            //    tblkategorisec.Visible = true;
            //    TblIcerik.Visible = false;
            //}
        }
    }

    private void KontrolEt()
    {
        KategoriGetir(0);
        divhata.Visible = true;
        lbhatamesaj.Text = "Lütfen sağ taraftan kategori seçiniz...";
        TblIcerik.Visible = false;
        if (Request.QueryString["id"] != null)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Ürün Düzenle";
            divicerik.Visible = true;
            BtnKaydet.Visible = false;
            BtnUpdate.Visible = true;
            urunGetir(Convert.ToInt32(Request.QueryString["id"]));
        }
    }

    private void urunGetir(int p)
    {
        divicerik.Attributes.Add("class", "g12");
        int id = Convert.ToInt32(Request.QueryString["id"]);
        divhata.Visible = false;

        TblIcerik.Visible = true;

        divkategori.Visible = false;
        UrunFactory islem = new UrunFactory();
        URUN i = islem.UrunDetayGetir(db, id);
        int katid = Convert.ToInt32(i.KATID);
        lbkat.Text = db.KATEGORIs.FirstOrDefault(a => a.KATID == katid).KATADI;
        tbad.Text = i.URUNADI;
        tbdess.Text = i.URUNDESS;
        tbkey.Text = i.URUNKEY;
        tbsira.Text = i.URUNSIRA.ToString();
        tbtitle.Text = i.URUNTITLE;
        chkAktif.Checked = Convert.ToBoolean(i.URUNDURUM);
        tbolcu.Text = i.URUNOLCU;
        tbanma.Text = i.URUNANMA;
        ltrcat.Text = i.URUNCAT;
        ltrbrosur.Text = i.URUNBROSUR;
        //DrpDil.SelectedValue = i.URUNDIL.ToString();
        CKEditorControl1.Text = i.URUNDETAY;
        chkAnasayfa.Checked = Convert.ToBoolean(i.URUNVITRIN);
    }



    private void KategoriGetir(int p)
    {

        int Dil = 1;
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
        }
    }



    private void icerikDuzenle()
    {




    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbad.Text) != true && string.IsNullOrEmpty(CKEditorControl1.Text) != true)
        {
            int kat = Convert.ToInt32(rdkat.SelectedValue);
            bool Aktifdurum = false;

            if (chkAktif.Checked)
            {
                Aktifdurum = true;
            }
            Genel g = new Genel();
            URUN ic = new URUN();
            ic.URUNADI = tbad.Text.Trim();
            ic.URUNDESS = tbdess.Text.Trim();
            ic.URUNDIL = 1;
            ic.URUNDURUM = Aktifdurum;
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text.Trim());
            }
            catch
            {
            }
            ic.URUNKEY = tbkey.Text.Trim();
            ic.URUNTITLE = tbtitle.Text.Trim();
            ic.URUNSIRA = sira;
            ic.URUNDETAY = CKEditorControl1.Text;
            ic.TARIH = DateTime.Now;
            ic.URUNURL = urlKontrol(Genel.UrlSeo(tbad.Text.Trim()));
            ic.KATID = kat;
            ic.URUNANMA = tbanma.Text;
            ic.URUNOLCU = tbolcu.Text;
            ic.URUNVITRIN = chkAnasayfa.Checked;

            string cat = "";
          

            if (FileUpload1.HasFile)
            {
                if (FileUpload1.HasFile)
                {

                    string gec1 = FileUpload1.PostedFile.FileName;
                    string deneme = System.IO.Path.GetExtension(gec1);
                    cat = Genel.UrlSeo(gec1.Replace(deneme, "")); ;
                    int sayi1 = 1;
                    for (int i = 0; i < sayi1; i++)
                    {
                        if (System.IO.File.Exists(Server.MapPath("../images/Dosya") + "\\" + cat) == true)
                        {
                            string a = cat.Replace(deneme, "");
                            cat = a + "(" + sayi1.ToString() + ")";
                            sayi1++;
                        }
                    }
                    cat += deneme;

                    FileUpload1.PostedFile.SaveAs(Server.MapPath("../images/Dosya") + "/" + cat);
                }
            }


            string brosur = "";
            if (FileUpload2.HasFile)
            {
                if (FileUpload2.HasFile)
                {

                    string gec1 = FileUpload2.PostedFile.FileName;
                    string deneme = System.IO.Path.GetExtension(gec1);
                    brosur = Genel.UrlSeo(gec1.Replace(deneme, "")); ;
                    int sayi1 = 1;
                    for (int i = 0; i < sayi1; i++)
                    {
                        if (System.IO.File.Exists(Server.MapPath("../images/Dosya") + "\\" + brosur) == true)
                        {
                            string a = brosur.Replace(deneme, "");
                            brosur = a + "(" + sayi1.ToString() + ")";
                            sayi1++;
                        }
                    }
                    brosur += deneme;

                    FileUpload2.PostedFile.SaveAs(Server.MapPath("../images/Dosya") + "/" + brosur);
                }
            }

            ic.URUNBROSUR = brosur;
            ic.URUNCAT = cat;
            db.AddToURUNs(ic);
            db.SaveChanges();


            divkaydet.Visible = true;
            divhata.Visible = false;
        }
    }

    private string urlKontrol(string url)
    {
        var ur = from x in db.KATEGORIs where x.KATURL == url select x.KATID;
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
        if (string.IsNullOrEmpty(tbad.Text) != true && string.IsNullOrEmpty(CKEditorControl1.Text) != true)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            bool Aktifdurum = false;

            if (chkAktif.Checked)
            {
                Aktifdurum = true;
            }
            Genel g = new Genel();
            UrunFactory islem = new UrunFactory();
            URUN ic = islem.UrunDetayGetir(db, id);
            ic.URUNADI = tbad.Text.Trim();
            ic.URUNDESS = tbdess.Text.Trim();
            ic.URUNDIL = 1;
            ic.URUNDURUM = Aktifdurum;
            ic.URUNID = id;
            int sira = 9999;
            try
            {
                sira = Convert.ToInt32(tbsira.Text.Trim());
            }
            catch
            {
            }

            string cat = ltrcat.Text;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.HasFile)
                {

                    string gec1 = FileUpload1.PostedFile.FileName;
                    string deneme = System.IO.Path.GetExtension(gec1);
                    cat = Genel.UrlSeo(gec1.Replace(deneme, "")); ;
                    int sayi1 = 1;
                    for (int i = 0; i < sayi1; i++)
                    {
                        if (System.IO.File.Exists(Server.MapPath("../images/Dosya") + "\\" + cat) == true)
                        {
                            string a = cat.Replace(deneme, "");
                            cat = a + "(" + sayi1.ToString() + ")";
                            sayi1++;
                        }
                    }
                    cat += deneme;

                    FileUpload1.PostedFile.SaveAs(Server.MapPath("../images/Dosya") + "/" + cat);
                }
            }


            string brosur = ltrbrosur.Text;
            if (FileUpload2.HasFile)
            {
                if (FileUpload2.HasFile)
                {

                    string gec1 = FileUpload2.PostedFile.FileName;
                    string deneme = System.IO.Path.GetExtension(gec1);
                    brosur = Genel.UrlSeo(gec1.Replace(deneme, "")); ;
                    int sayi1 = 1;
                    for (int i = 0; i < sayi1; i++)
                    {
                        if (System.IO.File.Exists(Server.MapPath("../images/Dosya") + "\\" + brosur) == true)
                        {
                            string a = brosur.Replace(deneme, "");
                            brosur = a + "(" + sayi1.ToString() + ")";
                            sayi1++;
                        }
                    }
                    brosur += deneme;

                    FileUpload2.PostedFile.SaveAs(Server.MapPath("../images/Dosya") + "/" + brosur);
                }
            }
            ic.URUNANMA = tbanma.Text;
            ic.URUNOLCU = tbolcu.Text;
            ic.URUNKEY = tbkey.Text.Trim();
            ic.URUNTITLE = tbtitle.Text.Trim();
            ic.URUNSIRA = sira;
            ic.URUNDETAY = CKEditorControl1.Text;
            ic.TARIH = DateTime.Now;
            ic.URUNURL = urlKontrol(Genel.UrlSeo(tbad.Text.Trim()));
            ic.URUNCAT = cat;
            ic.URUNBROSUR = brosur;
            ic.URUNVITRIN = chkAnasayfa.Checked;
            ic.URUNCAT = cat;
            ic.URUNBROSUR = brosur;
            db.SaveChanges();



            divduzen.Visible = true;
        }
    }
    protected void Btnileri_Click(object sender, EventArgs e)
    {
        if (rdkat.SelectedItem != null)
        {
            int kat = Convert.ToInt32(rdkat.SelectedItem.Value);
            KategoriGetir(kat);
        }
        else
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
    protected void DrpDil_SelectedIndexChanged(object sender, EventArgs e)
    {
        divhata.Visible = false;
        divkaydet.Visible = false;
        divduzen.Visible = false;
        KontrolEt();
    }
}