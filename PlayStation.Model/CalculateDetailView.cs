using System;

namespace PlayStation.Model
{
    public class CalculateDetailView
    {
        public string MachineName { get; set; }
        public string CalculateStatus { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan UsedTime { get; set; }
        public TimeSpan RemainingTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal UsedPrice { get; set; }
        public decimal AdditionTotal { get; set; }
        public decimal TotalPrice { get; set; }
        public int MachineStatus { get; set; }
    }
}
