using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidUITest
{
    [TestFixture]
    public class PierTest : BaseTest
    {

        [Test]
        public void PierNavigationTest()
        {
            Login();
            app.Tap("btnPier");
            app.WaitForElement("tvPierSelect");
            app.Tap(x => x.Id("lblListHeader").Text("Pier"));
            app.Tap(x => x.Id("lblListItem").Text("Pier 2"));
            app.WaitForElement("rlScannedBaggage");

            //BackNavigation
            app.TapCoordinates(0, 29);
            app.WaitForElement("tvPierSelect");
        }
    }
}
