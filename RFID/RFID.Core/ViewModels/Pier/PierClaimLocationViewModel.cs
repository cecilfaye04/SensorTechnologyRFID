using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Entities;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using RFID.Core.Services;
using System;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class PierClaimLocationViewModel : MvxViewModel<string>
    {
        private readonly IMvxNavigationService _navigationService;
        private ILogService _logger;

        public PierClaimLocationViewModel(IMvxNavigationService navigationService)
        {
            _logger = Mvx.Resolve<ILogService>();
            _navigationService = navigationService;
        }

        public override Task Initialize(string parameter)
        {
            pierClaimFlag = parameter;
            return Task.FromResult(true);
        }

        public async void InitializeList()
        {
            try
            {
                PageLocationTitle = "Please select a " + pierClaimFlag + " location";
                _logger.Trace("Service: SqliteService<UserModel> Method: LoadUser");
                ISqliteService<UserModel> userRepo = new SqliteService<UserModel>();
                var user = await userRepo.Load();
                GetPierClaimLocationInput pierInput = new GetPierClaimLocationInput()
                { AppName = user.Name, Username = user.Username, DeviceName = "Apple", Station = "123", Version = "1" };
                if (Mvx.Resolve<IValidation>().ObjectIsNotNull(pierInput))
                {
                    PierResponse = Mvx.Resolve<IRestService>().GetPierClaimLocation(pierInput);
                }
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("SqliteService<UserModel> Method: LoadUser ex: " + e.ToString() + "");
            }
        }

        public IMvxCommand ShowPierScanCommand
        {
            get { return new MvxCommand(ShowPierScanExecuted); }
        }

        private void ShowPierScanExecuted()
        {
            try
            {
                _logger.Trace("ShowPierScanExecuted Start");
                _navigationService.Navigate<PierClaimScanViewModel,Tuple<string,string>>(new Tuple<string, string>(pierClaimFlag,PierLocation));
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowPierScanExecuted ex: " + e.ToString() + "");
            }

        }

        public string pierClaimFlag;
        private string _pierLocation;
        public string PierLocation
        {
            get { return _pierLocation; }
            set { _pierLocation = value; }
        }

        private string _pageLocationTitle = "Please select a location";
        public string PageLocationTitle
        {
            get { return _pageLocationTitle; }
            set
            {
                _pageLocationTitle = value;
                RaisePropertyChanged(() => PageLocationTitle);
            }
        }

        private GetPierClaimLocationResponse _pierResponse;
        public  GetPierClaimLocationResponse PierResponse
        {
            get { return _pierResponse; }
            set { _pierResponse = value;
                RaisePropertyChanged(() => PierResponse);
            }
        }

    }
}