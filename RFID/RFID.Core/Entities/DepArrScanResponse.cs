using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class DepArrScanResponse : BaseResponse
    {
        public FlightInfo FlightData { get; set; }
        public List<Position> Positions { get; set; }
    }

    public class FlightInfo
    {
        public DateTime ETD { get; set; }
        public string Gate { get; set; }
        public string ShipNumber { get; set; }
        public string DestStation { get; set; }
    }

    public class Position
    {
        public string position { get; set; }
        public List<Commodity> Commodities { get; set; }
        public string Progress { get; set; }
    }

    public class Commodity
    {
        public string CommodityType { get; set; }
        public string LoadCount { get; set; }
        public string PlannedCount { get; set; }
    }
}
