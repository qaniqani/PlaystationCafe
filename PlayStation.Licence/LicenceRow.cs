using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PlayStation.Data;

namespace PlayStation.Licence
{
    public class LicenceRow
    {
        DataAccessLayer db = new DataAccessLayer();

        public int DBRowCount()
        {
            DataTable dt = db.GetDataTable("SELECT FIRST 1 * FROM LICENCE ORDER BY LREF DESC", System.Data.CommandType.Text, null);
            int row = dt != null ? dt.Rows.Count : 0;

            return row;
        }

        public LicenceService.LicenceDetail DBLicenceRow()
        {
            try
            {
            DataRow dr = db.GetDataRow("SELECT FIRST 1 * FROM LICENCE ORDER BY LREF DESC", System.Data.CommandType.Text, null);

            string allParams = Functions.Function.DecryptIt(dr["PARAMS"].ToString());
            string[] getParams = allParams.Split('~');

            LicenceService.LicenceDetail ld = new LicenceService.LicenceDetail();

            ld.Active = Convert.ToBoolean(getParams[0]);
            ld.BeforeCheckDate = Convert.ToDateTime(getParams[1]);
            ld.Demo= Convert.ToBoolean(getParams[2]);
            ld.LicenceEndDate = Convert.ToDateTime(getParams[3]);
            ld.LicenceKey = getParams[4];
            ld.LicenceStartDate = Convert.ToDateTime(getParams[5]);
            ld.ResultCode = Convert.ToBoolean(getParams[6]);
            ld.ResultMessage = getParams[7];
            ld.UpdateDayCount = Convert.ToInt32(getParams[8]);
            ld.UserCount = Convert.ToInt32(getParams[9]);

            return ld;
            }
            catch {
                return this.LicenceClearing();
            }
        }

        public void DBLicenceInsert(string LicenceString)
        {
            string query = string.Format("INSERT INTO LICENCE(PARAMS) VALUES ('{0}')", Functions.Function.EncryptIt(LicenceString));
            string msg = string.Empty;
            db.FbExecute(query, CommandType.Text, null, out msg);
        }

        private LicenceService.LicenceDetail LicenceClearing()
        {
            LicenceService.LicenceDetail ld = new LicenceService.LicenceDetail();
            ld.Active = false;
            ld.BeforeCheckDate = DateTime.Today;
            ld.Demo = false;
            ld.LicenceEndDate = DateTime.Today;
            ld.LicenceStartDate = DateTime.Today;
            ld.ResultCode = false;
            ld.ResultMessage = "Lisans servisine erişilemiyor. Lütfen internet bağlantınızı kontrol ederek tekrar deneyiniz.";
            ld.UpdateDayCount = 0;
            ld.UserCount = 1;

            return ld;
        }
    }
}
