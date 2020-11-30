using System;

namespace PlayStation.Model
{
    public class Products
    {
        public int LREF { get; set; }
        public string NAME { get; set; }
        public int STOCK { get; set; }
        public decimal UNITPRICE { get; set; }
        public DateTime DATETIME { get; set; }
        public int CREATEUSER { get; set; }
        public int? MODIFIEDUSER { get; set; }
        public DateTime? MODIFIEDDATETIME { get; set; }
    }
}
