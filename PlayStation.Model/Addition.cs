using System;

namespace PlayStation.Model
{
    public class Addition
    {
        public int LREF { get; set; }
        public int? MACHINEREF { get; set; }
        public int? MACHINENR { get; set; }
        public string MACHINENAME { get; set; }
        public int PRODUCTREF { get; set; }
        public string PRODUCTNAME { get; set; }
        public int PRODUCTSUNIT { get; set; }
        public decimal PRODUCTSPRICES { get; set; }
        public string NOTE { get; set; }
        public DateTime DATETIME { get; set; }
        public int STATUS { get; set; }
    }
}
