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
    public class BagInfoViewModel : BaseViewModel
    {
        public BagInfoViewModel()
        {
            GetBagInfoInput baginput = new GetBagInfoInput() { Bagtag = BagtagNo, DeviceName = "Apple", Station = "123", Username = "admin", Version = "1" };

            var bagInfo = Mvx.Resolve<IRestService>().GetBagInfo(baginput);

            Name = bagInfo.PaxName;
            Flight = bagInfo.FltCode + bagInfo.FltNum;
            FlightDate = bagInfo.FltDate;
            Itinerary = bagInfo.PaxItinerary;
        }

        public IMvxCommand ShowSearchTrackCommand
        {
            get { return new MvxCommand(ShowSearchTrackExecuted); }
        }

        private void ShowSearchTrackExecuted()
        {
            ShowViewModel<BagLocateViewModel>();
        }


        private string _itinerary;

        public string Itinerary
        {
            get { return _itinerary; }
            set { _itinerary = value; }
        }

        private string _flightDate;

        public string FlightDate
        {
            get { return _flightDate; }
            set { _flightDate = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private string _flight;
        public string Flight
        {
            get { return _flight; }
            set
            {
                _flight = value;
                RaisePropertyChanged(() => Flight);
            }
        }

        private string _bagtag;

        public string BagtagNo
        {
            get { return _bagtag; }
            set { _bagtag = value; }
        }
    }
}