using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Interfaces
{
    public interface IValidation
    {
        bool IsNull(string value);
        bool IsNumeric(string value);
        bool Is10Digits(string value);
        bool IsFlightNo(string value, out string newValue);
        bool IsPosition(string value);
        bool ObjectIsNotNull(object value);
    }
}
