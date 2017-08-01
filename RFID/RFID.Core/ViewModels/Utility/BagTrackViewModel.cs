using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels.Search
{
    public class BagTrackViewModel : BaseViewModel
    {
        public override void Start()
        {
            BagLatitude = base.GetParam("BagLatitude");
            BagLongitude = base.GetParam("BagLongitude");
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            if (parameters.Data.Count > 0)
            {
                base.RParam = (Dictionary<string, string>)parameters.Data;
            }
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
    }
}