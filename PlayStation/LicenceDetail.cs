using System;

namespace PlayStation
{
    public class LicenceDetail
    {
        public bool Active { get; set; }
        public bool Demo { get; set; }
        public DateTime LicenceEndDate { get; set; }
        public DateTime LicenceStartDate { get; set; }
        public string LicenceKey { get; set; }
        public string ResultMessage { get; set; }
    }
}
