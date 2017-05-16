using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RFID.Core.Models
{
    [Table("BagInfo")]
    public class BagInfo
    {
        [PrimaryKey]
        public string Bagtag { get; set; }
        public string FltCode { get; set; }
        public string FltNum { get; set; }
        public string FltDate { get; set; }
        public string PaxItinerary { get; set; }
        public string PaxName { get; set; }

        //public Location LastSeen { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }


        [TextBlob("BagScanPointsBlobbed")]
        public List<BagScanPoint> BagScanPoints { get; set; }

        public string BagScanPointsBlobbed { get; set; }
    }

    public class BagScanPoint
    {
        public string ScanTime { get; set; }
        public string ScanPoint { get; set; }
        public string Icon { get; set; }

    }
}
