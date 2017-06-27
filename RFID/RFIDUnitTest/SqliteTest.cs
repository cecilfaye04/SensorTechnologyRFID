using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmCross.Platform;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using RFID.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDUnitTest
{
    [TestClass]
    public class SqliteTest
    {
        [TestMethod]
        public async Task Load_IsNotNull()
        {
            //Arrange
            var SystemUnderTest = new SqliteService<UserModel>();
            //Act
            var actual = await SystemUnderTest.Load();
            //Assert
            Assert.IsNotNull(actual);
        }

        //[TestMethod]
        public async Task SqliteSpecificLoadTest()
        {
            //Arrange
            var SystemUnderTest = Mvx.Resolve<ISqliteService<BagInfo>>();
            //Act
            var actual = await SystemUnderTest.Load("123");
            //Assert
            Assert.IsNotNull(actual);
        }

        //[TestMethod]
        public void InsertUpdate_AreEqual()
        {
            //Arrange
            var SystemUnderTest = new SqliteService<UserModel>();
            var dependency = new UserModel()
            {
                Username = "admin",
                IsLoggedIn = true,
                Name = "Admin User",
                AppAccess = "Pier,Arrival,Departure,Claim,BSO"
            };
            var expected = "";
            //Act
            var actual = SystemUnderTest.InsertUpdate(dependency);
            actual.Wait();

            //Assert
            Assert.AreEqual(expected, actual);


        }



    }
}
