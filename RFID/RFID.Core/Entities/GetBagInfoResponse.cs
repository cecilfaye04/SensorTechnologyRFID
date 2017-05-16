using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class GetBagInfoResponse: BaseResponse
    {
        public string FltCode { get; set; }
        public string FltNum { get; set; }
        public string FltDate { get; set; }
        public string PaxName { get; set; }
        public string PaxItinerary { get; set; }
        public ScanPoint[] BagHistory { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }

    public class ScanPoint
    {
        public string Location { get; set; }
        public string DateTime { get; set; }
        public string ScanType { get; set; }
    }
}
