using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;

namespace PlayStation
{
    public partial class FrmTest : DevExpress.XtraEditors.XtraForm
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var surl = "http://www.nvisionsoft.net/LicenceService.aspx?LicenceKey={0}&AuthenticationKey={1}&MotherBoardSerial={2}&CPUSerial={3}&HDDSerial={4}";

            var url = new Uri(surl);

            MethodInfo getSyntax = typeof(UriParser).GetMethod("GetSyntax", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            FieldInfo flagsField = typeof(UriParser).GetField("m_Flags", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (getSyntax != null && flagsField != null)
            {
                foreach (string scheme in new[] { "http", "https" })
                {
                    UriParser parser = (UriParser)getSyntax.Invoke(null, new object[] { scheme });
                    if (parser != null)
                    {
                        int flagsValue = (int)flagsField.GetValue(parser);
                        // Clear the CanonicalizeAsFilePath attribute
                        if ((flagsValue & 0x1000000) != 0)
                            flagsField.SetValue(parser, flagsValue & ~0x1000000);
                    }
                }
            }

            url = new Uri(surl);

            //string.Format("http://www.nvisionsoft.net/LicenceService.aspx?LicenceKey={0}&AuthenticationKey={1}&MotherBoardSerial={2}&CPUSerial={3}&HDDSerial={4}",
            //string openKey = DateTime.Today.ToShortDateString();
            //string asd = Functions.Function.EncryptIt(openKey);
            richTextBox1.Text = url.ToString();
        }
    }
}