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
public class UiPais
{
    public static void MenuPais()
    {
    IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
     var ServicioPais = new PaisService(factory.CreateCountryRepository());

        Console.Clear();
        Console.WriteLine("\n--- MENÚ PAÍS ---");
        Console.WriteLine("\n1. Monstrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.Write("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    ServicioPais.ObtenerPais();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Por favor, ingrese el nombre del país: ");
                    string NombrePais = Console.ReadLine();
                    Pais pais = new Pais(NombrePais, 0);
                    ServicioPais.CrearPais(pais);
                    Console.WriteLine("El país ha sido creado con éxito. Presione enter para volver al menú de país");
                    Console.ReadKey(true);
                    MenuPais();
                    break;
                case '3':
                    Console.Clear();
                    ServicioPais.ObtenerPais();
                    Console.WriteLine("Por favor, ingrese el id del país que quiere editar: ");
                    int PaisId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Por favor, ingrese el nuevo nombre para el país: ");
                    string NuevoNombrePais =  Console.ReadLine();
                    Pais paisEditado = new Pais(NuevoNombrePais, PaisId);
                    ServicioPais.EditarPais(paisEditado);
                    Console.WriteLine("El país ha sido editado con éxito. Por favor, presione enter para volver al menú de país:");
                    Console.ReadKey(true);
                    MenuPais();
                    break;
                case '4':
                    Console.Clear();
                    ServicioPais.ObtenerPais();
                    Console.WriteLine("Por favor, ingrese el id del país que quiere eliminar: ");
                    int PaisIdEliminar = int.Parse(Console.ReadLine());
                    ServicioPais.EliminarPais(PaisIdEliminar);
                    Console.WriteLine("El país ha sido eliminado con éxito");
                    Console.ReadKey(true);
                    MenuPais();
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