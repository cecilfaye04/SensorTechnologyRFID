using Acr.UserDialogs;
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

namespace RFID.Core.ViewModels
{
    public class PierClaimLocationViewModel : BaseViewModel
    {
        public async void InitializeList()
        {
            try
            {
                //logger.Trace("SqliteService<UserModel> : LoadUser")
                ISqliteService<UserModel> userRepo = new SqliteService<UserModel>();
                var user = await userRepo.Load();
                GetPierClaimLocationInput pierInput = new GetPierClaimLocationInput()
                { AppName = user.Name, Username = user.Username, DeviceName = "Apple", Station = "123", Version = "1" };
                if (Mvx.Resolve<IValidation>().ObjectIsNotNull(pierInput))
                {
                    PierResponse = Mvx.Resolve<IRestService>().GetPierClaimLocation(pierInput);
                }

            }
            catch (Exception)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }

        public IMvxCommand ShowPierScanCommand
        {
            get { return new MvxCommand(ShowPierScanExecuted); }
        }

        private void ShowPierScanExecuted()
        {
            base.StoreParam("PierLocation", PierLocation);
            try
            {
                //logger.Trace("ShowViewModel : PierClaimScanViewModel")
                ShowViewModel<PierClaimScanViewModel>(base.SParam);
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }

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
            set { _pierResponse = value;
                RaisePropertyChanged(() => PierResponse);
            }
        }

    }
}