using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class PierClaimScanViewModel : MvxViewModel<string>
    {
        //public override void Start()
        //{
        //    PierLocation = base.GetParam("PierLocation");
        //}

        //protected override void InitFromBundle(IMvxBundle parameters)
        //{
        //    if (parameters.Data.Count > 0)
        //    {
        //        base.RParam = (Dictionary<string, string>)parameters.Data;
        //    }
        //}

        public override Task Initialize(string parameter)
        {
            PierLocation = parameter;
            return Task.FromResult(true);
        }


        private string _pierLocation;

        public string PierLocation
        {
            get { return _pierLocation; }
            set { _pierLocation = value; }
        }

    }
}