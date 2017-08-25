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
   public class HomeViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private ILogService _logger;

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            _logger = Mvx.Resolve<ILogService>();
            _navigationService = navigationService;
        }

        private void EnableApps(string appAccess)
        {
            IsPierVisible = appAccess.Contains("Pier");
            IsDepartureVisible = appAccess.Contains("Departures");
            IsArrivalVisible = appAccess.Contains("Arrivals");
            IsClaimVisible = appAccess.Contains("Claim");
            IsBSOVisible = appAccess.Contains("BSO");
        }

        private bool isPierVisible;
        public bool IsPierVisible
        {
            get { return isPierVisible; }
            set { isPierVisible = value; RaisePropertyChanged(() => IsPierVisible); }
        }

        private bool isDepartureVisible;
        public bool IsDepartureVisible
        {
            get { return isDepartureVisible; }
            set { isDepartureVisible = value; RaisePropertyChanged(() => IsDepartureVisible); }
        }

        private bool isArrivalVisible;
        public bool IsArrivalVisible
        {
            get { return isArrivalVisible; }
            set { isArrivalVisible = value; RaisePropertyChanged(() => IsArrivalVisible); }
        }

        private bool isClaimVisible;
        public bool IsClaimVisible
        {
            get { return isClaimVisible; }
            set { isClaimVisible = value; RaisePropertyChanged(() => IsClaimVisible); }
        }

        private bool isBSOVisible;
        public bool IsBSOVisible
        {
            get { return isBSOVisible; }
            set { isBSOVisible = value; RaisePropertyChanged(() => IsBSOVisible); }
        }

        public IMvxCommand ShowPierCommand
        {
            get { return new MvxCommand(ShowPierExecuted); }
        }

        private void ShowPierExecuted()
        {
            try
            {
                _logger.Trace("ShowPierExecuted Start , Param: Pier");
                _navigationService.Navigate<PierClaimLocationViewModel, string>("Pier");
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
                _logger.Trace("ShowClaimExecuted Start, Param: Claim");
                _navigationService.Navigate<PierClaimLocationViewModel, string>("Claim");
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowClaimExecuted ex: " + e.ToString() + "");
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
                _logger.Trace("ShowBsoExecuted Start, Param: BSO");
                _navigationService.Navigate<PierClaimLocationViewModel, string>("BSO");
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowBsoExecuted ex: " + e.ToString() + "");
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
                _logger.Trace("ShowDepartureExecuted Start, Param: Departure");
                _navigationService.Navigate<FlightEntryViewModel,string>("Departure");
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowDepartureExecuted ex: " + e.ToString() + "");
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
                _logger.Trace("ShowArrivalExecuted Start, Param: Arrival");
                _navigationService.Navigate<FlightEntryViewModel,string>("Arrival");
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowArrivalExecuted ex: " + e.ToString() + "");
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

        public IMvxCommand ShowRFIDEncoderCommand
        {
            get { return new MvxCommand(ShowRFIDEncoderExecuted); }
        }

        private void ShowRFIDEncoderExecuted()
        {
            try
            {
                _logger.Trace("ShowRFIDEncoderExecuted Start");
                _navigationService.Navigate<RfidEncoderViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowRFIDEncoderExecuted ex: " + e.ToString() + "");
            }
        }

        public async void InitializeButton()
        {
            try
            {
                _logger.Trace("Service: SqliteService<UserModel> Method: LoadUser");
                ISqliteService<UserModel> userRepo = new SqliteService<UserModel>();
                var user = await userRepo.Load();
                EnableApps(user.AppAccess);
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("SqliteService<UserModel> Method: LoadUser ex: " + e.ToString() + "");
            }
        }
    }

}
