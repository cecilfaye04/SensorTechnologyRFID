using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Polylines = Android.Gms.Maps.Model.Polyline;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RFID.Core.Interfaces;
using System.Threading.Tasks;
using Java.Net;
using System.IO;
using Javax.Net.Ssl;

namespace RFID.Droid.Services
{
    public class MapService : IMapService
    {
        public async Task<string> GetRouteInfo()
        {
            string response = string.Empty;
            try
            {
                await Task.Run(() =>
                {
                    URL url = new URL(string.Format("https://maps.googleapis.com/maps/api/directions/json?" + "origin={0},{1}&destination={2},{3}&key={4}",
                        47.639466, -122.130665, 47.639466, -122.130665, "AIzaSyCn2XMz_4-GjsAu2Ge1M6h8mFBVpResBYs"));

                    HttpsURLConnection urlConnection = (HttpsURLConnection)url.OpenConnection();
                    urlConnection.Connect();
                    var stream = urlConnection.InputStream;

                    using (var streamReader = new StreamReader(stream))
                    {
                        response = streamReader.ReadToEnd();
                    }
                });
            }
            catch (Exception e)
            {
                var x = e.Message;
            }
            return response;
            //if (Routes != null)
            //{
            //    Routes.Remove();
            //}
            //return response;
        }
    }
}