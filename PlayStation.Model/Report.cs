using System;

namespace PlayStation.Model
{
    public class Report
    {
        public int LREF { get; set; }
        public int MACHINEREF { get; set; }
        public int TARRIFSREF { get; set; }
        public int MACHINENR { get; set; }
        public string TARRIFNAME { get; set; }
        public string MACHINENAME { get; set; }
        public DateTime? STARTDATETIME { get; set; }
        public DateTime? STARTENDDATETIME { get; set; }
        public DateTime? USEDTIME { get; set; }
        public string DETAILS { get; set; }
        public decimal MACHINETOTAL { get; set; }
        public string ADDITIONNAME { get; set; }
        public int ADDITIONUNIT { get; set; }
        public decimal ADDITIONTOTAL { get; set; }
        public string CANCELREASON { get; set; }
        public int MACHINECLOSESTATUS { get; set; }
        public int STATUS { get; set; }
        public DateTime DATETIME { get; set; }
        public int CREATEUSER { get; set; }
        public int? MODIFIEDUSER { get; set; }
        public DateTime? MODIFIEDDATETIME { get; set; }
    }
}
