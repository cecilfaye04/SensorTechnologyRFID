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

    }

    public class BaseViewModel<T>: MvxViewModel<T> where T : class
    {
        private bool progressBarVisible;

        public bool ProgressBarVisible
        {
            get { return progressBarVisible; }
            set { progressBarVisible = value; RaisePropertyChanged(() => ProgressBarVisible); }
        }

        public override Task Initialize(T parameter)
        {
            return Task.FromResult(true);
        }
    }
}
