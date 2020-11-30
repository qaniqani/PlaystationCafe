using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using FirebirdSql.Data.FirebirdClient;

namespace PlayStation.Data
{
    public class Machine
    {
        private readonly DataAccessLayer _db = new DataAccessLayer();
        private readonly Additions _add = new Additions();
        private readonly Calculates _cal = new Calculates();

        private static Model.Machine _dragMachine;
        private static Model.Machine _dragMachine2;
        private static Model.Machine _dropMachine;

        public int Insert(Model.Machine mac, out string message)
        {
            const string query = @"INSERT INTO MACHINE(
                            NR,
                            BYTENAME,
                            BYTENR,
                            NAME,
                            STARTDATETIME,
                            HOLDDATETIME,
                            HOLDENDDATETIME,
                            ENDDATETIME,
                            MACHINESTATUS,
                            TARRIFSREF,
                            SELECTEDTARRIF
                                ) VALUES(
                            @NR,
                            @BYTENAME,
                            @BYTENR,
                            @NAME,
                            @STARTDATETIME,
                            @HOLDDATETIME,
                            @HOLDENDDATETIME,
                            @ENDDATETIME,
                            @MACHINESTATUS,
                            @TARRIFSREF,
                            @SELECTEDTARRIF)";

            var sp = new FbParameter[11];
            sp[0] = new FbParameter("@NR", mac.NR);
            sp[1] = new FbParameter("@BYTENAME", mac.BYTENAME);
            sp[2] = new FbParameter("@BYTENR", mac.BYTENR);
            sp[3] = new FbParameter("@NAME", mac.NAME);
            sp[4] = new FbParameter("@STARTDATETIME", mac.STARTDATETIME);
            sp[5] = new FbParameter("@HOLDDATETIME", mac.HOLDDATETIME);
            sp[6] = new FbParameter("@HOLDENDDATETIME", mac.HOLDENDDATETIME);
            sp[7] = new FbParameter("@ENDDATETIME", mac.ENDDATETIME);
            sp[8] = new FbParameter("@MACHINESTATUS", mac.MACHINESTATUS);
            sp[9] = new FbParameter("@TARRIFSREF", mac.TARRIFSREF);
            sp[10] = new FbParameter("@SELECTEDTARRIF", mac.SELECTEDTARRIF);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public int Update(Model.Machine mac, out string message)
        {
            const string query = @"UPDATE MACHINE SET
                            NR=@NR,
                            BYTENAME=@BYTENAME,
                            BYTENR=@BYTENR,
                            NAME=@NAME,
                            STARTDATETIME=@STARTDATETIME,
                            HOLDDATETIME=@HOLDDATETIME,
                            HOLDENDDATETIME=@HOLDENDDATETIME,
                            ENDDATETIME=@ENDDATETIME,
                            MACHINESTATUS=@MACHINESTATUS,
                            SELECTEDTARRIF=@SELECTEDTARRIF,
                            TARRIFSREF=@TARRIFSREF WHERE LREF=@LREF";

            var sp = new FbParameter[12];
            sp[0] = new FbParameter("@NR", mac.NR);
            sp[1] = new FbParameter("@BYTENAME", mac.BYTENAME);
            sp[2] = new FbParameter("@BYTENR", mac.BYTENR);
            sp[3] = new FbParameter("@NAME", mac.NAME);
            sp[4] = new FbParameter("@STARTDATETIME", mac.STARTDATETIME);
            sp[5] = new FbParameter("@HOLDDATETIME", mac.HOLDDATETIME);
            sp[6] = new FbParameter("@HOLDENDDATETIME", mac.HOLDENDDATETIME);
            sp[7] = new FbParameter("@ENDDATETIME", mac.ENDDATETIME);
            sp[8] = new FbParameter("@MACHINESTATUS", mac.MACHINESTATUS);
            sp[9] = new FbParameter("@TARRIFSREF", mac.TARRIFSREF);
            sp[10] = new FbParameter("@SELECTEDTARRIF", mac.SELECTEDTARRIF);
            sp[11] = new FbParameter("@LREF", mac.LREF);

            return _db.FbExecute(query, CommandType.Text, sp, out message);
        }

