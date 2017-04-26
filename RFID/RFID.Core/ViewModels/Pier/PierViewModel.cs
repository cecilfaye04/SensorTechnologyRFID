using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class PierViewModel : BaseViewModel
    {
        public IMvxCommand ShowPierScanCommand
        {
            get { return new MvxCommand(ShowPierScanExecuted); }
        }

        private void ShowPierScanExecuted()
        {
            ShowViewModel<PierScanViewModel>();
        }
    }
}
