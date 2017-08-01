using Acr.UserDialogs;
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
        public void ShowSearch()
        {

            ShowViewModel<BagInfoViewModel>();
        }

        public IMvxCommand ShowSearchResultCommand
        {
            get { return new MvxCommand(ShowSearchResultExecuted); }
        }

        private void ShowSearchResultExecuted()
        {
            try
            {
                //logger.Trace("ShowViewModel : BagInfoViewModel")
                ShowViewModel<BagInfoViewModel>();
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
                //logger.Trace("ShowViewModel : BagLocateViewModel")
                ShowViewModel<BagLocateViewModel>();
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
                //logger.Trace("ShowViewModel : BagTrackViewModel")
                ShowViewModel<BagTrackViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }
    }
}
