using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidUITest
{
    [TestFixture]
    public class DepartureTest : BaseTest
    {
        [Test]
        public void DepartureNavigationTest()
        {
            Login();
            app.Tap("btnDeparture");
            app.WaitForElement("llFlightEntry");
            app.Tap("btnNext");
            app.WaitForElement("llDepArr");

            //BackNavigation
            app.TapCoordinates(0, 29);
            app.WaitForElement("llFlightEntry");
        }

    }

}
