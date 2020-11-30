using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Controls
{
    public class Ckeditor : HtmlTextArea
    {
        //http://docs.cksource.com/ckeditor_api/symbols/CKEDITOR.config.html

        /// <summary>
        /// The base href URL used to resolve relative and absolute URLs in the editor content.
        /// </summary>
        public string BaseHref
        {
            get { return ViewState["BaseHref"] as string ?? ""; }
            set { ViewState["BaseHref"] = value; }
        }

        /// <summary>
        /// The height of editing area( content ), in relative or absolute.
        /// </summary>
        public Unit Height
        {
            get { return Util.Parse<Unit>(ViewState["Height"]); }
            set { ViewState["Height"] = value; }
        }

        /// <summary>
        /// The width of editing area( content ), in relative or absolute.
        /// </summary>
        public Unit Width
        {
            get { return Util.Parse<Unit>(ViewState["Width"]); }
            set { ViewState["Width"] = value; }
        }

        /// <summary>
        /// The toolbox (alias toolbar) definition.
        /// </summary>
        public string Toolbar
        {
            get { return ViewState["Toolbar"] as string ?? ""; }
            set { ViewState["Toolbar"] = value; }
        }

        /// <summary>
        /// The CSS file(s) as a csv list to be used to apply style to the contents.
        /// </summary>
        public string ContentsCss
        {
            get { return ViewState["ContentsCss"] as string ?? ""; }
            set { ViewState["ContentsCss"] = value; }
        }

		/// <summary>
        /// Set custom ckeditor settings as a csv list.
        /// </summary>
        public string Settings
        {
            get { return ViewState["Settings"] as string ?? ""; }
            set { ViewState["Settings"] = value; }
        }

        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            bool res = base.LoadPostData(postDataKey, postCollection);
            Value = Value.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
            return res;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (String.IsNullOrEmpty(BaseHref))
                throw new ArgumentException("CKeditor cannot have empty BaseHref.");

            List<string> settings = new List<string>();
            settings.Add("baseHref: '" + ResolveUrl(BaseHref) + "'");
            settings.Add("autoUpdateElement: false"); //manually calling update element on form postback in order to work with update panels
            settings.Add("htmlEncodeOutput: true");
            if (Height != Unit.Empty)
                settings.Add("height: '" + Height + "'");
            if (Width != Unit.Empty)
                settings.Add("width: '" + Width + "'");
            if (Toolbar != "")
                settings.Add("toolbar: '" + Toolbar + "'");
            if (ContentsCss != "")
                settings.Add("contentsCss: " + "[" + String.Join(",", Array.ConvertAll<string, string>(ContentsCss.TrimStart('[').TrimEnd(']').Split(','), delegate(string p) { return "'" + ResolveUrl(p.TrimStart('\'','"').TrimEnd('\'','"')) + "'"; })) + "]" + "");
			if (Settings != "")
                settings.Add(Settings);

            string initCkeditor = @"
            function initCKeditor(id, settings)
            {
                CKEDITOR.replace(id, settings);

                try
                {
                    var msajax = Sys.WebForms.PageRequestManager.getInstance();
                    msajax.add_pageLoading(function(sen,args)
                    {
                        var panels = args.get_panelsUpdating();
                        for (var i in panels)
                        {
                            var textareas = panels[i].getElementsByTagName('textarea');
                            for (var j in textareas)
                                if (textareas[j].id == id)
                                    CKEDITOR.instances[id].destroy(false);
                        }
                    });

                    msajax.add_endRequest(function()
                    {
                        if (!CKEDITOR.instances[id])
                            CKEDITOR.replace(id, settings);
                    });
                } catch(err) { }
            }; ";

            ScriptManager.RegisterClientScriptInclude(this, this.GetType(), "ckeditorScript", VirtualPathUtility.AppendTrailingSlash(ResolveUrl(BaseHref)) + "ckeditor.js");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ckeditorInit", Regex.Replace(initCkeditor, @"\s{2,}", " "), true);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ckeditorLoad" + UniqueID, "initCKeditor('" + ClientID + "', { " + String.Join(", ", settings) + " });", true);
            ScriptManager.RegisterOnSubmitStatement(this, this.GetType(), "ckeditorSave" + UniqueID, "CKEDITOR.instances['" + ClientID + "'].updateElement();");

            base.OnPreRender(e);
        }
    }
}
