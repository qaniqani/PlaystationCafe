using System;
using System.Collections.Generic;
using System.Data;
using System.Media;
using System.Windows.Forms;
using PlayStation.Data;
using PlayStation.Functions;
using PlayStation.Model;
using PlayStation.Model.Base;
using PlayStation.Properties;
using Calculates = PlayStation.Data.Calculates;
using Machine = PlayStation.Data.Machine;
using Tarrifs = PlayStation.Data.Tarrifs;

namespace PlayStation
{
    public class Process
    {
        private readonly Machine _mac = new Machine();
        private readonly Calculates _cal = new Calculates();
        private readonly Additions _add = new Additions();
        private readonly Tarrifs _tar = new Tarrifs();
        private readonly DataAccessLayer _dal = new DataAccessLayer();

        public static string Password = "1r8qxESGlmeFhVvw/47b2A==";
        public static string UserName = "8JdgbxbmgHA=";

        public static void LogInsert(string logDetail, TransactionType logType)
        {
            var log = new Logs();

            var l = new Log
            {
                CREATEUSER = (Global.CurrentUser != null ? Global.CurrentUser.LREF : 0),
                DATETIME = DateTime.Now,
                TRANSACTIONDETAIL = logDetail,
                TRANSACTIONNAME = logType.ToString(),
                TRANSACTIONTYPE = Convert.ToInt32(logType)
            };
            string message;
            log.Insert(l, out message);
        }

        public static void CreateMachine(int machineCount)
        {
            //TRUNCATE EDILECEK
            var mac = new Machine();
            var cal = new Calculates();
            mac.TruncateTable();
            for (var i = 1; i < machineCount + 1; i++)
            {
                var c = cal.MachineCalc(i);
                string message;
                if (c.STATUS == (int)MachineType.Durduruldu ||
                    c.STATUS == (int)MachineType.OzelAcik ||
                    c.STATUS == (int)MachineType.SureliAcik ||
                    c.STATUS == (int)MachineType.SuresizAcik)
                {
                    c.STATUS = (int)MachineType.IptalEdildi;
                    cal.Update(c, out message);
                }

                var m = new Model.Machine
                {
                    BYTENAME = "Byte" + i,
                    BYTENR = i,
                    MACHINESTATUS = Convert.ToInt32(MachineType.Kapali),
                    NAME = Global.CurrentSettings.MACHINETAGNAME + " " + i,
                    NR = i,
                    TARRIFSREF = 0,
                    SELECTEDTARRIF = 0
                };
                mac.Insert(m, out message);
            }
            LogInsert("Masa sayısı " + machineCount + " olarak değiştirildi.", TransactionType.Duzenle);
        }

        public void OpenFreeTime(Model.Machine m, Model.Tarrifs tar)
        {
            string message;
            var calc = new Model.Calculates();
            var dt = new DateTime(1, 1, 2, 0, 0, 0);

            m.ENDDATETIME = new DateTime();
            m.MACHINESTATUS = (int)MachineType.SuresizAcik;
            m.TARRIFSREF = tar.LREF;

            if (m.STARTDATETIME > dt)
            {
                #region //Hesap
                calc.MACHINETOTAL = 0;
                calc.MODIFIEDDATETIME = new DateTime();
                calc.MODIFIEDUSER = Global.CurrentUser.LREF;
                calc.STARTDATETIME = m.STARTDATETIME;
                calc.STARTENDDATETIME = new DateTime();
                calc.STATUS = m.MACHINESTATUS;
                calc.TARRIFSREF = tar.LREF;
                #endregion

                LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + m.NR + " süreli durumdan süresize geçirildi.", TransactionType.Duzenle);
            }
            else
            {
                m.STARTDATETIME = DateTime.Now;

                #region //Hesap
                calc.ADDITIONNAME = "";
                calc.ADDITIONTOTAL = 0;
                calc.ADDITIONUNIT = 0;
                calc.CANCELREASON = "";
                calc.CREATEUSER = Global.CurrentUser.LREF;
                calc.DATETIME = DateTime.Now;
                calc.DETAILS = "";
                calc.MACHINENAME = m.NAME;
                calc.MACHINENR = m.NR;
                calc.MACHINEREF = m.LREF;
                calc.MACHINETOTAL = 0;
                calc.MODIFIEDDATETIME = new DateTime();
                calc.MODIFIEDUSER = 0;
                calc.STARTDATETIME = m.STARTDATETIME;
                calc.STARTENDDATETIME = m.ENDDATETIME;
                calc.STATUS = m.MACHINESTATUS;
                calc.TARRIFSREF = tar.LREF;
                calc.USEDTIME = new DateTime();
                #endregion
                LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + m.NR + " " + tar.NAME + " tarifesi ile süresiz açıldı.", TransactionType.Ekle);
            }

