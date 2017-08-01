using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.ViewModels.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
   public class BottomNavigationViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public BottomNavigationViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void ShowSearch()
        {
            _navigationService.Navigate<BagInfoViewModel>();
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
                _navigationService.Navigate<BagInfoViewModel>();
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
                _navigationService.Navigate<BagTrackViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }
    }
}
