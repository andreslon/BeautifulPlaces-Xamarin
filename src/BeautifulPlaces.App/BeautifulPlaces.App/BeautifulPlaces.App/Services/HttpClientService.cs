using BeautifulPlaces.App.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BeautifulPlaces.App.Services
{
    public class HttpClientService : IHttpClientService
    { 
        public async Task<HttpResponseMessage> PostMultiPartAsync(string serviceUrl, HttpContent multipart)
        {
            using (var client = new HttpClient())
            {

                MultipartFormDataContent multiPartContent = new MultipartFormDataContent("----MyGreatBoundary");
                multipart.Headers.Add("Content-Type", "application/octet-stream");
                multiPartContent.Add(multipart, "this is the name of the content", "file");
                return await client.PostAsync(serviceUrl, multiPartContent);
            }
        }
        public async Task<HttpResponseMessage> PostAsync<TRequest>(string serviceUrl, TRequest request, Dictionary<string, string> headers = null, bool isStringContent = false, string mediaType = "application/json")
        {
            using (var client = new HttpClient())
            {
                string bodyRequest;

                if (isStringContent)
                {
                    bodyRequest = request.ToString();
                }
                else
                {
                    bodyRequest = JsonConvert.SerializeObject(request);
                }

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                return await client.PostAsync(serviceUrl, new StringContent(bodyRequest, System.Text.Encoding.UTF8, mediaType));
            }
        }
        public async Task<HttpResponseMessage> PutAsync<TRequest>(string serviceUrl, TRequest request, Dictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            {
                var bodyRequest = JsonConvert.SerializeObject(request);
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                return await client.PutAsync(serviceUrl, new StringContent(bodyRequest, System.Text.Encoding.UTF8, "application/json"));
            }
        }
        public async Task<HttpResponseMessage> GetAsync(string serviceUrl, Dictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                return await client.GetAsync(new Uri(serviceUrl));
            }
        }
        public async Task<HttpResponseMessage> DeleteAsync<TRequest>(string serviceUrl, TRequest request, Dictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            {
                var bodyRequest = JsonConvert.SerializeObject(request);

                HttpRequestMessage body = new HttpRequestMessage(HttpMethod.Delete, serviceUrl);
                body.Content = new StringContent(bodyRequest, System.Text.Encoding.UTF8, "application/json");

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                return await client.SendAsync(body);
            }
        }
    }
}
