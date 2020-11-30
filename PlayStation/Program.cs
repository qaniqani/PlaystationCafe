using System;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Globalization;
using System.Threading;

namespace PlayStation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var ci = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            var l = new FrmLogin();
            var dr = l.ShowDialog();
            if (dr != DialogResult.Yes) return;

            try
            {
                Application.Run(new FrmMaster());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu. Hata Kodu: " + ex.Message + Environment.NewLine + "Program kapatılacaktır.");
                Application.Exit();
            }
        }
    }
}
