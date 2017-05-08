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
        
        public void ShowMenu()
        {
            ShowViewModel<HomeViewModel>();
            ShowViewModel<SideMenuViewModel>();
        }

        public IMvxCommand ShowSearchCommand
        {
            get { return new MvxCommand(ShowSearchExecuted); }
        }

        private void ShowSearchExecuted()
        {
            ShowViewModel<SearchViewModel>();
        }
    }
}