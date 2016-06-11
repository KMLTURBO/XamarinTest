using Acquaint.Data;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
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

			var acquaintanceEditLayout = LayoutInflater.Inflate(Resource.Layout.AcquaintanceEdit, null);

			SetContentView(acquaintanceEditLayout);

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

			SetupViews(acquaintanceEditLayout, savedInstanceState);
		}

		void SetupViews(View layout, Bundle savedInstanceState)
		{
			// inflate the content layout
			_ContentLayout = layout.FindViewById<LinearLayout>(Resource.Id.acquaintanceEditContentLayout);


			_ContentLayout.InflateAndBindTextView(Resource.Id.nameSectionTitleTextView, "Name");

			_ContentLayout.InflateAndBindTextView(Resource.Id.firstNameLabel, "First");
			_ContentLayout.InflateAndBindTextView(Resource.Id.firstNameField, _Acquaintance.FirstName);

			_ContentLayout.InflateAndBindTextView(Resource.Id.lastNameLabel, "Last");
			_ContentLayout.InflateAndBindTextView(Resource.Id.lastNameField, _Acquaintance.LastName);


			_ContentLayout.InflateAndBindTextView(Resource.Id.employmentSectionTitleTextView, "Employment");

			_ContentLayout.InflateAndBindTextView(Resource.Id.companyLabel, "Company");
			_ContentLayout.InflateAndBindTextView(Resource.Id.companyField, _Acquaintance.Company);

			_ContentLayout.InflateAndBindTextView(Resource.Id.jobTitleLabel, "Title");
			_ContentLayout.InflateAndBindTextView(Resource.Id.jobTitleField, _Acquaintance.JobTitle);


			_ContentLayout.InflateAndBindTextView(Resource.Id.contactSectionTitleTextView, "Contact");

			_ContentLayout.InflateAndBindTextView(Resource.Id.phoneNumberLabel, "Phone");
			_ContentLayout.InflateAndBindTextView(Resource.Id.phoneNumberField, _Acquaintance.Phone);

			_ContentLayout.InflateAndBindTextView(Resource.Id.emailLabel, "Email");
			_ContentLayout.InflateAndBindTextView(Resource.Id.emailField, _Acquaintance.Email);
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

