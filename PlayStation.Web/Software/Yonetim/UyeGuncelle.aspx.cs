using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InPlusYonetimModel;

public partial class Yonetim_UyeGuncelle : System.Web.UI.Page
{
    YonetimEntities db = new YonetimEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal lt = Master.FindControl("ltMasterBaslik") as Literal;
            lt.Text = "Üye Ekle";
            if (Request.QueryString["id"] != null)
            {
                lt.Text = "Üye Güncelle";
                BtnKaydet.Visible = false;
                BtnUpdate.Visible = true;
                UyeDetayGetir();
            }
            else
            {
                BtnKaydet.Visible = true;
                BtnUpdate.Visible = false;
            }
        }
    }

    private void UyeDetayGetir()
    {
        int uyeid = Convert.ToInt32(Request.QueryString["id"].ToString());
        UYE u = db.UYEs.FirstOrDefault(uy => uy.UYEID == uyeid);
        if (u != null)
        {
            TbAd.Text = u.UYEAD;
            TbAdres.Text = u.UYEADRES;
            TbEposta.Text = u.UYEMAIL;
            TbGsm.Text = u.UYEGSM;
            TbParola.Text = u.UYEPAROLA;
            TbSoyad.Text = u.UYESOYAD;
            TbTel.Text = u.UYETEL;
            chkaktivasyondurum.Checked = Convert.ToBoolean(u.UYEAKTIVASYONDURUM);
            chkdurum.Checked = Convert.ToBoolean(u.UYEDURUM);



        }
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        if (TelVarmi(TbTel.Text.Trim(), 0) == true)
        {
            if (TelVarmi(TbGsm.Text.Trim(), 0) == true)
            {
                if (EpostaVarmi(TbEposta.Text.Trim(), 0) == true)
                {
                    UYE u = new UYE();
                    u.UYEAD = TbAd.Text;
                    u.UYEADRES = TbAdres.Text;
                    u.UYEAKTIVASYONDURUM = chkaktivasyondurum.Checked;
                    string deger = Guid.NewGuid().ToString();
                    u.UYEAKTIVASYONKOD = deger;
                    u.UYEDURUM = chkdurum.Checked;
                    u.UYEGSM = TbGsm.Text.Trim();
                    u.UYEIP = HttpContext.Current.Request.UserHostAddress.ToString();
                    u.UYEMAIL = TbEposta.Text.Trim();
                    u.UYEPAROLA = TbParola.Text.Trim();
                    u.UYESONGIRIS = DateTime.Now.ToShortDateString();
                    u.UYESOYAD = TbSoyad.Text;
                    u.UYESOZLESMEDURUM = true;
                    u.UYETARIH = DateTime.Now;
                    u.UYETEL = TbTel.Text;
                    db.AddToUYEs(u);
                    db.SaveChanges();
                    divhata.Visible = false;
                    divkaydet.Visible = true;

                }
                else
                {
                    divhata.Visible = true;
                    divkaydet.Visible = false;
                    divduzen.Visible = false;
                    lbhatamesaj.Text = "E-Posta başka üye tarafından kullanılmaktadır";
                }

            }
            else
            {
                divhata.Visible = true;
                divkaydet.Visible = false;
                divduzen.Visible = false;
                lbhatamesaj.Text = "GSM numarası başka üye tarafından kullanılmaktadır";
            }


        }
        else
        {
            divhata.Visible = true;
            divkaydet.Visible = false;
            divduzen.Visible = false;
            lbhatamesaj.Text = "Telefon numarası başka üye tarafından kullanılmaktadır";
        }


    }
    public bool TelVarmi(string tel, int uyeid)
    {
        bool varmi = true;
        UYE uy = null;
        if (uyeid == 0)
        {
            uy = db.UYEs.FirstOrDefault(a => a.UYETEL == tel || a.UYEGSM == tel);
        }
        else
        {
            uy = db.UYEs.FirstOrDefault(a => (a.UYETEL == tel || a.UYEGSM == tel) && a.UYEID != uyeid);
        }
        if (uy != null)
        {
            varmi = false;
        }

        return varmi;
    }
    public bool EpostaVarmi(string eposta, int uyeid)
    {
        bool varmi = true;
        UYE uy = null;
        if (uyeid == 0)
        {
            uy = db.UYEs.FirstOrDefault(a => a.UYEMAIL == eposta);
        }
        else
        {
            uy = db.UYEs.FirstOrDefault(a => a.UYEMAIL == eposta && a.UYEID != uyeid);
        }
        if (uy != null)
        {
            varmi = false;
        }

        return varmi;
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            int uyeid = Convert.ToInt32(Request.QueryString["id"]);
            if (TelVarmi(TbTel.Text.Trim(), uyeid) == true)
            {
                if (TelVarmi(TbGsm.Text.Trim(), uyeid) == true)
                {
                    if (EpostaVarmi(TbEposta.Text.Trim(), uyeid) == true)
                    {
                        UYE u = db.UYEs.FirstOrDefault(uy => uy.UYEID == uyeid);
                        if (u != null)
                        {
                            u.UYEAD = TbAd.Text;
                            u.UYEADRES = TbAdres.Text;
                            u.UYEAKTIVASYONDURUM = chkaktivasyondurum.Checked;
                            u.UYEDURUM = chkdurum.Checked;
                            u.UYEGSM = TbGsm.Text;
                            u.UYEMAIL = TbEposta.Text;
                            u.UYEPAROLA = TbParola.Text;
                            u.UYESOYAD = TbSoyad.Text;
                            u.UYETARIH = DateTime.Now;
                            u.UYETEL = TbTel.Text;
                            db.SaveChanges();
                            divduzen.Visible = true;

                            divhata.Visible = false;
                        }
                        else
                        {
                            divhata.Visible = true;
                            divkaydet.Visible = false;
                            divduzen.Visible = false;
                            lbhatamesaj.Text = "E-Posta başka üye tarafından kullanılmaktadır";
                        }

                    }
                    else
                    {
                        divhata.Visible = true;
                        divkaydet.Visible = false;
                        divduzen.Visible = false;
                        lbhatamesaj.Text = "GSM numarası başka üye tarafından kullanılmaktadır";
                    }


                }
                else
                {
                    divhata.Visible = true;
                    divkaydet.Visible = false;
                    divduzen.Visible = false;
                    lbhatamesaj.Text = "Telefon numarası başka üye tarafından kullanılmaktadır";
                }
            }
        }
    }
}