
using MvvmCross.Droid.Shared.Attributes;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Widget;

using RFID.Core.ViewModels;
using Android.Runtime;
using Android.Views;
using Android.App;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.search_frame,true)]
    [Register("RFID.Droid.Views.SearchTrackFragment")]
    public class BagTrackFragment : BaseFragment<BagTrackViewModel>
    {
        private GoogleMap _map;
        private MapFragment _mapFragment;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainMenuView)Activity).Title = "Jennifer Smith's Bag";
            ShowBackButton = true;
            var mainActivity = Activity as MainMenuView;
            var rootView = base.OnCreateView(inflater, container, savedInstanceState);
     
            //_mapFragment = mainActivity.FragmentManager.FindFragmentByTag("map") as MapFragment;
            //if (_mapFragment == null)
            //{
            //    GoogleMapOptions mapOptions = new GoogleMapOptions()
            //        .InvokeMapType(GoogleMap.MapTypeSatellite)
            //        .InvokeZoomControlsEnabled(false)
            //        .InvokeCompassEnabled(true);

            //    FragmentTransaction fragTx = mainActivity.FragmentManager.BeginTransaction();
            //    _mapFragment = MapFragment.NewInstance(mapOptions);
            //    fragTx.Add(Resource.Id.map, _mapFragment, "map");
            //    fragTx.Commit();
            //}
            //_mapFragment.GetMapAsync(this);
         
            return rootView;

        }
        //public void OnMapReady(GoogleMap map)
        //{
        //    _map = map;
        //}
     

       

        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#3E50B4"));
        protected override int FragmentId => Resource.Layout.fragment_bag_track;
    }
}