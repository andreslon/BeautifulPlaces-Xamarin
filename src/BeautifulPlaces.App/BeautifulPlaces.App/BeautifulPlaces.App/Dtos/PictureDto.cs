using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulPlaces.App.Dtos
{
    public class PictureDto
    {
        public string Id { get; set; }
        public string Uri { get; set; }
        public PlaceDto Place { get; set; }
    }
}
