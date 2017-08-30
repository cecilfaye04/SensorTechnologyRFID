using MvvmCross.Core.ViewModels;
using RFID.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels.Search
{
    public class BagTrackViewModel : BaseViewModel<BagInfo>
    {
        public override Task Initialize(BagInfo parameter)
        {
            BagLatitude = parameter.Latitude;
            BagLongitude = parameter.Longitude;
            PaxName = parameter.PaxName;
            return Task.FromResult(true);
        }

        private string _baglatitude;

        public string BagLatitude
        {
            get { return _baglatitude; }
            set { _baglatitude = value; }
        }

        private string _bagLongitude;

        public string BagLongitude
        {
            get { return _bagLongitude; }
            set { _bagLongitude = value; }
        }

        private string _paxName;

        public string PaxName
        {
            get { return _paxName; }
            set { _paxName = value; }
        }

    }
}