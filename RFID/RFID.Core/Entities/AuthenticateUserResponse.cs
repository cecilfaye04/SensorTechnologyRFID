using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class AuthenticateUserResponse: BaseResponse
    {
        public string Name { get; set; }
        public string AppAccess { get; set; }
    }

    //public class App
    //{
    //    public string AppName { get; set; }
    //    public string Color { get; set; }
    //}
}
