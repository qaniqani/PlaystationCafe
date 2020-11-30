using System;
using System.IO;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace PlayStation.Functions
{
    public class Function
    {
        public static string WriteRegistry(string pKey, string pValue)
        {
            try
            {
                var masterKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\CONSOLEPLUS\\CONSOLEDATABASE");

                masterKey.SetValue(pKey, pValue);
                masterKey.Close();
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string ReadRegistry(string pKey)
        {
            try
            {
                var regKey1 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\CONSOLEPLUS\\CONSOLEDATABASE");
                return (string)regKey1.GetValue(pKey);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string EncryptIt(string toEnrypt)
        {
            if (string.IsNullOrEmpty(toEnrypt)) return "";

            var data = System.Text.ASCIIEncoding.ASCII.GetBytes(toEnrypt);
            var rgbKey = System.Text.ASCIIEncoding.ASCII.GetBytes("01234567");
            var rgbIv = System.Text.ASCIIEncoding.ASCII.GetBytes("76543210");

            //1024-bit encryption
            var memoryStream = new MemoryStream(1024);
            var desCryptoServiceProvider = new DESCryptoServiceProvider();

            var cryptoStream = new CryptoStream(memoryStream,
                desCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIv),
                CryptoStreamMode.Write);

            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();

            var result = new byte[(int)memoryStream.Position];
            memoryStream.Position = 0;
            memoryStream.Read(result, 0, result.Length);

            cryptoStream.Close();
            return Convert.ToBase64String(result);
        }

        public static string DecryptIt(string toDecrypt)
        {
            var decrypted = string.Empty;
            if (string.IsNullOrEmpty(toDecrypt)) return decrypted;

            try
            {
                var data = Convert.FromBase64String(toDecrypt);
                var rgbKey = System.Text.ASCIIEncoding.ASCII.GetBytes("01234567");
                var rgbIV = System.Text.ASCIIEncoding.ASCII.GetBytes("76543210");

                var memoryStream = new MemoryStream(data.Length);

                var desCryptoServiceProvider = new DESCryptoServiceProvider();

                var cryptoStream = new CryptoStream(memoryStream,
                    desCryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV),
                    CryptoStreamMode.Read);

                memoryStream.Write(data, 0, data.Length);
                memoryStream.Position = 0;

                decrypted = new StreamReader(cryptoStream).ReadToEnd();

                cryptoStream.Close();
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            return decrypted;
        }

        public static decimal PriceRounding(decimal? price, decimal? gauge)
        {
            return ((int)(Convert.ToDecimal(price) / Convert.ToDecimal(gauge)) + 1) * Convert.ToDecimal(gauge);
        }

        public static string IfExistsDatabase(string dbName)
        {
            return string.Format("SELECT EXISTS( SELECT * FROM information_schema.TABLES WHERE TABLE_SCHEMA='{0}')", dbName);
        }

        public static string IfExistsTables(string dbName, string tableName)
        {
            return string.Format("SELECT EXISTS( SELECT * FROM information_schema.TABLES WHERE TABLE_SCHEMA='{0}' and TABLE_NAME='{1}')", dbName, tableName);
        }

        public static string IfExistsColumns(string dbName, string tableName, string columnName)
        {
            return string.Format("SELECT EXISTS( SELECT * FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='{0}' and TABLE_NAME='{1}' and COLUMN_NAME='{2}')", dbName, tableName, columnName);
        }

        public static string GetHddSerialNumber()
        {
            try
            {
                var searcher = new ManagementObjectSearcher("select * from Win32_DiskDrive");
                var asd = "0";
                foreach (var o in searcher.Get())
                {
                    var share = (ManagementObject) o;
                    foreach (var pc in share.Properties)
                    {
                        if (pc.Name == "SerialNumber")
                        {
                            asd = pc.Value.ToString();
                        }
                    }
                }
                return asd;
            }
            catch
            {
                return "0";
            }
        }

        public static string GetBiosSerialNumber()
        {
            try
            {
                var searcher = new ManagementObjectSearcher("select * from Win32_BIOS");
                var asd = "0";
                foreach (var o in searcher.Get())
                {
                    var share = (ManagementObject) o;
                    foreach (var pc in share.Properties)
                    {
                        if (pc.Name == "SerialNumber")
                        {
                            asd =  pc.Value.ToString();
                        }
                    }
                }
                return asd;
            }
            catch
            {
                return "0";
            }
        }

        public static string GetCpuSerialNumber()
        {
            try
            {
                var searcher = new ManagementObjectSearcher("select * from Win32_Processor");
                var asd = "0";
                foreach (var o in searcher.Get())
                {
                    var share = (ManagementObject) o;
                    foreach (var pc in share.Properties)
                    {
                        if (pc.Name == "ProcessorId")
                        {
                            asd = pc.Value.ToString();
                        }
                    }
                }
                return asd;
            }
            catch
            {
                return "0";
            }
        }

        public static bool InternetConnTest()
        {
            var blnConnected = false;

            var wr = (HttpWebRequest)WebRequest.Create("http://www.nvisionsoft.net");

            try
            {
                var wresp = (HttpWebResponse)wr.GetResponse();

                if (wresp.StatusCode == HttpStatusCode.OK)
                    blnConnected = true;

            }
            catch { blnConnected = false; }
            return blnConnected;
        }
    }
}
