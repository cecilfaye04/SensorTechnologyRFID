
using Android.App;
using Android.OS;
using Android.Views;
using Android.Content.PM;
using RFID.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Support.V4.Widget;
using Android.Views.InputMethods;
using Android.Support.V4.View;
using System.Collections.Generic;
using Android.Widget;
using System.Collections;
using ZXing.Mobile;

namespace RFID.Droid.Views
{
    [Activity(Label = "Home" ,Theme = "@style/AppTheme",
        LaunchMode = LaunchMode.SingleTop)]
    public class MainMenuView : MvxCachingFragmentCompatActivity<MainMenuViewModel>
    {
        public DrawerLayout DrawerLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main_menu);
            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            List<string> appAccess = new List<string>();

            if (savedInstanceState == null)
                ViewModel.ShowMenu();

            MobileBarcodeScanner.Initialize(this.Application);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
           MenuInflater.Inflate(Resource.Menu.home, menu);
            //FOR SPINNER AT DEPT ARR SCAN SCREEN
           //var y = menu.FindItem(Resource.Id.menu_spinner);
           // Spinner spin = (Spinner)MenuItemCompat.GetActionView(y);
           // var adapter = ArrayAdapter.CreateFromResource(
           //  this, Resource.Array.position_list, Android.Resource.Layout.SimpleSpinnerItem);
           // adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
           // spin.Adapter = adapter;
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
             
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    DrawerLayout.OpenDrawer(GravityCompat.Start);
                    OnBackPressed();
                    return true;
                case Resource.Id.menu_search:
                    ViewModel.ShowSearchCommand.Execute();
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
         
        private void ShowBackButton()
        {
            DrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);
        }


        private void ShowHamburguerMenu()
        {
            DrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeUnlocked);
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
                DrawerLayout.CloseDrawers();
            else
                DrawerLayout.CloseDrawers();
            base.OnBackPressed();
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null) return;
            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);
            CurrentFocus.ClearFocus();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}