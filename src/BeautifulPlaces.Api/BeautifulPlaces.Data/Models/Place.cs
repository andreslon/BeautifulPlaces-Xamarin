using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulPlaces.Data.Models
{
    public class Place
    {
        public Place()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public string Location { get; set; }
        public string Thumbnail { get; set; } 
    }
}
