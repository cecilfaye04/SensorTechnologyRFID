using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Entities;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using RFID.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels.Search
{
   public class SearchMultipleViewModel : BaseViewModel
    {
       
        private readonly IMvxNavigationService _navigationService;
        public SearchMultipleViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IMvxCommand ShowSearchResultCommand
        {
            get { return new MvxCommand(ShowSearchResultExecuted); }
        }

        private void ShowSearchResultExecuted()
        {
            //Sample 
            var bagInfo = new GetBagInfoResponse();
            GetBagInfoInput baginput = new GetBagInfoInput() { Bagtag = "1234", DeviceName = "Apple", Station = "123", Username = "admin", Version = "1" };
            try
            {
                bagInfo = Mvx.Resolve<IRestService>().GetBagInfo(baginput);
                var mBagInfo = new BagInfo();
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
                mBagInfo.Bagtag = "1111111111";
                mBagInfo.PaxName = bagInfo.PaxName;
                mBagInfo.PaxItinerary = bagInfo.PaxItinerary;
                mBagInfo.Latitude = bagInfo.Latitude;
                mBagInfo.Longitude = bagInfo.Longitude;
                mBagInfo.FltCode = bagInfo.FltCode;
                mBagInfo.FltDate = bagInfo.FltDate;
                mBagInfo.FltNum = bagInfo.FltNum;
                mBagInfo.BagScanPoints = mscanHistory;
                _navigationService.Navigate<BottomNavigationViewModel, BagInfo>(mBagInfo);
                _navigationService.Navigate<BagInfoViewModel, BagInfo>(mBagInfo);
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
            }
        }
    }
}
