using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using RFID.Core.Services;
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
            try
            {
                //logger.Trace("SqliteService<UserModel> : LoadUser")
                ISqliteService<UserModel> userRepo = new SqliteService<UserModel>();
                var user = await userRepo.Load();
                List<string> appAccess = user.AppAccess.Split(',').ToList<string>();
                appAccess.Reverse();
                AppAccess = appAccess;
            }
            catch (Exception)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
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
            try
            {
                //logger.Trace("ShowViewModel : HomeViewModel")
                ShowViewModel<HomeViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }

        public IMvxCommand ShowPierCommand
        {
            get { return new MvxCommand(ShowPierExecuted); }
        }

        private void ShowPierExecuted()
        {
            try
            {
                //logger.Trace("ShowViewModel : PierClaimLocationViewModel")
                ShowViewModel<PierClaimLocationViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }

        public IMvxCommand ShowDepartureCommand
        {
            get { return new MvxCommand(ShowDepartureExecuted); }
        }

        private void ShowDepartureExecuted()
        {
            try
            {
                //logger.Trace("ShowViewModel : FlightEntryViewModel")
                ShowViewModel<FlightEntryViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }

        public IMvxCommand LogoutCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    try
                    {
                        //logger.Trace("SqliteService<UserModel> : LoadUser")
                        ISqliteService<UserModel> userRepo = new SqliteService<UserModel>();
                        var user = await userRepo.Load();
                        user.IsLoggedIn = false;
                        await userRepo.InsertUpdate(user);
                    }
                    catch (Exception)
                    {
                        Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                        //logger.Log(LogLevel.Info,e.ToString);
                    }

                    ShowViewModel<LoginViewModel>();

                });
            }
        }


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
