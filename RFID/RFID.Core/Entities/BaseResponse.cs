using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class BaseResponse
    {
        public Boolean Success { get; set; }
        public string Message { get; set; }
    }
}
