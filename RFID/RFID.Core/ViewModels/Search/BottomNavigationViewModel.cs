using MvvmCross.Core.ViewModels;
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
            ShowViewModel<BagInfoViewModel>();
        }

        public IMvxCommand ShowLocationCommand
        {
            get { return new MvxCommand(ShowLocationExecuted); }
        }

        private void ShowLocationExecuted()
        {
            ShowViewModel<BagLocateViewModel>();
        }

        public IMvxCommand ShowTrackCommand
        {
            get { return new MvxCommand(ShowTrackExecuted); }
        }

        private void ShowTrackExecuted()
        {
            ShowViewModel<BagTrackViewModel>();
        }
    }
}
