using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using RFID.Core.ViewModels.Search;
using MvvmCross.Droid.Shared.Attributes;
using RFID.Core.ViewModels;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Gms.Maps;
using Android.Support.V4.App;
using Android.Gms.Maps.Model;
using System.Threading.Tasks;
using Java.Net;
using System.IO;
using Polylines = Android.Gms.Maps.Model.Polyline;
using Javax.Net.Ssl;
using Newtonsoft.Json;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.search_frame, true)]
    [Register("RFID.Droid.Views.BagTrackFragment")]
    public class BagTrackFragment : BaseFragment<BagTrackViewModel>, IOnMapReadyCallback
    {
        private GoogleMap googleMap;
        public PolylineOptions RouteLine { get; set; }
        public Polylines Routes { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainMenuView)Activity).Title = "Jennifer Smith's Bag";
            ShowBackButton = true;
            var mainActivity = Activity as MainMenuView;
            var rootView = base.OnCreateView(inflater, container, savedInstanceState);
            var mapFragment = (MapFragment)mainActivity.FragmentManager.FindFragmentById(Resource.Id.map);
            FragmentManager  fm = ChildFragmentManager;
            SupportMapFragment mapwFragment = (SupportMapFragment)fm.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
            return rootView;

        }

        public void OnMapReady(GoogleMap googleMap)
        {
            this.googleMap = googleMap;
            this.googleMap.MyLocationEnabled = true;
            MarkerOptions mrkerBagLocation = new MarkerOptions();
            mrkerBagLocation.SetPosition(new LatLng(47.636372, -122.126888));
            mrkerBagLocation.SetTitle("Bag Location");

            MarkerOptions mrkerUserLocation = new MarkerOptions();
            mrkerUserLocation.SetPosition(new LatLng(47.639466, -122.130665));
            mrkerUserLocation.SetTitle("Your Location");
            this.googleMap.AddMarker(mrkerUserLocation);
            this.googleMap.AddMarker(mrkerBagLocation);
            GetRouteInfo();

        }
        public async void GetRouteInfo()
        {
            string response = string.Empty;

            await Task.Run(() =>
            {
                URL url = new URL(string.Format("https://maps.googleapis.com/maps/api/directions/json?" + "origin={0},{1}&destination={2},{3}&key={4}",
                     47.636372, -122.126888, 47.639466, -122.130665, "AIzaSyCn2XMz_4-GjsAu2Ge1M6h8mFBVpResBYs"));

                HttpsURLConnection urlConnection = (HttpsURLConnection)url.OpenConnection();
                urlConnection.Connect();
                var stream = urlConnection.InputStream;

                using (var streamReader = new StreamReader(stream))
                {
                    response = streamReader.ReadToEnd();
                }
            });

            if (Routes != null)
            {
                Routes.Remove();
            }
            RouteLine = GetPolylines(response);
            RouteLine.InvokeColor(-65536);
            RouteLine.InvokeWidth(5);
            Routes = googleMap.AddPolyline(RouteLine);

        }

        public PolylineOptions GetPolylines(string routeInfo)
        {
            var routeObject = JsonConvert.DeserializeObject<Rootobject>(routeInfo);
            List<LatLng> coordinatesList = DecodeEncodedPolyline(routeObject.routes[0].overview_polyline.points);

            PolylineOptions polylines = new PolylineOptions();

            foreach (var lines in coordinatesList)
            {
                polylines.Add(lines);
            };
            polylines.Points.RemoveAt(0);
            return polylines;
        }

        public static List<LatLng> DecodeEncodedPolyline(string encodedPath)
        {
            int len = encodedPath.Length;
            // For speed we preallocate to an upper bound on the final length, then
            // truncate the array before returning.
            List<LatLng> path = new List<LatLng>();
            int index = 0;
            int lat = 0;
            int lng = 0;

            while (index < len)
            {
                int result = 1;
                int shift = 0;
                int b;
                do
                {
                    b = encodedPath[index++] - 63 - 1;
                    result += b << shift;
                    shift += 5;
                } while (b >= 0x1f);
                lat += (result & 1) != 0 ? ~(result >> 1) : (result >> 1);

                result = 1;
                shift = 0;
                do
                {
                    b = encodedPath[index++] - 63 - 1;
                    result += b << shift;
                    shift += 5;
                } while (b >= 0x1f);
                lng += (result & 1) != 0 ? ~(result >> 1) : (result >> 1);

                path.Add(new LatLng(lat * 1e-5, lng * 1e-5));
            }
            return path;
        }
        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#3E50B4"));
        protected override int FragmentId => Resource.Layout.fragment_bag_track;
    }
}