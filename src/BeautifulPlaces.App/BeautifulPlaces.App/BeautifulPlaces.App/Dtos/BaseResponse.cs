using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulPlaces.App.Dtos
{
    public class BaseResponse<T>
    {
        [JsonIgnore()]
        public HttpResponseMessage HttpResponse { get; set; }
        public T Response { get; set; }
    }
}
