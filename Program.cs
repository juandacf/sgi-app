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

        Console.Clear();
        Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
        Console.Write("\n1. Lugares\t2. Empresas\t3. Tercero\n4. Documento\t5. Venta\t6. Producto");
        Console.WriteLine("\n7. Compra\t8. Plan\t\t0. Salir");
        Console.Write("\nOpción: ");
        while(true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch(KeyPressed.KeyChar)
            {
                case '1':
                    UiLugares.MenuLugares();
                    break;
                case '2':
                    UiEmpresas.MenuEmpresas();
                    break;
                case '3':
                    UiTerceros.MenuTerceros();
                    break;
                case '4':
                    break;
                case '5':
                    break;
                case '6':
                    break;
                case '7':
                    break;
                case '8':
                    break;
                case '0':
                    break;
                default:
                    Console.WriteLine($"Tecla no reconocida {KeyPressed.KeyChar}");
                    break;
            }
        }
        

        
    }
}