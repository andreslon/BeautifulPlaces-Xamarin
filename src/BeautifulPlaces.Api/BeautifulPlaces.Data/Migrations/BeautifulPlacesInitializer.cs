using BeautifulPlaces.Data.Context;
using BeautifulPlaces.Data.Models;
using System.Collections.Generic;
namespace BeautifulPlaces.Data.Migrations
{
    public class BeautifulPlacesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BeautifulPlacesContext>
    {

        protected override void Seed(BeautifulPlacesContext context)
        { 
            var places = new List<Place>
            {
                new Place { Name="Medellin", Description="Hermosa ciudad", Location="Cra 57c#41" ,  Thumbnail="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" },
            };

            places.ForEach(s => context.Places.Add(s));
            context.SaveChanges();


            var pictures = new List<Picture>
            {
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , Place=places[0] },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , Place=places[0] },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , Place=places[0] },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , Place=places[0] },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , Place=places[0] },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , Place=places[0] },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , Place=places[0] },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , Place=places[0] },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , Place=places[0] },
            };

            pictures.ForEach(s => context.Pictures.Add(s));
            context.SaveChanges();
        }
    }
}
