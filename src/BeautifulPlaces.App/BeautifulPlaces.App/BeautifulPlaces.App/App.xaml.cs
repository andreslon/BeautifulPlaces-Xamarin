using BeautifulPlaces.App.ViewModels;
using BeautifulPlaces.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BeautifulPlaces.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new MasterDetailPage
            {
                BindingContext = new MainViewModel(),
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
