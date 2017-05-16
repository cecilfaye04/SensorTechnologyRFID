using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Models
{
    [Table("PierClaimBagScan")]
    public class PierClaimBagScan: Location
    {
        public string Bagtag { get; set; }
        public bool IsUploaded { get; set; }
        public string PierClaimLocation { get; set; }
        public DateTime ScanTime { get; set; }

    }
}
