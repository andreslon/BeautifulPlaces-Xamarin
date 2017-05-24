using BeautifulPlaces.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulPlaces.App.Interfaces
{
    public interface IApiService
    {
        Task<BaseResponse<List<PlaceDto>>> GetPlaces();
        Task<BaseResponse<List<PictureDto>>> GetPictures();
        Task<BaseResponse<PlaceDto>> UpdatePlace(PlaceDto placeDto);
    }
}
