using System;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using RFID.Core.ViewModels;
using System.Threading.Tasks;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class BottomNavigationFragment : BaseFragment<BottomNavigationViewModel>,BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private BottomNavigationView _bottomNavigation;
        private IMenuItem _previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainView)Activity).Title = "Search";
            ShowBackButton = true;

            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(FragmentId, null);

            //BottomNavigationView bottomNavigationView = (BottomNavigationView)
            //   FindViewsWith(R.id.bottom_navigation);

            //BottomNavigationView bottomNavigationView = FindViewsWith<BottomNavigationView>(Resource.id.bottom_navigation);


             _bottomNavigation = view.FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            _bottomNavigation.SetOnNavigationItemSelectedListener(this);
            if (savedInstanceState == null)
            ViewModel.ShowSearch();
            return view;
            //return base.OnCreateView(inflater, container, savedInstanceState);

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
                    break;
            }

            return true;
            //if (item != _previousMenuItem)
            //{
            //    _previousMenuItem?.SetChecked(false);
            //}

            //item.SetCheckable(true);
            //item.SetChecked(true);

            //_previousMenuItem = item;

            //Navigate(item.ItemId);

            //return true;
        }

        //private async Task Navigate(int itemId)
        //{

        //    // add a small delay to prevent any UI issues
        //    await Task.Delay(TimeSpan.FromMilliseconds(250));

        //    switch (itemId)
        //    {
        //        case Resource.Id.nav_result:
        //            ViewModel.ShowSearchResultCommand.Execute();
        //            break;
        //        case Resource.Id.nav_location:
        //            ViewModel.ShowLocationCommand.Execute();
        //            break;
        //        case Resource.Id.nav_track:

        //            break;
        //    }
        //}

        protected override int FragmentId => Resource.Layout.fragment_bottomNavigation;
    }
}