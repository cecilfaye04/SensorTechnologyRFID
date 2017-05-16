using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
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
    public class BagInfoViewModel : BaseViewModel
    {


        public BagInfoViewModel()
        {


            RetrieveDisplayBagInfo();
            testScanHistory();
        }

        /// <summary>
        /// delete after solving the issue in LoadBagInfoAsync
        /// </summary>
        private void testScanHistory()
        {
            GetBagInfoInput baginput = new GetBagInfoInput() { Bagtag = BagtagNo, DeviceName = "Apple", Station = "123", Username = "admin", Version = "1" };

            var bagInfo = Mvx.Resolve<IRestService>().GetBagInfo(baginput);

            Name = bagInfo.PaxName;
            Flight = bagInfo.FltCode + bagInfo.FltNum;
            FlightDate = bagInfo.FltDate;
            Itinerary = bagInfo.PaxItinerary;
            BagLatitude = bagInfo.Latitude;
            BagLongitude = bagInfo.Longitude;

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


            ScanHistory = mscanHistory;

        }

        private async void RetrieveDisplayBagInfo()
        {
            var mBagInfo = await Mvx.Resolve<ISqliteService>().LoadBagInfoAsync("123");
            Name = mBagInfo.PaxName;
            Flight = mBagInfo.FltCode + mBagInfo.FltNum;
            FlightDate = mBagInfo.FltDate;
            Itinerary = mBagInfo.PaxItinerary;
            BagLatitude = mBagInfo.Latitude.ToString();
            BagLongitude = mBagInfo.Longitude.ToString();
            //scanHistory = mBagInfo.BagScanPoints;
        }


        public override void Start()
        {
            BagtagNo = base.GetParam("Bagtag");
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            if (parameters.Data.Count > 0)
            {
                base.RParam = (Dictionary<string, string>)parameters.Data;
            }
        }



        public IMvxCommand ShowSearchTrackCommand
        {
            get { return new MvxCommand(ShowSearchTrackExecuted); }
        }

        private void ShowSearchTrackExecuted()
        {
            base.StoreParam("BagLatitude", BagLatitude);
            base.StoreParam("BagLongitude", BagLongitude);
            ShowViewModel<BagLocateViewModel>(base.SParam);
        }


        private string _itinerary;

        public string Itinerary
        {
            get { return _itinerary; }
            set { _itinerary = value;
                RaisePropertyChanged(() => Itinerary); }
        }

        private string _flightDate;

        public string FlightDate
        {
            get { return _flightDate; }
            set { _flightDate = value;
                RaisePropertyChanged(() => FlightDate); }
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
            set { _bagtag = value;
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