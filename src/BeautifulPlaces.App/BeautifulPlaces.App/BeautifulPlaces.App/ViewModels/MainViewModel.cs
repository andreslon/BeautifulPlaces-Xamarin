using BeautifulPlaces.App.Enumerations;
using BeautifulPlaces.App.Resources;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace BeautifulPlaces.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public List<PlaceViewModel> Places { get; set; }
        public PlaceViewModel SelectedPlace { get; set; }

        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
        public MainViewModel()
        {
            Places = new List<PlaceViewModel>();
            Places.Add(new PlaceViewModel
            {
                Description = "Description",
                Likes = 2,
                Location = "Location",
                Name = "Name",
                Thumbnail = "http://www.hotelpark10.com.co/pagomio/wp-content/uploads/2014/10/medellin-colombia-hotelpark10.jpg",

            });
            Places.Add(new PlaceViewModel
            {
                Description = "Description",
                Likes = 2,
                Location = "Location",
                Name = "Name",
                Thumbnail = "http://sociable.co/wp-content/uploads/2016/02/medellin.jpg",

            });
            LoadMenuItems();
        }
        private void LoadMenuItems()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>();
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = LocalizedStrings.Get("strHome"),
                Type = PageTypes.Home,
                Icon = "ic_home_white_24dp"
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = LocalizedStrings.Get("strRate"),
                Type = PageTypes.Rate,
                Icon = "ic_star_rate_white_18dp"
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = LocalizedStrings.Get("strContact"),
                Type = PageTypes.Contact,
                Icon = "ic_email_white_18dp"
            });
        }
    }
}
