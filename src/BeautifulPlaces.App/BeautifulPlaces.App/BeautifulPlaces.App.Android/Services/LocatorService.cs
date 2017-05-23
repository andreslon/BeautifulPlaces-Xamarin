
using BeautifulPlaces.App.Interfaces;
using BeautifulPlaces.App.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace BeautifulPlaces.App.Services
{
    public class LocatorService : ILocatorService
    {
        static LocatorService()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            ////Cross Services
            //SimpleIoc.Default.Register<IDialogService, DialogService>();
            //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            //SimpleIoc.Default.Register<IProgressDialogService, ProgressDialogService>();
        } 
        public T Get<T>() where T : class
        {
            return SimpleIoc.Default.GetInstance<T>();
        }
    }
}