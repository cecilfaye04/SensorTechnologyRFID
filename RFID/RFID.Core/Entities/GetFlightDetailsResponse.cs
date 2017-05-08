using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class GetFlightDetailsResponse: BaseResponse
    {
        public Flight Flight { get; set; }
        public LoadSummary LoadSummary { get; set; }
    }

    public class Flight
    {
        public string FltNum { get; set; }
        public string FltCode { get; set; }
        public string FltDate { get; set; }
        public string[] Positions { get; set; }
        public string ETD { get; set; }
        public string ETA { get; set; }
        public string Status { get; set; }
        public string Gate { get; set; }
        public string NoseNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }

    class LoadSummary
    {
        public string PercentLoaded { get; set; }
        public string Bags { get; set; }
        public string Mail { get; set; }
        public string Ballast { get; set; }
        public string Freight { get; set; }
        public string Comat { get; set; }
    }

}
