using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID.Core.Entities;
using RFID.Core.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using MvvmCross.Platform;

namespace RFID.Core.Services
{
    public class RestService : IRestService
    {
        HttpClient client;
        ILogService logger;

        public RestService()
        {
            logger = Mvx.Resolve<ILogService>();
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserInput input)
        {
            logger.Trace("Service : IRestService, Method : AuthenticateUser , Request : AuthenticateUserInput = {'Username' : " + input.Username + ",'Password' : " + input.Password + ", 'DeviceName' : 'Apple', 'Station' : '123', 'Version' : '1'};");
            var items = new AuthenticateUserResponse();
            var restUrl = "http://172.26.82.21:5000/AuthWebservice/login";
            var uri = new Uri(string.Format(restUrl, string.Empty));
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<AuthenticateUserResponse>(contents);
            }
            logger.Trace("Service : IRestService , Method : AuthenticateUser , Response : AuthenticateUserResponse = {'Name' : " + items.Name + ", 'AppAccess' : " + items.Applications + ", 'ReturnCode' : " + items.StatusCode + ", 'Message' :" + items.Message + "}");
            return items;
        }

        public async Task<DepArrScanResponse> DepArrScan(DepArrScanInput input)
        {
            logger.Trace("Service : IRestService, Method : DepArrScan , Request : DepArrScanInput = {'Bagtag' :" + input.Bagtag + ",'CarrierCode' : " + input.CarrierCode + ",'FlightNumber' : " + input.FlightNumber + ",'Position' : " + input.Position + " ,'ScanTime' : " + input.ScanTime + ",'DeviceName' : " + input.DeviceName + " , 'Station' : " + input.Station + " , 'Version' : " + input.Version + ", 'Username' : " + input.Username + " };");
            var items = new DepArrScanResponse();
            var restUrl = "http://172.26.82.21:5000/DeparturesWebservice/load";
            var uri = new Uri(string.Format(restUrl, string.Empty));

            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<DepArrScanResponse>(contents);
            }
            logger.Trace("Service : IRestService , Method : DepArrScan , Response : DepArrScanResponse = {'Flight': items , 'LoadSummary' : depArrScanResponse.LoadSummary , 'ReturnCode':bagInfo.ReturnCode,'Message':bagInfo.Message}");

