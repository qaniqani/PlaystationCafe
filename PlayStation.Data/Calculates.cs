using System;
using System.Collections.Generic;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace PlayStation.Data
{
    public class Calculates
    {
        private readonly DataAccessLayer _db = new DataAccessLayer();

        public int Insert(Model.Calculates cal, out string message)
        {
            const string query = @"INSERT INTO CALCULATES(
                            MACHINEREF,
                            TARRIFSREF,
                            MACHINENR,
                            MACHINENAME,
                            STARTDATETIME,
                            STARTENDDATETIME,
                            USEDTIME,
                            DETAILS,
                            MACHINETOTAL,
                            ADDITIONNAME,
                            ADDITIONUNIT,
                            ADDITIONTOTAL,
                            CANCELREASON,
                            MACHINECLOSESTATUS,
                            STATUS,
                            DATETIME,
                            CREATEUSER,
                            MODIFIEDUSER,
                            MODIFIEDDATETIME
                                ) VALUES(
                            @MACHINEREF,
                            @TARRIFSREF,
                            @MACHINENR,
                            @MACHINENAME,
                            @STARTDATETIME,
                            @STARTENDDATETIME,
                            @USEDTIME,
                            @DETAILS,
                            @MACHINETOTAL,
                            @ADDITIONNAME,
                            @ADDITIONUNIT,
                            @ADDITIONTOTAL,
                            @CANCELREASON,
                            @MACHINECLOSESTATUS,
                            @STATUS,
                            @DATETIME,
                            @CREATEUSER,
                            @MODIFIEDUSER,
                            @MODIFIEDDATETIME)";

            var sp = new FbParameter[19];
            sp[0] = new FbParameter("@MACHINEREF", cal.MACHINEREF);
            sp[1] = new FbParameter("@TARRIFSREF", cal.TARRIFSREF);
            sp[2] = new FbParameter("@MACHINENR", cal.MACHINENR);
            sp[3] = new FbParameter("@MACHINENAME", cal.MACHINENAME);
            sp[4] = new FbParameter("@STARTDATETIME", cal.STARTDATETIME);
            sp[5] = new FbParameter("@STARTENDDATETIME", cal.STARTENDDATETIME);
            sp[6] = new FbParameter("@USEDTIME", cal.USEDTIME);
            sp[7] = new FbParameter("@DETAILS", cal.DETAILS);
            sp[8] = new FbParameter("@MACHINETOTAL", cal.MACHINETOTAL);
            sp[9] = new FbParameter("@ADDITIONNAME", cal.ADDITIONNAME);
            sp[10] = new FbParameter("@ADDITIONUNIT", cal.ADDITIONUNIT);
            sp[11] = new FbParameter("@ADDITIONTOTAL", cal.ADDITIONTOTAL);
            sp[12] = new FbParameter("@CANCELREASON", cal.CANCELREASON);
            sp[13] = new FbParameter("@MACHINECLOSESTATUS", cal.MACHINECLOSESTATUS);
            sp[14] = new FbParameter("@STATUS", cal.STATUS);
            sp[15] = new FbParameter("@DATETIME", cal.DATETIME);
            sp[16] = new FbParameter("@CREATEUSER", cal.CREATEUSER);
            sp[17] = new FbParameter("@MODIFIEDUSER", cal.MODIFIEDUSER);
            sp[18] = new FbParameter("@MODIFIEDDATETIME", cal.MODIFIEDDATETIME);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public int Update(Model.Calculates cal, out string message)
        {
            const string query = @"UPDATE CALCULATES SET
                            MACHINEREF=@MACHINEREF,
                            TARRIFSREF=@TARRIFSREF,
                            MACHINENR=@MACHINENR,
                            MACHINENAME=@MACHINENAME,
                            STARTDATETIME=@STARTDATETIME,
                            STARTENDDATETIME=@STARTENDDATETIME,
                            USEDTIME=@USEDTIME,
                            DETAILS=@DETAILS,
                            MACHINETOTAL=@MACHINETOTAL,
                            ADDITIONNAME=@ADDITIONNAME,
                            ADDITIONUNIT=@ADDITIONUNIT,
                            ADDITIONTOTAL=@ADDITIONTOTAL,
                            CANCELREASON=@CANCELREASON,
                            MACHINECLOSESTATUS=@MACHINECLOSESTATUS,
                            STATUS=@STATUS,
                            DATETIME=@DATETIME,
                            CREATEUSER=@CREATEUSER,
                            MODIFIEDUSER=@MODIFIEDUSER,
                            MODIFIEDDATETIME=@MODIFIEDDATETIME WHERE LREF=@LREF";

            var sp = new FbParameter[20];
            sp[0] = new FbParameter("@MACHINEREF", cal.MACHINEREF);
            sp[1] = new FbParameter("@TARRIFSREF", cal.TARRIFSREF);
            sp[2] = new FbParameter("@MACHINENR", cal.MACHINENR);
            sp[3] = new FbParameter("@MACHINENAME", cal.MACHINENAME);
            sp[4] = new FbParameter("@STARTDATETIME", cal.STARTDATETIME);
            sp[5] = new FbParameter("@STARTENDDATETIME", cal.STARTENDDATETIME);
            sp[6] = new FbParameter("@USEDTIME", cal.USEDTIME);
            sp[7] = new FbParameter("@DETAILS", cal.DETAILS);
            sp[8] = new FbParameter("@MACHINETOTAL", cal.MACHINETOTAL);
            sp[9] = new FbParameter("@ADDITIONNAME", cal.ADDITIONNAME);
            sp[10] = new FbParameter("@ADDITIONUNIT", cal.ADDITIONUNIT);
            sp[11] = new FbParameter("@ADDITIONTOTAL", cal.ADDITIONTOTAL);
            sp[12] = new FbParameter("@CANCELREASON", cal.CANCELREASON);
            sp[13] = new FbParameter("@MACHINECLOSESTATUS", cal.MACHINECLOSESTATUS);
            sp[14] = new FbParameter("@STATUS", cal.STATUS);
            sp[15] = new FbParameter("@DATETIME", cal.DATETIME);
            sp[16] = new FbParameter("@CREATEUSER", cal.CREATEUSER);
            sp[17] = new FbParameter("@MODIFIEDUSER", cal.MODIFIEDUSER);
            sp[18] = new FbParameter("@MODIFIEDDATETIME", cal.MODIFIEDDATETIME);
            sp[19] = new FbParameter("@LREF", cal.LREF);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public Model.Calculates Select(int lref)
        {
            var cal = new Model.Calculates();

            var query = "SELECT FIRST 1 * FROM CALCULATES WHERE LREF=" + lref + " ORDER BY LREF DESC";

            var dr = _db.GetDataRow(query, CommandType.Text, null);
            if (dr == null) return cal;
            cal.ADDITIONNAME = dr["ADDITIONNAME"].ToString();
            cal.ADDITIONTOTAL = Convert.ToDecimal(dr["ADDITIONTOTAL"].ToString());
            cal.ADDITIONUNIT = Convert.ToInt32(dr["ADDITIONUNIT"].ToString());
            cal.CANCELREASON = dr["CANCELREASON"].ToString();
            cal.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
            cal.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
            cal.DETAILS = dr["DETAILS"].ToString();
            cal.LREF = Convert.ToInt32(dr["LREF"].ToString());
            cal.MACHINENAME = dr["MACHINENAME"].ToString();
            cal.MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString());
            cal.MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString());
            cal.MACHINETOTAL = Convert.ToDecimal(dr["MACHINETOTAL"].ToString());
            cal.MODIFIEDDATETIME = dr["MODIFIEDDATETIME"] != DBNull.Value ? Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString()) : DateTime.Now;
            cal.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
            cal.STARTDATETIME = Convert.ToDateTime(dr["STARTDATETIME"].ToString());
            cal.STARTENDDATETIME = Convert.ToDateTime(dr["STARTENDDATETIME"].ToString());
            cal.MACHINECLOSESTATUS = Convert.ToInt32(dr["MACHINECLOSESTATUS"].ToString());
            cal.STATUS = Convert.ToInt32(dr["STATUS"].ToString());
            cal.TARRIFSREF = Convert.ToInt32(dr["TARRIFSREF"].ToString());
            cal.USEDTIME = Convert.ToDateTime(dr["USEDTIME"].ToString());

            return cal;
        }

        public Model.Calculates EmptyChangeSelect(int machineNr)
        {
            var cal = new Model.Calculates();

            var query = "SELECT FIRST 1 * FROM CALCULATES WHERE MACHINENR=" + machineNr + " ORDER BY LREF DESC";

            var dr = _db.GetDataRow(query, CommandType.Text, null);
            if (dr == null) return cal;

            cal.ADDITIONNAME = dr["ADDITIONNAME"].ToString();
            cal.ADDITIONTOTAL = Convert.ToDecimal(dr["ADDITIONTOTAL"].ToString());
            cal.ADDITIONUNIT = Convert.ToInt32(dr["ADDITIONUNIT"].ToString());
            cal.CANCELREASON = dr["CANCELREASON"].ToString();
            cal.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
            cal.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
            cal.DETAILS = dr["DETAILS"].ToString();
            cal.LREF = Convert.ToInt32(dr["LREF"].ToString());
            cal.MACHINENAME = dr["MACHINENAME"].ToString();
            cal.MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString());
            cal.MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString());
            cal.MACHINETOTAL = Convert.ToDecimal(dr["MACHINETOTAL"].ToString());
            cal.MODIFIEDDATETIME = dr["MODIFIEDDATETIME"] != DBNull.Value ? Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString()) : DateTime.Now;
            cal.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
            cal.STARTDATETIME = Convert.ToDateTime(dr["STARTDATETIME"].ToString());
            cal.STARTENDDATETIME = Convert.ToDateTime(dr["STARTENDDATETIME"].ToString());
            cal.MACHINECLOSESTATUS = Convert.ToInt32(dr["MACHINECLOSESTATUS"].ToString());
            cal.STATUS = Convert.ToInt32(dr["STATUS"].ToString());
            cal.TARRIFSREF = Convert.ToInt32(dr["TARRIFSREF"].ToString());
            cal.USEDTIME = Convert.ToDateTime(dr["USEDTIME"].ToString());

            return cal;
        }

        public Model.Calculates MachineCalc(int machineNr)
        {
            var cal = new Model.Calculates();

            var query = "SELECT FIRST 1 * FROM CALCULATES WHERE MACHINENR=" + machineNr + " AND STATUS<>" + (int)Model.Base.MachineType.Durduruldu + " AND STATUS<>" + (int)Model.Base.MachineType.Kapali + " ORDER BY LREF DESC";

            var dr = _db.GetDataRow(query, CommandType.Text, null);

            if (dr == null) return cal;

            cal.ADDITIONNAME = dr["ADDITIONNAME"].ToString();
            cal.ADDITIONTOTAL = Convert.ToDecimal(dr["ADDITIONTOTAL"].ToString());
            cal.ADDITIONUNIT = Convert.ToInt32(dr["ADDITIONUNIT"].ToString());
            cal.CANCELREASON = dr["CANCELREASON"].ToString();
            cal.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
            cal.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
            cal.DETAILS = dr["DETAILS"].ToString();
            cal.LREF = Convert.ToInt32(dr["LREF"].ToString());
            cal.MACHINENAME = dr["MACHINENAME"].ToString();
            cal.MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString());
            cal.MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString());
            cal.MACHINETOTAL = Convert.ToDecimal(dr["MACHINETOTAL"].ToString());
            cal.MODIFIEDDATETIME = Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString());
            cal.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
            cal.STARTDATETIME = Convert.ToDateTime(dr["STARTDATETIME"].ToString());
            cal.STARTENDDATETIME = Convert.ToDateTime(dr["STARTENDDATETIME"].ToString());
            cal.MACHINECLOSESTATUS = Convert.ToInt32(dr["MACHINECLOSESTATUS"].ToString());
            cal.STATUS = Convert.ToInt32(dr["STATUS"].ToString());
            cal.TARRIFSREF = Convert.ToInt32(dr["TARRIFSREF"].ToString());
            cal.USEDTIME = Convert.ToDateTime(dr["USEDTIME"].ToString());

            return cal;
        }

        public int Delete(int lref, out string Message)
        {
            var query = "DELETE FROM CALCULATES WHERE LREF=" + lref;

            return _db.FbExecute(query, CommandType.Text, null, out Message);
        }

        public List<Model.Calculates> Select()
        {
            var query = "SELECT * FROM CALCULATES ORDER BY NR ASC";

            var li = new List<Model.Calculates>();

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return li;
            
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var cal = new Model.Calculates();
                var dr = dt.Rows[i];

                cal.ADDITIONNAME = dr["ADDITIONNAME"].ToString();
                cal.ADDITIONTOTAL = Convert.ToDecimal(dr["ADDITIONTOTAL"].ToString());
                cal.ADDITIONUNIT = Convert.ToInt32(dr["ADDITIONUNIT"].ToString());
                cal.CANCELREASON = dr["CANCELREASON"].ToString();
                cal.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
                cal.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
                cal.DETAILS = dr["DETAILS"].ToString();
                cal.LREF = Convert.ToInt32(dr["LREF"].ToString());
                cal.MACHINENAME = dr["MACHINENAME"].ToString();
                cal.MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString());
                cal.MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString());
                cal.MACHINETOTAL = Convert.ToDecimal(dr["MACHINETOTAL"].ToString());
                cal.MODIFIEDDATETIME = Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString());
                cal.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
                cal.STARTDATETIME = Convert.ToDateTime(dr["STARTDATETIME"].ToString());
                cal.STARTENDDATETIME = Convert.ToDateTime(dr["STARTENDDATETIME"].ToString());
                cal.MACHINECLOSESTATUS = Convert.ToInt32(dr["MACHINECLOSESTATUS"].ToString());
                cal.STATUS = Convert.ToInt32(dr["STATUS"].ToString());
                cal.TARRIFSREF = Convert.ToInt32(dr["TARRIFSREF"].ToString());
                cal.USEDTIME = Convert.ToDateTime(dr["USEDTIME"].ToString());

                li.Add(cal);
            }

            return li;
        }

        public Model.Calculates SelectCloseMachineLastCalculate(int machineLref)
        {
            var cal = new Model.Calculates();
            var dt = DateTime.Now.AddHours(-1);
            var query = "SELECT FIRST 1 * FROM CALCULATES WHERE MACHINENR=" + machineLref + " AND STARTENDDATETIME>'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt) + "' ORDER BY LREF DESC";

            var dr = _db.GetDataRow(query, CommandType.Text, null);
            if (dr == null) return cal;

            cal.ADDITIONNAME = dr["ADDITIONNAME"].ToString();
            cal.ADDITIONTOTAL = Convert.ToDecimal(dr["ADDITIONTOTAL"].ToString());
            cal.ADDITIONUNIT = Convert.ToInt32(dr["ADDITIONUNIT"].ToString());
            cal.CANCELREASON = dr["CANCELREASON"].ToString();
            cal.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
            cal.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
            cal.DETAILS = dr["DETAILS"].ToString();
            cal.LREF = Convert.ToInt32(dr["LREF"].ToString());
            cal.MACHINENAME = dr["MACHINENAME"].ToString();
            cal.MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString());
            cal.MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString());
            cal.MACHINETOTAL = Convert.ToDecimal(dr["MACHINETOTAL"].ToString());
            cal.MODIFIEDDATETIME = Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString());
            cal.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
            cal.STARTDATETIME = Convert.ToDateTime(dr["STARTDATETIME"].ToString());
            cal.STARTENDDATETIME = Convert.ToDateTime(dr["STARTENDDATETIME"].ToString());
            cal.MACHINECLOSESTATUS = Convert.ToInt32(dr["MACHINECLOSESTATUS"].ToString());
            cal.STATUS = Convert.ToInt32(dr["STATUS"].ToString());
            cal.TARRIFSREF = Convert.ToInt32(dr["TARRIFSREF"].ToString());
            cal.USEDTIME = Convert.ToDateTime(dr["USEDTIME"].ToString());

            return cal;
        }

        public List<Model.Report> GetDayCalculates()
        {
            var li = new List<Model.Report>();

            var machineType = (int)Model.Base.MachineType.Durduruldu + "," + (int)Model.Base.MachineType.SuresizAcik;

            var query = @"SELECT T.NAME,C.* FROM CALCULATES C INNER JOIN TARRIFS T ON C.TARRIFSREF=T.LREF WHERE C.STATUS NOT IN (" + machineType + ") AND C.STARTENDDATETIME>'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Today) + "' AND C.STARTENDDATETIME<'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Today.AddDays(1).AddSeconds(-1)) + "' ORDER BY LREF DESC";

            var dt = _db.GetDataTable(query, CommandType.Text, null);

            if (dt == null) return li;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                var c = new Model.Report();
                c.ADDITIONNAME = dr["ADDITIONNAME"].ToString();
                c.ADDITIONTOTAL = Convert.ToDecimal(dr["ADDITIONTOTAL"].ToString());
                c.ADDITIONUNIT = Convert.ToInt32(dr["ADDITIONUNIT"].ToString());
                c.CANCELREASON = dr["CANCELREASON"].ToString();
                c.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
                c.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
                c.DETAILS = dr["DETAILS"].ToString();
                c.LREF = Convert.ToInt32(dr["LREF"].ToString());
                c.MACHINENAME = dr["MACHINENAME"].ToString();
                c.MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString());
                c.MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString());
                c.MACHINETOTAL = Convert.ToDecimal(dr["MACHINETOTAL"].ToString());
                c.MODIFIEDDATETIME = Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString());
                c.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
                c.STARTDATETIME = Convert.ToDateTime(dr["STARTDATETIME"].ToString());
                c.STARTENDDATETIME = Convert.ToDateTime(dr["STARTENDDATETIME"].ToString());
                c.MACHINECLOSESTATUS = Convert.ToInt32(dr["MACHINECLOSESTATUS"].ToString());
                c.STATUS = Convert.ToInt32(dr["STATUS"].ToString());
                c.TARRIFNAME = dr["NAME"].ToString();
                c.TARRIFSREF = Convert.ToInt32(dr["TARRIFSREF"].ToString());
                c.USEDTIME = Convert.ToDateTime(dr["USEDTIME"].ToString());

                li.Add(c);
            }

            return li;
        }

        public List<Model.Report> GetBetweenCalculates(DateTime dt, DateTime dt1)
        {
            var li = new List<Model.Report>();

            var machineType = (int)Model.Base.MachineType.Durduruldu + "," + (int)Model.Base.MachineType.OzelAcik + "," + (int)Model.Base.MachineType.SuresizAcik;

            var query = "SELECT T.NAME,C.* FROM CALCULATES C INNER JOIN TARRIFS T ON C.TARRIFSREF=T.LREF WHERE C.STATUS NOT IN (" + machineType + ") AND C.STARTENDDATETIME < '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt1) + "' AND C.STARTENDDATETIME > '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt) + "' ORDER BY LREF DESC";

            var dt2 = _db.GetDataTable(query, CommandType.Text, null);

            if (dt2 == null) return li;
            for (var i = 0; i < dt2.Rows.Count; i++)
            {
                var dr = dt2.Rows[i];
                var c = new Model.Report
                {
                    ADDITIONNAME = dr["ADDITIONNAME"].ToString(),
                    ADDITIONTOTAL = Convert.ToDecimal(dr["ADDITIONTOTAL"].ToString()),
                    ADDITIONUNIT = Convert.ToInt32(dr["ADDITIONUNIT"].ToString()),
                    CANCELREASON = dr["CANCELREASON"].ToString(),
                    CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString()),
                    DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString()),
                    DETAILS = dr["DETAILS"].ToString(),
                    LREF = Convert.ToInt32(dr["LREF"].ToString()),
                    MACHINENAME = dr["MACHINENAME"].ToString(),
                    MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString()),
                    MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString()),
                    MACHINETOTAL = Convert.ToDecimal(dr["MACHINETOTAL"].ToString()),
                    MODIFIEDDATETIME = Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString()),
                    MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString()),
                    STARTDATETIME = Convert.ToDateTime(dr["STARTDATETIME"].ToString()),
                    STARTENDDATETIME = Convert.ToDateTime(dr["STARTENDDATETIME"].ToString()),
                    MACHINECLOSESTATUS = Convert.ToInt32(dr["MACHINECLOSESTATUS"].ToString()),
                    STATUS = Convert.ToInt32(dr["STATUS"].ToString()),
                    TARRIFNAME = dr["NAME"].ToString(),
                    TARRIFSREF = Convert.ToInt32(dr["TARRIFSREF"].ToString()),
                    USEDTIME = Convert.ToDateTime(dr["USEDTIME"].ToString())
                };

                li.Add(c);
            }

            return li;
        }
    }
}
