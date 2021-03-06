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
using MvvmCross.Droid.Support.V4;
using Android.Support.Design.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using System.Threading.Tasks;
using MvvmCross.Droid.Shared.Attributes;
using RFID.Core.ViewModels;

namespace RFID.Droid.Views
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.navigation_frame)]
    [Register("RFID.Droid.Views.SideMenuFragment")]
    public class SideMenuFragment : MvxFragment<SideMenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        private IMenuItem _previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.fragment_navigation, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.nav_home).SetChecked(true);
            //var x = ViewModel.AppAccess;
            //if (ViewModel.AppAccess.Count > 0)
            //{
            //    if (!ViewModel.AppAccess.Contains("BSO"))
            //    {
            //        _navigationView.Menu.FindItem(Resource.Id.nav_bso).SetVisible(false);
            //    }

            //    if (!ViewModel.AppAccess.Contains("Pier"))
            //    {
            //        _navigationView.Menu.FindItem(Resource.Id.nav_pier).SetVisible(false);
            //    }
            //    if (!ViewModel.AppAccess.Contains("Claim"))
            //    {
            //        _navigationView.Menu.FindItem(Resource.Id.nav_claim).SetVisible(false);
            //    }
            //    if (!ViewModel.AppAccess.Contains("Arrivals"))
            //    {
            //        _navigationView.Menu.FindItem(Resource.Id.nav_arrival).SetVisible(false);
            //    }
            //    if (!ViewModel.AppAccess.Contains("Departures"))
            //    {
            //        _navigationView.Menu.FindItem(Resource.Id.nav_departure).SetVisible(false);
            //    }
            //}
            //else
            //{ }




            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            if (item != _previousMenuItem)
            {
                _previousMenuItem?.SetChecked(false);
            }

            item.SetCheckable(true);
            item.SetChecked(true);

            _previousMenuItem = item;

            Navigate(item.ItemId);

            return true;
        }

        private async Task Navigate(int itemId)
        {
            ((MainMenuView)Activity).DrawerLayout.CloseDrawers();

            // add a small delay to prevent any UI issues
            await Task.Delay(TimeSpan.FromMilliseconds(250));

            switch (itemId)
            {
                case Resource.Id.nav_home:
                    ViewModel.ShowHomeCommand.Execute();
                    break;
                case Resource.Id.nav_pier:
                    ViewModel.ShowPierCommand.Execute();
                    break;
                case Resource.Id.nav_departure:
                    ViewModel.ShowDepartureCommand.Execute();
                    break;
                case Resource.Id.nav_arrival:
                    ViewModel.ShowArrivalCommand.Execute();
                    break;
                case Resource.Id.nav_claim:
                    ViewModel.ShowClaimCommand.Execute();
                    break;
                case Resource.Id.nav_bso:
                    ViewModel.ShowBsoCommand.Execute();
                    break;
                case Resource.Id.nav_encoder:
                    ViewModel.ShowEncoderCommand.Execute();
                    break;
                case Resource.Id.nav_search:
                    ViewModel.ShowSearchCommand.Execute();
                    break;
                case Resource.Id.nav_logout:
                    ViewModel.LogoutCommand.Execute();
                    break;
            }
        }
    }
}