using System;

namespace PlayStation.Model
{
    public class Settings
    {
        public int LREF { get; set; }
        public int VERSION { get; set; }
        public int MACHINECOUNT { get; set; }
        public string MACHINETAGNAME { get; set; }
        public bool MACHINESTATUS { get; set; }
        public DateTime? MINIMUMTIME { get; set; }
        public decimal? MINIMUMTOTAL { get; set; }
        public decimal? ROUNDINGPRICE { get; set; }
        public DateTime? DATETIME { get; set; }
        public bool ACTIVE { get; set; }
        public int CREATEUSER { get; set; }
        public int? MODIFIEDUSER { get; set; }
        public DateTime? MODIFIEDDATETIME { get; set; }
    }
}
