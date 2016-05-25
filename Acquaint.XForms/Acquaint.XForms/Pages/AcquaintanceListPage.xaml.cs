using System;
using Xamarin.Forms;
using Acquaint.Data;

namespace Acquaint.XForms
{
    public partial class AcquaintanceListPage : ContentPage
    {
        protected AcquaintanceListViewModel ViewModel => BindingContext as AcquaintanceListViewModel;

        public AcquaintanceListPage()
        {
            InitializeComponent();

            // on Android, we use a floating action button, so clear the ToolBarItems collection
            if (Device.OS == TargetPlatform.Android)
            {
                ToolbarItems.Clear();

                fab.Clicked = AndroidAddButtonClicked;
            }
        }

        /// <summary>
        /// The action to take when a list item is tapped.
        /// </summary>
        /// <param name="sender"> The sender.</param>
        /// <param name="e">The ItemTappedEventArgs</param>
        void ItemTapped (object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new AcquaintanceDetailPage() { BindingContext = new AcquaintanceDetailViewModel((Acquaintance)e.Item) });

            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// The action to take when the + button is clicked on Android.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The EventArgs</param>
        void AndroidAddButtonClicked (object sender, EventArgs e)
        {
			Navigation.PushAsync(new AcquaintanceEditPage() { BindingContext = new AcquaintanceEditViewModel() });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.LoadAcquaintancesCommand.Execute(null);
        }
    }
}

