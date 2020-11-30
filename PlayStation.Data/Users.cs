using System;
using System.Collections.Generic;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace PlayStation.Data
{
    public class Users
    {
        private readonly DataAccessLayer _db = new DataAccessLayer();

        public int Insert(Model.Users user, out string message)
        {
            const string query = @"INSERT INTO USERS(
                            TYPE,
                            NAME,
                            SURNAME,
                            USERNAME,
                            PASSWORD,
                            CHANGESTARTTIME,
                            DATETIME,
                            ACTIVE
                                ) VALUES(
                            @TYPE, 
                            @NAME, 
                            @SURNAME, 
                            @USERNAME,
                            @PASSWORD, 
                            @CHANGESTARTTIME, 
                            @DATETIME, 
                            @ACTIVE)";

            var sp = new FbParameter[8];
            sp[0] = new FbParameter("@TYPE", user.TYPE);
            sp[1] = new FbParameter("@NAME", user.NAME);
            sp[2] = new FbParameter("@SURNAME", user.SURNAME);
            sp[3] = new FbParameter("@USERNAME", user.USERNAME);
            sp[4] = new FbParameter("@PASSWORD", Functions.Function.EncryptIt(user.PASSWORD));
            sp[5] = new FbParameter("@CHANGESTARTTIME", user.CHANGESTARTTIME);
            sp[6] = new FbParameter("@DATETIME", user.DATETIME);
            sp[7] = new FbParameter("@ACTIVE", user.ACTIVE);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public int Update(Model.Users user, out string message)
        {
            const string query = @"UPDATE USERS SET
                            TYPE=@TYPE,
                            NAME=@NAME,
                            SURNAME=@SURNAME,
                            USERNAME=@USERNAME,
                            PASSWORD=@PASSWORD,
                            CHANGESTARTTIME=@CHANGESTARTTIME,
                            DATETIME=@DATETIME,
                            ACTIVE=@ACTIVE WHERE LREF=@LREF";

            var sp = new FbParameter[9];
            sp[0] = new FbParameter("@TYPE", user.TYPE);
            sp[1] = new FbParameter("@NAME", user.NAME);
            sp[2] = new FbParameter("@SURNAME", user.SURNAME);
            sp[3] = new FbParameter("@USERNAME", user.USERNAME);
            sp[4] = new FbParameter("@PASSWORD", Functions.Function.EncryptIt(user.PASSWORD));
            sp[5] = new FbParameter("@CHANGESTARTTIME", user.CHANGESTARTTIME);
            sp[6] = new FbParameter("@DATETIME", user.DATETIME);
            sp[7] = new FbParameter("@ACTIVE", user.ACTIVE);
            sp[8] = new FbParameter("@LREF", user.LREF);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public Model.Users SingleSelect(int lref)
        {
            var user = new Model.Users();

            var query = "SELECT * FROM USERS WHERE LREF=" + lref;

            var dr = _db.GetDataRow(query, CommandType.Text, null);
            if (dr == null) return user;
            user.ACTIVE = Convert.ToBoolean(Convert.ToInt32(dr["ACTIVE"].ToString()));
            user.CHANGESTARTTIME = Convert.ToBoolean(Convert.ToInt32(dr["CHANGESTARTTIME"].ToString()));
            user.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
            user.LREF = Convert.ToInt32(dr["LREF"].ToString());
            user.NAME = dr["NAME"].ToString();
            user.PASSWORD = Functions.Function.DecryptIt(dr["PASSWORD"].ToString());
            user.SURNAME = dr["SURNAME"].ToString();
            user.TYPE = Convert.ToInt32(dr["TYPE"].ToString());
            user.USERNAME = dr["USERNAME"].ToString();

            return user;
        }

        public int Delete(int lref, out string message)
        {
            var query = "DELETE FROM USERS WHERE LREF=" + lref;

            return _db.FbExecute(query, CommandType.Text, null, out message); ;
        }

        public List<Model.Users> Select()
        {
            const string query = "SELECT * FROM USERS ORDER BY LREF DESC";

            var li = new List<Model.Users>();

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return li;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var user = new Model.Users();
                var dr = dt.Rows[i];

                user.ACTIVE = Convert.ToBoolean(Convert.ToInt32(dr["ACTIVE"].ToString()));
                user.CHANGESTARTTIME = Convert.ToBoolean(Convert.ToInt32(dr["CHANGESTARTTIME"].ToString()));
                user.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
                user.LREF = Convert.ToInt32(dr["LREF"].ToString());
                user.NAME = dr["NAME"].ToString();
                user.PASSWORD = Functions.Function.DecryptIt(dr["PASSWORD"].ToString());
                user.SURNAME = dr["SURNAME"].ToString();
                user.TYPE = Convert.ToInt32(dr["TYPE"].ToString());
                user.USERNAME = dr["USERNAME"].ToString();

                li.Add(user);
            }

            return li;
        }

        public Model.Users SelectUser(string userName, string password)
        {
            var user = new Model.Users();

            const string query = "SELECT * FROM USERS WHERE USERNAME=@USERNAME AND PASSWORD=@PASSWORD AND ACTIVE=1";

            var sp = new FbParameter[3];
            sp[0] = new FbParameter("@USERNAME", userName);
            sp[1] = new FbParameter("@PASSWORD", Functions.Function.EncryptIt(password));

            var dr = _db.GetDataRow(query, CommandType.Text, sp);

            if (dr == null) return user;

            user.ACTIVE = Convert.ToBoolean(Convert.ToInt32(dr["ACTIVE"].ToString()));
            user.CHANGESTARTTIME = Convert.ToBoolean(Convert.ToInt32(dr["CHANGESTARTTIME"].ToString()));
            user.DATETIME = Convert.ToDateTime(dr["DATETIME"].ToString());
            user.LREF = Convert.ToInt32(dr["LREF"].ToString());
            user.NAME = dr["NAME"].ToString();
            user.PASSWORD = Functions.Function.DecryptIt(dr["PASSWORD"].ToString());
            user.SURNAME = dr["SURNAME"].ToString();
            user.TYPE = Convert.ToInt32(dr["TYPE"].ToString());
            user.USERNAME = dr["USERNAME"].ToString();

            return user;
        }
    }
}
