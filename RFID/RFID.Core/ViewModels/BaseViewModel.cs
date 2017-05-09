using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
   public class BaseViewModel : MvxViewModel
    {
        Dictionary<string, string> SParam;
        Dictionary<string, string> RParam;

        void StoreParam(string key, string value) {
            if (SParam == null)
            {
                SParam = new Dictionary<string, string>();
            }

            SParam.Add(key, value);
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {

            if (parameters.Data.Count > 0)
            {
                RParam = (Dictionary<string, string>)parameters.Data;
            }

            base.InitFromBundle(parameters);
        }

        string GetParam(string key, string value) {
            string sReturn = "";

            if (RParam != null && RParam.ContainsKey(key))
            {
                sReturn = RParam[key];
            }

            return sReturn;
        }
    }
}
