using RFID.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Interfaces
{
    public interface IRfid
    {
        /// <summary>
        /// Get/Set Property for the action to be done when trigger is pulled
        /// </summary>
        TriggerActions TriggerAction { get; set; }
        bool Enabled { get; set; }

        event EventHandler<RFIDScanEventArgs> OnRFIDScanEvent;
        event EventHandler<RFIDScanEventArgs> OnRFIDScanFail;
        event EventHandler<RFIDScanEventArgs> OnRFIDWriteEvent;
        event EventHandler<RFIDScanEventArgs> OnRFIDWriteEventFailed;
    }

    public enum TriggerActions {
        ReadSingle,
        ReadMultiple,
        Poll,
        Write

    }
}
