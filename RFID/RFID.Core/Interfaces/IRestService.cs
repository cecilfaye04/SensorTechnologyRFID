using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID.Core.Entities;

namespace RFID.Core.Interfaces
{
    public interface IRestService
    {
        AuthenticateUserResponse AuthenticateUser(AuthenticateUserInput input);
        DepArrScanResponse DepArrScan(DepArrScanInput input);
        GetBagInfoResponse GetBagInfo(GetBagInfoInput input);
        GetFlightDetailsResponse GetFlightDetails(GetFlightDetailsInput input);
        GetPierClaimLocationResponse GetPierClaimLocation(GetPierClaimLocationInput input);
        PierClaimScanResponse PierClaimScan(PierClaimScanInput input);
    }
}
