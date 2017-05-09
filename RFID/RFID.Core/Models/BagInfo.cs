using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Models
{
    public class BagInfo
    {
        public string FltCode { get; set; }
        public string FltNum { get; set; }
        public string FltDate { get; set; }
        public string PaxItinerary { get; set; }
        public string PaxName { get; set; }
        public BagScanPoint[] BagHistory { get; set; }
        public Location LastSeen { get; set; }

    }

    public class BagScanPoint
    {
        public string ScanPoint { get; set; }
        public string DateTime { get; set; }
    }
}
