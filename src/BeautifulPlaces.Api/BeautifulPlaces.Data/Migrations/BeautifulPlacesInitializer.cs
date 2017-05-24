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
                new Place {
                    Name ="Medellin"
                    , Description="Medellín es un municipio colombiano, capital del departamento de Antioquia. Es la ciudad más poblada del departamento y la segunda del país."
                    , Location="6°14′41″N 75°34′29″O" 
                    ,  Thumbnail="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" },
            }; 
            places.ForEach(s => context.Places.Add(s));
            context.SaveChanges(); 
            var pictures = new List<Picture>
            {
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , PlaceId=places[0].Id },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , PlaceId=places[0].Id },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , PlaceId=places[0].Id },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , PlaceId=places[0].Id },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , PlaceId=places[0].Id },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , PlaceId=places[0].Id },
                new Picture { Uri="http://elcampesino.co/wp-content/uploads/2016/03/4-1.jpg" , PlaceId=places[0].Id },
            }; 
            pictures.ForEach(s => context.Pictures.Add(s));
            context.SaveChanges();
        }
    }
}
