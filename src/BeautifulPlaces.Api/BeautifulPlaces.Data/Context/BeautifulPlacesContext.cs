using BeautifulPlaces.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace BeautifulPlaces.Data.Context
{
    public class BeautifulPlacesContext : DbContext
    {
        public BeautifulPlacesContext() : base("BeautifulPlacesContext")
        {
        }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
