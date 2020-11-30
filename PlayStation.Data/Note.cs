using System;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace PlayStation.Data
{
    public class Note
    {
        private readonly DataAccessLayer _db = new DataAccessLayer();

        public int Insert(Model.Note note, out string message)
        {
            const string query = @"INSERT INTO NOTES(
                            NOTE,
                            CREATEDATE
                                ) VALUES(
                            @NOTE,
                            @CREATEDATE)";

            var sp = new FbParameter[5];
            sp[0] = new FbParameter("@NOTE", note.NOTE);
            sp[1] = new FbParameter("@CREATEDATE", note.CREATEDATE);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public Model.Note Select()
        {
            var note = new Model.Note();

            const string query = @"SELECT FIRST 1 * FROM NOTES ORDER BY LREF DESC";

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return note;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];

                note.CREATEDATE = Convert.ToDateTime(dr["CREATEDATE"].ToString());
                note.NOTE = dr["NOTE"].ToString();
                note.LREF = Convert.ToInt32(dr["LREF"].ToString());
            }

            return note;
        }
    }
}
