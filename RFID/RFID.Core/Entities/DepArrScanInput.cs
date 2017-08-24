using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class DepArrScanInput: BaseInput
    {
        public string CarrierCode { get; set; }
        public string FlightNumber { get; set; }
        public string Position { get; set; }
        public string Bagtag { get; set; }
        public DateTime ScanTime { get; set; }
        //    public string AppName { get; set; }
        //    public string FltNum { get; set; }
        //    public string FltCode { get; set; }
        //    public string FltDate { get; set; }
        //    public string FltPosition { get; set; }
        //    public string CommodityID { get; set; }
        //    public string Longitude { get; set; }
        //    public string Latitude { get; set; }
    }
}
