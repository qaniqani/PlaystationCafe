using System;

namespace PlayStation.Model
{
    public class Tarrifs
    {
        public int LREF { get; set; }
        public string NAME { get; set; }
        public decimal HOURPRICE { get; set; }
        public decimal MINUTEPRICE { get; set; }
        public bool SELECTED { get; set; }
        public bool ACTIVE { get; set; }
        public DateTime DATETIME { get; set; }
        public int CREATEUSER { get; set; }
        public int? MODIFIEDUSER { get; set; }
        public DateTime? MODIFIEDDATETIME { get; set; }
    }
}
