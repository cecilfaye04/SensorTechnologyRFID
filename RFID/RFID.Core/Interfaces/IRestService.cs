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
        Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserInput input);
        //AuthenticateUserResponse AuthenticateUser(AuthenticateUserInput input);
        DepArrScanResponse DepArrScan(DepArrScanInput input);
        GetBagInfoResponse GetBagInfo(GetBagInfoInput input);
        GetFlightDetailsResponse GetFlightDetails(GetFlightDetailsInput input);
        GetPierClaimLocationResponse GetPierClaimLocation(GetPierClaimLocationInput input);
        Task<PierClaimScanResponse> PierScan(PierClaimScanInput input);
        Task<PierClaimScanResponse> ClaimScan(PierClaimScanInput input);
        Task<String> Consume();

        Dictionary<String, String> Parameters { set; }

        String WebMethod { set; }
    }
}
