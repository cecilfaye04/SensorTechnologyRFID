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
            apkPath = "C:/Users/jerome.manzano/Source/Repos/SensorTechnologyRFID/RFID/RFID.Droid/bin/Release/RFID.Droid.RFID.Droid-Signed.apk";
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

            app.WaitForElement(c => c.Button("button_login"));
            app.EnterText("text_username", "admin");
            app.EnterText("text_password", "admin");
            app.Tap("button_login");
            app.WaitForElement(c => c.Text("Dismiss"));
            
        }
        [Test]
        public void TestLogin()
        {
            app.Screenshot("First screen.");
            app.WaitForElement(c => c.Button("button_login"));
        }
    }

    public class WaitTimes : IWaitTimes {
        public TimeSpan GestureWaitTimeout { get { return TimeSpan.FromMinutes(1); } }
        public TimeSpan WaitForTimeout { get { return TimeSpan.FromMinutes(1); } }
    }
}

