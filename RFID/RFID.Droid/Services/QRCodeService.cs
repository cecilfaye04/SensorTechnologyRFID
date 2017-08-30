using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RFID.Core.Helpers;
using RFID.Core.Interfaces;
using ZXing;
using ZXing.Mobile;
using MvvmCross.Platform;
using System.Threading.Tasks;
using Android.Content.PM;
using RFID.Droid.Views;

namespace RFID.Droid.Services
{
    public class QRCodeService : IQrcodeService
    {
        ILogService Logger;
        MobileBarcodeScanner Scanner;
        public QRCodeService()
        {
            //Logger = Mvx.Resolve<ILogService>();
        }

        public bool IsScanning
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler<ScanEventArgs> OnScanEvent;
        public event EventHandler<ScanEventArgs> OnScanFail;

        public bool Close()
        {
            throw new NotImplementedException();
        }

        public bool Open()
        {
            try
            {
                OpernReader();

            }
            catch (Exception ex)
            {

                Logger.Trace("QRCode Open ex: " + ex.ToString());
                return false;
            }
            return true;
        }

        private async Task OpernReader()
        {
            
            Scanner = new MobileBarcodeScanner();
            Scanner.UseCustomOverlay = false;
            var result = await Scanner.Scan();

            if (result != null)
            {
                HandleScanResult(result);
            }
        }

        private void HandleScanResult(ZXing.Result result)
        {

            OnScanEvent(this, new ScanEventArgs(result.Text));

        }



        [Java.Interop.Export("UITestBackdoorScan")]
        public Java.Lang.String UITestBackdoorScan(string param)
        {
            var expectedFormat = BarcodeFormat.QR_CODE;
            Enum.TryParse(param, out expectedFormat);
            var opts = new MobileBarcodeScanningOptions
            {
                PossibleFormats = new List<BarcodeFormat> { expectedFormat }
            };
            var barcodeScanner = new MobileBarcodeScanner();

            Console.WriteLine("Scanning " + expectedFormat);

            //Start scanning
            barcodeScanner.Scan(opts).ContinueWith(t => {

                var result = t.Result;

                var format = result?.BarcodeFormat.ToString() ?? string.Empty;
                var value = result?.Text ?? string.Empty;

                //RunOnUiThread(() => {

                //    AlertDialog dialog = null;
                //    dialog = new AlertDialog.Builder(this)
                //                    .SetTitle("Barcode Result")
                //                    .SetMessage(format + "|" + value)
                //                    .SetNeutralButton("OK", (sender, e) => {
                //                        dialog.Cancel();
                //                    }).Create();
                //    dialog.Show();
                //});
            });

            return new Java.Lang.String();
        }
    }
}