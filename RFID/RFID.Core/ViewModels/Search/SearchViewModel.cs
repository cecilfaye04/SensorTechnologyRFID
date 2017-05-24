using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Entities;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using RFID.Core.Services;
using System.Collections.Generic;

namespace RFID.Core.ViewModels
{
    public class SearchViewModel : BaseViewModel    
    {
        public IMvxCommand ShowSearchResultCommand
        {
            get { return new MvxCommand(ShowSearchResultExecuted); }
        }

        private void ShowSearchResultExecuted()
        {
            ProgressBarVisible = true;
            ShowViewModel<BottomNavigationViewModel>();
            base.StoreParam("Bagtag", BagtagNo);

            GetBagInfoInput baginput = new GetBagInfoInput() { Bagtag = BagtagNo, DeviceName = "Apple", Station = "123", Username = "admin", Version = "1" };

            var bagInfo = Mvx.Resolve<IRestService>().GetBagInfo(baginput);

            if (bagInfo.ReturnCode == "1") {
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
                ShowViewModel<BagInfoViewModel>(base.SParam);
            } 
          
            ProgressBarVisible = false;
        }

        private string _bagtagNo;

        public string BagtagNo
        {
            get { return _bagtagNo; }
            set {
                _bagtagNo = value;
                RaisePropertyChanged(() => BagtagNo);
            }
        }




    }
}
