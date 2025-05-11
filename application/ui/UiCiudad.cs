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
    public static void MenuCiudad()
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var servicioCiudad = new CiudadService(factory.CreateCiudadRepository());
        var servicioRegion = new RegionService(factory.CreateRegionRepository());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ CIUDADES ---");
            Console.WriteLine("\n1. Mostrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (keyPressed.KeyChar)
            {
                case '1':
                    Console.Clear();
                    servicioCiudad.ObtenerCiudad();
                    Console.WriteLine("Presione cualquier tecla para volver al menú...");
                    Console.ReadKey(true);
                    break;

                case '2':
                    Console.Clear();
                    servicioRegion.ObtenerRegion();
                    Console.Write("Ingrese el ID de la región donde desea agregar la ciudad: ");
                    if (!int.TryParse(Console.ReadLine(), out int idRegion))
                    {
                        Console.WriteLine("❌ ID no válido.");
                    }
                    else
                    {
                        Console.Write("Ingrese el nombre de la ciudad a agregar: ");
                        string nombreCiudad = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nombreCiudad))
                        {
                            Console.WriteLine("❌ El nombre de la ciudad no puede estar vacío.");
                        }
                        else
                        {
                            Ciudad ciudad = new Ciudad(0, nombreCiudad, idRegion);
                            servicioCiudad.CrearCiudad(ciudad);
                            Console.WriteLine("✅ Ciudad creada con éxito.");
                        }
                    }
                    Console.WriteLine("Presione cualquier tecla para volver al menú...");
                    Console.ReadKey(true);
                    break;

                case '3':
                    Console.Clear();
                    servicioCiudad.ObtenerCiudad();
                    Console.Write("Ingrese el ID de la ciudad que desea modificar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idCiudadEditar))
                    {
                        Console.WriteLine("❌ ID no válido.");
                    }
                    else
                    {
                        Console.Write("Ingrese el nuevo nombre para la ciudad: ");
                        string nuevoNombre = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            Console.WriteLine("❌ El nombre no puede estar vacío.");
                        }
                        else
                        {
                            Ciudad ciudadEditada = new Ciudad(idCiudadEditar, nuevoNombre, 0);
                            servicioCiudad.EditarCiudad(ciudadEditada);
                            Console.WriteLine("✅ Ciudad modificada con éxito.");
                        }
                    }
                    Console.WriteLine("Presione cualquier tecla para volver al menú...");
                    Console.ReadKey(true);
                    break;

                case '4':
                    Console.Clear();
                    servicioCiudad.ObtenerCiudad();
                    Console.Write("Ingrese el ID de la ciudad que desea eliminar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idCiudadEliminar))
                    {
                        Console.WriteLine("❌ ID no válido.");
                    }
                    else
                    {
                        servicioCiudad.EliminarCiudad(idCiudadEliminar);
                        Console.WriteLine("✅ Ciudad eliminada con éxito.");
                    }
                    Console.WriteLine("Presione cualquier tecla para volver al menú...");
                    Console.ReadKey(true);
                    break;

                case '0':
                    UiLugares.MenuLugares();
                    return;

                default:
                    Console.WriteLine("❌ Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
