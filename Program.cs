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
        var ServicioCiudad = new CiudadService(factory.CreateCiudadRepository());
        var ServicioEmpresa = new EmpresaService(factory.CreateEmpresaRepository());
        var ServicioTercero = new TerceroService(factory.CreateTerceroRepository());

       Tercero nuevoTercero = new Tercero("123456789", "Juan", "Caballero", "juan.perez@mail.com", 1, 1, 1);

        ServicioTercero.EditarTercero(nuevoTercero);


     


        
    }
}