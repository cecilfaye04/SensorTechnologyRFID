using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class FlightEntryViewModel : BaseViewModel
    {
        private List<string> _flight = new List<string>()
            {
              "PR","DL","TG","AA","HA","AS","AR","NH","AI","SR","MP","MX"
            };
        public List<string> Flight
        {
            get { return _flight; }
            set { _flight = value; RaisePropertyChanged(() => Flight); }
        }

        private string _selectedflight = "";
        public string SelectedFlight
        {
            get { return _selectedflight; }
            set { _selectedflight = value; RaisePropertyChanged(() => SelectedFlight); }
        }

        private string _flightNo = "";

        public string FlightNo
        {
            get { return _flightNo; }
            set { _flightNo = value; }
        }

        private string _position = "";

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }


        public IMvxCommand ShowDepartmentScanCommand
        {
            get { return new MvxCommand(ShowDepartmentScanExecuted); }
        }

        private void ShowDepartmentScanExecuted()
        {
            string newFlightno;

            if (!Mvx.Resolve<IValidation>().IsFlightNo(FlightNo, out newFlightno))
            {
                Mvx.Resolve<IUserDialogs>().Alert("Invalid Flight No.", null, "Dismiss");
            }
            else if (!Mvx.Resolve<IValidation>().IsPosition(Position))
            {
                Mvx.Resolve<IUserDialogs>().Alert("Invalid Position.", null, "Dismiss");
            }
            else
            {
                try
                {
                    //logger.Trace("ShowViewModel : DepArrScanScreenViewModel")
                    ShowViewModel<DepArrScanScreenViewModel>();
                    //throw new System.ArgumentException("Parameter cannot be null", "original");
                }
                catch (Exception e)
                {
                    Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                    Mvx.Resolve<ILogService>().Trace("e");
                    //logger.Log(LogLevel.Info,e.ToString);
                }
            }
        }
    }
}