
using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace RFID.Droid
{
    [Activity(
         Label = "RFID.Droid"
         , MainLauncher = true
         , Icon = "@drawable/icon"
         , NoHistory = true
         , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
    }
}