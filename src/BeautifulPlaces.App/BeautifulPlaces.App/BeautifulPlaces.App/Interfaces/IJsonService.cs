using System.Net.Http;
using System.Threading.Tasks;

namespace BeautifulPlaces.App.Interfaces
{
    public interface IJsonService
    {
        Task<TResponse> GetSerializedResponse<TResponse>(HttpResponseMessage result);
        TResponse Deserialize<TResponse>(string text);
        string Serialize(object obj);
    }
}
