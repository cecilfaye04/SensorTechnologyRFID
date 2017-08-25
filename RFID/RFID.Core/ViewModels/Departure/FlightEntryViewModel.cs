using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
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
    public class FlightEntryViewModel : MvxViewModel<string>
    {
        private readonly IMvxNavigationService _navigationService;
        private ILogService _logger;

        public FlightEntryViewModel(IMvxNavigationService navigationService)
        {
            _logger = Mvx.Resolve<ILogService>();
            _navigationService = navigationService;
        }

        public override Task Initialize(string parameter)
        {
            departureArrivalFlag = parameter;
            return Task.FromResult(true);
        }

        public string departureArrivalFlag { get; set; }

        public IMvxCommand ShowDepartmentScanCommand
        {
            get { return new MvxCommand(ShowDepartmentScanExecuted); }
        }

        private void ShowDepartmentScanExecuted()
        {
            try
            {
                _logger.Trace("ShowDepartmentScanExecuted Start");
                _navigationService.Navigate<DepArrScanScreenViewModel, string>(departureArrivalFlag);
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowDepartmentScanExecuted ex: " + e.ToString() + "");
            }
        }


    }
}