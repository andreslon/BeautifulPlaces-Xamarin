using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulPlaces.App.Dtos
{ 
    public class PlaceDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public string Location { get; set; }
        public string Thumbnail { get; set; }
    }
}
