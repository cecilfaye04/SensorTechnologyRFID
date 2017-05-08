using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class BaseInput
    {
        public string Username { get; set; }
        public string Version { get; set; }
        public string Station { get; set; }
        public string DeviceName { get; set; }

    }
}
