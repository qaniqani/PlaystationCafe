using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using InPlusYonetimModel;
namespace PlupLoadSample
{
    /// <summary>
    /// Summary description for ImageUpload
    /// </summary>
    public class ImageUpload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int chunk = context.Request["chunk"] != null ? int.Parse(context.Request["chunk"]) : 0;
            string fileName = context.Request["name"] != null ? context.Request["name"] : string.Empty;

            HttpPostedFile fileUpload = context.Request.Files[0];

            var uploadPath = context.Server.MapPath("~/uploads");
            using (var fs = new FileStream(Path.Combine(uploadPath, fileName), chunk == 0 ? FileMode.Create : FileMode.Append))
            {
                var buffer = new byte[fileUpload.InputStream.Length];
                fileUpload.InputStream.Read(buffer, 0, buffer.Length);

                fs.Write(buffer, 0, buffer.Length);
                using (YonetimEntities db = new YonetimEntities())
                {
                    ICERIKRESIM ir = new ICERIKRESIM();
                    ir.DURUM = true;
                    ir.RESIM = fileName;
                    ir.SIRA = 9999;
                    ir.TARIH = DateTime.Now;
                    db.AddToICERIKRESIMs(ir);
                    db.SaveChanges();

                }
            }


            context.Response.ContentType = "text/plain";
            context.Response.Write("Success.");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}