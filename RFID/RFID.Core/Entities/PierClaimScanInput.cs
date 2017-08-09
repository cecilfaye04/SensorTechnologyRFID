using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class PierClaimScanInput: BaseInput 
    {
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public List<Bag> Bags { get; set; }
    }

    public class Bag
    {
        public string Bagtag { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime ScanTime { get; set; }
    }
}
