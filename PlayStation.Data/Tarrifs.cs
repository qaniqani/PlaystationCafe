using System;
using System.Collections.Generic;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace PlayStation.Data
{
    public class Tarrifs
    {
        private readonly DataAccessLayer _db = new DataAccessLayer();

        public int Insert(Model.Tarrifs tar, out string message)
        {
            const string query = @"INSERT INTO TARRIFS(
                            NAME,
                            HOURPRICE,
                            MINUTEPRICE,
                            SELECTED,
                            ACTIVE,
                            DATETIME,
                            CREATEUSER,
                            MODIFIEDUSER,
                            MODIFIEDDATETIME
                                ) VALUES(
                            @NAME,
                            @HOURPRICE,
                            @MINUTEPRICE,
                            @SELECTED,
                            @ACTIVE,
                            @DATETIME,
                            @CREATEUSER,
                            @MODIFIEDUSER,
                            @MODIFIEDDATETIME)";

            var sp = new FbParameter[9];
            sp[0] = new FbParameter("@NAME", tar.NAME);
            sp[1] = new FbParameter("@HOURPRICE", tar.HOURPRICE);
            sp[2] = new FbParameter("@MINUTEPRICE", tar.MINUTEPRICE);
            sp[3] = new FbParameter("@SELECTED", tar.SELECTED);
            sp[4] = new FbParameter("@ACTIVE", tar.ACTIVE);
            sp[5] = new FbParameter("@DATETIME", tar.DATETIME);
            sp[6] = new FbParameter("@CREATEUSER", tar.CREATEUSER);
            sp[7] = new FbParameter("@MODIFIEDUSER", tar.MODIFIEDUSER);
            sp[8] = new FbParameter("@MODIFIEDDATETIME", tar.MODIFIEDDATETIME);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public int Update(Model.Tarrifs tar, out string message)
        {
            const string query = @"UPDATE TARRIFS SET
                            NAME=@NAME,
                            HOURPRICE=@HOURPRICE,
                            MINUTEPRICE=@MINUTEPRICE,
                            SELECTED=@SELECTED,
                            ACTIVE=@ACTIVE,
                            DATETIME=@DATETIME,
                            CREATEUSER=@CREATEUSER,
                            MODIFIEDUSER=@MODIFIEDUSER,
                            MODIFIEDDATETIME=@MODIFIEDDATETIME WHERE LREF=@LREF";

            var sp = new FbParameter[10];
            sp[0] = new FbParameter("@NAME", tar.NAME);
            sp[1] = new FbParameter("@HOURPRICE", tar.HOURPRICE);
            sp[2] = new FbParameter("@MINUTEPRICE", tar.MINUTEPRICE);
            sp[3] = new FbParameter("@SELECTED", tar.SELECTED);
            sp[4] = new FbParameter("@ACTIVE", tar.ACTIVE);
            sp[5] = new FbParameter("@DATETIME", tar.DATETIME);
            sp[6] = new FbParameter("@CREATEUSER", tar.CREATEUSER);
            sp[7] = new FbParameter("@MODIFIEDUSER", tar.MODIFIEDUSER);
            sp[8] = new FbParameter("@MODIFIEDDATETIME", tar.MODIFIEDDATETIME);
            sp[9] = new FbParameter("@LREF", tar.LREF);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public void UpdateSelectFalse()
        {
            string message;

            const string query = @"UPDATE TARRIFS SET SELECTED=0";

            _db.FbExecute(query, CommandType.Text, null, out message);
        }

        public Model.Tarrifs Select(int lref)
        {
            var tar = new Model.Tarrifs();

            var query = "SELECT * FROM TARRIFS WHERE LREF=" + lref;

            var dr = _db.GetDataRow(query, CommandType.Text, null);

            if (dr == null) return tar;

            tar.ACTIVE = Convert.ToBoolean(Convert.ToInt32(dr["ACTIVE"].ToString()));
            tar.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
            tar.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
            tar.HOURPRICE = Convert.ToDecimal(dr["HOURPRICE"].ToString());
            tar.LREF = Convert.ToInt32(dr["LREF"].ToString());
            tar.MINUTEPRICE = Convert.ToDecimal(dr["MINUTEPRICE"].ToString());
            tar.MODIFIEDDATETIME = Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString());
            tar.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
            tar.NAME = dr["NAME"].ToString();
            tar.SELECTED = Convert.ToBoolean(Convert.ToInt32(dr["SELECTED"].ToString()));

            return tar;
        }

        public Model.Tarrifs Selected()
        {
            var tar = new Model.Tarrifs();

            const string query = "SELECT * FROM TARRIFS WHERE SELECTED=1";

            var dr = _db.GetDataRow(query, CommandType.Text, null);

            if (dr == null) return tar;

            tar.ACTIVE = Convert.ToBoolean(Convert.ToInt32(dr["ACTIVE"].ToString()));
            tar.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
            tar.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
            tar.HOURPRICE = Convert.ToDecimal(dr["HOURPRICE"].ToString());
            tar.LREF = Convert.ToInt32(dr["LREF"].ToString());
            tar.MINUTEPRICE = Convert.ToDecimal(dr["MINUTEPRICE"].ToString());
            tar.MODIFIEDDATETIME = Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString());
            tar.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
            tar.NAME = dr["NAME"].ToString();
            tar.SELECTED = Convert.ToBoolean(Convert.ToInt32(dr["SELECTED"].ToString()));

            return tar;
        }

        public int Delete(int lref, out string Message)
        {
            var query = "DELETE FROM TARRIFS WHERE LREF=" + lref;

            return _db.FbExecute(query, CommandType.Text, null, out Message); ;
        }

        public List<Model.Tarrifs> Select()
        {
            const string query = "SELECT * FROM TARRIFS ORDER BY LREF DESC";

            var li = new List<Model.Tarrifs>();

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return li;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var tar = new Model.Tarrifs();
                var dr = dt.Rows[i];

                tar.ACTIVE = Convert.ToBoolean(Convert.ToInt32(dr["ACTIVE"].ToString()));
                tar.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
                tar.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
                tar.HOURPRICE = Convert.ToDecimal(dr["HOURPRICE"].ToString());
                tar.LREF = Convert.ToInt32(dr["LREF"].ToString());
                tar.MINUTEPRICE = Convert.ToDecimal(dr["MINUTEPRICE"].ToString());
                tar.MODIFIEDDATETIME = Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString());
                tar.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
                tar.NAME = dr["NAME"].ToString();
                tar.SELECTED = Convert.ToBoolean(Convert.ToInt32(dr["SELECTED"].ToString()));

                li.Add(tar);
            }

            return li;
        }
    }
}
