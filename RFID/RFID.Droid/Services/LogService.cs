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
//using Serilog;
using System.Xml;
using NLog.Config;
using System.IO;
using RFID.Droid.Views;

namespace RFID.Droid.Services
{
    public class LogService : ILogService
    {
        public LogService()
        {
            //XmlLoggingConfiguration xmlLoggingConfiguration = new XmlLoggingConfiguration(XmlTextReader.Create(Application.Context.Assets.Open("NLog.config")), null);
            //LogManager.Configuration = xmlLoggingConfiguration;

            //Stream stream = Application.Context.Assets.Open("NLog.config");
            //var reader = XmlTextReader.Create(stream);
            //var config = new XmlLoggingConfiguration(reader, null); //filename is not required.
            //LogManager.Configuration = config;
            //LogManager.ThrowExceptions = true;
            //LogManager.ThrowConfigExceptions = true;
        }

        public void Trace(string message)
        {
            // Logger logger = LogManager.GetCurrentClassLogger();
            //logger.Trace("Sample trace message");
            //logger.Debug("Sample debug message");
            //logger.Info("Sample informational message");
            //logger.Warn("Sample warning message");
            //logger.Error("Sample error message");
            //logger.Fatal("Sample fatal error message");

            //// alternatively you can call the Log() method
            //// and pass log level as the parameter.
            //logger.Log(LogLevel.Info, "Sample informational message");

        }
    }
}