using RFID.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Interfaces
{
    public interface IQrcode
    {
        /// <summary>
        /// Readonly property to check if QRCode reader is on the process of scanning
        /// </summary>
        bool IsScanning { get; }
        /// <summary>
        /// Method to begin QRCode Reading process
        /// </summary>
        /// <returns></returns>
        bool Open();
        /// <summary>
        /// Method to stop QRCode Reading process
        /// </summary>
        /// <returns></returns>
        bool Close();
        /// <summary>
        /// Event to raise when read is successful
        /// </summary>
        event EventHandler<ScanEventArgs> OnScanEvent;
        /// <summary>
        /// Event to raise when read fails
        /// </summary>
        event EventHandler<ScanEventArgs> OnScanFail;


    }
}
