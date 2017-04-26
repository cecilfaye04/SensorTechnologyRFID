using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class SearchResultViewModel : BaseViewModel
    {
        public SearchResultViewModel()
        {

        }

        public IMvxCommand ShowSearchTrackCommand
        {
            get { return new MvxCommand(ShowSearchTrackExecuted); }
        }

        private void ShowSearchTrackExecuted()
        {
            ShowViewModel<SearchTrackViewModel>();
        }
    }
}
