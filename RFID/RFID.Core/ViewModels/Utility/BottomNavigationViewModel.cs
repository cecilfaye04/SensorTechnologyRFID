using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Models;
using RFID.Core.ViewModels.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
   public class BottomNavigationViewModel : MvxViewModel<BagInfo>
    {
        private readonly IMvxNavigationService _navigationService;
        private BagInfo _BagInfo = new BagInfo();
        public BottomNavigationViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override Task Initialize(BagInfo parameter)
        {
            _BagInfo = parameter;
            return Task.FromResult(true);
        }

        public void ShowSearch()
        {
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
                //logger.Trace("Navigate : BagInfoViewModel")
                _navigationService.Navigate<BagInfoViewModel, BagInfo>(_BagInfo);
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
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
                //logger.Trace("Navigate : BagLocateViewModel")
                _navigationService.Navigate<BagLocateViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
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
                //logger.Trace("Navigate : BagTrackViewModel")
                _navigationService.Navigate<BagTrackViewModel, BagInfo>(_BagInfo);
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }

      
    }
}
