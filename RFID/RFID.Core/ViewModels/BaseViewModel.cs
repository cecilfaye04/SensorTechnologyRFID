using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RFID.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private bool progressBarVisible;

        public bool ProgressBarVisible
        {
            get { return progressBarVisible; }
            set { progressBarVisible = value; RaisePropertyChanged(() => ProgressBarVisible); }
        }
    }
}
