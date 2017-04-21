using MvvmCross.Core.ViewModels;
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
            ShowViewModel<SearchResultViewModel>();
        }
        public IMvxCommand ShowSearchResultCommand
        {
            get { return new MvxCommand(ShowSearchResultExecuted); }
        }

        private void ShowSearchResultExecuted()
        {
            ShowViewModel<SearchResultViewModel>();
        }

        public IMvxCommand ShowLocationCommand
        {
            get { return new MvxCommand(ShowLocationExecuted); }
        }

        private void ShowLocationExecuted()
        {
            ShowViewModel<SearchTrackViewModel>();
        }
    }
}
