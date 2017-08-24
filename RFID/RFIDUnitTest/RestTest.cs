using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFID.Core.Entities;
using RFID.Core.Services;
using RFID.Core.Models;
using System.Threading.Tasks;
using MvvmCross.Platform;
using RFID.Core.Interfaces;

namespace RFIDUnitTest
{
    [TestClass]
    public class RestTest
    {
        //[TestMethod]
        //public void AuthenticateUser_Successful()
        //{
        //    //Arrange   
        //    var SystemUnderTest = new RestService();
        //    var dependency = new AuthenticateUserInput()
        //    {
        //        Username = "admin",
        //        Password = "password",
        //        DeviceName = "Apple",
        //        Station = "123",
        //        Version = "1"
        //    };
        //    var expected = "1";
        //    //Act
        //    var actual = SystemUnderTest.AuthenticateUser(dependency);

        //    //Assert
        //    Assert.AreEqual(expected, actual.ReturnCode);
        //}

        [TestMethod]
        public void GetBagInfo_AreEqual()
        {
            //Arrange
            var SystemUnderTest = new RestService();
            var dependency = new GetBagInfoInput()
            { Bagtag = "1234567890",
                DeviceName = "Apple",
                Station = "123",    
                Username = "admin",
                Version = "1" };

            var expected = new GetBagInfoResponse()
            {
                StatusCode = "0",
            FltCode = "DL",
                FltDate = DateTime.Now.ToString("MMMdd"),
                FltNum = "1234",
                PaxName = "Bill Gates",
                PaxItinerary = "MNL-NRT-MSP",
                Latitude = "47.72980",
                Longitude = "-122.14931"
            };
            //Act
            var actual = SystemUnderTest.GetBagInfo(dependency);

            //Assert
            Assert.AreEqual(expected.StatusCode, actual.StatusCode);
        }

        [TestMethod]
        public void GetPierClaimLocation_AreEqual()
        {
            //Arrange
            var SystemUnderTest = new RestService();
            var dependency = new GetPierClaimLocationInput()
            { AppName = "Admin User", Username = "admin", DeviceName = "Apple", Station = "123", Version = "1" };

            var expected = new GetPierClaimLocationResponse();
            PierClaimLocations main1 = new PierClaimLocations();
            main1.Name = "Pier";
            main1.SubLocations = new string[] { "Pier 1", "Pier 2", "Pier 3" };
            PierClaimLocations main2 = new PierClaimLocations();
            main2.Name = "DCI Bullpen";
            main2.SubLocations = new string[] { };
            PierClaimLocations main3 = new PierClaimLocations();
            main3.Name = "Arrivals";
            main3.SubLocations = new string[] { "DL Arvl", "OA Arvl", "AS Arvl" };
            expected.MainLocations = new PierClaimLocations[] { main1, main2, main3 };
            expected.StatusCode = "0";


            //Act
            var actual = SystemUnderTest.GetPierClaimLocation(dependency);

            //Assert
            Assert.AreEqual(expected.StatusCode, actual.StatusCode);
        }

        [TestMethod]
        public void PierClaimScan_AreEqual()
        {
            //Arrange
            var SystemUnderTest = new RestService();
            var dependency = new PierClaimScanInput()
            { Username = "admin", DeviceName = "Apple", Station = "123", Version = "1" };

            //var expected = "1";

            //Act
            var actual = SystemUnderTest.PierScan(dependency);

            //Assert
            //Assert.AreEqual(expected, actual.Stat);
        }

        [TestMethod]
        public void GetFlightDetails_AreEqual()
        {
            //Arrange
            var SystemUnderTest = new RestService();
            var dependency = new GetFlightDetailsInput()
            {
                  FltDate = DateTime.Now.ToString("HH:mm MMM dd, yyyy"),
                  FltNum = "123",
                  FltCode = "AZ",
                  FltPosition = "11",
                  Station = "MNL",
                 AppName = "Departures"
            };

            var expected = "1";
          
            //Act
            var actual = SystemUnderTest.GetFlightDetails(dependency);

            //Assert
            Assert.AreEqual(expected, actual.StatusCode);
        }

        //[TestMethod]
        //public void DepArrScan_AreEqual()
        //{
        //    //Arrange
        //    var SystemUnderTest = new RestService();
        //    var dependency = new DepArrScanInput()
        //    {
        //        FltDate = DateTime.Now.ToString("HH:mm MMM dd, yyyy"),
        //        FltNum = "123",
        //        FltCode = "AZ",
        //        FltPosition = "11",
        //        Station = "MNL",
        //        AppName = "Departures",
        //        Latitude = "121.1212",
        //        Longitude = "121.111"
        //    };

        //    var expected = "1";

        //    //Act
        //    var actual = SystemUnderTest.DepArrScan(dependency);

        //    //Assert
        //    Assert.AreEqual(expected, actual.StatusCode);
        //}



    }

   
}
