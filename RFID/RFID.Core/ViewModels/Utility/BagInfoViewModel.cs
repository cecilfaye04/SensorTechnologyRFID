using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Newtonsoft.Json;
using RFID.Core.Entities;
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
    public class BagInfoViewModel : BaseViewModel<BagInfo>
    {
        private readonly IMvxNavigationService _navigationService;
        private ILogService _logger;

        public BagInfoViewModel(IMvxNavigationService navigationService)
        {
            _logger = Mvx.Resolve<ILogService>();
            _navigationService = navigationService;
        }
        
        public override Task Initialize(BagInfo parameter)
        {
            BagtagNo = parameter.Bagtag;
            Name = parameter.PaxName;
            Flight = parameter.FltCode + parameter.FltNum;
            FlightDate = parameter.FltDate;
            Itinerary = parameter.PaxItinerary;
            BagLatitude = parameter.Latitude.ToString();
            BagLongitude = parameter.Longitude.ToString();
            ScanHistory = parameter.BagScanPoints;
            return Task.FromResult(true);
        }

        public IMvxCommand ShowSearchTrackCommand
        {
            get { return new MvxCommand(ShowSearchTrackExecuted); }
        }

        private void ShowSearchTrackExecuted()
        {
            try
            {
                _logger.Trace("ShowSearchTrackExecuted Start");
                _navigationService.Navigate<BagLocateViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowSearchTrackExecuted ex: " + e.ToString() + "");
            }
        }
     
        private string _itinerary;
        public string Itinerary
        {
            get { return _itinerary; }
            set
            {
                _itinerary = value;
                RaisePropertyChanged(() => Itinerary);
            }
        }

        private string _flightDate;
        public string FlightDate
        {
            get { return _flightDate; }
            set
            {
                _flightDate = value;
                RaisePropertyChanged(() => FlightDate);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private string _flight;
        public string Flight
        {
            get { return _flight; }
            set
            {
                _flight = value;
                RaisePropertyChanged(() => Flight);
            }
        }

        private string _bagtag;

        public string BagtagNo
        {
            get { return _bagtag; }
            set
            {
                _bagtag = value;
                RaisePropertyChanged(() => BagtagNo);
            }
        }

        private string _baglatitude;
        public string BagLatitude
        {
            get { return _baglatitude; }
            set { _baglatitude = value; }
        }

        private string _bagLongitude;
        public string BagLongitude
        {
            get { return _bagLongitude; }
            set { _bagLongitude = value; }
        }

        private List<BagScanPoint> scanHistory;
        public List<BagScanPoint> ScanHistory
        {
            get { return scanHistory; }
            set { scanHistory = value; RaisePropertyChanged(() => ScanHistory); }
        }

    }


}