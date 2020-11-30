using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImarApp
{
    public class PageBase : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            GZipSIKISTIRMA(HttpContext.Current);
            base.OnLoad(e);
        }

        /// <summary>
        /// Sıkıştırma uygulayan method
        /// </summary>
        /// <param name="context">O Anki Aktif Context</param>
        public static void GZipSIKISTIRMA(HttpContext context)
        {
            HttpResponse Response = context.Response;

            if (GzipEtkinMi(context))
            {
                string encoding = context.Request.Headers["Accept-Encoding"];

                //deflate sıkıştırmayı destekleyenler için
                if (encoding.Contains("deflate"))
                {
                    Response.Filter = new System.IO.Compression.DeflateStream(Response.Filter, System.IO.Compression.CompressionMode.Compress);
                    Response.AppendHeader("Content-Encoding", "deflate");
                }
                else
                {
                    //Gzip sıkıştırmayı destekleyenler için
                    Response.Filter = new System.IO.Compression.GZipStream(Response.Filter, System.IO.Compression.CompressionMode.Compress);
                    Response.AppendHeader("Content-Encoding", "gzip");
                }
                //Sıkıştırılmış bilgi tarayıcıya belirtiliyor!
                Response.AppendHeader("Vary", "Content-Encoding");
            }
        }

        /// <summary>
        /// Sıkıştırma Destekleniyor mu kontrol et.
        /// </summary>
        /// <param name="context">O Anki aktif Context</param>
        /// <returns>True yada False</returns>
        public static bool GzipEtkinMi(HttpContext context)
        {
            //Tarayıcı sıkıştırma destekliyor mu ?
            string AcceptEncoding = context.Request.Headers["Accept-Encoding"];

            if (!string.IsNullOrEmpty(AcceptEncoding))
            {
                //evet
                return (AcceptEncoding.Contains("gzip") || AcceptEncoding.Contains("deflate"));
            }
            else
            {
                //hayır.
                return false;
            }
        }
    }

    public class PageBaseMaster : System.Web.UI.MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
            GZipSIKISTIRMA(HttpContext.Current);
            base.OnLoad(e);
        }

        /// <summary>
        /// Sıkıştırma uygulayan method
        /// </summary>
        /// <param name="context">O Anki Aktif Context</param>
        public static void GZipSIKISTIRMA(HttpContext context)
        {
            HttpResponse Response = context.Response;

            if (GzipEtkinMi(context))
            {
                string encoding = context.Request.Headers["Accept-Encoding"];

                //deflate sıkıştırmayı destekleyenler için
                if (encoding.Contains("deflate"))
                {
                    Response.Filter = new System.IO.Compression.DeflateStream(Response.Filter, System.IO.Compression.CompressionMode.Compress);
                    Response.AppendHeader("Content-Encoding", "deflate");
                }
                else
                {
                    //Gzip sıkıştırmayı destekleyenler için
                    Response.Filter = new System.IO.Compression.GZipStream(Response.Filter, System.IO.Compression.CompressionMode.Compress);
                    Response.AppendHeader("Content-Encoding", "gzip");
                }
                //Sıkıştırılmış bilgi tarayıcıya belirtiliyor!
                Response.AppendHeader("Vary", "Content-Encoding");
            }
        }

        /// <summary>
        /// Sıkıştırma Destekleniyor mu kontrol et.
        /// </summary>
        /// <param name="context">O Anki aktif Context</param>
        /// <returns>True yada False</returns>
        public static bool GzipEtkinMi(HttpContext context)
        {
            //Tarayıcı sıkıştırma destekliyor mu ?
            string AcceptEncoding = context.Request.Headers["Accept-Encoding"];

            if (!string.IsNullOrEmpty(AcceptEncoding))
            {
                //evet
                return (AcceptEncoding.Contains("gzip") || AcceptEncoding.Contains("deflate"));
            }
            else
            {
                //hayır.
                return false;
            }
        }
    }
}