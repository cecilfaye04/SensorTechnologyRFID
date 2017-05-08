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
            if (input.Username == "admin" && input.Password == "password")
            {
                //Entities.App pierApp = new Entities.App() { AppName = "Pier", Color = "Blue" };
                //Entities.App claimApp = new Entities.App() { AppName = "Claim", Color = "Violet" };
                //Entities.App departureApp = new Entities.App() { AppName = "Departure", Color = "Red" };
                //Entities.App[] listOfApp = new Entities.App[] { pierApp, departureApp, claimApp };

                AuthenticateUserResponse loginResponse = new AuthenticateUserResponse()
                {
                    ReturnCode = "1",
                    Name = "XamarinRFID",
                    Message = "Successfully Login",
                    AppAccess = "Pier,Departure,Claim,Arrival"
                };
                return loginResponse;
            }

            else
            {
                AuthenticateUserResponse loginResponse = new AuthenticateUserResponse()
                {
                    ReturnCode = "0",
                    Name = "XamarinRFID",
                    Message = "Failed Login",
                    AppAccess = null
                };
                return loginResponse;
            }
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
