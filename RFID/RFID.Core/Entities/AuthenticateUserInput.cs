﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class AuthenticateUserInput: BaseInput
    {
        public string Password { get; set; }
    }
}
