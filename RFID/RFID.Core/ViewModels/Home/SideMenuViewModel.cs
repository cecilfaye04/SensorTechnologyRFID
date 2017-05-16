using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class SideMenuViewModel : BaseViewModel
    {

        public override async void Start()
        {
            await Mvx.Resolve<IInitilializeSqliteService>().InitializeAsync();
            var user = await Mvx.Resolve<ISqliteService>().LoadUserAsync();
            List<string> appAccess = user.AppAccess.Split(',').ToList<string>();
            appAccess.Reverse();
            AppAccess = appAccess;
        }

        private List<string> appAccess;

        public List<string> AppAccess
        {
            get { return appAccess; }
            set { appAccess = value; }
        }

        #region Cross Platform Commands & Handlers

        public IMvxCommand ShowHomeCommand
        {
            get { return new MvxCommand(ShowHomeExecuted); }
        }

        private void ShowHomeExecuted()
        {
            ShowViewModel<HomeViewModel>();
        }

        public IMvxCommand ShowPierCommand
        {
            get { return new MvxCommand(ShowPierExecuted); }
        }

        private void ShowPierExecuted()
        {
            ShowViewModel<PierClaimLocationViewModel>();
        }

        public IMvxCommand ShowDepartureCommand
        {
            get { return new MvxCommand(ShowDepartureExecuted); }
        }

        private void ShowDepartureExecuted()
        {
            ShowViewModel<FlightEntryViewModel>();
        }

        public IMvxCommand LogoutCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var user = await Mvx.Resolve<ISqliteService>().LoadUserAsync();
                    user.IsLoggedIn = false;
                    await Mvx.Resolve<ISqliteService>().UpdateUserAsync(user);
                    ShowViewModel<LoginViewModel>();
                });
            }
        }
        //public IMvxCommand ShowSettingCommand
        //{
        //    get { return new MvxCommand(ShowSettingsExecuted); }
        //}



        //public IMvxCommand ShowHelpCommand
        //{
        //    get { return new MvxCommand(ShowHelpExecuted); }
        //}

        //private void ShowHelpExecuted()
        //{
        //    ShowViewModel<HelpAndFeedbackViewModel>();
        //}

        #endregion

        #region Android Specific Demos

        //public IMvxCommand ShowRecyclerCommand
        //{
        //    get { return new MvxCommand(ShowRecyclerExecuted); }
        //}

        ////private void ShowRecyclerExecuted()
        ////{
        ////    ShowViewModel<ExampleRecyclerViewModel>();
        ////}

        //public IMvxCommand ShowViewPagerCommand
        //{
        //    get { return new MvxCommand(ShowViewPagerExecuted); }
        //}

        //private void ShowViewPagerExecuted()
        //{
        //    ShowViewModel<ExampleViewPagerViewModel>();
        //}

        #endregion
    }
}
