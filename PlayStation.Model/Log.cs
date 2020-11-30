using System;

namespace PlayStation.Model
{
    public class Log
    {
        public int LREF { get; set; }
        public int? TRANSACTIONTYPE { get; set; }
        public string TRANSACTIONNAME { get; set; }
        public string TRANSACTIONDETAIL { get; set; }
        public DateTime DATETIME { get; set; }
        public int CREATEUSER { get; set; }
    }

    public class LogView
    {
        public int LREF { get; set; }
        public int? TRANSACTIONTYPE { get; set; }
        public string TRANSACTIONNAME { get; set; }
        public string TRANSACTIONDETAIL { get; set; }
        public DateTime DATETIME { get; set; }
        public int CREATEUSER { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string USERNAME { get; set; }
    }
}
