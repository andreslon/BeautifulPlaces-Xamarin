using BeautifulPlaces.App.Interfaces;
using BeautifulPlaces.App.ViewModels;
using BeautifulPlaces.App.Views;
using Xamarin.Forms;

namespace BeautifulPlaces.App
{
    public partial class App : Application
    {
        public static ILocatorService LocatorService { get; set; }
        public static NavigationPage NavigationPage { get; set; }
        public App()
        {
            InitializeComponent();
            SetMainPage();
        }

        public static void SetMainPage()
        {
            NavigationPage = new NavigationPage(new PlacesPage())
            {
                Title = "Todos",
                Icon = "ic_filter_list_white_24dp.png"
            };
            Current.MainPage = new MasterDetailPage
            {
                BindingContext = LocatorService.Get<MainViewModel>(),
                Detail = new TabbedPage
                {
                    Children =
                        {
                            NavigationPage,
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

        async public static void SetNavigationPage(Page page) {
            NavigationPage.SetBackButtonTitle(page, "Atrás");
            await NavigationPage.PushAsync(page);
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
