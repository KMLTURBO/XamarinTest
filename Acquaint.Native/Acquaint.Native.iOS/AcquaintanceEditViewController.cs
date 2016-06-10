using System;
using Acquaint.Data;
using UIKit;

namespace Acquaint.Native.iOS
{
	public partial class AcquaintanceEditViewController : UITableViewController
	{
		/// <summary>
		/// Gets or sets the acquaintance.
		/// </summary>
		/// <value>The acquaintance.</value>
		public Acquaintance Acquaintance { get; private set; }

		AcquaintanceDetailViewController _DetailViewController;
		AcquaintanceTableViewController _ListViewController;

		public void SetAcquaintance (Acquaintance acquaintance, AcquaintanceDetailViewController detailViewController = null, AcquaintanceTableViewController listViewController = null)
		{
			Acquaintance = acquaintance;
			if (detailViewController != null)
				_DetailViewController = detailViewController;
			if (listViewController != null)
				_ListViewController = listViewController;
		}

		public AcquaintanceEditViewController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			_FirstNameField.Text = Acquaintance.FirstName;
			_LastNameField.Text = Acquaintance.LastName;
			_CompanyNameField.Text = Acquaintance.Company;
			_JobTitleField.Text = Acquaintance.JobTitle;
			_PhoneNumberField.Text = Acquaintance.Phone;
			_EmailAddressField.Text = Acquaintance.Email;
			_StreetField.Text = Acquaintance.Street;
			_CityField.Text = Acquaintance.City;
			_StateField.Text = Acquaintance.State;
			_ZipField.Text = Acquaintance.PostalCode;

			_DeleteButton.TouchUpInside += (sender, e) => {
				UIAlertController alert = UIAlertController.Create ("Delete?", $"Are you sure you want to delete {Acquaintance.FirstName} {Acquaintance.LastName}?", UIAlertControllerStyle.Alert);

				// cancel button
				alert.AddAction (UIAlertAction.Create ("Cancel", UIAlertActionStyle.Cancel, null));

				// delete button
				alert.AddAction (UIAlertAction.Create ("Delete", UIAlertActionStyle.Destructive, (action) => {
					if (action != null) {
						if (_DetailViewController != null) {
							NavigationController.PopViewController (false); // skipping animation in order to not show the detail screen for the acquaintance we just deleted
							_DetailViewController.DeleteAcquaintance ();
						}
						if (_ListViewController != null) {
							_ListViewController.DeleteAcquaintance (Acquaintance);
						};
					}
				}));

				UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController (alert, true, null);
			};

			NavigationItem.RightBarButtonItem.Clicked += (sender, e) => {

				if (string.IsNullOrWhiteSpace (Acquaintance.LastName) || string.IsNullOrWhiteSpace (Acquaintance.FirstName)) {
					
					UIAlertController alert = UIAlertController.Create ("Invalid name!", "A acquaintance must have both a first and last name.", UIAlertControllerStyle.Alert);

					// cancel button
					alert.AddAction (UIAlertAction.Create ("OK", UIAlertActionStyle.Cancel, null));

					UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController (alert, true, null);

				} else if (!RequiredAddressFieldCombinationIsFilled) {

					UIAlertController alert = UIAlertController.Create ("Invalid address!", "You must enter either a street, city, and state combination, or a postal code.", UIAlertControllerStyle.Alert);

					// cancel button
					alert.AddAction (UIAlertAction.Create ("OK", UIAlertActionStyle.Cancel, null));
				} else {

					Acquaintance.FirstName = _FirstNameField.Text;
					Acquaintance.LastName = _LastNameField.Text;
					Acquaintance.Company = _CompanyNameField.Text;
					Acquaintance.JobTitle = _JobTitleField.Text;
					Acquaintance.Phone = _PhoneNumberField.Text;
					Acquaintance.Email = _EmailAddressField.Text;
					Acquaintance.Street = _StreetField.Text;
					Acquaintance.City = _CityField.Text;
					Acquaintance.State = _StateField.Text;
					Acquaintance.PostalCode = _ZipField.Text;

					if (_DetailViewController != null) {
						_DetailViewController.SetAcquaintance (Acquaintance);
					};

					if (_ListViewController != null) {
						_ListViewController.SaveAcquaintance (Acquaintance);
					};

					NavigationController.PopViewController (true);
				}
			};
		}

		bool RequiredAddressFieldCombinationIsFilled {
			get {
				if (String.IsNullOrWhiteSpace(AddressString)) {
					return true;
				}
				if (!String.IsNullOrWhiteSpace(_StreetField.Text) && !String.IsNullOrWhiteSpace(_CityField.Text) && !String.IsNullOrWhiteSpace(_StateField.Text)) {
					return true;
				}
				if (!String.IsNullOrWhiteSpace(_ZipField.Text) && (String.IsNullOrWhiteSpace(_StreetField.Text) || String.IsNullOrWhiteSpace(_CityField.Text) || String.IsNullOrWhiteSpace(_StateField.Text) )) {
					return true;
				}

				return false;
			}
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		string AddressString 
		{
			get 
			{
				return string.Format (
					"{0} {1} {2} {3}",
					_StreetField.Text,
					!string.IsNullOrWhiteSpace (_CityField.Text) ? _CityField.Text + "," : "",
					_StateField.Text,
					_ZipField.Text);
			}
		}
	}
}


