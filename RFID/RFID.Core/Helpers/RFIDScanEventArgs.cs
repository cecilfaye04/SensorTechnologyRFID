using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Helpers
{
    public class RFIDScanEventArgs : EventArgs
    {
        public RFIDLabel ScannedValue;

        public RFIDScanEventArgs(RFIDLabel scannedValue)
        {
            ScannedValue = scannedValue;
        }
    }

    public class RFIDLabel {

        public string LabelID { get; set; }
        public string AFI { get; set; }
        public string TrackingID { get; set; }

    }
}
