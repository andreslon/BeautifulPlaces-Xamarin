using BeautifulPlaces.App.Dtos;
using BeautifulPlaces.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulPlaces.App.Services
{
    public class ApiService : IApiService
    {
        public string hostApi { get; set; } = "http://beautifulplacesapi.azurewebsites.net/";

        public IHttpClientService HttpClientService { get; set; }
        public IJsonService JsonService { get; set; }
        public ApiService(IHttpClientService httpClientService, IJsonService jsonService)
        {
            JsonService = jsonService;
            HttpClientService = httpClientService;
        } 
        public async Task<BaseResponse<List<PlaceDto>>> GetPlaces()
        {  
            try
            {
                HttpResponseMessage result = await HttpClientService.GetAsync($"{hostApi}api/Places");
                if (result.IsSuccessStatusCode)
                {

                    var serializedResponse = await JsonService.GetSerializedResponse<List<PlaceDto>>(result);
                    var response = new BaseResponse<List<PlaceDto>>() { Response = serializedResponse };
                    response.HttpResponse = result;
                    return response;
                }
                else
                {
                    return new BaseResponse<List<PlaceDto>>() { HttpResponse = result };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<PlaceDto>>() { HttpResponse = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest } };
            }
        }
        public async Task<BaseResponse<List<PictureDto>>> GetPictures()
        {
            try
            {
                HttpResponseMessage result = await HttpClientService.GetAsync($"{hostApi}api/Pictures");
                if (result.IsSuccessStatusCode)
                {

                    var serializedResponse = await JsonService.GetSerializedResponse<List<PictureDto>>(result);
                    var response = new BaseResponse<List<PictureDto>>() { Response = serializedResponse };
                    response.HttpResponse = result;
                    return response;
                }
                else
                {
                    return new BaseResponse<List<PictureDto>>() { HttpResponse = result };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<PictureDto>>() { HttpResponse = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest } };
            }
        }
    }
}