        public Model.Machine Select(int lref)
        {
            var mac = new Model.Machine();

            var query = "SELECT * FROM MACHINE WHERE NR=" + lref;

            var dr = _db.GetDataRow(query, CommandType.Text, null);
            if (dr == null) return mac;

            mac.BYTENAME = dr["BYTENAME"].ToString();
            mac.BYTENR = Convert.ToInt32(dr["BYTENR"].ToString());
            mac.ENDDATETIME = Convert.ToDateTime(dr["ENDDATETIME"].ToString());
            mac.HOLDDATETIME = Convert.ToDateTime(dr["HOLDDATETIME"].ToString());
            mac.HOLDENDDATETIME = Convert.ToDateTime(dr["HOLDENDDATETIME"].ToString());
            mac.LREF = Convert.ToInt32(dr["LREF"].ToString());
            mac.MACHINESTATUS = Convert.ToInt32(dr["MACHINESTATUS"].ToString());
            mac.NAME = dr["NAME"].ToString();
            mac.NR = Convert.ToInt32(dr["NR"].ToString());
            mac.STARTDATETIME = Convert.ToDateTime(dr["STARTDATETIME"].ToString());
            mac.TARRIFSREF = Convert.ToInt32(Convert.ToInt32(dr["TARRIFSREF"].ToString()));
            mac.SELECTEDTARRIF = Convert.ToInt32(Convert.ToInt32(dr["SELECTEDTARRIF"].ToString()));

            return mac;
        }

        public int Delete(int lref, out string message)
        {
            var query = "DELETE FROM MACHINE WHERE LREF=" + lref;

            return _db.FbExecute(query, CommandType.Text, null, out message);
        }

        public int TruncateTable()
        {
            const string query = "DELETE FROM MACHINE";
            string message;
            return _db.FbExecute(query, CommandType.Text, null, out message);
        }

        public List<Model.Machine> EmptyMachine()
        {
            var query = "SELECT * FROM MACHINE WHERE MACHINESTATUS = '" + (int)Model.Base.MachineType.Kapali + "' ORDER BY NR ASC";

            var li = new List<Model.Machine>();

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return li;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var mac = new Model.Machine();
                var dr = dt.Rows[i];

                mac.BYTENAME = dr["BYTENAME"].ToString();
                mac.BYTENR = Convert.ToInt32(dr["BYTENR"].ToString());
                mac.ENDDATETIME = Convert.ToDateTime(dr["ENDDATETIME"].ToString());
                mac.HOLDDATETIME = Convert.ToDateTime(dr["HOLDDATETIME"].ToString());
                mac.HOLDENDDATETIME = Convert.ToDateTime(dr["HOLDENDDATETIME"].ToString());
                mac.LREF = Convert.ToInt32(dr["LREF"].ToString());
                mac.MACHINESTATUS = Convert.ToInt32(dr["MACHINESTATUS"].ToString());
                mac.NAME = dr["NAME"].ToString();
                mac.NR = Convert.ToInt32(dr["NR"].ToString());
                mac.STARTDATETIME = Convert.ToDateTime(dr["STARTDATETIME"].ToString());
                mac.TARRIFSREF = Convert.ToInt32(Convert.ToInt32(dr["TARRIFSREF"].ToString()));
                mac.SELECTEDTARRIF = Convert.ToInt32(Convert.ToInt32(dr["SELECTEDTARRIF"].ToString()));

                li.Add(mac);
            }

            return li;
        }

        public List<Model.Machine> Select()
        {
            const string query = "SELECT * FROM MACHINE ORDER BY NR ASC";

            var li = new List<Model.Machine>();

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return li;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var mac = new Model.Machine();
                var dr = dt.Rows[i];

                mac.BYTENAME = dr["BYTENAME"].ToString();
                mac.BYTENR = Convert.ToInt32(dr["BYTENR"].ToString());
                mac.ENDDATETIME = Convert.ToDateTime(dr["ENDDATETIME"].ToString());
                mac.HOLDDATETIME = Convert.ToDateTime(dr["HOLDDATETIME"].ToString());
                mac.HOLDENDDATETIME = Convert.ToDateTime(dr["HOLDENDDATETIME"].ToString());
                mac.LREF = Convert.ToInt32(dr["LREF"].ToString());
                mac.MACHINESTATUS = Convert.ToInt32(dr["MACHINESTATUS"].ToString());
                mac.NAME = dr["NAME"].ToString();
                mac.NR = Convert.ToInt32(dr["NR"].ToString());
                mac.STARTDATETIME = Convert.ToDateTime(dr["STARTDATETIME"].ToString());
                mac.TARRIFSREF = Convert.ToInt32(Convert.ToInt32(dr["TARRIFSREF"].ToString()));
                mac.SELECTEDTARRIF = Convert.ToInt32(Convert.ToInt32(dr["SELECTEDTARRIF"].ToString()));

                li.Add(mac);
            }

