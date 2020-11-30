using System;

namespace PlayStation.Model
{
    public class Machine
    {
        public int LREF { get; set; }
        public int NR { get; set; }
        public string BYTENAME { get; set; }
        public int BYTENR { get; set; }
        public string NAME { get; set; }
        public DateTime STARTDATETIME { get; set; }
        public DateTime HOLDDATETIME { get; set; }
        public DateTime HOLDENDDATETIME { get; set; }
        public DateTime ENDDATETIME { get; set; }
        public int MACHINESTATUS { get; set; }
        public int TARRIFSREF { get; set; }
        public int SELECTEDTARRIF { get; set; }
    }
}
