using System.Data.Entity;

namespace GeolocationWebApi.Models
{
    public class GeoLocalizationContexr : DbContext
    {
        private static string connectionString = @"Data Source=PAWEL-PC\SQL2017;Initial Catalog=Test;Integrated Security=True";


        public GeoLocalizationContexr() : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer<GeoLocalizationContexr>(new CreateDatabaseIfNotExists<GeoLocalizationContexr>());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GeoLocalization> GeoLocalizations { get; set; }
    }
}