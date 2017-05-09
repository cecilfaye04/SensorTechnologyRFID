using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Entities;
using RFID.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class SearchViewModel : BaseViewModel    
    {

        public IMvxCommand ShowSearchResultCommand
        {
            get { return new MvxCommand(ShowSearchResultExecuted); }
        }

        private void ShowSearchResultExecuted()
        {
            ShowViewModel<BottomNavigationViewModel>();
            base.StoreParam("Bagtag", BagtagNo);
            ShowViewModel<BagInfoViewModel>(base.SParam);

        }

        private string _bagtagNo;

        public string BagtagNo
        {
            get { return _bagtagNo; }
            set {
                _bagtagNo = value;
                RaisePropertyChanged(() => BagtagNo);
            }
        }




    }
}
