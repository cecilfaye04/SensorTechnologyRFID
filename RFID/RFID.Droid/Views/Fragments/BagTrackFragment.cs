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

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.search_frame, true)]
    [Register("RFID.Droid.Views.BagTrackFragment")]
    public class BagTrackFragment : BaseFragment<BagTrackViewModel>, IOnMapReadyCallback
    {
        private static View view;
        private GoogleMap googleMap;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainMenuView)Activity).Title = "Jennifer Smith's Bag";
            ShowBackButton = true;
            var mainActivity = Activity as MainMenuView;
            var rootView = base.OnCreateView(inflater, container, savedInstanceState);
            var mapFragment = (MapFragment)mainActivity.FragmentManager.FindFragmentById(Resource.Id.map);
            FragmentManager  fm = ChildFragmentManager;
            SupportMapFragment mapwFragment = (SupportMapFragment)fm.FindFragmentById(Resource.Id.map);
            //if (mapwFragment == null)
            //{
            //    mapwFragment = new SupportMapFragment();
            //    FragmentTransaction ft = fm.BeginTransaction();
            //    ft.Add(Resource.Id.map, mapwFragment, "mapFragment");
            //    ft.Commit();
            //    fm.ExecutePendingTransactions();
            //}
            mapFragment.GetMapAsync(this);

            //if (view != null)
            //{
            //    ViewGroup parent = (ViewGroup)view;
            //    if (parent != null)
            //        parent.RemoveView(view);
            //}
            //try
            //{
            //    view = inflater.Inflate(Resource.Id.map, container, false);
            //}
            //catch (InflateException e)
            //{
            //    /* map is already there, just return view as it is */
            //}
            return rootView;

        }
        //public override void OnDestroy()
        //{
        //    var mainActivity = Activity as MainMenuView;
        //    var mapFragment = (MapFragment)mainActivity.FragmentManager.FindFragmentById(Resource.Id.map);
        //    if (mapFragment != null)
        //        mainActivity.FragmentManager.BeginTransaction().Remove(mapFragment).Commit();
        //    base.OnDestroy();

        //}
        public async void OnMapReady(GoogleMap googleMap)
        {
            this.googleMap = googleMap;
            this.googleMap.MyLocationEnabled = true;
        }

        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#3E50B4"));
        protected override int FragmentId => Resource.Layout.fragment_bag_track;
    }
}