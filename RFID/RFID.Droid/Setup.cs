using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using RFID.Core.Services;
using System.Reflection;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Platform.Droid.Platform;
using RFID.Core.Interfaces;
using Acr.UserDialogs;
using System.Threading.Tasks;
using Android.Util;
using RFID.Droid.Services;

namespace RFID.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterSingleton<IInitilializeSqliteService>(new InitializeSqliteService());
            Mvx.RegisterSingleton<ILogService>(new LoggingService());
            Mvx.RegisterSingleton<IQrcodeService>(new QRCodeService());
            UserDialogs.Init(() => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
            AndroidEnvironment.UnhandledExceptionRaiser -= StoreLogger;
            AndroidEnvironment.UnhandledExceptionRaiser += StoreLogger;
            //TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
            return new  RFID.Core.App();
        }

        private void StoreLogger(object sender, RaiseThrowableEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Exception.Message);
        }

      
        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(Android.Support.Design.Widget.NavigationView).Assembly,
            typeof(Android.Support.Design.Widget.FloatingActionButton).Assembly,
            typeof(Android.Support.V7.Widget.Toolbar).Assembly,
            typeof(Android.Support.V4.Widget.DrawerLayout).Assembly,
            typeof(Android.Support.V4.View.ViewPager).Assembly,
            typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly
        };


        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);

            //add a presentation hint handler to listen for pop to root
            mvxFragmentsPresenter.AddPresentationHintHandler<MvxPanelPopToRootPresentationHint>(hint =>
            {
                var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
                var fragmentActivity = activity as Android.Support.V4.App.FragmentActivity;

                for (int i = 0; i < fragmentActivity.SupportFragmentManager.BackStackEntryCount; i++)
                {
                    fragmentActivity.SupportFragmentManager.PopBackStack();
                }
                return true;
            });
            //register the presentation hint to pop to root
            //picked up in the third view model
            Mvx.RegisterSingleton<MvxPresentationHint>(() => new MvxPanelPopToRootPresentationHint());
            return mvxFragmentsPresenter;
        }


        //protected override IMvxTrace CreateDebugTrace()
        //{
        //    return new DebugTrace();
        //}
    }
}