using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Helpers
{
    public class ScanEventArgs : EventArgs
    {
        public string ScannedValue;

        public ScanEventArgs(string scannedText) {
            ScannedValue = scannedText;
        }
    }
}