            return items;
        }

        public GetBagInfoResponse GetBagInfo(GetBagInfoInput input)
        {
            logger.Trace("Service : IRestService, Method : GetBagInfo , Request : GetBagInfoInput = {'Bagtag' : input.Bagtag, 'DeviceName' : 'Appl', 'Station' : '123', 'Version' : '1' };");
            GetBagInfoResponse getBagInfoResponse = new GetBagInfoResponse();
            getBagInfoResponse.FltCode = "DL";
            getBagInfoResponse.FltDate = DateTime.Now.ToString("MMMdd");
            getBagInfoResponse.FltNum = "1234";
            getBagInfoResponse.StatusCode = "0";
            getBagInfoResponse.PaxName = "Bill Gates";
            getBagInfoResponse.PaxItinerary = "MNL-NRT-MSP";
            getBagInfoResponse.Latitude = "47.636372";
            getBagInfoResponse.Longitude = "-122.126888";


            List<ScanPoint> scanHistory = new List<ScanPoint>();
            scanHistory.Add(newscanPoint("ic_checkin", "Checkin - MNL - Manila, Philippines"));
            scanHistory.Add(newscanPoint("ic_departure", "Departure - MNL - Manila, Philippines"));
            scanHistory.Add(newscanPoint("ic_arrival", "Arrival - NRT - Tokyo, Japan"));
            scanHistory.Add(newscanPoint("ic_departure", "Departure - NRT - Tokyo, Japan"));
            scanHistory.Add(newscanPoint("ic_arrival", "Arrival - MSP - Minneapolis, USA"));
            scanHistory.Add(newscanPoint("ic_departure", "Departure - MSP - Minneapolis, USA"));
            getBagInfoResponse.BagHistory = scanHistory.ToArray<ScanPoint>();

            logger.Trace("Service : IRestService , Method : GetBagInfo , Response : GetBagInfoResponse = {'BagHistory': bagInfo.BagHistory, 'ReturnCode':bagInfo.ReturnCode,'Message':bagInfo.Message}");
            return getBagInfoResponse;

        }

        private ScanPoint newscanPoint(string icon, string name)
        {
            logger.Trace("Service : IRestService, Method : newscanPoint , Request : {'Icon' : icon, 'Name' : name };");
            ScanPoint mscanpoint = new ScanPoint();
            mscanpoint.ScanType = icon;
            mscanpoint.Location = name;
            mscanpoint.DateTime = DateTime.Now.ToString("HH:mm MMM dd, yyyy");
            logger.Trace("Service : IRestService, Method : newscanPoint , Response : ScanPoint = {'ScanType' :  mscanpoint.ScanType, 'Location' :  mscanpoint.Location , 'DateTime' = mscanpoint.DateTime };");
            return mscanpoint;
        }

        public GetFlightDetailsResponse GetFlightDetails(GetFlightDetailsInput input)
        {
            logger.Trace("Service : IRestService, Method : GetFlightDetails , Request : GetFlightDetailsResponse = {'CommodityID' : input.CommodityID,'FltCode' : input.FltCode,'FltDate' : input.FltDate,'FltNum' : input.FltNum, 'FltPosition' : input.FltPosition,'DeviceName' : 'Apple', 'Station' : '123', 'Version' : '1' };");
            GetFlightDetailsResponse getFlightDetailsResponse = new GetFlightDetailsResponse();
            getFlightDetailsResponse.StatusCode = "0";

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
            logger.Trace("Service : IRestService , Method : GetFlightDetails , Response : GetFlightDetailsResponse = {'Flight': depArrScanResponse.Flight , 'LoadSummary' : depArrScanResponse.LoadSummary , 'ReturnCode':bagInfo.ReturnCode,'Message':bagInfo.Message}");
            return getFlightDetailsResponse;
        }

        public GetPierClaimLocationResponse GetPierClaimLocation(GetPierClaimLocationInput input)
        {
            logger.Trace("Service : IRestService, Method : GetPierClaimLocation, Request : GetPierClaimLocationInput = {'Appname':user.Name,'Username' : user.Username, 'DeviceName' : 'Apple', 'Station' : '123', 'Version' : '1' }");
            GetPierClaimLocationResponse getPierClaimLocationResponse = new GetPierClaimLocationResponse();
            PierClaimLocations main1 = new PierClaimLocations();
            main1.Name = "Pier";
            main1.SubLocations = new string[] { "Pier 1", "Pier 2", "Pier 3" };
            PierClaimLocations main2 = new PierClaimLocations();
            main2.Name = "DCI Bullpen";
            main2.SubLocations = new string[] { };
            PierClaimLocations main3 = new PierClaimLocations();
            main3.Name = "Arrivals";
            main3.SubLocations = new string[] { "DL Arvl", "OA Arvl", "AS Arvl" };

            getPierClaimLocationResponse.MainLocations = new PierClaimLocations[] { main1, main2, main3 };
            getPierClaimLocationResponse.StatusCode = "0";
            logger.Trace("Service : IRestService , Method : GetPierClaimLocation , Response : GetPierClaimLocationResponse = {'MainLocation':PierResponse.MainLocation, 'ReturnCode':PierResponse.ReturnCode,'Message':PierResponse.Message}");

            return getPierClaimLocationResponse;
        }

        //Working(Temporary). Will delete after finishing webapi.config
        public async Task<PierClaimScanResponse> PierScan(PierClaimScanInput input)
        {
            //var x = GetWebApi("AuthWebService");
            PierClaimScanResponse items = new PierClaimScanResponse();
            var restUrl = "http://172.26.82.21:5000/PierWebservice/bags";
            var uri = new Uri(string.Format(restUrl, string.Empty));
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<PierClaimScanResponse>(contents);
            }
            return items;

            ////logger.Trace("Service : IRestService, Method : PierClaimScan , Request : PierClaimScanInput = {"Bags" : input.Bags, "DeviceName" : input.DeviceName,"MyProperty" : input.MyProperty,"PierClaimLocation": input.PierClaimLocation, "Station" : input.Station, "Version" : input.Version};")
            //PierClaimScanResponse pierClaimScan = new PierClaimScanResponse();
            //pierClaimScan.Success = true;
            ////logger.Trace("Service : IRestService , Method : PierClaimScan , Response : PierClaimScanResponse =  {"ReturnCode":PierResponse.ReturnCode,"Message":PierResponse.Message};
            //return pierClaimScan;
        }

        //Working(Temporary). Will delete after finishing webapi.config
        public async Task<PierClaimScanResponse> ClaimScan(PierClaimScanInput input)
        {
            PierClaimScanResponse items = new PierClaimScanResponse();
            var uri = "http://172.26.82.21:5000/ClaimWebservice/bags";
            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<PierClaimScanResponse>(contents);
            }
            return items;
        }

        //Working.
        //Used HttpClient instead of HttpWebRequest
        public async Task<string> Consume()
        {

            Uri uri = new Uri(_webConfig["actionUri"]);
            /////write the rest of the parameters in postData
            _parameters.Add("Station", "MNL");
            _parameters.Add("Device", "Android");
            _parameters.Add("Version", "0.1");
            string json = JsonConvert.SerializeObject(_parameters, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, _webConfig["contentType"]);
            logger.Trace("Service : IRestService , Method : " + _webConfig["method"] + " ,Request : " + json + "");

            var response = await client.PostAsync(uri, content);
            var returnResponse = await response.Content.ReadAsStringAsync();

            logger.Trace("Service : IRestService , Method : " + _webConfig["method"] + " ,Response : " + returnResponse + "");

            return returnResponse;
        }


        private Dictionary<string, string> _parameters;
        public Dictionary<string, string> Parameters
        {
            set
            {
                _parameters = value;
            }
        }

        private Dictionary<string, string> _webConfig;

        public string WebMethod
        {
            set
            {
                _webConfig = new Dictionary<string, string>();
                Assembly assembly = typeof(App).GetTypeInfo().Assembly;
                using (var stream = assembly.GetManifestResourceStream("RFID.Core.webapi.config"))
                using (var reader = new StreamReader(stream))
                {
                    var doc = XDocument.Parse(reader.ReadToEnd());
                    foreach (XElement xe in doc.Elements("Services").Elements("Service"))
                    {
                        if (xe.Attribute("Name").Value == value)
                        {
                            _webConfig.Add("method", xe.Element("Method").Value);
                            _webConfig.Add("methodUri", xe.Element("MethodURI").Value);
                            _webConfig.Add("actionUri", xe.Element("ActionURI").Value);
                            _webConfig.Add("contentType", xe.Element("ContentType").Value);
                        }
                    }
                    /// use the to update value of _webConfig like uri, method, content etc.
                    /// read the values from a local XML config
                }
            }
        }
    }
}
