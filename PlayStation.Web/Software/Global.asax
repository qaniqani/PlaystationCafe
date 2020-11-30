<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        System.Web.Routing.RouteTable.Routes.Ignore("{resource}.axd/{*pathInfo}");
        //RSS
        //statik sayfalar

        //System.Web.Routing.RouteTable.Routes.Add("kat2", new System.Web.Routing.Route("kat/{kat}/", new System.Web.Routing.PageRouteHandler("~/kategori.aspx")));

        System.Web.Routing.RouteTable.Routes.Add("formkaydi", new System.Web.Routing.Route("icerik-detay/firma-kaydi-ve-download", new System.Web.Routing.PageRouteHandler("~/FirmaKaydi.aspx")));

        System.Web.Routing.RouteTable.Routes.Add("iletisim", new System.Web.Routing.Route("icerik-detay/iletisim-bilgileri", new System.Web.Routing.PageRouteHandler("~/iletisim.aspx")));
        
        System.Web.Routing.RouteTable.Routes.Add("icerik", new System.Web.Routing.Route("icerik-detay/{IcURL}", new System.Web.Routing.PageRouteHandler("~/IcerikDetaylar.aspx")));

        System.Web.Routing.RouteTable.Routes.Add("icicerik", new System.Web.Routing.Route("icerik-menu/{icicerik}", new System.Web.Routing.PageRouteHandler("~/icerik.aspx")));

        
       

        //System.Web.Routing.RouteTable.Routes.Add("icerikmenu", new System.Web.Routing.Route("icerikmenu/{biz-kimiz}/", new System.Web.Routing.PageRouteHandler("~/icerik.aspx")));
        //System.Web.Routing.RouteTable.Routes.Add("hakkimizda", new System.Web.Routing.Route("menu/hakkimizda/", new System.Web.Routing.PageRouteHandler("~/icerik.aspx")));
        //System.Web.Routing.RouteTable.Routes.Add("mekan", new System.Web.Routing.Route("menu/mekan/", new System.Web.Routing.PageRouteHandler("~/mekan.aspx")));
        //System.Web.Routing.RouteTable.Routes.Add("organizasyon", new System.Web.Routing.Route("menu/organizasyon/", new System.Web.Routing.PageRouteHandler("~/organizasyonlarimiz.aspx")));
        //System.Web.Routing.RouteTable.Routes.Add("rezervasyon", new System.Web.Routing.Route("menu/rezervasyon/", new System.Web.Routing.PageRouteHandler("~/rezervasyon.aspx")));
        //System.Web.Routing.RouteTable.Routes.Add("iletisim", new System.Web.Routing.Route("menu/iletisim/", new System.Web.Routing.PageRouteHandler("~/iletisim.aspx")));
        //System.Web.Routing.RouteTable.Routes.Add("menu", new System.Web.Routing.Route("menu/menuler/", new System.Web.Routing.PageRouteHandler("~/menu.aspx")));
        //System.Web.Routing.RouteTable.Routes.Add("organizasyonlarimiz", new System.Web.Routing.Route("org/{org}/", new System.Web.Routing.PageRouteHandler("~/organizasyonlarimiz.aspx")));
        //System.Web.Routing.RouteTable.Routes.Add("kat", new System.Web.Routing.Route("menu/{menu}/", new System.Web.Routing.PageRouteHandler("~/icerik.aspx")));
    }
    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
    }
    void Application_Error(object sender, EventArgs e)
    {
        try
        {
            Exception excp = Server.GetLastError();
            string HataOlusanSayfa = Request.CurrentExecutionFilePath;
            string mesaj = "";
            using (System.IO.StreamWriter str = new System.IO.StreamWriter(Server.MapPath("~/logs/HataLog.txt"), true))
            {
                /* str isminde StreamWriter türünden bir nesne örneği oluşturdum. Bunu Server.MapPath() ile yerini gösterdiğim klasörde oluşturacak olan errorLog.txt dosyasına yazmak için kullanılır. Bu arada sorabilirsiniz biz böyle bir klasör açtık ama text dosyası koymadık diye. Endişelenmeyin asp.net bunu sizin yerinize yapacaktir.Bu arada true ise Append yani var olan dosyanın uzerine yazılmasını sağlar. false olması durumda ise önceki yazılanlar silinip üzerine yazılma olacaktır ama açıkcası asla tavsiye etmem bu proje için ;) Burada ise tırnaklar içine aldığımız string ifadenin belirttiğimiz yere yazılması sağlanır */
                str.WriteLine("---- URL Adresi------");
                str.WriteLine(HataOlusanSayfa); /* Hata oluşma tarihini kaydetmek için kullandık */
                str.WriteLine("---- Hata Olusma Zamani------");
                str.WriteLine(DateTime.Now.ToString()); /* Hata oluşma tarihini kaydetmek için kullandık */
                str.WriteLine("---- Hata Mesajı ------------"); /* Yine string ifade yazılır */
                if (excp.InnerException != null)
                {
                    mesaj = excp.InnerException.Message;
                }
                else
                {
                    mesaj = excp.Message;
                }
                str.WriteLine(mesaj); /* Burada ise oluşan hatamızı yazıyoruz */
                str.WriteLine("---- Mesaj Icerigi ----------");
                str.WriteLine(excp.StackTrace); /* Ve son olarak burada ise hatamızın içeriği yazılıyor */
                str.Flush();/* Bu komut ise önbellekte tutulan yazılmış olan verilerin silinmesini sağlar */
                str.Close(); /*ve nesnesimiz kapatılıp yok edilir */
            };
            Server.ClearError();
            Server.Transfer("~/error.html");
        }
        catch
        { }

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {

        //InPlusYonetimModel.YonetimEntities db = new InPlusYonetimModel.YonetimEntities();
        //string url = HttpContext.Current.Request.Url.PathAndQuery.Trim();
        //InPlusYonetimModel.TBL_YONLENDIRME yonlendirme = db.TBL_YONLENDIRME.FirstOrDefault(s => s.EskiUrl == url);
        //if (yonlendirme != null)
        //{
        //    Response.RedirectPermanent(yonlendirme.YeniUrl);
        //}
    }
</script>
