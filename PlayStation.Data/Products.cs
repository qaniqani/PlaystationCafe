using System;
using System.Collections.Generic;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace PlayStation.Data
{
    public class Products
    {
        private readonly DataAccessLayer _db = new DataAccessLayer();

        public int Insert(Model.Products pro, out string Message)
        {
            const string query = @"INSERT INTO PRODUCTS(
                            NAME,
                            STOCK,
                            UNITPRICE,
                            DATETIME,
                            CREATEUSER,
                            MODIFIEDUSER,
                            MODIFIEDDATETIME
                                ) VALUES(
                            @NAME,
                            @STOCK,
                            @UNITPRICE,
                            @DATETIME,
                            @CREATEUSER,
                            @MODIFIEDUSER,
                            @MODIFIEDDATETIME)";

            var sp = new FbParameter[7];
            sp[0] = new FbParameter("@NAME", pro.NAME);
            sp[1] = new FbParameter("@STOCK", pro.STOCK);
            sp[2] = new FbParameter("@UNITPRICE", pro.UNITPRICE);
            sp[3] = new FbParameter("@DATETIME", pro.DATETIME);
            sp[4] = new FbParameter("@CREATEUSER", pro.CREATEUSER);
            sp[5] = new FbParameter("@MODIFIEDUSER", pro.MODIFIEDUSER);
            sp[6] = new FbParameter("@MODIFIEDDATETIME", pro.MODIFIEDDATETIME);

            return _db.FbExecute(query, CommandType.Text, sp, out Message);
        }

        public int Update(Model.Products pro, out string message)
        {
            const string query = @"UPDATE PRODUCTS SET
                            NAME=@NAME,
                            STOCK=@STOCK,
                            UNITPRICE=@UNITPRICE,
                            CREATEUSER=@CREATEUSER,
                            DATETIME=@DATETIME,
                            MODIFIEDUSER=@MODIFIEDUSER,
                            MODIFIEDDATETIME=@MODIFIEDDATETIME WHERE LREF=@LREF";

            var sp = new FbParameter[8];
            sp[0] = new FbParameter("@NAME", pro.NAME);
            sp[1] = new FbParameter("@STOCK", pro.STOCK);
            sp[2] = new FbParameter("@UNITPRICE", pro.UNITPRICE);
            sp[3] = new FbParameter("@DATETIME", pro.DATETIME.ToString());
            sp[4] = new FbParameter("@CREATEUSER", pro.CREATEUSER);
            sp[5] = new FbParameter("@MODIFIEDUSER", pro.MODIFIEDUSER);
            sp[6] = new FbParameter("@MODIFIEDDATETIME", pro.MODIFIEDDATETIME);
            sp[7] = new FbParameter("@LREF", pro.LREF);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public Model.Products Select(int lref)
        {
            var pro = new Model.Products();

            var query = "SELECT * FROM PRODUCTS WHERE LREF=" + lref;

            var dr = _db.GetDataRow(query, CommandType.Text, null);
            if (dr == null) return pro;

            pro.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
            pro.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
            pro.LREF = Convert.ToInt32(dr["LREF"].ToString());
            pro.MODIFIEDDATETIME = Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString());
            pro.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
            pro.NAME = dr["NAME"].ToString();
            pro.STOCK = Convert.ToInt32(dr["STOCK"].ToString());
            pro.UNITPRICE = Convert.ToDecimal(dr["UNITPRICE"].ToString());

            return pro;
        }

        public int Delete(int lref, out string message)
        {
            var query = "DELETE FROM PRODUCTS WHERE LREF=" + lref;

            return _db.FbExecute(query, CommandType.Text, null, out message); ;
        }

        public List<Model.Products> Select()
        {
            const string query = "SELECT * FROM PRODUCTS ORDER BY LREF DESC";

            var li = new List<Model.Products>();

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return li;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var pro = new Model.Products();
                var dr = dt.Rows[i];

                pro.CREATEUSER = Convert.ToInt32(dr["CREATEUSER"].ToString());
                pro.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
                pro.LREF = Convert.ToInt32(dr["LREF"].ToString());
                pro.MODIFIEDDATETIME = Convert.ToDateTime(dr["MODIFIEDDATETIME"].ToString());
                pro.MODIFIEDUSER = Convert.ToInt32(dr["MODIFIEDUSER"].ToString());
                pro.NAME = dr["NAME"].ToString();
                pro.STOCK = Convert.ToInt32(dr["STOCK"].ToString());
                pro.UNITPRICE = Convert.ToDecimal(dr["UNITPRICE"].ToString());

                li.Add(pro);
            }

            return li;
        }
    }
}
