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
using NLog.Common;
using NLog;
using System.Xml;
using NLog.Config;
using System.IO;

namespace RFID.Droid.Services
{
    public class LoggingService : ILogService
    {

        NLog.Logger Logger;

        public LoggingService() {
            Stream stream = Application.Context.Assets.Open("NLog.config");
            var reader = XmlTextReader.Create(stream);
            var config = new XmlLoggingConfiguration(reader, null);
            LogManager.Configuration = config;
            LogManager.ThrowExceptions = true;
            LogManager.ThrowConfigExceptions = true;
            Logger = NLog.LogManager.GetCurrentClassLogger();
        }
        public void Trace(string message)
        {
            try
            {
                Logger.Trace("TRACE: " + message);
                Logger.Debug("DEBUG: " + message);
            }
            catch (Exception ex)
            {

                Logger.Trace(ex);
            }
         
            //var x = message;
        }
    }
}