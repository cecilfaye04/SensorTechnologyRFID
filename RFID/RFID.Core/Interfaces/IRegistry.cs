using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RFID.Core.Interfaces
{
    interface IRegistry
    {
        String DeviceName { get; set; }
        String Station { get; set; }
        String Version { get; set; }
    }
}
