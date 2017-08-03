using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using Xamarin.UITest.Utils;

namespace AndroidUITest
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            string apkPath = Environment.GetEnvironmentVariable("ANDROID_APK_PATH");
            //string emulatorSerial = Environment.GetEnvironmentVariable("ANDROID_EMULATOR_SERIAL");
            apkPath = "C:/Users/cecil.clemente/Source/Repos/SensorTechnologyXamarinRFID/RFID/RFID.Droid/bin/Release/RFID.Droid.RFID.Droid-Signed.apk";
            //apkPath = "C:/Users/jerome.manzano/Source/Repos/SensorTechnologyRFID/RFID/RFID.Droid/bin/Release/RFID.Droid.RFID.Droid-Signed.apk";
            app = ConfigureApp
                .Android
                .DeviceIp("127.0.0.1")
                .PreferIdeSettings()
                .ApkFile(apkPath)
                //.DeviceSerial(emulatorSerial)
                .WaitTimes(new WaitTimes())
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                //.ApkFile ("../../../Android/bin/Debug/UITestsAndroid.apk")
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void FailedLoginTest()
        {
            app.WaitForElement("button_login");
            app.EnterText("text_username", "admin");
            app.EnterText("text_password", "admin");
            app.Tap("button_login");
            app.WaitForElement(c => c.Text("Dismiss"));
        }

        [Test]
        public void SuccessfulLoginTest()
        {
            app.WaitForElement("button_login");
            app.EnterText("text_username", "admin");
            app.EnterText("text_password", "password");
            app.Tap("button_login");
            app.WaitForElement("content_frame");
        }

        [Test]
        public void SideMenuNavigationTest()
        {
            SuccessfulLoginTest();
            app.TapCoordinates(0, 29);
            app.WaitForElement("text_view_fullname");

            //Home
            app.Tap(x => x.Id("design_menu_item_text").Text("Home"));
            app.WaitForElement("main_content");
            app.TapCoordinates(0, 29);

            //Pier
            app.Tap(x => x.Id("design_menu_item_text").Text("Pier"));
            app.WaitForElement("tvPierSelect");
            app.TapCoordinates(0, 29);

            //Departure
            app.Tap(x => x.Id("design_menu_item_text").Text("Departure"));
            app.WaitForElement("llFlightEntry");
            app.TapCoordinates(0, 29);

            //Search
            app.ScrollToVerticalEnd("navigation_frame");
            app.Tap(x => x.Id("design_menu_item_text").Text("Search"));
            app.WaitForElement("rlSearch");
            app.TapCoordinates(0, 29);

            //RFID Encoder
            app.Tap(x => x.Id("design_menu_item_text").Text("RFID Encoder"));
            app.WaitForElement("llRfidEncoder");
            app.TapCoordinates(0, 29);

            //Logout
            app.Tap(x => x.Id("design_menu_item_text").Text("Logout"));
            app.WaitForElement("button_login");
        }

        [Test]
        public void SingleSearchTest()
        {
            SuccessfulLoginTest();
            app.Tap("menu_search");
            app.EnterText("etBagtagNo", "1234567890");
            app.Tap("btnNext");
            SearchResultTest();
        }

        [Test]
        public void MultipleSearchTest()
        {
            SuccessfulLoginTest();
            app.Tap("menu_search");
            app.Tap("btnScan");
            app.WaitForElement("llResult1");
            app.Tap("btnNext");
            SearchResultTest();
        }

        [Test]
        public void PierNavigationTest()
        {
            SuccessfulLoginTest();
            app.Tap("btnPier");
            app.WaitForElement("tvPierSelect");
            app.Tap(x => x.Id("lblListHeader").Text("Pier"));
            app.Tap(x => x.Id("lblListItem").Text("Pier 2"));
            app.WaitForElement("rlScannedBaggage");
        }

        [Test]
        public void DepartureNavigationTest()
        {
            SuccessfulLoginTest();
            app.Tap("btnDeparture");
            app.WaitForElement("llFlightEntry");
            app.Tap("btnNext");
            app.WaitForElement("llDepArr");
        }

        [Test]
        public void RFIDEncoderNavigationTest()
        {
            SuccessfulLoginTest();
            app.Tap("btnRFIDEncoder");
            app.WaitForElement("llRfidEncoder");
        }

        [Test]
        public void TestLogin()
        {
            app.Screenshot("First screen.");
            app.WaitForElement(c => c.Button("button_login"));
        }

        private void SearchResultTest()
        {
            //BagInfo
            app.WaitForElement(x => x.Id("rlBagInfo"));

            //BagTrack
            app.Tap(x => x.Id("nav_track"));
            app.WaitForElement(x => x.Id("flBagtrack"));

            //BagLocate
            app.Tap(x => x.Id("nav_location"));
            app.WaitForElement(x => x.Id("textView1"));
        }
    }

    public class WaitTimes : IWaitTimes {
        public TimeSpan GestureWaitTimeout { get { return TimeSpan.FromMinutes(1); } }
        public TimeSpan WaitForTimeout { get { return TimeSpan.FromMinutes(1); } }
    }
}


