
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
using System;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.search_frame)]
    [Register("RFID.Droid.Views.SearchTrackFragment")]
    public class BagLocateFragment : BaseFragment<BagLocateViewModel> /*, IOnMapReadyCallback*/
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainMenuView)Activity).Title = "Jennifer Smith's Bag";
            ShowBackButton = true;
            var mainActivity = Activity as MainMenuView;
            var rootView = base.OnCreateView(inflater, container, savedInstanceState);
            return rootView;

        }

        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#3E50B4"));
        protected override int FragmentId => Resource.Layout.fragment_bag_locate;
    }
}