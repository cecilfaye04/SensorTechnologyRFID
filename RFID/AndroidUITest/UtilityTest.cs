using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidUITest
{
    [TestFixture]
    public class UtilityTest : BaseTest
    {
        [Test]
        public void SingleSearchTest()
        {
            Login();
            app.Tap("menu_search");
            app.EnterText("etBagtagNo", "1234567890");
            app.Tap("btnNext");
            SearchResultTest();
        }

        [Test]
        public void MultipleSearchTest()
        {
            Login();
            app.Tap("menu_search");
            app.Tap("btnScan");
            app.WaitForElement("llResult1");
            app.Tap("btnNext");
            SearchResultTest();
        }

        [Test]
        public void RFIDEncoderNavigationTest()
        {
            Login();
            app.Tap("btnRFIDEncoder");
            app.WaitForElement("llRfidEncoder");
        }

        private void SearchResultTest()
        {
            //BagInfo
            app.WaitForElement("rlBagInfo");

            //BagTrack
            app.Tap("nav_track");
            app.WaitForElement("flBagtrack");

            //BagLocate
            app.Tap("nav_location");
            app.WaitForElement("textView1");
        }
    }
}
