using Acquaint.Data;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Acquaint.Native.Droid
{
	[Activity]
	public class AquaintanceEditActivity : AppCompatActivity
	{
		readonly IDataSource<Acquaintance> _AcquaintanceDataSource;
		Acquaintance _Acquaintance;
		View _ContentLayout;

		public AquaintanceEditActivity()
		{
			_AcquaintanceDataSource = new AcquaintanceDataSource();
		}

		protected override async void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			var acquaintanceDetailLayout = LayoutInflater.Inflate(Resource.Layout.AcquaintanceEdit, null);

			SetContentView(acquaintanceDetailLayout);

			SetSupportActionBar(FindViewById<Toolbar>(Resource.Id.toolbar));

			// ensure that the system bar color gets drawn
			Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

			// enable the back button in the action bar
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetHomeButtonEnabled(true);

			// extract the acquaintance id fomr the intent
			var acquaintanceId = Intent.GetStringExtra(GetString(Resource.String.acquaintanceEditIntentKey));

			// fetch the acquaintance based on the id
			_Acquaintance = await _AcquaintanceDataSource.GetItem(acquaintanceId);
		}

		// this override is called when the back button is tapped
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (item != null)
			{
				switch (item.ItemId)
				{
				case Android.Resource.Id.Home:
					// execute a back navigation
					OnBackPressed();
					break;
				}
			}

			return base.OnOptionsItemSelected(item);
		}
	}
}

