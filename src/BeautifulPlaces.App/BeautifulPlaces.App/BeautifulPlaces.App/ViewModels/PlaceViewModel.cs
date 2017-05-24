using BeautifulPlaces.App.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BeautifulPlaces.App.ViewModels
{
    public class PlaceViewModel : ViewModelBase
    {
        public PlaceViewModel()
        {

        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public string Location { get; set; }
        public string Thumbnail { get; set; }
        public ObservableCollection<PictureViewModel> Pictures { get; set; }
        public ICommand SelectCommand { get { return new RelayCommand(Select); } }

        async private void Select()
        {
            var main = App.LocatorService.Get<MainViewModel>();
            main.SelectedPlace = this;
            App.SetNavigationPage(new PlaceDetailPage()); 
        }
    }
}
