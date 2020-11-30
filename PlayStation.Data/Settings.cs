using System;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace PlayStation.Data
{
    public class Settings
    {
        private readonly DataAccessLayer _db = new DataAccessLayer();

        public int Insert(Model.Settings set, out string message)
        {
            const string query = @"INSERT INTO SETTINGS(
                            VERSION,
                            MACHINECOUNT,
                            MACHINETAGNAME,
                            MACHINESTATUS,
                            MINIMUMTIME,
                            MINIMUMTOTAL,
                            ROUNDINGPRICE,
                            DATETIME,
                            ACTIVE, 
                            CREATEUSER, 
                            MODIFIEDUSER, 
                            MODIFIEDDATETIME
                                ) VALUES(
                            @VERSION, 
                            @MACHINECOUNT, 
                            @MACHINETAGNAME, 
                            @MACHINESTATUS,
                            @MINIMUMTIME, 
                            @MINIMUMTOTAL, 
                            @ROUNDINGPRICE, 
                            @DATETIME, 
                            @ACTIVE, 
                            @CREATEUSER, 
                            @MODIFIEDUSER, 
                            @MODIFIEDDATETIME)";

            var sp = new FbParameter[12];
            sp[0] = new FbParameter("@VERSION", set.VERSION);
            sp[1] = new FbParameter("@MACHINECOUNT", set.MACHINECOUNT);
            sp[2] = new FbParameter("@MACHINETAGNAME", set.MACHINETAGNAME);
            sp[3] = new FbParameter("@MACHINESTATUS", set.MACHINESTATUS);
            sp[4] = new FbParameter("@MINIMUMTIME", set.MINIMUMTIME);
            sp[5] = new FbParameter("@MINIMUMTOTAL", set.MINIMUMTOTAL);
            sp[6] = new FbParameter("@ROUNDINGPRICE", set.ROUNDINGPRICE);
            sp[7] = new FbParameter("@DATETIME", set.DATETIME);
            sp[8] = new FbParameter("@ACTIVE", set.ACTIVE);
            sp[9] = new FbParameter("@CREATEUSER", set.CREATEUSER);
            sp[10] = new FbParameter("@MODIFIEDUSER", set.MODIFIEDUSER);
            sp[11] = new FbParameter("@MODIFIEDDATETIME", set.MODIFIEDDATETIME);

            return _db.FbExecute(query, CommandType.Text, sp, out message);;
        }

        public Model.Settings Select(out string message)
        {
            var set = new Model.Settings();
            
            message = "";
            const string query = "SELECT FIRST 1 * FROM SETTINGS ORDER BY LREF DESC";

            var dr = _db.GetDataRow(query, CommandType.Text, null);
            if (dr == null) return set;

            set.ACTIVE = Convert.ToBoolean(Convert.ToInt32(dr["ACTIVE"].ToString()));
            set.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
            set.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
            set.LREF = Convert.ToInt32(dr["LREF"].ToString());
            set.MACHINECOUNT = Convert.ToInt32(dr["MACHINECOUNT"].ToString());
            set.MACHINETAGNAME = dr["MACHINETAGNAME"].ToString();
            set.MACHINESTATUS = Convert.ToBoolean(Convert.ToInt32(dr["MACHINESTATUS"].ToString()));
            set.MINIMUMTIME = Convert.ToDateTime(dr["MINIMUMTIME"].ToString());
            set.MINIMUMTOTAL = Convert.ToDecimal(dr["MINIMUMTOTAL"].ToString());
            set.MODIFIEDDATETIME = Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString());
            set.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
            set.ROUNDINGPRICE = Convert.ToDecimal(dr["ROUNDINGPRICE"].ToString());
            set.VERSION = Convert.ToInt32(dr["VERSION"].ToString());

            return set;
        }
    }
}
