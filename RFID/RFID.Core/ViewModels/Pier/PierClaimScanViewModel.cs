using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Entities;
using RFID.Core.Helpers;
using RFID.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class PierClaimScanViewModel : BaseViewModel<Tuple<string, string>>
    {
        private ILogService Logger;
        public PierClaimScanViewModel() {
            //uncomment InitReaders once implementation for the QR, RFID and Barcode reader is ready
            Logger = Mvx.Resolve<ILogService>();
            InitReaders();

        }
        public override Task Initialize(Tuple<string, string> parameter)
        {
            pierClaimFlag = parameter.Item1;
            PierLocation = parameter.Item2;
            return Task.FromResult(true);
        }

        public string pierClaimFlag;

        private string _pierLocation;
        public string PierLocation
        {
            get { return _pierLocation; }
            set { _pierLocation = value; }
        }

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
                //return new MvxCommand(ScanBagtagExecuted);
                return new MvxCommand(RunQRCOde);
            }
        }

        private async void RunQRCOde() {

            QRCodeReader.Open();
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

    #region Readers

        IBarcodeService BarcodeReader;
        IQrcodeService QRCodeReader;
        IRfidService RFIDReader;
        private void InitReaders()
        {
            //BarcodeReader = Mvx.Resolve<IBarcode>();
            QRCodeReader = Mvx.Resolve<IQrcodeService>();
            //RFIDReader = Mvx.Resolve<IRfid>();

            QRCodeReader.OnScanEvent += OnScanEvent;
            QRCodeReader.OnScanFail += OnScanFail;
            //BarcodeReader.OnScanEvent += OnScanEvent;
            //BarcodeReader.OnScanFail += OnScanFail;

            //RFIDReader.OnRFIDScanEvent += OnRFIDScanEvent;
            //RFIDReader.OnRFIDScanFail += OnRFIDScanFail;
            //RFIDReader.OnRFIDWriteEvent += OnRFIDScanEvent;
            //RFIDReader.OnRFIDWriteEventFailed += OnRFIDScanFail;
        }

        private void OnScanEvent(object sender, ScanEventArgs e){
            try
            {
                BagtagNo = e.ScannedValue;
            }
            catch (Exception ex)
            {
                Logger.Trace("OnScanEvent Ex: " + ex.ToString());
            }
        }

        private void OnScanFail(object sender, ScanEventArgs e) {

        }

        private void OnRFIDScanFail(object sender, RFIDScanEventArgs e)
        {

        }

        private void OnRFIDScanEvent(object sender, RFIDScanEventArgs e)
        {

        }
    #endregion

}
}