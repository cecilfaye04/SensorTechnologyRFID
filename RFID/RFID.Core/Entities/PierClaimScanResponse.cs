using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class PierClaimScanResponse:BaseResponse
    {
        public List<BagResponse> Bags { get; set; }
    }

    public class BagResponse
    {
        public string Bagtag { get; set; }
        public Boolean Success { get; set; }
        public string Message { get; set; }
    }
}
