using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Utils;

namespace AndroidUITest
{
    [TestFixture]
    public class BaseTest
    {
        internal AndroidApp app;

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

        public void Login()
        {
            app.WaitForElement("button_login");
            app.EnterText("text_username", "admin");
            app.EnterText("text_password", "password");
            app.Tap("button_login");
            app.WaitForElement("content_frame");
        }


        public class WaitTimes : IWaitTimes
        {
            public TimeSpan GestureWaitTimeout { get { return TimeSpan.FromMinutes(1); } }
            public TimeSpan WaitForTimeout { get { return TimeSpan.FromMinutes(1); } }
        }

    }
}
