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

    }
}
