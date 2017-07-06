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
using Serilog;

namespace RFID.Droid.Services
{
    public class LogService : ILogService
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        public void Trace(string message)
        {
           
            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
          .WriteTo.LiterateConsole()
           .WriteTo.File("log.txt", shared: true)
            .WriteTo.RollingFile("logs\\myapp-{Date}.txt")
              .CreateLogger();

            Log.Debug(message);
            Log.Information("Hello, world!");
            //logger.Debug(DateTime.Now + message);
            //logger.Trace("asd");
            //Log.CloseAndFlush();
        }
    }
}