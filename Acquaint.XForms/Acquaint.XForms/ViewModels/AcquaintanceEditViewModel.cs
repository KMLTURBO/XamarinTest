using System;
using System.Threading.Tasks;
using Acquaint.Data;
using Acquaint.Util;
using FormsToolkit;
using Xamarin.Forms;
using AutoMapper;

namespace Acquaint.XForms
{
	public class AcquaintanceEditViewModel : BaseNavigationViewModel
	{
		public AcquaintanceEditViewModel(Acquaintance acquaintance = null)
		{
			if (acquaintance == null)
			{
				Acquaintance = new Acquaintance()
				{ 
					Id = Guid.NewGuid().ToString(),
					PhotoUrl = "placeholderProfileImage.png"
				};
			}
			else
			{
				Mapper.Initialize(cfg => cfg.CreateMap<Acquaintance, Acquaintance>());

				// Use AutoMapper to make a copy of the Acquaintance.
				// On the edit screen, we want to only deal with this copy until we're ready to save.
				// If we didn't make this copy, then the item would be updated instantaneously without saving, 
				// by virtue of the ObservableObject type that the Acquaint model inherits from.
				Acquaintance = Mapper.Map<Acquaintance>(acquaintance);
			}
		}

		public Acquaintance Acquaintance { private set; get; }

		Command _SaveAcquaintanceCommand;

		public Command SaveAcquaintanceCommand
		{
			get
			{
				return _SaveAcquaintanceCommand ?? (_SaveAcquaintanceCommand = new Command(() => ExecuteSaveAcquaintanceCommand()));
			}
		}

		async Task ExecuteSaveAcquaintanceCommand()
		{
			if (string.IsNullOrWhiteSpace(Acquaintance.LastName) || string.IsNullOrWhiteSpace(Acquaintance.FirstName))
			{
				MessagingService.Current.SendMessage<MessagingServiceAlert>(MessageKeys.DisplayAlert, new MessagingServiceAlert()
					{
						Title = "Invalid name!", 
						Message = "A acquaintance must have both a first and last name.",
						Cancel = "OK"
					});
			}
			else if (!RequiredAddressFieldCombinationIsFilled)
			{
				MessagingService.Current.SendMessage<MessagingServiceAlert>(MessageKeys.DisplayAlert, new MessagingServiceAlert()
					{
						Title = "Invalid address!", 
						Message = "You must enter either a street, city, and state combination, or a postal code.",
						Cancel = "OK"
					});
			}
			else
			{
				MessagingService.Current.SendMessage<Acquaintance>(MessageKeys.SaveAcquaintance, Acquaintance);

				await PopAsync();
			}
		}

		Command _DeleteAcquaintanceCommand;
			
		public Command DeleteAcquaintanceCommand => _DeleteAcquaintanceCommand ?? (_DeleteAcquaintanceCommand = new Command(ExecuteDeleteAcquaintanceCommand));

		void ExecuteDeleteAcquaintanceCommand()
		{
			MessagingService.Current.SendMessage<MessagingServiceQuestion>(MessageKeys.DisplayQuestion, new MessagingServiceQuestion()
				{
					Title = string.Format("Delete {0}?", Acquaintance.DisplayName),
					Question = null,
					Positive = "Delete",
					Negative = "Cancel",
					OnCompleted = new Action<bool>(async result =>
						{
							if (!result) return;

							// send a message that we want the given acquaintance to be deleted
							MessagingService.Current.SendMessage<Acquaintance>(MessageKeys.DeleteAcquaintance, Acquaintance);

							// pop the navigation stack twice so we get back to the list
							await PopAsync(false);
							await PopAsync();
						})
				});
		}

		bool RequiredAddressFieldCombinationIsFilled
		{
			get
			{
				if (Acquaintance.AddressString.IsNullOrWhiteSpace())
				{
					return true;
				}
				if (!Acquaintance.Street.IsNullOrWhiteSpace() && !Acquaintance.City.IsNullOrWhiteSpace() && !Acquaintance.State.IsNullOrWhiteSpace())
				{
					return true;
				}
				if (!Acquaintance.PostalCode.IsNullOrWhiteSpace() && (Acquaintance.Street.IsNullOrWhiteSpace() || Acquaintance.City.IsNullOrWhiteSpace() || Acquaintance.State.IsNullOrWhiteSpace()))
				{
					return true;
				}

				return false;
			}
		}
	}
}

