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
    public class LoginTest : BaseTest
    {
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
        public void LogoutTest()
        {
            SuccessfulLoginTest();
            app.TapCoordinates(0, 29);
            app.ScrollToVerticalEnd("navigation_frame");
            app.Tap(x => x.Id("design_menu_item_text").Text("Logout"));
            app.WaitForElement("button_login");
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

    }

}