            _mac.Update(m, out message);
            MachineCalcInsertAndUpdate(calc, m, null, "", "", "Insert", MachineType.SuresizAcik);
        }

        public void OpenLimitedTime(Model.Machine m, Model.Tarrifs tar, int time)
        {
            string message;
            m.ENDDATETIME = DateTime.Now.AddMinutes(time);
            m.MACHINESTATUS = (int)MachineType.SureliAcik;
            m.STARTDATETIME = DateTime.Now;
            m.TARRIFSREF = tar.LREF;

            #region //Hesap

            var calc = new Model.Calculates
            {
                ADDITIONNAME = "",
                ADDITIONTOTAL = 0,
                ADDITIONUNIT = 0,
                CANCELREASON = "",
                CREATEUSER = Global.CurrentUser.LREF,
                DATETIME = DateTime.Now,
                DETAILS = "",
                MACHINENAME = Global.CurrentSettings.MACHINETAGNAME + " " + m.NR,
                MACHINENR = m.NR,
                MACHINEREF = m.LREF,
                MACHINETOTAL = tar.MINUTEPRICE*time,
                MODIFIEDDATETIME = new DateTime(),
                MODIFIEDUSER = 0,
                STARTDATETIME = DateTime.Now,
                STARTENDDATETIME = DateTime.Now.AddMinutes(time),
                STATUS = m.MACHINESTATUS,
                TARRIFSREF = tar.LREF,
                USEDTIME = new DateTime()
            };

            #endregion

            _mac.Update(m, out message);
            MachineCalcInsertAndUpdate(calc, m, null, "", "", "Insert", MachineType.SureliAcik);
            LogInsert(m.NAME + " --> " + string.Format("{0:n} TL", calc.MACHINETOTAL) + " süreli açıldı.", TransactionType.Ekle);
        }

        public void EditLimitedTime(Model.Machine m, Model.Tarrifs tar, int minute)
        {
            string message;
            m.ENDDATETIME = m.ENDDATETIME.AddMinutes(minute);

            var totalMinute = Convert.ToInt32((m.ENDDATETIME - m.STARTDATETIME).TotalMinutes);

            #region //Hesap
            var calc = _cal.MachineCalc(m.NR);
            calc.MACHINETOTAL = tar.MINUTEPRICE * totalMinute;
            calc.STARTENDDATETIME = m.ENDDATETIME;
            #endregion

            _mac.Update(m, out message);
            MachineCalcInsertAndUpdate(calc, m, null, "", "", "Update", MachineType.SureliAcik);
            LogInsert(m.NAME + " süresi değiştirildi. " + string.Format("{0:n} TL", calc.MACHINETOTAL) + " olarak ayarlandı.", TransactionType.Ekle);
        }

        public void ExpiredMachine()
        {
            var li = _mac.ExpiredTime();
            if (li.Count <= 0) return;

            foreach (var item in li)
            {
                var c = _cal.MachineCalc(item.NR);
                var adds = _add.NotPaidSelect(item.NR);

                MachineCalcInsertAndUpdate(c, item, adds, "", "", "Update", MachineType.Kapali);

                MachineClosed(item);
            }
            var sp = new SoundPlayer(Resources.ring);
            sp.Play();
        }

        public void HoldMachineCalculate(Model.Machine m)
        {
            var dtFlag = new DateTime(1, 1, 2, 0, 0, 0);

            if (m.HOLDDATETIME > dtFlag)
            {
                //Daha once beklemeye alinip, devam ettirildiyse beklemede kaldigi sure kadar baslangic saatini geri at.
                var usedHold = m.HOLDENDDATETIME - m.HOLDDATETIME;
                m.HOLDDATETIME = DateTime.Now - usedHold;
            }
            else
                m.HOLDDATETIME = DateTime.Now;

            m.MACHINESTATUS = (int)MachineType.Durduruldu;
            string message;

            _mac.Update(m, out message);
            LogInsert(m.NAME + " hesabı durduruldu.", TransactionType.Ekle);
        }

        public void HoldOffMachineCalculate(Model.Machine m)
        {
            m.MACHINESTATUS = (int)MachineType.SuresizAcik;
            m.HOLDENDDATETIME = DateTime.Now;
            string message;

            _mac.Update(m, out message);
            LogInsert(m.NAME + " hesabı tekrar devam ettirildi.", TransactionType.Duzenle);
        }

        public void MachineClosed(Model.Machine machine)
        {
            var logMessage = " hesabı kapatıldı.";
            if (machine.MACHINESTATUS == (int)MachineType.SureliAcik)
                logMessage = " süresi dolduğu için otomatik kapatıldı.";

            var dt = new DateTime(1, 1, 1, 0, 0, 0);
            machine.ENDDATETIME = dt;
            machine.MACHINESTATUS = (int)MachineType.Kapali;
            machine.STARTDATETIME = dt;
            machine.TARRIFSREF = 0;
            machine.HOLDDATETIME = dt;
            machine.HOLDENDDATETIME = dt;

            string message;
            _mac.Update(machine, out message);
            LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + machine.NR + logMessage, TransactionType.Duzenle);
        }

        public void MachineCalcInsertAndUpdate(Model.Calculates c, Model.Machine m, List<Addition> adds, string cancelReason, string detail, string commandType, MachineType transactionType)
        {
            var cdv = DetailView(m);

            var t = _tar.Select(m.TARRIFSREF);

            string message;

            #region //Hesaplar
            switch (commandType)
            {
                case "Insert":
                    c.STARTDATETIME = m.STARTDATETIME;
                    c.CANCELREASON = cancelReason;
                    c.MODIFIEDDATETIME = DateTime.Now;
                    c.MODIFIEDUSER = Global.CurrentUser.LREF;
                    c.STATUS = m.MACHINESTATUS;
                    c.TARRIFSREF = m.TARRIFSREF;
                    c.USEDTIME = DateTime.MinValue.Add(cdv.UsedTime);
                    c.DETAILS += detail;
                    c.MACHINECLOSESTATUS = m.MACHINESTATUS;

                    if ((int)MachineType.SureliAcik != m.MACHINESTATUS)
                        c.MACHINETOTAL = cdv.TotalPrice;
                    break;
                case "Update":
                    c.STARTDATETIME = m.STARTDATETIME;
                    c.STARTENDDATETIME = m.ENDDATETIME;
                    c.CANCELREASON = cancelReason;
                    c.MODIFIEDDATETIME = DateTime.Now;
                    c.MODIFIEDUSER = Global.CurrentUser.LREF;
                    c.STATUS = (int)transactionType;
                    c.TARRIFSREF = m.TARRIFSREF;
                    c.USEDTIME = DateTime.MinValue.Add(cdv.UsedTime);
                    c.DETAILS += detail;
                    c.MACHINECLOSESTATUS = m.MACHINESTATUS;

                    //SÜRELİ HESAPLARDA KULLANIM ÜCRETİ YERİNE VERİLEN PARA BEDELİNİN GEÇERLİ OLMASI İÇİN COMMENTLERİ KALDIR.
                    //ÖRNEĞİN: 3TL'LİK HESAP 10DK KULLANILDIYSA KAPANDIĞINDA 3TL HESAP BEDELİ ÇIKAR.
                    //COMMENTLİ ŞEKİLDE KULLANIM ÜCRETİ ÜZERİNDEN İŞLEM YAPAR
                    //AYNI İŞLEM FrmMachineClose FORMUNDA DA VAR.


                    //if ((int)Model.Base.MachineType.SureliAcik != m.MACHINESTATUS)
                    //{
                    var ts = m.ENDDATETIME - m.STARTDATETIME;

                    var machineTotal = (t.MINUTEPRICE * Convert.ToDecimal(ts.TotalMinutes));

                    if (machineTotal < Global.CurrentSettings.MINIMUMTOTAL && t.HOURPRICE > 0)
                        machineTotal = Convert.ToDecimal(Global.CurrentSettings.MINIMUMTOTAL);
                    else if (machineTotal > Global.CurrentSettings.MINIMUMTOTAL && t.HOURPRICE > 0)
                        machineTotal = cdv.TotalPrice;                        

                    c.MACHINETOTAL = machineTotal;
                    break;
                //}
            }
            #endregion

            #region //Adisyon
            if (adds != null)
            { 
                string asd;
                var addsAll = _add.PaidSelect(m.NR);
                foreach (var item in addsAll)
                {
                    item.STATUS = (int)AdditionStatus.Odendi;
                    _add.Update(item, out asd);
                }

                foreach (var item2 in adds)
                {
                    c.ADDITIONNAME += item2.PRODUCTNAME + " - ";
                    c.ADDITIONTOTAL += (item2.PRODUCTSPRICES * item2.PRODUCTSUNIT);
                    c.ADDITIONUNIT += item2.PRODUCTSUNIT;
                    item2.STATUS = (int)AdditionStatus.HesapKapatildi;
                    _add.Update(item2, out asd);
                }
            }
            #endregion

            switch (commandType)
            {
                case "Update":
                    _cal.Update(c, out message);
                    break;
                case "Insert":
                    _cal.Insert(c, out message);
                    break;
            }
        }

        public CalculateDetailView DetailView(Model.Machine selectedMachine)
        {
            var m = _mac.Select(selectedMachine.NR);
            var c = _cal.MachineCalc(selectedMachine.NR);
            var t = _tar.Select(selectedMachine.TARRIFSREF);
            var adds = _add.NotPaidSelect(selectedMachine.NR);
            var dtNow = DateTime.Now;

            var cdv = new CalculateDetailView();

            #region //Hesap durdurma islemi

            #endregion

            #region //Adisyon islemi
            decimal additionTotal = 0;
            if (adds != null)
                foreach (var item in adds)
                {
                    additionTotal += (item.PRODUCTSPRICES * item.PRODUCTSUNIT);
                }

            cdv.AdditionTotal = (additionTotal > 0 ? additionTotal : Convert.ToDecimal(0.0));
            #endregion

            #region //Makine durumu
            cdv.CalculateStatus = (m.MACHINESTATUS == (int)MachineType.Durduruldu ? "Beklemede" :
                                    m.MACHINESTATUS == (int)MachineType.Kapali ? "Kapalı" :
                                    m.MACHINESTATUS == (int)MachineType.OzelAcik ? "Tarifeli" :
                                    m.MACHINESTATUS == (int)MachineType.SureliAcik ? "Süreli" :
                                    m.MACHINESTATUS == (int)MachineType.SuresizAcik ? "Süresiz" : "-");
            #endregion

            #region //Makine adi
            cdv.MachineName = Global.CurrentSettings.MACHINETAGNAME + " " + m.NR;
            #endregion

            #region //Bitis Suresi

            var dtEndTime = m.MACHINESTATUS == (int)MachineType.SureliAcik ? m.ENDDATETIME : new DateTime(1, 1, 1, 0, 0, 0);

            cdv.EndTime = dtEndTime;
            #endregion

            #region //Kalan Sure
            TimeSpan tsReaminingTime;
            if (m.MACHINESTATUS == (int)MachineType.SureliAcik)
                tsReaminingTime = m.ENDDATETIME - dtNow;
            else
                tsReaminingTime = new TimeSpan(0, 0, 0);
            cdv.RemainingTime = tsReaminingTime;
            #endregion

            #region //Baslangic Suresi
            cdv.StartTime = m.STARTDATETIME;
            #endregion

            #region //Kullanilan Sure
            TimeSpan tsUsedTime;
            if (m.STARTDATETIME > DateTime.Now.AddDays(-3) && m.MACHINESTATUS != (int)MachineType.Durduruldu)
            {
                //Normal aciksa buradan al
                var dtHold = new DateTime(1, 1, 2, 0, 0, 0);

                //Hesabin durduruldugu kadar zamani simdiki zamandan eksilt.
                if (m.HOLDDATETIME > dtHold && m.HOLDENDDATETIME > dtHold)
                {
                    var tsUsedHold = m.HOLDENDDATETIME - m.HOLDDATETIME;
                    tsUsedTime = dtNow.Add(-tsUsedHold) - m.STARTDATETIME;
                }
                else
                    tsUsedTime = dtNow - m.STARTDATETIME;
            }
            else if (m.MACHINESTATUS == (int)MachineType.Durduruldu)
                //Hesap durdurulduysa buradan al
                tsUsedTime = m.HOLDDATETIME - m.STARTDATETIME;
            else
                tsUsedTime = new TimeSpan(0, 0, 0);
            cdv.UsedTime = tsUsedTime;
            #endregion

            #region //Kullanim Ucreti
            if (m.STARTDATETIME > DateTime.Now.AddDays(-30) && m.MACHINESTATUS != (int)MachineType.Durduruldu)
            {
                //Acik hesapsa buradan hesapla

                decimal usedPrice = 0;
                //Hesap beklemeye alindiysa buradan hesapla
                var dtHold = new DateTime(1, 1, 2, 0, 0, 0);

                if (Global.CurrentSettings.MINIMUMTOTAL <= t.HOURPRICE)
                {
                    if (m.HOLDDATETIME > dtHold && m.HOLDENDDATETIME > dtHold)
                    {
                        var tsUsedHold = m.HOLDENDDATETIME - m.HOLDDATETIME;
                        var startTime = m.STARTDATETIME + tsUsedHold;
                        var totalMinute = Convert.ToInt32((dtNow - startTime).TotalMinutes);

                        usedPrice = Function.PriceRounding(Convert.ToDecimal(t.MINUTEPRICE * totalMinute), Global.CurrentSettings.ROUNDINGPRICE);
                    }
                    else
                    {
                        var totalMinute = Convert.ToInt32((dtNow - m.STARTDATETIME).TotalMinutes);
                        usedPrice = Function.PriceRounding(Convert.ToDecimal(t.MINUTEPRICE * totalMinute), Global.CurrentSettings.ROUNDINGPRICE);
                    }

                    cdv.UsedPrice = usedPrice < Global.CurrentSettings.MINIMUMTOTAL ? Convert.ToDecimal(Global.CurrentSettings.MINIMUMTOTAL) : usedPrice;
                }
                else
                    cdv.UsedPrice = usedPrice;
            }
            else if (m.MACHINESTATUS == (int)MachineType.Durduruldu)
                //Durdurulduysa buradan hesapla
                cdv.UsedPrice = Function.PriceRounding(Convert.ToDecimal(t.MINUTEPRICE * Convert.ToInt32((m.HOLDDATETIME - m.STARTDATETIME).TotalMinutes)), Global.CurrentSettings.ROUNDINGPRICE);
            else
                cdv.UsedPrice = Convert.ToDecimal(0.0);
            #endregion

            #region //Toplam Ucret
            if (m.STARTDATETIME > DateTime.Now.AddDays(-30) && m.MACHINESTATUS != (int)MachineType.Durduruldu)
            {
                //Acik hesapsa buradan hesapla

                decimal usedPrice = 0;
                //Hesap beklemeye alindiysa buradan hesapla
                var dtHold = new DateTime(1, 1, 2, 0, 0, 0);

                if (Global.CurrentSettings.MINIMUMTOTAL <= t.HOURPRICE)
                {
                    if (m.HOLDDATETIME > dtHold && m.HOLDENDDATETIME > dtHold)
                    {
                        var tsUsedHold = m.HOLDENDDATETIME - m.HOLDDATETIME;
                        var startTime = m.STARTDATETIME + tsUsedHold;
                        var totalMinute = Convert.ToInt32((dtNow - startTime).TotalMinutes);

                        usedPrice = Function.PriceRounding(Convert.ToDecimal(t.MINUTEPRICE * totalMinute), Global.CurrentSettings.ROUNDINGPRICE);
                    }
                    else
                    {
                        var totalMinute = Convert.ToInt32((dtNow - m.STARTDATETIME).TotalMinutes);
                        usedPrice = Function.PriceRounding(Convert.ToDecimal(t.MINUTEPRICE * totalMinute), Global.CurrentSettings.ROUNDINGPRICE);
                    }

                    if (usedPrice < Global.CurrentSettings.MINIMUMTOTAL)
                        usedPrice = Convert.ToDecimal(Global.CurrentSettings.MINIMUMTOTAL);

                    cdv.TotalPrice = usedPrice;
                }
                else
                    cdv.TotalPrice = usedPrice;
            }
            else if (m.MACHINESTATUS == (int)MachineType.Durduruldu)
            {
                //Durdurulduysa buradan hesapla
                decimal TotalPrice = Function.PriceRounding(Convert.ToDecimal(t.MINUTEPRICE * Convert.ToInt32((m.HOLDDATETIME - m.STARTDATETIME).TotalMinutes)), Global.CurrentSettings.ROUNDINGPRICE);

                if (TotalPrice < Global.CurrentSettings.MINIMUMTOTAL)
                    TotalPrice = Convert.ToDecimal(Global.CurrentSettings.MINIMUMTOTAL);

                cdv.TotalPrice = TotalPrice;
            }
            else
                cdv.TotalPrice = Convert.ToDecimal(0.0);

            if (m.MACHINESTATUS == (int)MachineType.SureliAcik)
                cdv.TotalPrice = c.MACHINETOTAL;
            #endregion

            #region //Makine statusu
            cdv.MachineStatus = m.MACHINESTATUS;
            #endregion

            return cdv;
        }

        public void CalculatesTransfer(Model.Machine dragMachine, Model.Machine dropMachine)
        {
            var calcDrag = _cal.MachineCalc(dragMachine.NR);
            var calcDrop = _cal.MachineCalc(dropMachine.NR);

            var adds = _add.NotPaidSelect(dragMachine.NR);

            var cdv = DetailView(dragMachine);

            string message;
            #region //Hesaplar
            calcDrop.DETAILS += " - " + Global.CurrentSettings.MACHINETAGNAME + " " + dragMachine.NR + " Hesabı aktarıldı.";

            calcDrag.CANCELREASON = Global.CurrentSettings.MACHINETAGNAME + " " + dropMachine.NR + " numaralı yere taşındı.";
            calcDrag.STARTDATETIME = new DateTime();
            calcDrag.STARTENDDATETIME = new DateTime();
            calcDrag.TARRIFSREF = 0;
            calcDrag.USEDTIME = new DateTime();

            calcDrag.STATUS = (int)MachineType.Kapali;
            #endregion

            #region //Adisyon
            if (adds != null)
            {
                string asd;
                foreach (var item2 in adds)
                {
                    calcDrop.ADDITIONNAME += item2.PRODUCTNAME + " - ";
                    calcDrop.ADDITIONTOTAL += (item2.PRODUCTSPRICES * item2.PRODUCTSUNIT);
                    calcDrop.ADDITIONUNIT += item2.PRODUCTSUNIT;
                    item2.MACHINENAME = Global.CurrentSettings.MACHINETAGNAME + " " + dropMachine.NR;
                    item2.MACHINENR = dropMachine.NR;
                    item2.MACHINEREF = dropMachine.LREF;
                    _add.Update(item2, out asd);
                }
            }
            #endregion

            var cdvDrag = DetailView(dragMachine);
            var cdvDrop = DetailView(dropMachine);

            _cal.Update(calcDrop, out message);
            _cal.Update(calcDrag, out message);

            var dtFlag = new DateTime(1, 1, 2, 0, 0, 0);
            if (dragMachine.HOLDDATETIME > dtFlag)
            {
                //Daha once beklemeye alinip, devam ettirildiyse beklemede kaldigi sure kadar baslangic saatini geri at.

                #region //Suruklenen makinenin zamani
                var dragUsedHold = dragMachine.HOLDENDDATETIME - dragMachine.HOLDDATETIME; //03:25
                var dragTransHold = DateTime.Now - cdv.StartTime; //01:30
                var dragTotalHold = dragUsedHold + dragTransHold;
                #endregion

                var dt = dropMachine.STARTDATETIME - dragTotalHold;

                dropMachine.STARTDATETIME = dt;
            }
            else
            {
                var dragTransTotal = DateTime.Now - cdv.StartTime; //01:30
                var dt = dropMachine.STARTDATETIME - dragTransTotal;

                dropMachine.STARTDATETIME = dt;
            }

            _mac.Update(dropMachine, out message);

            dragMachine.MACHINESTATUS = (int)MachineType.Kapali;
            MachineClosed(dragMachine);

            LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + dragMachine.NR + " --> " + Global.CurrentSettings.MACHINETAGNAME + " " + dropMachine.NR + " hesabı aktarıldı. Hesap ücreti: " + Global.CurrentSettings.MACHINETAGNAME + " " + dragMachine.NR + ": " + string.Format("{0:n} TL", (cdvDrag.AdditionTotal + cdvDrag.TotalPrice)) + " - " + Global.CurrentSettings.MACHINETAGNAME + " " + dropMachine.NR + ": " + string.Format("{0:n} TL", (cdvDrop.AdditionTotal + cdvDrop.TotalPrice)), TransactionType.Duzenle);
        }

        public void BackToCalculate(Model.Machine machine, out string result)
        {
            //adisyonlar geri alinacak.
            var c = _cal.SelectCloseMachineLastCalculate(machine.NR);

            if (c.STARTDATETIME != null)
            {
                c.STATUS = c.MACHINECLOSESTATUS;

                machine.ENDDATETIME = Convert.ToDateTime(c.STARTENDDATETIME);
                machine.MACHINESTATUS = c.MACHINECLOSESTATUS;
                machine.STARTDATETIME = Convert.ToDateTime(c.STARTDATETIME);
                machine.TARRIFSREF = c.TARRIFSREF;

                string message;
                if (c.ADDITIONUNIT > 0)
                {
                    var adds = _add.CalculatesBackNotPaidSelect(machine.NR);
                    foreach (var item in adds)
                    {
                        item.STATUS = (int)AdditionStatus.Odenmedi;
                        _add.Update(item, out message);
                    }
                }

                _mac.Update(machine, out message);
                _cal.Update(c, out message);
                LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + machine.NR + " hesabı geri alındı.", TransactionType.Duzenle);
                result = string.Empty;
            }
            else
                result = "Son 1 saatte masanın hesabı bulunmamaktadır.";
        }

        public void WriteDatabaseSetting()
        {
            Function.WriteRegistry("Password", Password);
            Function.WriteRegistry("UserName", UserName);

            SetDatabaseSetting();

            var insertUser = @"INSERT INTO USERS(TYPE,NAME,SURNAME,USERNAME,PASSWORD,CHANGESTARTTIME,DATETIME,ACTIVE)
                                VALUES ('1','admin','admin','admin','uIsHXDPpOPA=',1,'" + DateTime.Now.ToShortDateString() + "',1);";

            var insertTarrif = @"INSERT INTO TARRIFS(NAME,HOURPRICE,MINUTEPRICE,SELECTED,ACTIVE,DATETIME,CREATEUSER,MODIFIEDUSER, MODIFIEDDATETIME) VALUES ('Hafta ici tarifesi',2,0.033333333,1,1,'" + DateTime.Now.ToShortDateString() + "',0,0,'" + DateTime.Now.ToShortDateString() + "');";

            var insertSetting = @"INSERT INTO SETTINGS(VERSION,MACHINECOUNT,MACHINETAGNAME,MACHINESTATUS,MINIMUMTIME,MINIMUMTOTAL, ROUNDINGPRICE,DATETIME,ACTIVE, CREATEUSER, MODIFIEDUSER, MODIFIEDDATETIME) VALUES (1,0,'Play Station',0,'" + DateTime.Now.ToShortDateString() + "',0.25,0.25, '" + DateTime.Now.ToShortDateString() + "', 1,0,0,'" + DateTime.Now.ToShortDateString() + "');";

            string msg;

            _dal.FbExecute(insertSetting, CommandType.Text, null, out msg);

            _dal.FbExecute(insertTarrif, CommandType.Text, null, out msg);

            _dal.FbExecute(insertUser, CommandType.Text, null, out msg);
        }

        public void SetDatabaseSetting()
        {
            //Data.DataAccessLayer.ServerName = Functions.Function.DecryptIt(Functions.Function.ReadRegistry("ServerName"));
            DataAccessLayer.InitialCatalog = Application.StartupPath + "\\CONSOLE.FDB";
            DataAccessLayer.UserName = Function.DecryptIt(Function.ReadRegistry("UserName"));
            DataAccessLayer.Password = Function.DecryptIt(Function.ReadRegistry("Password"));
        }

        public void ClearDatabaseSetting()
        {
            //Functions.Function.WriteRegistry("DatabaseName", string.Empty);
            Function.WriteRegistry("Password", string.Empty);
            //Functions.Function.WriteRegistry("ServerName", string.Empty);
            Function.WriteRegistry("UserName", string.Empty);
        }
    }
}