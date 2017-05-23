using BeautifulPlaces.App.Enumerations;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BeautifulPlaces.App.ViewModels
{
    public class MenuItemViewModel
    {
        public MenuItemViewModel()
        {
        } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public PageTypes Type { get; set; }
        public ICommand GoToMenuOptionCommand { get { return new RelayCommand(GoToMenuOption); } }
        private void GoToMenuOption()
        { 
            if (Type == PageTypes.Contact)
            {
                Device.OpenUri(new Uri("mailto:andreslon@outlook.com"));
            }
            else if (Type == PageTypes.Rate)
            {
                Device.OpenUri(new Uri("https://play.google.com/store/apps/details?id=com.beautifulplace&hl=es"));
            }
            else  
            {
                    return; 
            } 
        }
    }
}
