using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.ui;
internal class Program
{
    private static void Main(string[] args)
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var ServicioPais = new PaisService(factory.CreateCountryRepository());
        var ServicioRegion = new RegionService(factory.CreateRegionRepository());
        var ServicioCiudad = new CiudadService(factory.CreateCiudadRepository());
        var ServicioEmpresa = new EmpresaService(factory.CreateEmpresaRepository());
        var  ServicioTercero = new TerceroService(factory.CreateTerceroRepository());
        var ServicioEmpleado = new EmpleadoService(factory.CreateEmpleadoRepository());

        Empleado empleado1 = new Empleado(
            "123",                // Id
            "Juan",                  // Nombre
            "Caballero",                 // Apellido
            "juan.perez@email.com",  // Email
            1,                       // Id_Tipo_Documento
            1,                       // Id_Tipo_Tercero
            new DateTime(2023, 5, 1),// FechaIngreso
            4500000.00,              // SalarioBase
            2,                       // Id_Eps
            1,                       // IdArl
            101                     // Id_ciudad
        );

        ServicioEmpleado.EditarEmpleado(empleado1);


        // UiMainMenu.MainMenu();
    }
}