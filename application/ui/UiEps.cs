using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.services;
using sgi_app.domain.entities;

namespace sgi_app.application.ui;
public class UiEps
{
    public static void MenuEps()
    {
        string connectionDatabase = "server=localhost;database=miniproject;user=root;password=123456;";
        IDbFactory factory = new PostgresDbFactory(connectionDatabase);
        var servicioEps = new EpsService(factory.CreateEpsRepository());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ EPS ---");
            Console.WriteLine("\n1. Mostrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (keyPressed.KeyChar)
            {
                case '1':
                    Console.Clear();
                    servicioEps.MostrarTodos();
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '2':
                    Console.Clear();
                    Console.Write("Nombre de la nueva EPS: ");
                    string nombre = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("❌ El nombre no puede estar vacío.");
                    }
                    else
                    {
                        var nuevaEps = new Eps { Nombre = nombre };
                        servicioEps.CrearEps(nuevaEps);
                        Console.WriteLine("✅ EPS creada exitosamente.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '3':
                    Console.Clear();
                    Console.Write("ID de la EPS a actualizar: ");
                    if (int.TryParse(Console.ReadLine(), out int idActualizar))
                    {
                        Console.Write("Nuevo nombre: ");
                        string nuevoNombre = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            Console.WriteLine("❌ El nombre no puede estar vacío.");
                        }
                        else
                        {
                            servicioEps.ActualizarEps(idActualizar, nuevoNombre);
                            Console.WriteLine("✅ EPS actualizada exitosamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '4':
                    Console.Clear();
                    Console.Write("ID de la EPS a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        servicioEps.EliminarEps(idEliminar);
                        Console.WriteLine("✅ EPS eliminada exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '0':
                    UiEmpresas.MenuEmpresas(); // Revisa si aquí quieres redirigir a otro menú diferente
                    return;

                default:
                    Console.WriteLine("❌ Opción no reconocida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

