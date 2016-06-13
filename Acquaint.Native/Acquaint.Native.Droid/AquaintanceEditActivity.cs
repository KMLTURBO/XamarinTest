using System;
using System.Threading.Tasks;
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
		Acquaintance _Acquaintance;
		View _ContentLayout;

		EditText _FirstNameField;
		EditText _LastNameField;
		EditText _CompanyField;
		EditText _JobTitleField;
		EditText _PhoneField;
		EditText _EmailField;
		EditText _StreetField;
		EditText _CityField;
		EditText _StateField;
		EditText _ZipField;

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

			// extract the acquaintance id from the intent
			var acquaintanceId = Intent.GetStringExtra(GetString(Resource.String.acquaintanceEditIntentKey));

			// fetch the acquaintance based on the id
			_Acquaintance = await MainApplication.AcquaintanceDataSource.GetItem(acquaintanceId);

			Title = SupportActionBar.Title = "";

			SetupViews(acquaintanceEditLayout, savedInstanceState);
		}

		void SetupViews(View layout, Bundle savedInstanceState)
		{
			_ContentLayout = layout.FindViewById<LinearLayout>(Resource.Id.acquaintanceEditContentLayout);


			_ContentLayout.InflateAndBindTextView(Resource.Id.nameSectionTitleTextView, "Name");

			_ContentLayout.InflateAndBindTextView(Resource.Id.firstNameLabel, "First");
			_FirstNameField = _ContentLayout.InflateAndBindEditText(Resource.Id.firstNameField, _Acquaintance.FirstName);

			_ContentLayout.InflateAndBindTextView(Resource.Id.lastNameLabel, "Last");
			_LastNameField = _ContentLayout.InflateAndBindEditText(Resource.Id.lastNameField, _Acquaintance.LastName);


			_ContentLayout.InflateAndBindTextView(Resource.Id.employmentSectionTitleTextView, "Employment");

			_ContentLayout.InflateAndBindTextView(Resource.Id.companyLabel, "Company");
			_CompanyField = _ContentLayout.InflateAndBindEditText(Resource.Id.companyField, _Acquaintance.Company);

			_ContentLayout.InflateAndBindTextView(Resource.Id.jobTitleLabel, "Title");
			_JobTitleField = _ContentLayout.InflateAndBindEditText(Resource.Id.jobTitleField, _Acquaintance.JobTitle);


			_ContentLayout.InflateAndBindTextView(Resource.Id.contactSectionTitleTextView, "Contact");

			_ContentLayout.InflateAndBindTextView(Resource.Id.phoneNumberLabel, "Phone");
			_PhoneField = _ContentLayout.InflateAndBindEditText(Resource.Id.phoneNumberField, _Acquaintance.Phone);

			_ContentLayout.InflateAndBindTextView(Resource.Id.emailLabel, "Email");
			_EmailField = _ContentLayout.InflateAndBindEditText(Resource.Id.emailField, _Acquaintance.Email);


			_ContentLayout.InflateAndBindTextView(Resource.Id.addressSectionTitleTextView, "Address");

			_ContentLayout.InflateAndBindTextView(Resource.Id.streetLabel, "Street");
			_StreetField = _ContentLayout.InflateAndBindEditText(Resource.Id.streetField, _Acquaintance.Street);

			_ContentLayout.InflateAndBindTextView(Resource.Id.cityLabel, "City");
			_CityField = _ContentLayout.InflateAndBindEditText(Resource.Id.cityField, _Acquaintance.City);

			_ContentLayout.InflateAndBindTextView(Resource.Id.stateLabel, "State");
			_StateField = _ContentLayout.InflateAndBindEditText(Resource.Id.stateField, _Acquaintance.State);

			_ContentLayout.InflateAndBindTextView(Resource.Id.zipLabel, "ZIP");
			_ZipField = _ContentLayout.InflateAndBindEditText(Resource.Id.zipField, _Acquaintance.PostalCode);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.AcquaintanceEditMenu, menu);

			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case Android.Resource.Id.Home:
				OnBackPressed();
				break;
			case Resource.Id.acquaintanceSaveButton:
				Save();
				OnBackPressed();
				break;
			}

			return base.OnOptionsItemSelected(item);
		}

		void Save() 
		{
			_Acquaintance.FirstName = _FirstNameField.Text;
			_Acquaintance.LastName = _LastNameField.Text;
			_Acquaintance.Company = _CompanyField.Text;
			_Acquaintance.JobTitle = _JobTitleField.Text;
			_Acquaintance.Phone = _PhoneField.Text;
			_Acquaintance.Email = _EmailField.Text;
			_Acquaintance.Street = _StreetField.Text;
			_Acquaintance.City = _CityField.Text;
			_Acquaintance.State = _StateField.Text;
			_Acquaintance.PostalCode = _ZipField.Text;

			MainApplication.AcquaintanceDataSource.SaveItem(_Acquaintance);
		}
	}
}

