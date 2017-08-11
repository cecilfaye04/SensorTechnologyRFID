using Acr.UserDialogs;
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
    public class PierClaimScanViewModel : MvxViewModel<Tuple<string, string>>
    {

        public override Task Initialize(Tuple<string, string> parameter)
        {
            pierClaimFlag = parameter.Item1;
            PierLocation = parameter.Item2;
            return Task.FromResult(true);
        }

        private string _pierLocation;

        public string PierLocation
        {
            get { return _pierLocation; }
            set { _pierLocation = value; }
        }

        public string pierClaimFlag;
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

        private int _successValue;
        public int SuccessValue
        {
            get { return _successValue; }
            set
            {
                _successValue = value;
                RaisePropertyChanged(() => SuccessValue);
            }
        }

        private int _failedValue;
        public int FailedValue
        {
            get { return _failedValue; }
            set
            {
                _failedValue = value;
                RaisePropertyChanged(() => FailedValue);
            }
        }

        private int _totalValue;
        public int TotalValue
        {
            get { return _totalValue; }
            set
            {
                _totalValue = value;
                RaisePropertyChanged(() => TotalValue);
            }
        }

        public IMvxCommand ScanBagtagCommand
        {
            get
            {
                return new MvxCommand(ScanBagtagExecuted);
            }
        }

        private async void ScanBagtagExecuted()
        {
            if (!string.IsNullOrEmpty(BagtagNo))
            {
                PierClaimScanInput pierClaimInput = new PierClaimScanInput();
                PierClaimScanResponse scanResult = new PierClaimScanResponse();

                pierClaimInput.Username = "admin";
                pierClaimInput.Version = "0.1";
                pierClaimInput.DeviceName = "Android";
                pierClaimInput.Station = "MNL";
                pierClaimInput.Location = "Pier";
                pierClaimInput.SubLocation = "PIER0001";
                List<Bag> bagList = new List<Bag>();
                bagList.Add(new Bag() { Bagtag = BagtagNo, Latitude = "", Longitude = "", ScanTime = DateTime.Now });
                pierClaimInput.Bags = bagList;

                if (pierClaimFlag == "Pier")
                {
                     scanResult = await Mvx.Resolve<IRestService>().PierScan(pierClaimInput);
                }
                else
                {
                     scanResult = await Mvx.Resolve<IRestService>().ClaimScan(pierClaimInput);
                }
               
                foreach (var bag in scanResult.Bags)
                {
                    if (bag.Success == true)
                    {
                        TotalValue++;
                        SuccessValue++;
                    }
                    else
                    {
                        TotalValue++;
                        FailedValue++;
                    }
                }

                BagtagNo = "";
            }
            else
            {
                Mvx.Resolve<IUserDialogs>().Alert("Bagtag cannot be empty.",null, "Dismiss");
            }
        }


    }
}