using Android.App;
using Android.Content.PM;
using Android.OS;
using Acquaint.XForms.Droid;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin;

namespace Acquaint.XForms.Droid
{
	[Activity (Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
	// inhertiting from FormsAppCompatActivity is imperative to taking advantage of Android AppCompat libraries
	{
		protected override void OnCreate (Bundle bundle)
		{
			Insights.Initialize (XamarinInsights.ApiKey, this);
			// this line is essential to wiring up the toolbar styles defined in ~/Resources/layout/toolbar.axml
			FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
			base.OnCreate (bundle);
			Forms.Init (this, bundle);
			FormsMaps.Init (this, bundle);
			ImageCircleRenderer.Init ();
			LoadApplication (new App ());
		}
	}
}
