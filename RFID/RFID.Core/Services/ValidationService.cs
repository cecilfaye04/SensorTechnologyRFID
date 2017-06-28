using RFID.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Services
{
    public class ValidationService : IValidation
    {
        public bool IsNull(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public bool IsNumeric(string value)
        {
            int n;
            return int.TryParse(value, out n);
        }

        public bool Is10Digits(string value = "")
        {
            return value.Length == 10 ?  true :  false;
        }

        public bool IsFlightNo(string value,out string newValue)
        {
            newValue = string.Empty;
            if (value.Length <= 4 && !string.IsNullOrEmpty(value) )
            {
                newValue = value.PadLeft(4, '0');
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsPosition(string value)
        {
            return value.Length == 3 ? true : false;
        }

        public bool ObjectIsNotNull(object x)
        {
            return x != null;
        }
    }
}
