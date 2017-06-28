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
            //logger.Trace("Service : IRestService, Method : AuthenticateUser , Request : AuthenticateUserInput = {"Username" : input.username,"Password" : input.Password, "DeviceName" : "Apple", "Station" : "123", "Version" : "1" };")
            AuthenticateUserResponse loginResponse = new AuthenticateUserResponse();

            if (input.Username == "admin" && input.Password == "password")
            {
                loginResponse = new AuthenticateUserResponse()
                {
                    ReturnCode = "1",
                    Name = "Admin User",
                    Message = "Successfully Login",
                    AppAccess = "Pier,Arrival,Departure,Claim,BSO"
                };
            }
            else
            {
                 loginResponse = new AuthenticateUserResponse()
                {
                    ReturnCode = "0",
                    Name = "XamarinRFID",
                    Message = "Failed Login",
                    AppAccess = null
                };
            }
            //logger.Trace("Service : IRestService , Method : AuthenticateUser , Response : AuthenticateUserResponse = {"Name" : loginResponse.Name , "AppAccess" : loginResponse.AppAccess, "ReturnCode" : loginResponse.ReturnCode,"Message" : loginResponse.Message};
            return loginResponse;
        }

        public DepArrScanResponse DepArrScan(DepArrScanInput input)
        {
            //logger.Trace("Service : IRestService, Method : DepArrScan , Request : DepArrScanInput = {"CommodityID" : input.CommodityID,"FltCode" : input.FltCode,"FltDate" : input.FltDate,"FltNum" : input.FltNum, "FltPosition" : input.FltPosition,"DeviceName" : "Apple", "Station" : "123", "Version" : "1" };")
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
            //logger.Trace("Service : IRestService , Method : DepArrScan , Response : DepArrScanResponse = {"Flight": depArrScanResponse.Flight , "LoadSummary" : depArrScanResponse.LoadSummary , "ReturnCode":bagInfo.ReturnCode,"Message":bagInfo.Message};
            return depArrScanResponse;
        }

        public GetBagInfoResponse GetBagInfo(GetBagInfoInput input)
        {
            //logger.Trace("Service : IRestService, Method : GetBagInfo , Request : GetBagInfoInput = {"Bagtag" : input.Bagtag, "DeviceName" : "Apple", "Station" : "123", "Version" : "1" };")
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

            //logger.Trace("Service : IRestService , Method : GetBagInfo , Response : GetBagInfoResponse = {"BagHistory": bagInfo.BagHistory, "ReturnCode":bagInfo.ReturnCode,"Message":bagInfo.Message};
            return getBagInfoResponse;

        }

        private ScanPoint newscanPoint(string icon, string name)
        {
            //logger.Trace("Service : IRestService, Method : newscanPoint , Request : {"Icon" : icon, "Name" : name };")
            ScanPoint mscanpoint = new ScanPoint();
            mscanpoint.ScanType = icon;
            mscanpoint.Location = name;
            mscanpoint.DateTime = DateTime.Now.ToString("HH:mm MMM dd, yyyy");
            //logger.Trace("Service : IRestService, Method : newscanPoint , Response : ScanPoint = {"ScanType" :  mscanpoint.ScanType, "Location" :  mscanpoint.Location , "DateTime" = mscanpoint.DateTime };")
            return mscanpoint;
        }

        public GetFlightDetailsResponse GetFlightDetails(GetFlightDetailsInput input)
        {
            //logger.Trace("Service : IRestService, Method : GetFlightDetails , Request : GetFlightDetailsResponse = {"CommodityID" : input.CommodityID,"FltCode" : input.FltCode,"FltDate" : input.FltDate,"FltNum" : input.FltNum, "FltPosition" : input.FltPosition,"DeviceName" : "Apple", "Station" : "123", "Version" : "1" };")
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
            //logger.Trace("Service : IRestService , Method : GetFlightDetails , Response : GetFlightDetailsResponse = {"Flight": depArrScanResponse.Flight , "LoadSummary" : depArrScanResponse.LoadSummary , "ReturnCode":bagInfo.ReturnCode,"Message":bagInfo.Message};
            return getFlightDetailsResponse;
        }

        public GetPierClaimLocationResponse GetPierClaimLocation(GetPierClaimLocationInput input)
        {
            //logger.Trace("Service : IRestService, Method : GetPierClaimLocation, Request : GetPierClaimLocationInput = {"Appname":user.Name,"Username" : user.Username, "DeviceName" : "Apple", "Station" : "123", "Version" : "1" };")
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
            //logger.Trace("Service : IRestService , Method : GetPierClaimLocation , Response : GetPierClaimLocationResponse = {"MainLocation":PierResponse.MainLocation, "ReturnCode":PierResponse.ReturnCode,"Message":PierResponse.Message};
            return getPierClaimLocationResponse;
        }

        public PierClaimScanResponse PierClaimScan(PierClaimScanInput input)
        {
            //logger.Trace("Service : IRestService, Method : PierClaimScan , Request : PierClaimScanInput = {"Bags" : input.Bags, "DeviceName" : input.DeviceName,"MyProperty" : input.MyProperty,"PierClaimLocation": input.PierClaimLocation, "Station" : input.Station, "Version" : input.Version};")
            PierClaimScanResponse pierClaimScan = new PierClaimScanResponse();
            pierClaimScan.ReturnCode = "1";
            //logger.Trace("Service : IRestService , Method : PierClaimScan , Response : PierClaimScanResponse =  {"ReturnCode":PierResponse.ReturnCode,"Message":PierResponse.Message};
            return pierClaimScan;
        }
    }
}
