using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
   public class HomeViewModel : BaseViewModel
    {

        public override async void Start()
        {
            await Mvx.Resolve<IInitilializeSqliteService>().InitializeAsync();
            var user = await Mvx.Resolve<ISqliteService>().LoadUserAsync();
            List<string> appAccess = user.AppAccess.Split(',').ToList<string>();
            appAccess.Reverse();
            AppAccess = appAccess;
        }


        private List<string> appAccess;

        public List<string> AppAccess
        {
            get { return appAccess; }
            set { appAccess = value; }
        }

        public IMvxCommand ShowPeirCommand
        {
            get { return new MvxCommand(ShowPeirExecuted); }
        }


        private void ShowPeirExecuted()
        {
            ShowViewModel<PierClaimLocationViewModel>();
        }

        public IMvxCommand ShowDepartureCommand
        {
            get { return new MvxCommand(ShowDepartureExecuted); }
        }

        private void ShowDepartureExecuted()
        {
            ShowViewModel<FlightEntryViewModel>();
        }

    }

}
