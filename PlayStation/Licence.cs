using System;
using System.Data;
using System.Globalization;
using PlayStation.Data;
using PlayStation.Functions;

namespace PlayStation
{
    public class Licence
    {
        private readonly DataAccessLayer _db = new DataAccessLayer();

        public int DbRowCount()
        {
            var dt = _db.GetDataTable("SELECT FIRST 1 * FROM LICENCE ORDER BY LREF DESC", CommandType.Text, null);
            var row = dt != null ? dt.Rows.Count : 0;

            return row;
        }

        public LicenceDetail DbLicenceRow()
        {
            try
            {
                var dr = _db.GetDataRow("SELECT FIRST 1 * FROM LICENCE ORDER BY LREF DESC", CommandType.Text, null);

                var allParams = Function.DecryptIt(dr["PARAMS"].ToString());
                var getParams = allParams.Split('~');

                var culture = new CultureInfo("tr-TR");

                DateTime endDate;
                DateTime.TryParseExact(getParams[2], "dd.MM.yyyy HH:mm:ss", culture, DateTimeStyles.None, out endDate);
                
                DateTime startDate;
                DateTime.TryParseExact(getParams[3], "dd.MM.yyyy HH:mm:ss", culture, DateTimeStyles.None, out startDate);

                var ld = new LicenceDetail
                {
                    Active = Convert.ToBoolean(getParams[0]),
                    Demo = Convert.ToBoolean(getParams[1]),
                    LicenceEndDate = endDate,
                    LicenceStartDate = startDate,
                    ResultMessage = getParams[4],
                    LicenceKey = getParams[5]
                };

                return ld;
            }
            catch
            {
                return LicenceClear();
            }
        }

        public void DbLicenceInsert(string licenceString)
        {
            var query = string.Format("INSERT INTO LICENCE(PARAMS) VALUES ('{0}')", Function.EncryptIt(licenceString));
            string msg;
            _db.FbExecute(query, CommandType.Text, null, out msg);
        }

        public LicenceDetail LicenceClear()
        {
            var ld = new LicenceDetail
            {
                Active = false,
                Demo = false,
                LicenceEndDate = DateTime.Today,
                LicenceStartDate = DateTime.Today,
                ResultMessage = "Lisans sureniz dolmustur. Programi aktif etmek icin lutfen irtibata gecerek lisans satin aliniz.",
                LicenceKey = string.Empty
            };

            var licenceString = ld.Active + "~" +
                                ld.Demo + "~" +
                                ld.LicenceEndDate.ToString("dd.MM.yyyy HH:mm:ss") + "~" +
                                ld.LicenceStartDate.ToString("dd.MM.yyyy HH:mm:ss") + "~" +
                                ld.ResultMessage + "~" +
                                ld.LicenceKey;

            DbLicenceInsert(licenceString);

            return ld;
        }

        private LicenceDetail DemoLicence()
        {
            var ld = new LicenceDetail
            {
                Active = true,
                Demo = false,
                LicenceEndDate = DateTime.Today,
                LicenceStartDate = DateTime.Today,
                ResultMessage = "Demo hesabiniz aktif olmustur."
            };

            return ld;
        }

        public LicenceDetail ActiveLicence(string licenceKey, string message)
        {
            var ld = new LicenceDetail
            {
                Active = true,
                Demo = false,
                LicenceEndDate = DateTime.Today.AddYears(50),
                LicenceStartDate = DateTime.Today,
                ResultMessage = message,
                LicenceKey = licenceKey
            };

            var licenceString = ld.Active + "~" +
                                ld.Demo + "~" +
                                ld.LicenceEndDate.ToString("dd.MM.yyyy HH:mm:ss") + "~" +
                                ld.LicenceStartDate.ToString("dd.MM.yyyy HH:mm:ss") + "~" +
                                ld.ResultMessage + "~" +
                                ld.LicenceKey;

            DbLicenceInsert(licenceString);

            return ld;
        }

        public LicenceDetail ActiveDemoLicence()
        {
            if (!string.IsNullOrEmpty(Function.ReadRegistry("LicenceDemo")))
            {
                LicenceClear();
                return null;
            }

            var ld = new LicenceDetail
            {
                Active = false,
                Demo = true,
                LicenceEndDate = DateTime.Today.AddMonths(1),
                LicenceStartDate = DateTime.Today,
                ResultMessage = "Demo hesabiniz aktif olmustur."
            };

            var licenceString = ld.Active + "~" +
                                ld.Demo + "~" +
                                ld.LicenceEndDate.ToString("dd.MM.yyyy HH:mm:ss") + "~" +
                                ld.LicenceStartDate.ToString("dd.MM.yyyy HH:mm:ss") + "~" +
                                ld.ResultMessage + "~" +
                                ld.LicenceKey;

            DbLicenceInsert(licenceString);

            Function.WriteRegistry("LicenceDemo", "true");

            return ld;
        }
    }
}