            return li;
        }

        public List<Model.Machine> ExpiredTime()
        {
            var query = "SELECT * FROM MACHINE WHERE MACHINESTATUS=2 AND ENDDATETIME <= '"+ DateTime.Now.ToString(CultureInfo.InvariantCulture) +"' ORDER BY NR ASC";

            var li = new List<Model.Machine>();

            var dt = _db.GetDataTable(query, CommandType.Text, null);
            if (dt == null) return li;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var mac = new Model.Machine();
                var dr = dt.Rows[i];

                mac.BYTENAME = dr["BYTENAME"].ToString();
                mac.BYTENR = Convert.ToInt32(dr["BYTENR"].ToString());
                mac.ENDDATETIME = Convert.ToDateTime(dr["ENDDATETIME"].ToString());
                mac.HOLDDATETIME = Convert.ToDateTime(dr["HOLDDATETIME"].ToString());
                mac.HOLDENDDATETIME = Convert.ToDateTime(dr["HOLDENDDATETIME"].ToString());
                mac.LREF = Convert.ToInt32(dr["LREF"].ToString());
                mac.MACHINESTATUS = Convert.ToInt32(dr["MACHINESTATUS"].ToString());
                mac.NAME = dr["NAME"].ToString();
                mac.NR = Convert.ToInt32(dr["NR"].ToString());
                mac.STARTDATETIME = Convert.ToDateTime(dr["STARTDATETIME"].ToString());
                mac.TARRIFSREF = Convert.ToInt32(Convert.ToInt32(dr["TARRIFSREF"].ToString()));
                mac.SELECTEDTARRIF = Convert.ToInt32(Convert.ToInt32(dr["SELECTEDTARRIF"].ToString()));

                li.Add(mac);
            }

            return li;
        }

        public void EmptyChangeMachine(Model.Machine selectedMachine, Model.Machine changeMachine)
        {
            var m = selectedMachine;
            var ch = changeMachine;
            var adds = _add.NotPaidSelect(selectedMachine.NR);

            #region //Hesabi Aktar
            var c = _cal.EmptyChangeSelect(m.NR);
            c.MACHINENAME = ch.NAME;
            c.MACHINENR = ch.NR;
            c.MACHINEREF = ch.LREF;
            c.TARRIFSREF = m.TARRIFSREF;
            c.MODIFIEDDATETIME = DateTime.Now;
            
            string message;

            _cal.Update(c, out message);
            #endregion

            if (adds != null)
            {
                string asd;
                foreach (var item2 in adds)
                {
                    //adisyonlari aktarmiyor...
                    c.ADDITIONNAME += item2.PRODUCTNAME + " - ";
                    c.ADDITIONTOTAL += item2.PRODUCTSPRICES;
                    c.ADDITIONUNIT += item2.PRODUCTSUNIT;
                    item2.MACHINENAME = ch.NAME;
                    item2.MACHINENR = ch.NR;
                    item2.MACHINEREF = ch.LREF;
                    _add.Update(item2, out asd);
                }
            }

            ch.ENDDATETIME = m.ENDDATETIME;
            ch.HOLDDATETIME = m.HOLDDATETIME;
            ch.HOLDENDDATETIME = m.HOLDENDDATETIME;
            ch.MACHINESTATUS = m.MACHINESTATUS;
            ch.STARTDATETIME = m.STARTDATETIME;
            ch.TARRIFSREF = m.TARRIFSREF;

            m.ENDDATETIME = new DateTime(1, 1, 1, 0, 0, 0);
            m.HOLDDATETIME = new DateTime(1, 1, 1, 0, 0, 0);
            m.HOLDENDDATETIME = new DateTime(1, 1, 1, 0, 0, 0);
            m.MACHINESTATUS = (int)Model.Base.MachineType.Kapali;
            m.STARTDATETIME = new DateTime(1, 1, 1, 0, 0, 0);
            m.TARRIFSREF = 0;

            Update(ch, out message);
            Update(m, out message);

        }

        public void DragDropChangeMachine(Model.Machine selectedMachine, Model.Machine selectedMachine2, Model.Machine changeMachine)
        {
            string message;
            _dragMachine = selectedMachine;
            _dragMachine2 = selectedMachine;
            _dropMachine = changeMachine;

            var dragSelected = _cal.EmptyChangeSelect(_dragMachine.NR);
            var dragSelected2 = _cal.EmptyChangeSelect(_dragMachine.NR);
            var dropSelected = _cal.EmptyChangeSelect(_dropMachine.NR);
            var dropSelected2 = _cal.EmptyChangeSelect(_dropMachine.NR);
            var addsDrag = _add.NotPaidSelect(_dragMachine.NR);
            var addsDrop = _add.NotPaidSelect(_dropMachine.NR);

            #region //Adisyonlar
            if (addsDrag != null)
            {
                string asd;
                foreach (var item2 in addsDrag)
                {
                    dropSelected.ADDITIONNAME += item2.PRODUCTNAME + " - ";
                    dropSelected.ADDITIONTOTAL += item2.PRODUCTSPRICES;
                    dropSelected.ADDITIONUNIT += item2.PRODUCTSUNIT;
                    item2.MACHINENAME = _dropMachine.NAME;
                    item2.MACHINENR = _dropMachine.NR;
                    item2.MACHINEREF = _dropMachine.LREF;
                    _add.Update(item2, out asd);
                }
            }

            if (addsDrop != null)
            {
                string asd;
                foreach (var item2 in addsDrop)
                {
                    //adisyonlari aktarmiyor...
                    dragSelected.ADDITIONNAME += item2.PRODUCTNAME + " - ";
                    dragSelected.ADDITIONTOTAL += item2.PRODUCTSPRICES;
                    dragSelected.ADDITIONUNIT += item2.PRODUCTSUNIT;
                    item2.MACHINENAME = _dragMachine.NAME;
                    item2.MACHINENR = _dragMachine.NR;
                    item2.MACHINEREF = _dragMachine.LREF;
                    _add.Update(item2, out asd);
                }
            }
            #endregion

            #region //Hesabi Aktar
            dragSelected.CANCELREASON = dropSelected2.CANCELREASON;
            dragSelected.CREATEUSER = dropSelected2.CREATEUSER;
            dragSelected.DATETIME = dropSelected2.DATETIME;
            dragSelected.DETAILS = dropSelected2.DETAILS;
            //DragSelected.MACHINENAME = DropSelected2.MACHINENAME;
            //DragSelected.MACHINENR = DropSelected2.MACHINENR;
            //DragSelected.MACHINEREF = DropSelected2.MACHINEREF;
            dragSelected.MACHINETOTAL = dropSelected2.MACHINETOTAL;
            dragSelected.MODIFIEDDATETIME = dropSelected2.MODIFIEDDATETIME;
            dragSelected.MODIFIEDUSER = dropSelected2.MODIFIEDUSER;
            dragSelected.STARTDATETIME = dropSelected2.STARTDATETIME;
            dragSelected.STARTENDDATETIME = dropSelected2.STARTENDDATETIME;
            dragSelected.STATUS = dropSelected2.STATUS;
            dragSelected.TARRIFSREF = dropSelected2.TARRIFSREF;
            dragSelected.USEDTIME = dropSelected2.USEDTIME;

            dropSelected.ADDITIONNAME = dragSelected2.ADDITIONNAME;
            dropSelected.ADDITIONTOTAL = dragSelected2.ADDITIONTOTAL;
            dropSelected.ADDITIONUNIT = dragSelected2.ADDITIONUNIT;
            dropSelected.CANCELREASON = dragSelected2.CANCELREASON;
            dropSelected.CREATEUSER = dragSelected2.CREATEUSER;
            dropSelected.DATETIME = dragSelected2.DATETIME;
            dropSelected.DETAILS = dragSelected2.DETAILS;
            //DropSelected.MACHINENAME = DragSelected2.MACHINENAME;
            //DropSelected.MACHINENR = DragSelected2.MACHINENR;
            //DropSelected.MACHINEREF = DragSelected2.MACHINEREF;
            dropSelected.MACHINETOTAL = dragSelected2.MACHINETOTAL;
            dropSelected.MODIFIEDDATETIME = dragSelected2.MODIFIEDDATETIME;
            dropSelected.MODIFIEDUSER = dragSelected2.MODIFIEDUSER;
            dropSelected.STARTDATETIME = dragSelected2.STARTDATETIME;
            dropSelected.STARTENDDATETIME = dragSelected2.STARTENDDATETIME;
            dropSelected.STATUS = dragSelected2.STATUS;
            dropSelected.TARRIFSREF = dragSelected2.TARRIFSREF;
            dropSelected.USEDTIME = dragSelected2.USEDTIME;
            #endregion

            _dragMachine.ENDDATETIME = changeMachine.ENDDATETIME;
            _dragMachine.HOLDDATETIME = changeMachine.HOLDDATETIME;
            _dragMachine.HOLDENDDATETIME = changeMachine.HOLDENDDATETIME;
            _dragMachine.MACHINESTATUS = changeMachine.MACHINESTATUS;
            _dragMachine.STARTDATETIME = changeMachine.STARTDATETIME;
            _dragMachine.TARRIFSREF = changeMachine.TARRIFSREF;

            _dropMachine.ENDDATETIME = selectedMachine2.ENDDATETIME;
            _dropMachine.HOLDDATETIME = selectedMachine2.HOLDDATETIME;
            _dropMachine.HOLDENDDATETIME = selectedMachine2.HOLDENDDATETIME;
            _dropMachine.MACHINESTATUS = selectedMachine2.MACHINESTATUS;
            _dropMachine.STARTDATETIME = selectedMachine2.STARTDATETIME;
            _dropMachine.TARRIFSREF = selectedMachine2.TARRIFSREF;

            Update(_dropMachine, out message);
            Update(_dragMachine, out message);

            _cal.Update(dragSelected, out message);
            _cal.Update(dropSelected, out message);
        }
    }
}
