using System;

namespace PlayStation.Model
{
    public class DebtList
    {
        public int LREF { get; set; }
        public string NAME { get; set; }
        public string GSMNR { get; set; }
        public decimal DEBTAMOUNT { get; set; }
        public DateTime DEBTDATE { get; set; }
        public DateTime CREATEDATE { get; set; }
    }
}
