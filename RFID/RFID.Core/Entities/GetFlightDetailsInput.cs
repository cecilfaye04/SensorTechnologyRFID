using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Entities
{
    public class GetFlightDetailsInput: BaseInput  
    {
        public string AppName { get; set; }
        public string FltNum { get; set; }
        public string FltCode { get; set; }
        public string FltDate { get; set; }
        public string FltPosition { get; set; }
    }
}
