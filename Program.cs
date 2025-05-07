using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;

internal class Program
{
    private static void Main(string[] args)
    {
        
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var ServicioPais = new PaisService(factory.CreateCountryRepository());
        var ServicioArl = new ArlService(factory.CreateArlRepository());
        var ServicioRegion = new RegionService(factory.CreateRegionRepository());

        Region region = new Region(1, "Amazonas", 2);

        ServicioRegion.EliminarRegion(1);
        


        
    }
}