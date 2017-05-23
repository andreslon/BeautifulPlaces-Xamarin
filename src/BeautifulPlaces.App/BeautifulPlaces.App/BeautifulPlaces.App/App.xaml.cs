using BeautifulPlaces.App.Interfaces;
using BeautifulPlaces.App.ViewModels;
using BeautifulPlaces.App.Views;
using Xamarin.Forms;

namespace BeautifulPlaces.App
{
    public partial class App : Application
    {
        public static ILocatorService LocatorService { get; set; }

        public App()
        {
            InitializeComponent();
            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new MasterDetailPage
            {
                BindingContext = LocatorService.Get<MainViewModel>(),
                Detail = new TabbedPage
                {
                    Children =
                        {
                            new NavigationPage(new PlacesPage())
                            {
                                Title = "Todos",
                                Icon = "ic_filter_list_white_24dp.png"
                            },
                            new NavigationPage(new AddPlacePage())
                            {
                                Title = "Agregar",
                                Icon = "ic_place_white_24dp.png"
                            },
                        }
                },
                Master = new MenuPage
                {
                    Title = "ContentPage"
                }
            };

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
