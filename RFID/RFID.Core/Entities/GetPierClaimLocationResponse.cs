using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class GetPierClaimLocationResponse: BaseResponse
    {
        public PierClaimLocations MainLocations { get; set; }
    }

    public class PierClaimLocations
    {
        public string Name { get; set; }
        public string[] SubLocations { get; set; }
    }
}
