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
                    Name = "Admin User",
                    Message = "Successfully Login",
                    AppAccess = "Pier,Arrival,Departure,Claim,BSO"
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
            DepArrScanResponse depArrScanResponse = new DepArrScanResponse();
            depArrScanResponse.ReturnCode = "1";

            Flight flight = new Flight();
            flight.Destination = "NRT";
            flight.Origin = "MNL";
            flight.FltNum = "1234";
            flight.FltCode = "5J";
            flight.Gate = "G23";
            flight.NoseNumber = "004321";

            LoadSummary loadSummary = new LoadSummary();
            loadSummary.Ballast = "1/1";
            loadSummary.Bags = "2/2";
            loadSummary.Comat = "3/3";
            loadSummary.Freight = "4/4";
            loadSummary.Mail = "5/5";
            loadSummary.PercentLoaded = "100";
            
            if (input.AppName == "Departures")
            {
                flight.ETD = DateTime.Now.ToString();
            }
            else {
                flight.ETA = DateTime.Now.ToString();
            }

            depArrScanResponse.Flight = flight;
            depArrScanResponse.LoadSummary = loadSummary;
           
            return depArrScanResponse;
        }

        public GetBagInfoResponse GetBagInfo(GetBagInfoInput input)
        {
            GetBagInfoResponse getBagInfoResponse = new GetBagInfoResponse();
            getBagInfoResponse.FltCode = "DL";
            getBagInfoResponse.FltDate = DateTime.Now.ToString("MMMdd");
            getBagInfoResponse.FltNum = "1234";
            getBagInfoResponse.ReturnCode = "1";
            getBagInfoResponse.PaxName = "Bill Gates";
            getBagInfoResponse.PaxItinerary = "MNL-NRT-MSP";
            getBagInfoResponse.Latitude = "47.72980";
            getBagInfoResponse.Longitude = "-122.14931";

            
            List<ScanPoint> scanHistory = new List<ScanPoint>();
            scanHistory.Add(newscanPoint("ic_checkin", "Checkin - MNL - Manila, Philippines"));
            scanHistory.Add(newscanPoint("ic_departure", "Departure - MNL - Manila, Philippines"));
            scanHistory.Add(newscanPoint("ic_arrival", "Arrival - NRT - Tokyo, Japan"));
            scanHistory.Add(newscanPoint("ic_departure", "Departure - NRT - Tokyo, Japan"));
            scanHistory.Add(newscanPoint("ic_arrival", "Arrival - MSP - Minneapolis, USA"));
            scanHistory.Add(newscanPoint("ic_departure", "Departure - MSP - Minneapolis, USA"));
            getBagInfoResponse.BagHistory = scanHistory.ToArray<ScanPoint>();

        
            return getBagInfoResponse;

        }

        private ScanPoint newscanPoint(string icon, string name)
        {
            ScanPoint mscanpoint = new ScanPoint();
            mscanpoint.ScanType = icon;
            mscanpoint.Location = name;
            mscanpoint.DateTime = DateTime.Now.ToString("HH:mm MMM dd, yyyy");
            return mscanpoint;
        }

        public GetFlightDetailsResponse GetFlightDetails(GetFlightDetailsInput input)
        {
            GetFlightDetailsResponse getFlightDetailsResponse = new GetFlightDetailsResponse();
            getFlightDetailsResponse.ReturnCode = "1";

            Flight flight = new Flight();
            getFlightDetailsResponse.Flight.Destination = "NRT";
            getFlightDetailsResponse.Flight.Origin = "MNL";
            getFlightDetailsResponse.Flight.FltNum = "1234";
            getFlightDetailsResponse.Flight.FltCode = "5J";
            getFlightDetailsResponse.Flight.Gate = "G23";
            getFlightDetailsResponse.Flight.NoseNumber = "004321";

            LoadSummary loadSummary = new LoadSummary();
            getFlightDetailsResponse.LoadSummary.Ballast = "1/1";
            getFlightDetailsResponse.LoadSummary.Bags = "2/2";
            getFlightDetailsResponse.LoadSummary.Comat = "3/3";
            getFlightDetailsResponse.LoadSummary.Freight = "4/4";
            getFlightDetailsResponse.LoadSummary.Mail = "5/5";
            getFlightDetailsResponse.LoadSummary.PercentLoaded = "100";

            if (input.AppName == "Departures")
            {
                getFlightDetailsResponse.Flight.ETD = DateTime.Now.ToString();
            }
            else
            {
                getFlightDetailsResponse.Flight.ETA = DateTime.Now.ToString();
            }

            getFlightDetailsResponse.Flight = flight;
            getFlightDetailsResponse.LoadSummary = loadSummary;

            return getFlightDetailsResponse;
        }

        public GetPierClaimLocationResponse GetPierClaimLocation(GetPierClaimLocationInput input)
        {
            GetPierClaimLocationResponse getPierClaimLocationResponse = new GetPierClaimLocationResponse();
            PierClaimLocations main1 = new PierClaimLocations();
            main1.Name = "Pier";
            main1.SubLocations = new string[] { "Pier 1", "Pier 2", "Pier 3" };
            PierClaimLocations main2 = new PierClaimLocations();
            main2.Name = "DCI Bullpen";
            main2.SubLocations = new string[] { };
            PierClaimLocations main3 = new PierClaimLocations();
            main3.Name = "Arrivals";
            main3.SubLocations = new string[] {"DL Arvl", "OA Arvl", "AS Arvl" };

            getPierClaimLocationResponse.MainLocations = new PierClaimLocations[] { main1, main2, main3 };
            getPierClaimLocationResponse.ReturnCode = "1";
            return getPierClaimLocationResponse;
        }

        public PierClaimScanResponse PierClaimScan(PierClaimScanInput input)
        {
            PierClaimScanResponse pierClaimScan = new PierClaimScanResponse();
            pierClaimScan.ReturnCode = "1";

            return pierClaimScan;
        }
    }
}
