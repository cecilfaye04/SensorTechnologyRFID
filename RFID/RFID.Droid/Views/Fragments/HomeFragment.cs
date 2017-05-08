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
using MvvmCross.Droid.Shared.Attributes;
using RFID.Core.ViewModels;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace RFID.Droid.Views
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.content_frame)]
    [Register("RFID.Droid.Views.HomeFragment")]
    public class HomeFragment : BaseFragment<HomeViewModel>
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainMenuView)Activity).Title = "Home";
            ShowHamburgerMenu = true;

            var view = base.OnCreateView(inflater, container, savedInstanceState);

            if (!ViewModel.AppAccess.Contains("BSO"))
            {
                view.FindViewById<LinearLayout>(Resource.Id.llBSO).Visibility = ViewStates.Gone;
            }
            if (!ViewModel.AppAccess.Contains("Pier"))
            {
                view.FindViewById<LinearLayout>(Resource.Id.llPier).Visibility = ViewStates.Gone;
            }
            if (!ViewModel.AppAccess.Contains("Claim"))
            {
                view.FindViewById<LinearLayout>(Resource.Id.llClaim).Visibility = ViewStates.Gone;
            }
            if (!ViewModel.AppAccess.Contains("Arrival"))
            {
                view.FindViewById<LinearLayout>(Resource.Id.llArrival).Visibility = ViewStates.Gone;
            }
            if (!ViewModel.AppAccess.Contains("Departure"))
            {
                view.FindViewById<LinearLayout>(Resource.Id.llDeparture).Visibility = ViewStates.Gone;
            }


            return view;
        }

        protected override int FragmentId => Resource.Layout.fragment_home;
        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#3E50B4"));

    }
}