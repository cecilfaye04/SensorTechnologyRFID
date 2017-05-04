using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
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

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.search_frame, true)]
    [Register("RFID.Droid.Views.BagTrackFragment")]
    public class BagTrackFragment : BaseFragment<BagTrackViewModel>
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
        protected override int FragmentId => Resource.Layout.fragment_bag_track;
    }
}