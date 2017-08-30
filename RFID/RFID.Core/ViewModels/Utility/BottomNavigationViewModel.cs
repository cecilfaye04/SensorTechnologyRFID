using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using RFID.Core.ViewModels.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
   public class BottomNavigationViewModel : BaseViewModel<BagInfo>
    {
        private readonly IMvxNavigationService _navigationService;
        private ILogService _logger;
        private BagInfo _BagInfo;
        public BottomNavigationViewModel(IMvxNavigationService navigationService)
        {
            _logger = Mvx.Resolve<ILogService>();
            _navigationService = navigationService;
        }

        public override Task Initialize(BagInfo parameter)
        {
            _BagInfo = new BagInfo();
            _BagInfo = parameter;
            return Task.FromResult(true);
        }

        public void ShowSearch()
        {
            _logger.Trace("ShowSearch Start");
            _navigationService.Navigate<BagInfoViewModel, BagInfo>(_BagInfo);
        }

        public IMvxCommand ShowSearchResultCommand
        {
            get { return new MvxCommand(ShowSearchResultExecuted); }
        }

        private void ShowSearchResultExecuted()
        {
            try
            {
                _logger.Trace("ShowSearchResultExecuted Start");
                _navigationService.Navigate<BagInfoViewModel, BagInfo>(_BagInfo);
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowSearchResultExecuted ex: " + e.ToString() + "");
            }
        }

        public IMvxCommand ShowLocationCommand
        {
            get { return new MvxCommand(ShowLocationExecuted); }
        }

        private void ShowLocationExecuted()
        {
            try
            {
                _logger.Trace("ShowLocationExecuted Start");
                _navigationService.Navigate<BagLocateViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowLocationExecuted ex: " + e.ToString() + "");
            }
        }

        public IMvxCommand ShowTrackCommand
        {
            get { return new MvxCommand(ShowTrackExecuted); }
        }

        private void ShowTrackExecuted()
        {
            try
            {
                _logger.Trace("ShowTrackCommand Start");
                _navigationService.Navigate<BagTrackViewModel, BagInfo>(_BagInfo);
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowTrackCommand ex: " + e.ToString() + "");
            }
        }

      
    }
}
