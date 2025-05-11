using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.ui;
public class UiArl
{
    public static void MenuArl()
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var ServicioArl = new ArlService(factory.CreateArlRepository());
        Console.Clear();
        Console.WriteLine("\n--- MENÚ ARL ---");
        Console.WriteLine("\n1. Mostrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.Write("Opción: ");

        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            Console.WriteLine();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    Console.Clear();
                    ServicioArl.ObtenerArl();
                    break;

                case '2':
                    Console.Clear();
                    Console.Write("Por favor, ingrese el nombre de la ARL: ");
                    string nombreArl = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombreArl))
                    {
                        Console.WriteLine("❌ El nombre de la ARL no puede estar vacío.");
                    }
                    else
                    {
                        Arl nuevaArl = new Arl(nombreArl, 0);
                        ServicioArl.CrearArl(nuevaArl);
                        Console.WriteLine("✅ La ARL ha sido creada con éxito.");
                    }
                    Console.WriteLine("Presione Enter para volver al menú.");
                    Console.ReadKey();
                    MenuArl();
                    break;

                case '3':
                    Console.Clear();
                    ServicioArl.ObtenerArl();
                    Console.Write("Ingrese el ID de la ARL que desea editar: ");
                    if (!int.TryParse(Console.ReadLine(), out int arlIdEditar))
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }
                    else
                    {
                        Console.Write("Ingrese el nuevo nombre de la ARL: ");
                        string nuevoNombre = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            Console.WriteLine("❌ El nombre no puede estar vacío.");
                        }
                        else
                        {
                            Arl arlEditada = new Arl(nuevoNombre, arlIdEditar);
                            ServicioArl.EditarArl(arlEditada);
                            Console.WriteLine("✅ La ARL ha sido editada con éxito.");
                        }
                    }
                    Console.WriteLine("Presione Enter para volver al menú.");
                    Console.ReadKey();
                    MenuArl();
                    break;

                case '4':
                    Console.Clear();
                    ServicioArl.ObtenerArl();
                    Console.Write("Ingrese el ID de la ARL que desea eliminar: ");
                    if (!int.TryParse(Console.ReadLine(), out int arlIdEliminar))
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }
                    else
                    {
                        ServicioArl.EliminarArl(arlIdEliminar);
                        Console.WriteLine("✅ La ARL ha sido eliminada con éxito.");
                    }
                    Console.WriteLine("Presione Enter para volver al menú.");
                    Console.ReadKey();
                    MenuArl();
                    break;

                case '0':
                    UiEmpresas.MenuEmpresas();
                    break;

                default:
                    Console.WriteLine("❌ Opción no válida.");
                    break;
            }
        }
    }
}
