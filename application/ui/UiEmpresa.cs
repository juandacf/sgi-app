using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.application.ui;
public class UiEmpresa
{
    public static void MenuEmpresa()
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var servicioEmpresa = new EmpresaService(factory.CreateEmpresaRepository());
        var servicioCiudad = new CiudadService(factory.CreateCiudadRepository());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ EMPRESA ---");
            Console.WriteLine("\n1. Mostrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (keyPressed.KeyChar)
            {
                case '1':
                    Console.Clear();
                    servicioEmpresa.ObtenerEmpresa();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey(true);
                    break;

                case '2':
                    Console.Clear();
                    Console.Write("Ingrese el nombre de la empresa: ");
                    string nombreEmpresa = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombreEmpresa))
                    {
                        Console.WriteLine("❌ El nombre de la empresa no puede estar vacío.");
                    }
                    else
                    {
                        servicioCiudad.ObtenerCiudad();
                        Console.Write("Ingrese el ID de la ciudad: ");
                        if (int.TryParse(Console.ReadLine(), out int idCiudad))
                        {
                            Empresa nuevaEmpresa = new Empresa(0, nombreEmpresa, idCiudad, DateTime.Now);
                            servicioEmpresa.CrearEmpresa(nuevaEmpresa);
                            Console.WriteLine("✅ La empresa ha sido añadida con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("❌ ID de ciudad inválido.");
                        }
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey(true);
                    break;

                case '3':
                    Console.Clear();
                    servicioEmpresa.ObtenerEmpresa();
                    Console.Write("Ingrese el ID de la empresa que desea actualizar: ");
                    if (int.TryParse(Console.ReadLine(), out int idActualizar))
                    {
                        Console.Write("Ingrese el nuevo nombre de la empresa: ");
                        string nuevoNombre = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            Console.WriteLine("❌ El nombre no puede estar vacío.");
                        }
                        else
                        {
                            Empresa empresaActualizada = new Empresa(idActualizar, nuevoNombre, 1, DateTime.Now);
                            servicioEmpresa.EditarEmpresa(empresaActualizada);
                            Console.WriteLine("✅ La empresa fue actualizada con éxito.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey(true);
                    break;

                case '4':
                    Console.Clear();
                    servicioEmpresa.ObtenerEmpresa();
                    Console.Write("Ingrese el ID de la empresa que desea eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        servicioEmpresa.EliminarEmpresa(idEliminar);
                        Console.WriteLine("✅ Empresa eliminada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey(true);
                    break;

                case '0':
                    UiEmpresas.MenuEmpresas();
                    return;

                default:
                    Console.WriteLine("❌ Opción no válida. Intente nuevamente.");
                    Console.ReadKey(true);
                    break;
            }
        }
    }
}
