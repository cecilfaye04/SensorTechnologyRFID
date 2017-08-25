using RFID.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Interfaces
{
    public interface IBarcode
    {
        /// <summary>
        /// Event to raise when read is successful
        /// </summary>
        event EventHandler<ScanEventArgs> OnScanEvent;
        /// <summary>
        /// Event to raise when read fails
        /// </summary>
        event EventHandler<ScanEventArgs> OnScanFail;
        /// <summary>
        /// Property to set or get the status of barcode reader
        /// </summary>
        bool Enabled { get; set; }
    }
}
