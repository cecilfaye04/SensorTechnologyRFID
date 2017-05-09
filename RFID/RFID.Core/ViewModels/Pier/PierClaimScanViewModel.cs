using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class PierClaimScanViewModel : BaseViewModel
    {
        public override void Start()
        {
            PierLocation = base.GetParam("PierLocation");
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            if (parameters.Data.Count > 0)
            {
                base.RParam = (Dictionary<string, string>)parameters.Data;
            }
        }

        private string _pierLocation;

        public string PierLocation
        {
            get { return _pierLocation; }
            set { _pierLocation = value; }
        }

    }
}