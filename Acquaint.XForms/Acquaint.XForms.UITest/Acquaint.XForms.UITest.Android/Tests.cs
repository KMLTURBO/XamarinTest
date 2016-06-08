using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace Acquaint.XForms.UITest.Android
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
			app = ConfigureApp
				.Android
			// TODO: Update this path to point to your Android app and uncomment the
			// code if the app is not included in the solution.
			//.ApkFile ("../../../Android/bin/Debug/UITestsAndroid.apk")
				.StartApp();
		}

		[Test]
		public void UpdateFirstName() {
			app.Screenshot("App start, display list");
			app.ScrollDownTo("Green, Monica");
			app.Screenshot("Scrolled to Monica Green");
			app.Tap(x => x.Text("Green, Monica"));
			app.Screenshot("Detail screen");
			app.Tap(x => x.Marked("Edit"));
			app.Screenshot("Edit screen");
			app.ScrollDownTo("First");
			app.Tap(x => x.Text("Monica"));
			app.ClearText();
			app.Screenshot("Cleared first name field");
			app.EnterText("Erica");
			app.DismissKeyboard();
			app.Screenshot("Altered value of company name field");
			app.Tap(x => x.Marked("Save"));
			app.Screenshot("Saved changes, navigated to detail screen");
			app.Tap(x => x.Class("ImageButton"));
			app.ScrollTo("Green, Erica");
			app.Screenshot("First name updated on list screen");
		}

	}
}

