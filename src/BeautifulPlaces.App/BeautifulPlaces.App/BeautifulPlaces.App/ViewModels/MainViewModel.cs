using BeautifulPlaces.App.Enumerations;
using BeautifulPlaces.App.Interfaces;
using BeautifulPlaces.App.Resources;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BeautifulPlaces.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private List<PlaceViewModel> _Places;

        public List<PlaceViewModel> Places
        {
            get { return _Places; }
            set { Set(ref _Places, value); }
        }

        public PlaceViewModel SelectedPlace { get; set; }
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        public IApiService ApiService { get; set; }
        public MainViewModel(IApiService apiService)
        {
            ApiService = apiService;
            
            LoadMenuItems();
            LoadPlaces();
        }


        async public void LoadPlaces()
        {
            var placesResponse = await ApiService.GetPlaces();
            if (placesResponse.HttpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var picturesResponse = await ApiService.GetPictures();
                if (picturesResponse.HttpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Places = new List<PlaceViewModel>();
                    foreach (var place in placesResponse.Response)
                    {
                        var placeViewModel = new PlaceViewModel
                        {
                            Description = place.Description,
                            Id = place.Id,
                            Likes = place.Likes,
                            Location = place.Location,
                            Name = place.Name,
                            Thumbnail = place.Thumbnail,
                            Pictures = new ObservableCollection<PictureViewModel>()
                        };

                        var pictures = picturesResponse.Response.Where(x => x.PlaceId == place.Id);
                        if (pictures != null && pictures.Count() > 0)
                        {
                            foreach (var picture in pictures)
                            {
                                placeViewModel.Pictures.Add(new PictureViewModel { Id = picture.Id, Uri = picture.Uri });
                            }
                        }
                        Places.Add(placeViewModel); 
                    }
                }
                else
                {
                    await App.NavigationPage.DisplayAlert("Ups!", "Ha ocurrido un error obteniendo datos del servidor.", "Aceptar");
                }
            }
            else
            {
                await App.NavigationPage.DisplayAlert("Ups!", "Ha ocurrido un error obteniendo datos del servidor.", "Aceptar");
            }
        }
        async public void SetLike(PlaceViewModel placeViewModel)
        {
            var placeResponse = await ApiService.UpdatePlace(new Dtos.PlaceDto
            {
                Description = placeViewModel.Description,
                Id = placeViewModel.Id,
                Likes = placeViewModel.Likes,
                Location = placeViewModel.Location,
                Name = placeViewModel.Name,
                Thumbnail = placeViewModel.Thumbnail,
            });
            if (placeResponse.HttpResponse.StatusCode == System.Net.HttpStatusCode.OK
                || placeResponse.HttpResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                await App.NavigationPage.DisplayAlert("Exitoso!", "Gracias por proporcionar un voto por este lugar.", "Aceptar");
            }
            else
            {
                await App.NavigationPage.DisplayAlert("Ups!", "Ha ocurrido un error enviando datos a el servidor.", "Aceptar");
            }
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
