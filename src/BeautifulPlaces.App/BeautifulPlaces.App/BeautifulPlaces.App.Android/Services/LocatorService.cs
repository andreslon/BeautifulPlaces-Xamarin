
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
            //Cross Services
            SimpleIoc.Default.Register<IApiService, ApiService>();
            SimpleIoc.Default.Register<IHttpClientService, HttpClientService>();
            SimpleIoc.Default.Register<IJsonService, JsonService>();
        }
        public T Get<T>() where T : class
        {
            return SimpleIoc.Default.GetInstance<T>();
        }
    }
}