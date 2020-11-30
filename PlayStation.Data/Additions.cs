using System;
using System.Collections.Generic;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace PlayStation.Data
{
    public class Additions
    {
        private readonly DataAccessLayer _db = new DataAccessLayer();

        public int Insert(Model.Addition adds, out string message)
        {
            const string query = @"INSERT INTO ADDITIONS(
                            MACHINEREF,
                            MACHINENR,
                            MACHINENAME,
                            PRODUCTREF,
                            PRODUCTNAME,
                            PRODUCTUNITS,
                            PRODUCTSPRICES,
                            NOTE,
                            DATETIME,
                            STATUS
                                ) VALUES(
                            @MACHINEREF,
                            @MACHINENR,
                            @MACHINENAME,
                            @PRODUCTREF,
                            @PRODUCTNAME,
                            @PRODUCTUNITS,
                            @PRODUCTSPRICES,
                            @NOTE,
                            @DATETIME,
                            @STATUS)";

            var sp = new FbParameter[10];
            sp[0] = new FbParameter("@MACHINEREF", adds.MACHINEREF);
            sp[1] = new FbParameter("@MACHINENR", adds.MACHINENR);
            sp[2] = new FbParameter("@MACHINENAME", adds.MACHINENAME);
            sp[3] = new FbParameter("@PRODUCTREF", adds.PRODUCTREF);
            sp[4] = new FbParameter("@PRODUCTNAME", adds.PRODUCTNAME);
            sp[5] = new FbParameter("@PRODUCTUNITS", adds.PRODUCTSUNIT);
            sp[6] = new FbParameter("@PRODUCTSPRICES", adds.PRODUCTSPRICES);
            sp[7] = new FbParameter("@NOTE", adds.NOTE);
            sp[8] = new FbParameter("@DATETIME", adds.DATETIME);
            sp[9] = new FbParameter("@STATUS", adds.STATUS);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public int Update(Model.Addition adds, out string message)
        {
            const string query = @"UPDATE ADDITIONS SET
                            MACHINEREF=@MACHINEREF,
                            MACHINENR=@MACHINENR,
                            MACHINENAME=@MACHINENAME,
                            PRODUCTREF=@PRODUCTREF,
                            PRODUCTNAME=@PRODUCTNAME,
                            PRODUCTUNITS=@PRODUCTUNITS,
                            PRODUCTSPRICES=@PRODUCTSPRICES,
                            NOTE=@NOTE,
                            DATETIME=@DATETIME,
                            STATUS=@STATUS WHERE LREF=@LREF";

            var sp = new FbParameter[11];
            sp[0] = new FbParameter("@MACHINEREF", adds.MACHINEREF);
            sp[1] = new FbParameter("@MACHINENR", adds.MACHINENR);
            sp[2] = new FbParameter("@MACHINENAME", adds.MACHINENAME);
            sp[3] = new FbParameter("@PRODUCTREF", adds.PRODUCTREF);
            sp[4] = new FbParameter("@PRODUCTNAME", adds.PRODUCTNAME);
            sp[5] = new FbParameter("@PRODUCTUNITS", adds.PRODUCTSUNIT);
            sp[6] = new FbParameter("@PRODUCTSPRICES", adds.PRODUCTSPRICES);
            sp[7] = new FbParameter("@NOTE", adds.NOTE);
            sp[8] = new FbParameter("@DATETIME", adds.DATETIME);
            sp[9] = new FbParameter("@STATUS", adds.STATUS);
            sp[10] = new FbParameter("@LREF", adds.LREF);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public Model.Addition Select(int lref)
        {
            var adds = new Model.Addition();

            var query = "SELECT * FROM ADDITIONS WHERE LREF=" + lref;

            var dr = _db.GetDataRow(query, CommandType.Text, null);
            if (dr == null) return adds;

            adds.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
            adds.LREF = Convert.ToInt32(dr["LREF"].ToString());
            adds.MACHINENAME = dr["MACHINENAME"].ToString();
            adds.MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString());
            adds.MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString());
            adds.NOTE = dr["NOTE"].ToString();
            adds.PRODUCTNAME = dr["PRODUCTNAME"].ToString();
            adds.PRODUCTREF = Convert.ToInt32(dr["PRODUCTREF"].ToString());
            adds.PRODUCTSPRICES = Convert.ToDecimal(dr["PRODUCTSPRICES"].ToString());
            adds.PRODUCTSUNIT = Convert.ToInt32(dr["PRODUCTUNITS"].ToString());
            adds.STATUS = Convert.ToInt32(dr["STATUS"].ToString());

            return adds;
        }

        public int Delete(int lref, out string message)
        {
            var query = "DELETE FROM ADDITIONS WHERE LREF=" + lref;

            return _db.FbExecute(query, CommandType.Text, null, out message); ;
        }

        public List<Model.Addition> CalculatesBackNotPaidSelect(int machineNr)
        {
            var query = "SELECT * FROM ADDITIONS WHERE MACHINENR='" + machineNr + "' AND STATUS=" + (int)Model.Base.AdditionStatus.HesapKapatildi + " ORDER BY LREF DESC";

            var li = new List<Model.Addition>();

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return li;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var adds = new Model.Addition();
                var dr = dt.Rows[i];

                adds.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
                adds.LREF = Convert.ToInt32(dr["LREF"].ToString());
                adds.MACHINENAME = dr["MACHINENAME"].ToString();
                adds.MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString());
                adds.MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString());
                adds.NOTE = dr["NOTE"].ToString();
                adds.PRODUCTNAME = dr["PRODUCTNAME"].ToString();
                adds.PRODUCTREF = Convert.ToInt32(dr["PRODUCTREF"].ToString());
                adds.PRODUCTSPRICES = Convert.ToDecimal(dr["PRODUCTSPRICES"].ToString());
                adds.PRODUCTSUNIT = Convert.ToInt32(dr["PRODUCTUNITS"].ToString());
                adds.STATUS = Convert.ToInt32(dr["STATUS"].ToString());

                li.Add(adds);
            }

            return li;
        }

        public List<Model.Addition> NotPaidSelect(int machineNr)
        {
            var query = "SELECT * FROM ADDITIONS WHERE MACHINENR='" + machineNr + "' AND STATUS=" + (int)Model.Base.AdditionStatus.Odenmedi + " ORDER BY LREF DESC";

            var li = new List<Model.Addition>();

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return li;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var adds = new Model.Addition();
                var dr = dt.Rows[i];

                adds.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
                adds.LREF = Convert.ToInt32(dr["LREF"].ToString());
                adds.MACHINENAME = dr["MACHINENAME"].ToString();
                adds.MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString());
                adds.MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString());
                adds.NOTE = dr["NOTE"].ToString();
                adds.PRODUCTNAME = dr["PRODUCTNAME"].ToString();
                adds.PRODUCTREF = Convert.ToInt32(dr["PRODUCTREF"].ToString());
                adds.PRODUCTSPRICES = Convert.ToDecimal(dr["PRODUCTSPRICES"].ToString());
                adds.PRODUCTSUNIT = Convert.ToInt32(dr["PRODUCTUNITS"].ToString());
                adds.STATUS = Convert.ToInt32(dr["STATUS"].ToString());

                li.Add(adds);
            }

            return li;
        }

        public List<Model.Addition> PaidSelect()
        {
            var query = "SELECT * FROM ADDITIONS WHERE STATUS=" + (int)Model.Base.AdditionStatus.Odendi + " ORDER BY LREF DESC";

            var li = new List<Model.Addition>();

            var dt = _db.GetDataTable(query, CommandType.Text, null);

            if (dt == null) return li;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var adds = new Model.Addition();
                var dr = dt.Rows[i];

                adds.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
                adds.LREF = Convert.ToInt32(dr["LREF"].ToString());
                adds.MACHINENAME = dr["MACHINENAME"].ToString();
                adds.MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString());
                adds.MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString());
                adds.NOTE = dr["NOTE"].ToString();
                adds.PRODUCTNAME = dr["PRODUCTNAME"].ToString();
                adds.PRODUCTREF = Convert.ToInt32(dr["PRODUCTREF"].ToString());
                adds.PRODUCTSPRICES = Convert.ToDecimal(dr["PRODUCTSPRICES"].ToString());
                adds.PRODUCTSUNIT = Convert.ToInt32(dr["PRODUCTUNITS"].ToString());
                adds.STATUS = Convert.ToInt32(dr["STATUS"].ToString());

                li.Add(adds);
            }

            return li;
        }

        public List<Model.Addition> PaidSelect(int machineNr)
        {
            var query = "SELECT * FROM ADDITIONS WHERE MACHINENR=" + machineNr + " AND STATUS IN (" + (int)Model.Base.AdditionStatus.Odendi + ", " + (int)Model.Base.AdditionStatus.HesapKapatildi + ") ORDER BY LREF DESC";

            var li = new List<Model.Addition>();

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return li;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var adds = new Model.Addition();
                var dr = dt.Rows[i];

                adds.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
                adds.LREF = Convert.ToInt32(dr["LREF"].ToString());
                adds.MACHINENAME = dr["MACHINENAME"].ToString();
                adds.MACHINENR = Convert.ToInt32(dr["MACHINENR"].ToString());
                adds.MACHINEREF = Convert.ToInt32(dr["MACHINEREF"].ToString());
                adds.NOTE = dr["NOTE"].ToString();
                adds.PRODUCTNAME = dr["PRODUCTNAME"].ToString();
                adds.PRODUCTREF = Convert.ToInt32(dr["PRODUCTREF"].ToString());
                adds.PRODUCTSPRICES = Convert.ToDecimal(dr["PRODUCTSPRICES"].ToString());
                adds.PRODUCTSUNIT = Convert.ToInt32(dr["PRODUCTUNITS"].ToString());
                adds.STATUS = Convert.ToInt32(dr["STATUS"].ToString());

                li.Add(adds);
            }

            return li;
        }
    }
}
