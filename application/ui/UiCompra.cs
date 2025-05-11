using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.services;
using sgi_app.domain.entities;

namespace sgi_app.application.ui;

public class UiCompra
{
    public static void MenuCompra()
    {
        string connectionDatabase = "server=localhost;database=miniproject;user=root;password=123456;";
        IDbFactory factory = new PostgresDbFactory(connectionDatabase);
        var servicioCompra = new CompraService(factory.CreateCompraRepository());

        var servicioEmpleado = new EmpleadoService(factory.CreateEmpleadoRepository());
        var servicioProveedor = new ProveedorService(factory.CreateProveedorRepository());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ COMPRA ---");
            Console.WriteLine("\n1. Mostrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (KeyPressed.KeyChar)
            {
                case '1':
                    servicioCompra.MostrarTodos();
                    break;

                case '2':
                    Compra compra = new Compra();

                    Console.WriteLine("Proveedores:");
                    servicioProveedor.ObtenerProveedor();

                    Console.Write("\nIngrese id del proveedor: ");
                    if (!int.TryParse(Console.ReadLine(), out int idProveedor))
                    {
                        Console.WriteLine("ID del proveedor inválido.");
                        break;
                    }
                    compra.IdTerceroProveedor = idProveedor;

                    Console.WriteLine("\nEmpleados:");
                    servicioEmpleado.ObtenerEmpleado();

                    Console.Write("\nIngrese id del empleado: ");
                    if (!int.TryParse(Console.ReadLine(), out int idEmpleado))
                    {
                        Console.WriteLine("ID del empleado inválido.");
                        break;
                    }
                    compra.IdTerceroEmpleado = idEmpleado;

                    compra.Fecha = DateTime.Now;

                    Console.Write("\nIngrese documento de la compra: ");
                    compra.DocumentoCompra = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(compra.DocumentoCompra))
                    {
                        Console.WriteLine("El documento no puede estar vacío.");
                        break;
                    }

                    servicioCompra.CrearCompra(compra);
                    Console.WriteLine("Compra creada con éxito.");
                    break;

                case '3':
                    Console.Write("Id de la compra a actualizar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idActualizar))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    Console.Write("Nuevo documento: ");
                    string nuevoDocumento = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nuevoDocumento))
                    {
                        Console.WriteLine("El documento no puede estar vacío.");
                        break;
                    }

                    servicioCompra.ActualizarCompra(idActualizar, nuevoDocumento);
                    Console.WriteLine("Compra actualizada.");
                    break;

                case '4':
                    Console.Write("ID a eliminar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    servicioCompra.EliminarCompra(idEliminar);
                    Console.WriteLine("Compra eliminada.");
                    break;

                case '0':
                    UiVentaCompra.MenuVentaCompra();
                    return;

                default:
                    Console.WriteLine("Opción no reconocida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
