using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RFID.Core.Interfaces;
//using NLog;
//using Serilog;
using System.Xml;
using System.IO;
using RFID.Droid.Views;

namespace RFID.Droid.Services
{
    public class LogService : ILogService
    {
        public void Trace(string message)
        {
            var x = message;
        }
    }
}