using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class DepartureViewModel : BaseViewModel
    {
        private List<string> _flight = new List<string>()
            {
              "ZE","PH","JPN","ABC","DEF","GHI","JKL","MNO","PQR","STU","VWX","YZ"
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

        private List<int> _gate = new List<int>()
            {
              191,192,193,194,195,196,197,964,489,164,165,971,369,741
            };
        public List<int> Gate
        {
            get { return _gate; }
            set { _gate = value; RaisePropertyChanged(() => Gate); }
        }

        private string _selectedGate = "";
        public string SelectedGate
        {
            get { return _selectedGate; }
            set { _selectedGate = value; RaisePropertyChanged(() => SelectedGate); }
        }
    }
}
