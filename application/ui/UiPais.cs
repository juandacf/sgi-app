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
        var servicioPais = new PaisService(factory.CreateCountryRepository());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ PAÍS ---");
            Console.WriteLine("1. Mostrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (keyPressed.KeyChar)
            {
                case '1':
                    Console.Clear();
                    servicioPais.ObtenerPais();
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '2':
                    Console.Clear();
                    Console.WriteLine("Por favor, ingrese el nombre del país:");
                    string nombrePais = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombrePais))
                    {
                        Console.WriteLine("❌ Nombre inválido.");
                    }
                    else
                    {
                        var nuevoPais = new Pais(nombrePais, 0);
                        servicioPais.CrearPais(nuevoPais);
                        Console.WriteLine("✅ El país ha sido creado con éxito.");
                    }
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '3':
                    Console.Clear();
                    servicioPais.ObtenerPais();
                    Console.Write("\nIngrese el ID del país a editar: ");
                    if (int.TryParse(Console.ReadLine(), out int paisId))
                    {
                        Console.Write("Ingrese el nuevo nombre del país: ");
                        string nuevoNombre = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            Console.WriteLine("❌ El nombre no puede estar vacío.");
                        }
                        else
                        {
                            var paisEditado = new Pais(nuevoNombre, paisId);
                            servicioPais.EditarPais(paisEditado);
                            Console.WriteLine("✅ El país ha sido editado con éxito.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '4':
                    Console.Clear();
                    servicioPais.ObtenerPais();
                    Console.Write("\nIngrese el ID del país a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        servicioPais.EliminarPais(idEliminar);
                        Console.WriteLine("✅ El país ha sido eliminado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '0':
                    UiLugares.MenuLugares();
                    return;

                default:
                    Console.WriteLine("❌ Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
