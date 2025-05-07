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

        Pais pais = new Pais(Id:1, Nombre:"Mexico");
        
        ServicioPais.EditarPais(pais);

        ServicioPais.ObtenerPais();

        
    }
}