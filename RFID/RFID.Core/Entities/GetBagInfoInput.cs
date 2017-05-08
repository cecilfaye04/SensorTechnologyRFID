using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class GetBagInfoInput: BaseInput
    {
        public string Bagtag { get; set; }
        public string Logitude { get; set; }
        public string Latitude { get; set; }
    }
}
