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
        protected Dictionary<string, string> SParam;
        protected Dictionary<string, string> RParam;

        protected void StoreParam(string key, string value)
        {

            if (SParam == null)
            {
                SParam = new Dictionary<string, string>();
            }

            if (SParam.ContainsKey(key))
            {
                SParam[key] = value;
            }
            else
            {
                SParam.Add(key, value);
            }

        }

        //protected override void InitFromBundle(IMvxBundle parameters)
        //{

        //    if (parameters.Data.Count > 0)
        //    {
        //        RParam = (Dictionary<string, string>)parameters.Data;
        //    }

        //    base.InitFromBundle(parameters);
        //}

        protected string GetParam(string key)
        {
            string sReturn = "";

            if (RParam != null && RParam.ContainsKey(key))
            {
                sReturn = RParam[key];
            }

            return sReturn;
        }
    }
}
