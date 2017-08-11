using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Entities;
using RFID.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class DepArrScanScreenViewModel : BaseViewModel
    {
        private string _bagtagNo;
        public string BagtagNo
        {
            get { return _bagtagNo; }
            set
            {
                _bagtagNo = value;
                RaisePropertyChanged(() => BagtagNo);
            }
        }

        private string _normalLoadCount="0";
        public string NormalLoadCount
        {
            get { return _normalLoadCount; }
            set
            {
                _normalLoadCount = value;
                RaisePropertyChanged(() => NormalLoadCount);
            }
        }

        private string _heavyLoadCount="0";
        public string HeavyLoadCount
        {
            get { return _heavyLoadCount; }
            set
            {
                _heavyLoadCount = value;
                RaisePropertyChanged(() => HeavyLoadCount);
            }
        }

        private string _valetLoadCount="0";
        public string ValetLoadCount
        {
            get { return _valetLoadCount; }
            set
            {
                _valetLoadCount = value;
                RaisePropertyChanged(() => ValetLoadCount);
            }
        }

        private string _mailLoadCount = "0/0";
        public string MailLoadCount
        {
            get { return _mailLoadCount; }
            set
            {
                _mailLoadCount = value;
                RaisePropertyChanged(() => MailLoadCount);
            }
        }

        private string _freightLoadCount = "0/0";
        public string FreightLoadCount
        {
            get { return _freightLoadCount; }
            set
            {
                _freightLoadCount = value;
                RaisePropertyChanged(() => FreightLoadCount);
            }
        }

        private string _ballastLoadCount="0/0";
        public string BallastLoadCount
        {
            get { return _ballastLoadCount; }
            set
            {
                _ballastLoadCount = value;
                RaisePropertyChanged(() => BallastLoadCount);
            }
        }

        private string _comatLoadCount = "0/0";
        public string ComatLoadCount
        {
            get { return _comatLoadCount; }
            set
            {
                _comatLoadCount = value;
                RaisePropertyChanged(() => ComatLoadCount);
            }
        }

        private string _totalLoadCount = "0";
        public string TotalLoadCount
        {
            get { return _totalLoadCount; }
            set
            {
                _totalLoadCount = value;
                RaisePropertyChanged(() => TotalLoadCount);
            }
        }

        private string _progressCount = "0";
        public string ProgressCount
        {
            get { return _progressCount; }
            set
            {
                _progressCount = value;
                RaisePropertyChanged(() => ProgressCount);
            }
        }



        public IMvxCommand DepArrScanBagtagCommand
        {
            get
            {
                return new MvxCommand(DepArrScanBagtagExecuted);
            }
        }

        private async void DepArrScanBagtagExecuted()
        {
            DepArrScanInput scanInput = new DepArrScanInput();

            scanInput.Username = "admin";
            scanInput.DeviceName = "Android";
            scanInput.Station = "MNL";
            scanInput.CarrierCode = "5J";
            scanInput.FlightNumber = "557";
            scanInput.Position = "1";
            scanInput.Bagtag = BagtagNo;
            scanInput.ScanTime = DateTime.Now;

            var scanResult = await Mvx.Resolve<IRestService>().DepArrScan(scanInput);
            var x = scanResult.Positions.FirstOrDefault().Commodities;
            ProgressCount = scanResult.Positions.FirstOrDefault().Progress;
            TotalLoadCount = "1";
            foreach (var item in x)
            {
                switch (item.CommodityType)
                {
                    case "normalBags":
                        NormalLoadCount = item.LoadCount;
                        break;
                    case "heavyBags":
                        HeavyLoadCount = item.LoadCount;
                        break;
                    case "valetBags":
                        ValetLoadCount = item.LoadCount;
                        break;
                    case "mail":
                        MailLoadCount = item.LoadCount + "/" + item.PlannedCount;
                        break;
                    case "freight":
                        FreightLoadCount = item.LoadCount + "/" + item.PlannedCount;
                        break;
                    case "ballast":
                        BallastLoadCount = item.LoadCount + "/" + item.PlannedCount;
                        break;
                    case "comat":
                        ComatLoadCount = item.LoadCount + "/" + item.PlannedCount;
                        break;
                    default:
                        break;
                }
            }
 
        }
    }
}