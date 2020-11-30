using System;
using System.Collections.Generic;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace PlayStation.Data
{
    public class Logs
    {
        private readonly DataAccessLayer _db = new DataAccessLayer();

        public int Insert(Model.Log log, out string message)
        {
            const string query = @"INSERT INTO LOGS(
                            TRANSACTIONTYPE,
                            TRANSACTIONNAME,
                            TRANSACTIONDETAIL,
                            DATETIME,
                            CREATEUSER
                                ) VALUES(
                            @TRANSACTIONTYPE,
                            @TRANSACTIONNAME,
                            @TRANSACTIONDETAIL,
                            @DATETIME,
                            @CREATEUSER)";

            var sp = new FbParameter[5];
            sp[0] = new FbParameter("@TRANSACTIONTYPE", log.TRANSACTIONTYPE);
            sp[1] = new FbParameter("@TRANSACTIONNAME", log.TRANSACTIONNAME);
            sp[2] = new FbParameter("@TRANSACTIONDETAIL", log.TRANSACTIONDETAIL);
            sp[3] = new FbParameter("@DATETIME", log.DATETIME);
            sp[4] = new FbParameter("@CREATEUSER", log.CREATEUSER);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public List<Model.LogView> Select100Rows()
        {
            var logs = new List<Model.LogView>();

            const string query = @"SELECT FIRST 100 L.*,U.NAME,U.SURNAME,U.USERNAME FROM LOGS L
                            INNER JOIN USERS U
                            ON U.LREF = L.CREATEUSER
                            ORDER BY L.LREF DESC";

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return logs;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                var log = new Model.LogView
                {
                    CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString()),
                    DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString()),
                    LREF = Convert.ToInt32(dr["LREF"].ToString()),
                    TRANSACTIONDETAIL = dr["TRANSACTIONDETAIL"].ToString(),
                    TRANSACTIONNAME = dr["TRANSACTIONNAME"].ToString(),
                    TRANSACTIONTYPE = Convert.ToInt32(dr["TRANSACTIONTYPE"].ToString()),
                    NAME = dr["NAME"].ToString(),
                    SURNAME = dr["SURNAME"].ToString(),
                    USERNAME = dr["USERNAME"].ToString()
                };

                logs.Add(log);
            }

            return logs;
        }

        public List< Model.LogView> SelectEndRow()
        {
            const string query = @"SELECT FIRST 5 L.*,U.NAME,U.SURNAME,U.USERNAME FROM LOGS L
                            INNER JOIN USERS U
                            ON U.LREF = L.CREATEUSER
                            ORDER BY L.LREF DESC";

            var li = new List<Model.LogView>();
            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return li;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                var log = new Model.LogView
                {
                    CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString()),
                    DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString()),
                    LREF = Convert.ToInt32(dr["LREF"].ToString()),
                    TRANSACTIONDETAIL = dr["TRANSACTIONDETAIL"].ToString(),
                    TRANSACTIONNAME = dr["TRANSACTIONNAME"].ToString(),
                    TRANSACTIONTYPE = Convert.ToInt32(dr["TRANSACTIONTYPE"].ToString()),
                    NAME = dr["NAME"].ToString(),
                    SURNAME = dr["SURNAME"].ToString(),
                    USERNAME = dr["USERNAME"].ToString()
                };
                li.Add(log);
            }
            return li;
        }

        public List<Model.LogView> SelectDateBetween(DateTime dt1, DateTime dt2, out string message)
        {
            var logs = new List<Model.LogView>();

            message = "";
            var query = @"SELECT L.*,U.NAME,U.SURNAME,U.USERNAME FROM LOGS L" + Environment.NewLine +
                            "INNER JOIN USERS U" + Environment.NewLine +
                            "ON U.LREF = L.CREATEUSER" + Environment.NewLine +
                            "WHERE" + Environment.NewLine +
                            "L.DATETIME BETWEEN '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt1) + "' AND '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt2.AddDays(1)) + "' " + Environment.NewLine +
                            "ORDER BY L.LREF DESC";

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return logs;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                var log = new Model.LogView
                {
                    CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString()),
                    DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString()),
                    LREF = Convert.ToInt32(dr["LREF"].ToString()),
                    TRANSACTIONDETAIL = dr["TRANSACTIONDETAIL"].ToString(),
                    TRANSACTIONNAME = dr["TRANSACTIONNAME"].ToString(),
                    TRANSACTIONTYPE = Convert.ToInt32(dr["TRANSACTIONTYPE"].ToString()),
                    NAME = dr["NAME"].ToString(),
                    SURNAME = dr["SURNAME"].ToString(),
                    USERNAME = dr["USERNAME"].ToString()
                };

                logs.Add(log);
            }

            return logs;
        }
    }
}
