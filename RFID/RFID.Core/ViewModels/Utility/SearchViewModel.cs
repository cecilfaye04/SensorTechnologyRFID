using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Entities;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using RFID.Core.Services;
using RFID.Core.ViewModels.Search;
using System;
using System.Collections.Generic;

namespace RFID.Core.ViewModels
{
    public class SearchViewModel : BaseViewModel 
    {
        private readonly IMvxNavigationService _navigationService;
        private ILogService _logger;

        public SearchViewModel(IMvxNavigationService navigationService)
        {
            _logger = Mvx.Resolve<ILogService>();
            _navigationService = navigationService;
        }

        public IMvxCommand ShowSearchResultCommand
        {
            get { return new MvxCommand(ShowSearchResultExecuted); }
        }

        private void ShowSearchResultExecuted()
        {
            //ProgressBarVisible = true;
            BagInfo mBagInfo = new BagInfo();
            if (Mvx.Resolve<IValidation>().Is10Digits(BagtagNo) && !String.IsNullOrEmpty(BagtagNo))
            {
                GetBagInfoInput baginput = new GetBagInfoInput() { Bagtag = BagtagNo, DeviceName = "Apple", Station = "123", Username = "admin", Version = "1" };
                var bagInfo = new GetBagInfoResponse();
                try
                {
                    if (Mvx.Resolve<IValidation>().ObjectIsNotNull(baginput))
                    {
                        bagInfo = Mvx.Resolve<IRestService>().GetBagInfo(baginput);
                    }
                }
                catch (Exception e)
                {
                    Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                    _logger.Trace("ShowSearchResultExecuted ex: " + e.ToString() + "");
                }

                if (bagInfo.StatusCode == "0")
                {
                    BagScanPoint scanPoint;
                    List<BagScanPoint> mscanHistory = new List<BagScanPoint>();
                    foreach (var item in bagInfo.BagHistory)
                    {
                        scanPoint = new BagScanPoint();
                        scanPoint.Icon = item.ScanType;
                        scanPoint.ScanPoint = item.Location;
                        scanPoint.ScanTime = item.DateTime;
                        mscanHistory.Add(scanPoint);
                    }
                    mBagInfo.Bagtag = BagtagNo;
                    mBagInfo.PaxName = bagInfo.PaxName;
                    mBagInfo.PaxItinerary = bagInfo.PaxItinerary;
                    mBagInfo.Latitude = bagInfo.Latitude;
                    mBagInfo.Longitude = bagInfo.Longitude;
                    mBagInfo.FltCode = bagInfo.FltCode;
                    mBagInfo.FltDate = bagInfo.FltDate;
                    mBagInfo.FltNum = bagInfo.FltNum;
                    mBagInfo.BagScanPoints = mscanHistory;
                    ISqliteService<BagInfo> bagRepo = new SqliteService<BagInfo>();
                    var user = bagRepo.InsertUpdate(mBagInfo);
                    _navigationService.Navigate<BottomNavigationViewModel, BagInfo>(mBagInfo);
                    _navigationService.Navigate<BagInfoViewModel, BagInfo>(mBagInfo);
                }
            }
            else
            {
                Mvx.Resolve<IUserDialogs>().Alert("Bagtag no must contains 10 digits.","Invalid Bagtag no!","Dismiss");
            }
          
            //ProgressBarVisible = false;
        }

        private string _bagtagNo ;
        public string BagtagNo
        {
            get { return _bagtagNo; }
            set {
                _bagtagNo = value;
                RaisePropertyChanged(() => BagtagNo);
            } 
        }

        public IMvxCommand ShowMultipleSearchCommand
        {
            get { return new MvxCommand(ShowMultipleSearchExecuted); }
        }

        private void ShowMultipleSearchExecuted()
        {
            try
            {
                _logger.Trace("ShowMultipleSearchExecuted Start");
                _navigationService.Navigate<SearchMultipleViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowMultipleSearchExecuted ex: " + e.ToString() + "");
            }
        }
    }
}
