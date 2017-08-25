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
        private ILogService _logger;

        public SideMenuViewModel(IMvxNavigationService navigationService)
        {
            _logger = Mvx.Resolve<ILogService>();
            _navigationService = navigationService;
        }

        public override async void Start()
        {
            try
            {
                _logger.Trace("Service: SqliteService<UserModel> Method: Load");
                ISqliteService<UserModel> userRepo = new SqliteService<UserModel>();
                var user = await userRepo.Load();
                List<string> appAccess = user.AppAccess.Split(',').ToList<string>();
                appAccess.Reverse();
                AppAccess = appAccess;
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("Service: SqliteService<UserModel> Method: Load" + e.ToString() + "");
            }
        }

        private List<string> appAccess;
        public List<string> AppAccess
        {
            get { return appAccess; }
            set { appAccess = value; }
        }


        public IMvxCommand ShowHomeCommand
        {
            get { return new MvxCommand(ShowHomeExecuted); }
        }

        private void ShowHomeExecuted()
        {
            try
            {
                _logger.Trace("ShowHomeExecuted Start");
                _navigationService.Navigate<HomeViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowHomeExecuted ex: " + e.ToString() + "");
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
                _logger.Trace("ShowPierExecuted Start");
                _navigationService.Navigate<PierClaimLocationViewModel,string>("Pier");
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowPierExecuted ex: " + e.ToString() + "");
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
                _logger.Trace("ShowClaimExecuted Start");
                _navigationService.Navigate<PierClaimLocationViewModel, string>("Claim");
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowClaimExecuted ex: " + e.ToString() + "");
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
                _logger.Trace("ShowDepartureExecuted Start");
                _navigationService.Navigate<FlightEntryViewModel, string>("Departure");
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowDepartureExecuted ex: " + e.ToString() + "");
            }
        }

        public IMvxCommand ShowBsoCommand
        {
            get { return new MvxCommand(ShowBsoExecuted); }
        }

        private void ShowBsoExecuted()
        {
            try
            {
                _logger.Trace("ShowBsoExecuted Start");
                _navigationService.Navigate<PierClaimLocationViewModel, string>("BSO");
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowBsoExecuted ex: " + e.ToString() + "");
            }
        }

        public IMvxCommand ShowArrivalCommand
        {
            get { return new MvxCommand(ShowArrivalExecuted); }
        }

        private void ShowArrivalExecuted()
        {
            try
            {
                _logger.Trace("ShowArrivalExecuted Start");
                _navigationService.Navigate<FlightEntryViewModel, string>("Arrival");
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowArrivalExecuted ex: " + e.ToString() + "");
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
                _logger.Trace("ShowEncoderExecuted Start");
                _navigationService.Navigate<RfidEncoderViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowEncoderExecuted ex: " + e.ToString() + "");
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
                _logger.Trace("ShowSearchExecuted Start");
                _navigationService.Navigate<SearchViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowSearchExecuted ex: " + e.ToString() + "");
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
                        _logger.Trace("Service: SqliteService<UserModel> Method: Load");
                        ISqliteService<UserModel> userRepo = new SqliteService<UserModel>();
                        var user = await userRepo.Load();
                        user.IsLoggedIn = false;
                        await userRepo.InsertUpdate(user);
                    }
                    catch (Exception e)
                    {
                        Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                        _logger.Trace("LogoutCommand ex: " + e.ToString() + "");
                    }
                    await _navigationService.Navigate<LoginViewModel>();
                });
            }
        }
    }
}
