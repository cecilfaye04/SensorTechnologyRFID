using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID.Core.Entities;
using RFID.Core.Interfaces;

namespace RFID.Core.Services
{
    public class RestService : IRestService
    {
        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserInput input)
        {
            throw new NotImplementedException();
        }

        public DepArrScanResponse DepArrScan(DepArrScanInput input)
        {
            throw new NotImplementedException();
        }

        public GetBagInfoResponse GetBagInfo(GetBagInfoInput input)
        {
            throw new NotImplementedException();
        }

        public GetFlightDetailsResponse GetFlightDetails(GetFlightDetailsInput input)
        {
            throw new NotImplementedException();
        }

        public GetPierClaimLocationResponse GetPierClaimLocation(GetPierClaimLocationInput input)
        {
            throw new NotImplementedException();
        }

        public PierClaimScanInput PierClaimScan(PierClaimScanInput input)
        {
            throw new NotImplementedException();
        }
    }
}
