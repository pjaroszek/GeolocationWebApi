using GeolocationWebApi.Models;
using System.Data.Entity.Migrations;

namespace Jaroszek.ProofOfConcept.GeolocationWebApi.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GeoLocalizationContexr>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(global::GeolocationWebApi.Models.GeoLocalizationContexr context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
