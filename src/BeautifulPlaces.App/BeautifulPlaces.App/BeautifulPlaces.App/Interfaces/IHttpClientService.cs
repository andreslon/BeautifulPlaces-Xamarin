using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BeautifulPlaces.App.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> PostMultiPartAsync(string serviceUrl, HttpContent multipart); 
        Task<HttpResponseMessage> PostAsync<TRequest>(string serviceUrl, TRequest request, Dictionary<string, string> headers = null, bool isStringContent = false, string mediaType = "application/json");
        Task<HttpResponseMessage> PutAsync<TRequest>(string serviceUrl, TRequest request, Dictionary<string, string> headers = null);
        Task<HttpResponseMessage> GetAsync(string serviceUrl, Dictionary<string, string> headers = null);
        Task<HttpResponseMessage> DeleteAsync<TRequest>(string serviceUrl, TRequest request, Dictionary<string, string> headers = null);
    }
}
