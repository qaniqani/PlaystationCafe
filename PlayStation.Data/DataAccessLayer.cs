using System;
using System.Linq;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace PlayStation.Data
{
    public class DataAccessLayer
    {
        public static string InitialCatalog;
        public static string UserName;
        public static string Password;

        public static string CreateConnString()
        {
            var connString = string.Format("ServerType=1;USER={1};PASSWORD={2};Dialect=3;DATABASE={0};Role=CONSOLEPLUS;",
                                                InitialCatalog,
                                                UserName,
                                                Password
                                                );

            return connString;
        }

        public static FbConnection OpenMyConnection()
        {
            var conn = new FbConnection(CreateConnString());
            return conn;
        }

        public static void CloseMyConnection(FbConnection conn)
        {
            conn.Close();
            conn.Dispose();
        }

        public static bool ConnectionTest()
        {
            try
            {
                var conn = OpenMyConnection();
                conn.Open();
                CloseMyConnection(conn);
                return true;
            }
            catch { return false; }
        }

        public int FbExecute(string query, CommandType ct, FbParameter[] sp, out string message)
        {
            var conn = OpenMyConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                var tran = conn.BeginTransaction();

                var cmd = new FbCommand(query, conn, tran) {CommandType = ct};

                if (sp != null)
                {
                    for (var i = 0; i < sp.Length; i++)
                    {
                        if (sp[i] != null)
                            cmd.Parameters.Add(sp.ToList()[i]);
                    }
                }
                message = "";
                var asd = cmd.ExecuteNonQuery();
                tran.Commit();
                return asd;
            }
            catch (FbException ex)
            {
                message = "Bir hata oluştu. Hata kodu: " + ex.Message;
                return -1;
            }
            finally { CloseMyConnection(conn); }
        }

        public DataTable GetDataTable(string query, CommandType ct, FbParameter[] sp)
        {
            var conn = OpenMyConnection();

            var cmd = new FbCommand(query, conn) {CommandType = ct};

            if (sp != null)
            {
                for (var i = 0; i < sp.Count(); i++)
                    cmd.Parameters.Add(sp.ToList()[i]);
            }

            using (var da = new FbDataAdapter(cmd))
            {
                var dt = new DataTable();

                try
                {
                    da.Fill(dt);
                }
                catch
                {
                    // ignored
                }

                cmd.Dispose();
                CloseMyConnection(conn);
                return (dt.Rows.Count > 0 ? dt : null);
            }
        }

        public DataRow GetDataRow(string query, CommandType ct, FbParameter[] sp)
        {
            var conn = OpenMyConnection();
            var cmd = new FbCommand(query, conn) {CommandType = ct};

            if (sp != null)
            {
                for (var i = 0; i < sp.Count(); i++)
                    if (sp[i] != null)
                        cmd.Parameters.Add(sp.ToList()[i]);
            }

            using (var da = new FbDataAdapter(cmd))
            {
                var dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                CloseMyConnection(conn);
                cmd.Dispose();
                return (dt.Rows.Count > 0 ? dt.Rows[0] : null);
            }
        }

        public string GetCell(string query, CommandType ct, FbParameter[] sp)
        {
            var conn = OpenMyConnection();
            var cmd = new FbCommand(query, conn) {CommandType = ct};

            if (sp != null)
            {
                for (var i = 0; i < sp.Count(); i++)
                    cmd.Parameters.Add(sp.ToList()[i]);
            }

            using (var da = new FbDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);

                cmd.Dispose();
                CloseMyConnection(conn);
                return (dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : string.Empty);
            }
        }

        public bool Exists(string sqlQuery, out string message)
        {
            message = "";

            var conn = OpenMyConnection();
            var cmd = new FbCommand(sqlQuery, conn);
            var exists = false;
            try
            {
                conn.Open();
                exists = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                message = "Bir hata oluştu. Hata kodu: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }

            return exists;
        }
    }
}