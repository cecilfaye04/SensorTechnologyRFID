
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
                
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.home, menu);
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
    }
}