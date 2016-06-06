using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace Acquaint.XForms.UITest.iOS
{
	[TestFixture]
	public class Tests
	{
		iOSApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			// TODO: If the iOS app being tested is included in the solution then open
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
			app = ConfigureApp
				.iOS
			// TODO: Update this path to point to your iOS app and uncomment the
			// code if the app is not included in the solution.
			//.AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/Acquaint.XForms.UITest.iOS.iOS.app")
				.StartApp();
		}

		[Test]
		public void UpdateFirstName() {
			app.Screenshot("App start, display list");
			app.ScrollTo("Green, Monica");
			app.Screenshot("Scrolled to Monica Green");
			app.Tap(x => x.Marked("Green, Monica"));
			app.Screenshot("Detail screen");
			app.Tap(x => x.Id("edit.png"));
			app.Screenshot("Edit screen");
			app.Tap(x => x.Marked("Monica"));
			app.ClearText(x => x.Text("Monica"));
			app.Screenshot("Cleared first name field");
			app.EnterText(x => x.Class("UITextField"), "Erica");
			app.Screenshot("Altered value first name field");
			app.Tap(x => x.Id("save.png"));
			app.Screenshot("Saved changes, navigated to detail screen");
			app.Tap(x => x.Marked("List"));
			app.ScrollTo("Green, Erica");
			app.Screenshot("First name updated on list screen");
		}

		[Test]
		public void UpdateLastName() {
			app.Screenshot("App start, display list");
			app.ScrollTo("Green, Monica");
			app.Screenshot("Scrolled to Monica Green");
			app.Tap(x => x.Marked("Green, Monica"));
			app.Screenshot("Detail screen");
			app.Tap(x => x.Id("edit.png"));
			app.Screenshot("Edit screen");
			app.Tap(x => x.Marked("Green"));
			app.ClearText(x => x.Text("Green"));
			app.Screenshot("Cleared last name field");
			app.EnterText(x => x.Class("UITextField"), "Johnson");
			app.Screenshot("Altered value last name field");
			app.Tap(x => x.Id("save.png"));
			app.Screenshot("Saved changes, navigated to detail screen");
			app.Tap(x => x.Marked("List"));
			app.ScrollTo("Johnson, Erica");
			app.Screenshot("First name updated on list screen");
		}
	}
}

