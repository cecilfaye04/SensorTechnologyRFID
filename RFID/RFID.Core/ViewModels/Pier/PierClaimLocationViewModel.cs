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
    public class PierClaimLocationViewModel : BaseViewModel
    {

        public PierClaimLocationViewModel()
        {
          

        }

        public async override void Start()
        {
            await Mvx.Resolve<IInitilializeSqliteService>().InitializeAsync();
            var user = await Mvx.Resolve<ISqliteService>().LoadUserAsync();
            GetPierClaimLocationInput pierInput = new GetPierClaimLocationInput()
            { AppName = user.Name, Username = user.Username , DeviceName = "Apple" , Station="123", Version="1"};
            PierResponse = Mvx.Resolve<IRestService>().GetPierClaimLocation(pierInput);
        }



        public IMvxCommand ShowPierScanCommand
        {
            get {
                return new MvxCommand(ShowPierScanExecuted); }
        }

        private void ShowPierScanExecuted()
        {
            base.StoreParam("PierLocation", PierLocation);
            ShowViewModel<PierClaimScanViewModel>(base.SParam);
        }

        private string _pierLocation;

        public string PierLocation
        {
            get { return _pierLocation; }
            set { _pierLocation = value; }
        }

        private GetPierClaimLocationResponse _pierResponse;

        public  GetPierClaimLocationResponse PierResponse
        {
            get { return _pierResponse; }
            set { _pierResponse = value; }
        }

    }
}