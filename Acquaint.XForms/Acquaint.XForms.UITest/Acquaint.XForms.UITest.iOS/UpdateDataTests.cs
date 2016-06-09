using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;
using System.Threading;

namespace Acquaint.XForms.UITest.iOS
{
	[TestFixture]
	public class UpdateDataTests
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
			//
			// ^^^ THIS IS THE WAY THE ACQUAINT APP IS SETUP FOR UITESTS ^^^


			app = ConfigureApp
				.iOS
			// TODO: Update this path to point to your iOS app and uncomment the
			// code if the app is not included in the solution.
			//.AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/Acquaint.XForms.UITest.iOS.iOS.app")
			//
			// ^^^ THIS IS *NOT* THE WAY THE ACQUAINT APP IS SETUP FOR UITESTS ^^^
				.StartApp();
		} 

		[Test]
		public void UpdateFirstName() {
			app.WaitForElement(x => x.Marked("Armstead, Evan")); // wait for the list to appear
			app.Screenshot("App start, display list");
			app.ScrollDownTo("Green, Monica");
			app.Screenshot("Scrolled to Monica Green");
			app.Tap(x => x.Marked("Green, Monica"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Detail screen");
			app.Tap(x => x.Id("edit.png"));
			app.Screenshot("Edit screen");
			app.ScrollDownTo("First");
			app.Tap(x => x.Marked("Monica"));
			app.ClearText();
			app.Screenshot("Cleared first name field");
			app.EnterText("Erica");
			app.DismissKeyboard();
			app.Screenshot("Altered value of company name field");
			app.Tap(x => x.Id("save.png"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Saved changes, navigated to detail screen, first name updated");
			app.Tap(x => x.Marked("List"));
			app.ScrollDownTo("Green, Erica");
			app.Screenshot("First name updated on list screen, first name updated");
		}

		[Test]
		public void UpdateLastName() {
			app.WaitForElement(x => x.Marked("Armstead, Evan")); // wait for the list to appear
			app.Screenshot("App start, display list");
			app.ScrollDownTo("Green, Monica");
			app.Screenshot("Scrolled to Monica Green");
			app.Tap(x => x.Marked("Green, Monica"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Detail screen");
			app.Tap(x => x.Id("edit.png"));
			app.Screenshot("Edit screen");
			app.ScrollDownTo("Last");
			app.Tap(x => x.Marked("Green"));
			app.ClearText();
			app.Screenshot("Cleared last name field");
			app.EnterText("Johnson");
			app.DismissKeyboard();
			app.Screenshot("Altered value of last name field");
			app.Tap(x => x.Id("save.png"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Saved changes, navigated to detail screen, last name updated");
			app.Tap(x => x.Marked("List"));
			app.ScrollDownTo("Johnson, Monica");
			app.Screenshot("First name updated on list screen, last name updated");
		}

		[Test]
		public void UpdateCompanyName() {
			app.WaitForElement(x => x.Marked("Armstead, Evan")); // wait for the list to appear
			app.Screenshot("App start, display list");
			app.ScrollDownTo("Green, Monica");
			app.Screenshot("Scrolled to Monica Green");
			app.Tap(x => x.Marked("Green, Monica"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Detail screen");
			app.Tap(x => x.Id("edit.png"));
			app.Screenshot("Edit screen");
			app.ScrollDownTo("Company");
			app.Tap(x => x.Marked("Calcom Logistics"));
			app.ClearText();
			app.Screenshot("Cleared company name field");
			app.EnterText("Bay Shipping Inc");
			app.DismissKeyboard();
			app.Screenshot("Altered value of company name field");
			app.Tap(x => x.Id("save.png"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Saved changes, navigated to detail screen, company updated");
			app.Tap(x => x.Marked("List"));
			app.ScrollDownTo("Green, Monica");
			app.Screenshot("Company name updated on list screen, company updated");
		}

		[Test]
		public void UpdateTitle() {
			app.WaitForElement(x => x.Marked("Armstead, Evan")); // wait for the list to appear
			app.Screenshot("App start, display list");
			app.ScrollDownTo("Green, Monica");
			app.Screenshot("Scrolled to Monica Green");
			app.Tap(x => x.Marked("Green, Monica"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Detail screen");
			app.Tap(x => x.Id("edit.png"));
			app.Screenshot("Edit screen");
			app.ScrollDownTo("Title");
			app.Tap(x => x.Marked("Director"));
			app.ClearText();
			app.Screenshot("Cleared title field");
			app.EnterText("COO");
			app.DismissKeyboard();
			app.Screenshot("Altered value of title field");
			app.Tap(x => x.Id("save.png"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Saved changes, navigated to detail screen, title updated");
		}

		[Test]
		public void UpdatePhoneNumber() {
			app.WaitForElement(x => x.Marked("Armstead, Evan")); // wait for the list to appear
			app.Screenshot("App start, display list");
			app.ScrollDownTo("Green, Monica");
			app.Screenshot("Scrolled to Monica Green");
			app.Tap(x => x.Marked("Green, Monica"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Detail screen");
			app.Tap(x => x.Id("edit.png"));
			app.Screenshot("Edit screen");
			app.ScrollDownTo("Phone");
			app.Tap(x => x.Marked("925-353-8029"));
			app.ClearText();
			app.Screenshot("Cleared phone number field");
			app.EnterText("9257878888");
			app.DismissKeyboard();
			app.Screenshot("Altered value of phone number field");
			app.Tap(x => x.Id("save.png"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Saved changes, navigated to detail screen, phone updated");
		}

		[Test]
		public void UpdateEmailAddress() {
			app.WaitForElement(x => x.Marked("Armstead, Evan")); // wait for the list to appear
			app.Screenshot("App start, display list");
			app.ScrollDownTo("Green, Monica");
			app.Screenshot("Scrolled to Monica Green");
			app.Tap(x => x.Marked("Green, Monica"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Detail screen");
			app.Tap(x => x.Id("edit.png"));
			app.Screenshot("Edit screen");
			app.ScrollDownTo("Email");
			app.Tap(x => x.Marked("mgreen@calcomlogistics.com"));
			app.ClearText();
			app.Screenshot("Cleared email field");
			app.EnterText("mgreen@bayshipping.com");
			app.DismissKeyboard();
			app.Screenshot("Altered value of email field");
			app.Tap(x => x.Id("save.png"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Saved changes, navigated to detail screen, email updated");
		}

		[Test]
		public void UpdateMailingAddress() {
			app.WaitForElement(x => x.Marked("Armstead, Evan")); // wait for the list to appear
			app.Screenshot("App start, display list");
			app.ScrollDownTo("Green, Monica");
			app.Screenshot("Scrolled to Monica Green");
			app.Tap(x => x.Marked("Green, Monica"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Detail screen");
			app.Tap(x => x.Id("edit.png"));
			app.Screenshot("Edit screen");

			app.ScrollDownTo("Street");
			app.Tap(x => x.Marked("230 3rd Ave"));
			app.ClearText();
			app.Screenshot("Cleared street field");
			app.EnterText("1395 Middle Harbor Rd");
			app.DismissKeyboard();
			app.Screenshot("Altered value of street field");

			app.ScrollDownTo("City");
			app.Tap(x => x.Marked("San Francisco"));
			app.ClearText();
			app.Screenshot("Cleared city field");
			app.EnterText("Oakland");
			app.DismissKeyboard();
			app.Screenshot("Altered value of city field");

			app.ScrollDownTo("ZIP");
			app.Tap(x => x.Marked("94118"));
			app.ClearText();
			app.Screenshot("Cleared ZIP field");
			app.EnterText("94612");
			app.DismissKeyboard();
			app.Screenshot("Altered value of ZIP field");

			app.Tap(x => x.Id("save.png"));
			app.WaitForElement(x => x.Class("MKNewAnnotationContainerView")); // wait for the map to appear
			Thread.Sleep(2000); // wait 2 seconds to give map time to fully render
			app.Screenshot("Saved changes, navigated to detail screen, address updated");
		}
	}
}

