using System;
using System.Collections.Generic;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace PlayStation.Data
{
    public class DebtList
    {
        private readonly DataAccessLayer _db = new DataAccessLayer();

        public int Insert(Model.DebtList debt, out string message)
        {
            const string query = @"INSERT INTO DEBTLIST(
                            NAME,
                            GSMNR,
                            DEBTDATE,
                            DEBTAMOUNT,
                            CREATEDATE
                                ) VALUES(
                            @NAME,
                            @GSMNR,
                            @DEBTDATE,
                            @DEBTAMOUNT,
                            @CREATEDATE)";

            var sp = new FbParameter[5];
            sp[0] = new FbParameter("@NAME", debt.NAME);
            sp[1] = new FbParameter("@GSMNR", debt.GSMNR);
            sp[2] = new FbParameter("@DEBTDATE", debt.DEBTDATE);
            sp[3] = new FbParameter("@DEBTAMOUNT", debt.DEBTAMOUNT);
            sp[4] = new FbParameter("@CREATEDATE", debt.CREATEDATE);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public List<Model.DebtList> Select()
        {
            var debtList = new List<Model.DebtList>();

            const string query = @"SELECT * FROM DEBTLIST ORDER BY LREF DESC";

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return debtList;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                var debt = new Model.DebtList
                {
                    CREATEDATE = Convert.ToDateTime(dr["CREATEDATE"].ToString()),
                    DEBTAMOUNT = Convert.ToDecimal(dr["DEBTAMOUNT"].ToString()),
                    DEBTDATE = Convert.ToDateTime(dr["DEBTDATE"].ToString()),
                    LREF = Convert.ToInt32(dr["LREF"].ToString()),
                    GSMNR = dr["GSMNR"].ToString(),
                    NAME = dr["NAME"].ToString()
                };

                debtList.Add(debt);
            }

            return debtList;
        }

        public int Update(Model.DebtList debt, out string message)
        {
            const string query = @"UPDATE DEBTLIST SET
                            NAME=@NAME,
                            GSMNR=@GSMNR,
                            DEBTAMOUNT=@DEBTAMOUNT,
                            DEBTDATE=@DEBTDATE,
                            CREATEDATE=@CREATEDATE,
                            WHERE LREF=@LREF";

            var sp = new FbParameter[6];
            sp[0] = new FbParameter("@NAME", debt.NAME);
            sp[1] = new FbParameter("@GSMNR", debt.GSMNR);
            sp[2] = new FbParameter("@DEBTAMOUNT", debt.DEBTAMOUNT);
            sp[3] = new FbParameter("@DEBTDATE", debt.DEBTDATE);
            sp[4] = new FbParameter("@CREATEDATE", debt.CREATEDATE);
            sp[5] = new FbParameter("@LREF", debt.LREF);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public void Delete(int lref)
        {
            string message;
            var query = @"DELETE FROM DEBTLIST WHERE LREF=" + lref;
            _db.FbExecute(query, CommandType.Text, null, out message);
        }
    }
}
