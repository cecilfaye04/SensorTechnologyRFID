using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFID.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDUnitTest
{
    [TestClass]
    public class ValidateTest
    {
        [TestMethod]
        public void IsNumeric_IsTrue()
        {
            //Arrange
            var SystemUnderTest = new ValidationService();
            var dependency = "123456781";

            //Act
            var actual = SystemUnderTest.IsNumeric(dependency);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Is10Digits_IsTrue()
        {
            //Arrange
            var SystemUnderTest = new ValidationService();
            var dependency = "1234567890";

            //Act
            var actual = SystemUnderTest.Is10Digits(dependency);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFlightNo_IsTrue()
        {
            //Arrange
            var SystemUnderTest = new ValidationService();
            var dependency = "1200";
            var xz = "";
            //Act
            var actual = SystemUnderTest.IsFlightNo(dependency, out xz);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsPosition_IsTrue()
        {
            //Arrange
            var SystemUnderTest = new ValidationService();
            var dependency = "123";
            //Act
            var actual = SystemUnderTest.IsPosition(dependency);

            //Assert
            Assert.IsTrue(actual);
        }

    }
}
