<%@ WebHandler Language="C#" Class="resimyukle" %>

using System;
using System.Web;
using InPlusYonetimModel;
public class resimyukle : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "multipart/form-data";
        context.Response.Expires = -1;
        try
        {
            HttpPostedFile postedFile = context.Request.Files["file"];
            string savepath = HttpContext.Current.Server.MapPath("~/images/Icerik/");
            var extension = System.IO.Path.GetExtension(postedFile.FileName);

            if (!System.IO.Directory.Exists(savepath))
                System.IO.Directory.CreateDirectory(savepath);

            var id = Guid.NewGuid() + extension;
            if (extension != null)
            {
                var fileLocation = string.Format("{0}{1}",
                                                 savepath,
                                                 id);
                postedFile.SaveAs(fileLocation);
                using (YonetimEntities db= new YonetimEntities())
                { 
                    DOSYAUPLOAD du = new DOSYAUPLOAD();
                    du.DOSYAADI = id;
                    du.DIL = Convert.ToInt32(1);
                    du.DOSYAYOLU = "/images/Icerik/" + id;
                    du.DOSYATUR = 1;
                    db.AddToDOSYAUPLOADs(du);
                    db.SaveChanges();
                }
                context.Response.Write("/images/Icerik/" + id);
            }
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    

}