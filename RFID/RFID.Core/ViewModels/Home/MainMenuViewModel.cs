using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private ILogService _logger;

        public MainMenuViewModel(IMvxNavigationService navigationService)
        {
            _logger = Mvx.Resolve<ILogService>();
            _navigationService = navigationService;
        }

        public void ShowMenu()
        {
            try
            {
                _logger.Trace("ShowMenu Start");
                _navigationService.Navigate<HomeViewModel>();
                _navigationService.Navigate<SideMenuViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowMenu ex: " + e.ToString() + "");
            }
        }

        public IMvxCommand ShowSearchCommand
        {
            get { return new MvxCommand(ShowSearchExecuted); }
        }

        private void ShowSearchExecuted()
        {
            try
            {
                _logger.Trace("ShowSearchExecuted Start");
                _navigationService.Navigate<SearchViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                _logger.Trace("ShowSearchExecuted ex: " + e.ToString() + "");
            }
        }
    }
}