using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Newtonsoft.Json;
using RFID.Core.Entities;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                //var xss = JsonConvert.SerializeObject(mBagInfo.BagScanPoints);
                //mBagInfo.BagScanPointsBlobbed = xss;
                Mvx.Resolve<ISqliteService>().UpdateBagInfoAsync(mBagInfo);

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
