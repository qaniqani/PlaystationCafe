using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PhotoResize : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["src"].ToString().Contains("http:") != true)
                {
                    Response.Clear();
                    //Parametreleri aliyoruz.
                    int yukseklik = 0;
                    int genislik = 0;
                    string ResimAdi = string.Empty;
                    if (Request.QueryString["Tur"] == "Crop")
                    {
                        if (Request["genislik"] != null)
                        {
                            genislik = Int32.Parse(Request["genislik"].ToString());
                        }
                        if (Request["yukseklik"] != null)
                        {
                            yukseklik = Int32.Parse(Request["yukseklik"].ToString());
                        }
                        ResimAdi = Request.QueryString["src"];
                        string uzanti = System.IO.Path.GetExtension(Server.MapPath(ResimAdi));
                        //Parametreleri metodumuza gönderiyoruz...
                        byte[] pBuffer = ImageResize.imgCrop(Server.MapPath(ResimAdi), genislik-1, yukseklik);
                        Response.ContentType = "image/" + uzanti;
                        //Sayfamizin contenttype'ni image olarak belirledik ve Resmimiz olusturuluyor...
                        Response.OutputStream.Write(pBuffer, 0, pBuffer.Length);
                    }
                    else if (Request.QueryString["Tur"] == "Fix")
                    {
                        if (Request["genislik"] != null)
                        {
                            genislik = Int32.Parse(Request["genislik"].ToString());
                        }
                        if (Request["yukseklik"] != null)
                        {
                            yukseklik = Int32.Parse(Request["yukseklik"].ToString());
                        }
                        ResimAdi = Request.QueryString["src"];
                        string uzanti = System.IO.Path.GetExtension(Server.MapPath(ResimAdi));
                        //Parametreleri metodumuza gönderiyoruz...
                        byte[] pBuffer = ImageResize.FixedSize(Server.MapPath(ResimAdi), genislik, yukseklik);

                        //byte[] pBuffer = ImageResize.KucukResimOlustur(ResimAdi, yukseklik, genislik, uzanti);
                        Response.ContentType = "image/" + uzanti;
                        //Sayfamizin contenttype'ni image olarak belirledik ve Resmimiz olusturuluyor...
                        Response.OutputStream.Write(pBuffer, 0, pBuffer.Length);
                    }
                    Response.End();
                }
                else
                {
                    Response.RedirectPermanent("Burayı sadece imarbilgileri.com kullanabilir!.. Ama bu meraklı oldugunu gosterir. Daha fazla bilgi icin: admin@imarbilgileri.com'dan bana ulaş.");
                }
            }
        }
        catch
        { }
    }
}