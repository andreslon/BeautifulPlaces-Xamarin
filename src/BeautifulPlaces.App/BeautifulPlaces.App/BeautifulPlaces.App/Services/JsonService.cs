using BeautifulPlaces.App.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
namespace BeautifulPlaces.App.Services
{
    public class JsonService : IJsonService
    {
        public async Task<TResponse> GetSerializedResponse<TResponse>(HttpResponseMessage result)
        {
            string response = await result.Content.ReadAsStringAsync();
            TResponse serializedResponse = JsonConvert.DeserializeObject<TResponse>(response);
            return serializedResponse;
        } 
        public T Deserialize<T>(string text)
        {
            T deserializedObject = JsonConvert.DeserializeObject<T>(text);
            return deserializedObject;
        }
        public string Serialize(object obj)
        {
            string serializedObject = JsonConvert.SerializeObject(obj);
            return serializedObject;
        }
    }
}
