using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulPlaces.Data.Models
{ 
    public class Picture
    {
        public Picture()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Uri { get; set; }
        [Required]
        public Guid PlaceId { get; set; }
    }
}
