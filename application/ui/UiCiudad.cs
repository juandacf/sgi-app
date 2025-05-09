using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using Npgsql;
using sgi_app.application.services;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.domain.entities;
using sgi_app.application.ui;

namespace sgi_app.application.ui;

    public class UiCiudad
    {
        public static void MenuCiudad(){
            
            IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
            var servicioCiudad = new CiudadService(factory.CreateCiudadRepository());
            var ServicioRegion = new RegionService(factory.CreateRegionRepository());

            Console.Clear();
            Console.WriteLine("\n--- MENÚ CIUDADES ---");
            Console.WriteLine("\n1. Monstrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            while(true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey();
                switch(KeyPressed.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        servicioCiudad.ObtenerCiudad();
                        Console.WriteLine("Oprima 0 para volver al menú principal: ");
                        
                        break;
                    case '2':
                        Console.Clear();
                        ServicioRegion.ObtenerRegion();
                        Console.WriteLine("Por favor, ingrese el nombre de la región a la que quiere agregarle la ciudad: ");
                        int IdRegion = int.Parse(Console.ReadLine());
                        Console.WriteLine("Por favor, escoja el nombre de la ciudad a  agregar: ");
                        string NombreCiudad = Console.ReadLine();
                        Ciudad ciudad = new Ciudad(0,NombreCiudad,IdRegion);
                        servicioCiudad.CrearCiudad(ciudad);
                        Console.WriteLine("La ciudad ha sido creada con éxito. Por favor, oprima enter para volver al menú principal");
                        Console.ReadKey(true);
                        MenuCiudad();
                        break;
                    case '3':
                    Console.Clear();
                    servicioCiudad.ObtenerCiudad();
                    Console.WriteLine("Por favor, ingrese el id de la ciudad que quiere modificar: ");
                    int IdEscogido = int.Parse(Console.ReadLine());
                    Console.WriteLine("Por favor, escoja el nuevo nombre para la ciudad: ");
                    string NuevoNombre = Console.ReadLine();
                    Ciudad ciudadEditada =  new Ciudad(IdEscogido, NuevoNombre, 0);
                    servicioCiudad.EditarCiudad(ciudadEditada);
                    Console.WriteLine("La ciudad ha sido editada con éxito. Presione enter para volver al menú principal");
                    Console.ReadKey(true);
                    MenuCiudad();
                        break;
                    case '4':
                    Console.Clear();
                    servicioCiudad.ObtenerCiudad();
                    Console.WriteLine("Por favor, ingrese el id de la ciudad que quiere eliminar: ");
                    int IdCiudadEliminar = int.Parse(Console.ReadLine());
                    servicioCiudad.EliminarCiudad(IdCiudadEliminar);
                    Console.WriteLine("La ciudad ha sido eliminada con éxito. Presione enter para volver al menú");
                    Console.ReadKey(true);
                    MenuCiudad();
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