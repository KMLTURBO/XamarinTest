using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace Acquaint.Native.UITest.Android
{
	[TestFixture]
	public class AcquaintanceUpdatingTests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			// TODO: If the Android app being tested is included in the solution then open
			// the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			//
			// ^^^ THIS IS THE WAY THE ACQUAINT APP IS SETUP FOR UITESTS ^^^

			app = ConfigureApp
				.Android

			// TODO: Update this path to point to your Android app and uncomment the
			// code if the app is not included in the solution.
			//.ApkFile ("../../../Android/bin/Debug/UITestsAndroid.apk")
			//
			// ^^^ THIS IS *NOT* THE WAY THE ACQUAINT APP IS SETUP FOR UITESTS ^^^

				.StartApp();
		}

		// tests coming soon
	}
}

