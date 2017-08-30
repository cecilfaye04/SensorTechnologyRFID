using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RFID.Core.Interfaces;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RFID.Droid.Services
{
    public class LoggingService : ILogService
    {
        public void Trace(string message)
        {
            var x = message;
        }
    }
}