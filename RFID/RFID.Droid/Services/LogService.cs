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
using NLog;

namespace RFID.Droid.Services
{
    public class LogService : ILogService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void Trace(string message)
        {
            logger.Debug(DateTime.Now + message);
            logger.Trace("asd");
        }
    }
}