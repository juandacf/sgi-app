using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.ui;

namespace sgi_app.application.ui;
public class UiRegion
{
    public static void MenuRegion()
    {
    IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
     var ServicioRegion = new RegionService(factory.CreateRegionRepository());
     var ServicioPais = new PaisService(factory.CreateCountryRepository());
        Console.Clear();
        Console.WriteLine("\n--- MENÚ REGIÓN ---");
        Console.WriteLine("\n1. Monstrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.Write("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                ServicioRegion.ObtenerRegion();
                    break;
                case '2':
                Console.Clear();
                ServicioPais.ObtenerPais();
                Console.WriteLine("Por favor, ingrese el id del país al que quiere anexar la región: ");
                int IdPais = int.Parse(Console.ReadLine());
                Console.WriteLine("Por favor, ingrese el nombre de la region");
                string NombreRegion = Console.ReadLine();
                Region region = new Region(0, NombreRegion,1);
                ServicioRegion.CrearRegion(region);
                Console.WriteLine("La región ha sido creada con éxito. por favor, presione enter para volver al menú");
                Console.ReadKey(true);
                MenuRegion();
                    break;
                case '3':
                Console.Clear();
                ServicioRegion.ObtenerRegion();
                Console.WriteLine("Por favor, Ingrese el id de la región: ");
                int IdRegion = int.Parse(Console.ReadLine());
                Console.WriteLine("Por favor, ingrese el nuevo nombre de la región: ");
                string NombreRegionEditable =  Console.ReadLine();
                Region regionEditada = new Region(IdRegion, NombreRegionEditable, 0 );
                ServicioRegion.EditarRegion(regionEditada);
                Console.WriteLine("La región fue editada con éxito. Por favor, oprima enter para volver al menú.");
                Console.ReadKey();
                MenuRegion();
                    break;
                case '4':
                ServicioRegion.ObtenerRegion();
                Console.WriteLine("Por favor, ingrese le id de la región que desea eliminar: ");
                int RegionAEliminar = int.Parse(Console.ReadLine());
                ServicioRegion.EliminarRegion(RegionAEliminar);
                Console.WriteLine("La región fue eliminnada con éxito");
                    break;
                case '0':
                    UiLugares.MenuLugares();
                    break;
                default:
                    Console.WriteLine("Tecla no reconocida");
                    break;
            }
        }
    }
}