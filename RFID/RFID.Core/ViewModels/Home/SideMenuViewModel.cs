using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
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
        private readonly IMvxNavigationService _navigationService;

        public SideMenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

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
                //logger.Trace("Navigate : HomeViewModel")
                _navigationService.Navigate<HomeViewModel>();
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
                //logger.Trace("Navigate : PierClaimLocationViewModel")
                _navigationService.Navigate<PierClaimLocationViewModel,string>("Pier");
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }

        public IMvxCommand ShowClaimCommand
        {
            get { return new MvxCommand(ShowClaimExecuted); }
        }

        private void ShowClaimExecuted()
        {
            try
            {
                //logger.Trace("Navigate : PierClaimLocationViewModel")
                _navigationService.Navigate<PierClaimLocationViewModel, string>("Claim");
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
                //logger.Trace("Navigate : FlightEntryViewModel")
                _navigationService.Navigate<FlightEntryViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }

        public IMvxCommand ShowEncoderCommand
        {
            get { return new MvxCommand(ShowEncoderExecuted); }
        }

        private void ShowEncoderExecuted()
        {
            try
            {
                //logger.Trace("Navigate : RfidEncoderViewModel")
                _navigationService.Navigate<RfidEncoderViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }

        public IMvxCommand ShowSearchCommand
        {
            get { return new MvxCommand(ShowSearchExecuted); }
        }

        private void ShowSearchExecuted()
        {
            try
            {
                //logger.Trace("Navigate : SearchViewModel")
                _navigationService.Navigate<SearchViewModel>();
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

                    await _navigationService.Navigate<LoginViewModel>();
                });
            }
        }


        #endregion
    }
}
