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
        var ServicioTercero = new TerceroService(factory.CreateTerceroRepository());
        var ServicioArl = new ArlService(factory.CreateArlRepository());
        var ServicioCliente = new ClienteService(factory.CreateClienteRepository());
        var ServicioProveedor = new ProveedorService(factory.CreateProveedorRepository());
        
        Proveedor proveedor = new Proveedor(
    IdProveedor: 1,
    Id: "123",
    Nombre: "María",
    Apellido: "Gómez",
    Email: "maria.gomez@proveedores.com",
    Id_Tipo_Documento: 2,
    Id_Tipo_Tercero: 3,
    Descuento: 15.5,
    DiaPago: 7,
    Id_ciudad: 11001
);

    ServicioProveedor.EliminarProveedor(5);
        

        UiMainMenu.MainMenu();
    }
}