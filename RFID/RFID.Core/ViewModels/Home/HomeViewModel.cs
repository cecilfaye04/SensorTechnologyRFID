using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
   public class HomeViewModel : BaseViewModel
    {
        public IMvxCommand ShowPeirCommand
        {
            get { return new MvxCommand(ShowPeirExecuted); }
        }

        private void ShowPeirExecuted()
        {
            ShowViewModel<PierViewModel>();
        }

        public IMvxCommand ShowDepartureCommand
        {
            get { return new MvxCommand(ShowDepartureExecuted); }
        }

        private void ShowDepartureExecuted()
        {
            ShowViewModel<DepartureViewModel>();
        }

    }

}
