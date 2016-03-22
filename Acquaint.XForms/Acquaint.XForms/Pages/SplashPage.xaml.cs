using Xamarin.Forms;
using System.Threading.Tasks;

namespace Acquaint.XForms
{
    /// <summary>
    /// Splash Page that is used on Androd only. iOS splash characteristics are NOT defined here, ub tn the iOS prject settings.
    /// </summary>
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // await a new task
            await Task.Factory.StartNew(async () => {

                // delay for a few seconds on the splash screen
                await Task.Delay(3000);

                // instantiate a NavigationPage with the AcquaintanceListPage
                var navPage = new NavigationPage(new AcquaintanceListPage() { Title = "Acquaintances",  BindingContext = new AcquaintanceListViewModel() });

                // if this is iOS set the nav bar text color
                if (Device.OS == TargetPlatform.iOS)
                    navPage.BarTextColor = Color.White;

                // on the main UI thread, set the MainPage to the navPage
                Device.BeginInvokeOnMainThread(() => {
                    Application.Current.MainPage = navPage;
                });
            });


        }
    }
}

