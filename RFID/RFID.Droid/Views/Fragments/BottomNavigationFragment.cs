using System;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using RFID.Core.ViewModels;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.content_frame,true)]
    public class BottomNavigationFragment : BaseFragment<BottomNavigationViewModel>,BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private BottomNavigationView _bottomNavigation;
        private IMenuItem _previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainMenuView)Activity).Title = "Search";
            ShowBackButton = true;


            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _bottomNavigation = view.FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            _bottomNavigation.SetOnNavigationItemSelectedListener(this);
            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.nav_result:
                    ViewModel.ShowSearchResultCommand.Execute();
                    break;
                case Resource.Id.nav_location:
                    ViewModel.ShowLocationCommand.Execute();
                    break;
                case Resource.Id.nav_track:
                    ViewModel.ShowTrackCommand.Execute();
                    break;
            }

            return true;
        }

        protected override int FragmentId => Resource.Layout.fragment_search_bottom_nav;
        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#3E50B4"));

    }
}