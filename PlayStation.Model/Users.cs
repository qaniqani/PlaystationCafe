using System;

namespace PlayStation.Model
{
    public class Users
    {
        public int LREF { get; set; }
        public int TYPE { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public bool CHANGESTARTTIME { get; set; }
        public DateTime DATETIME { get; set; }
        public bool ACTIVE { get; set; }
    }
}
