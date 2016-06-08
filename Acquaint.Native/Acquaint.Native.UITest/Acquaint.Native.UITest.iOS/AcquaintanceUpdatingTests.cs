using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace Acquaint.Native.UITest.iOS
{
	[TestFixture]
	public class AcquaintanceUpdatingTests
	{
		iOSApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			// TODO: If the iOS app being tested is included in the solution, then open
			// the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			//
			// The iOS project should have the Xamarin.TestCloud.Agent NuGet package
			// installed. To start the Test Cloud Agent the following code should be
			// added to the FinishedLaunching method of the AppDelegate:
			//
			//    #if ENABLE_TEST_CLOUD
			//    Xamarin.Calabash.Start();
			//    #endif
			//
			// ^^^ THIS IS THE WAY THE ACQUAINT APP IS SETUP FOR UITESTS ^^^


			app = ConfigureApp
				.iOS
			// TODO: If the iOS app being tested is NOT included in the solution, then
			// uncomment this code and update this path to point to your iOS app.
			// .AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/Acquaint.Native.UITest.iOS.iOS.app")
			//
			// ^^^ THIS IS *NOT* THE WAY THE ACQUAINT APP IS SETUP FOR UITESTS ^^^

			.StartApp();
		}

		// tests coming soon
	}
}

