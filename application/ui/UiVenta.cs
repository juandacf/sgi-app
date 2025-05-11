using System;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.services;
using sgi_app.domain.entities;

namespace sgi_app.application.ui;

public class UiVenta
{
    public static void MenuVenta()
    {
        string connectionDatabase = "server=localhost;database=miniproject;user=root;password=123456;";
        IDbFactory factory = new PostgresDbFactory(connectionDatabase);
        var servicioVenta = new VentaService(factory.CreateVentaRepository());
        var servicioEmpleado = new EmpleadoService(factory.CreateEmpleadoRepository());
        var servicioCliente = new ClienteService(factory.CreateClienteRepository());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ VENTA ---");
            Console.WriteLine("1. Mostrar todas\t2. Crear nueva");
            Console.WriteLine("3. Actualizar\t\t4. Eliminar");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");

            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (KeyPressed.KeyChar)
            {
                case '1':
                    servicioVenta.MostrarTodos();
                    break;

                case '2':
                    Venta venta = new Venta
                    {
                        Fecha = DateTime.Now
                    };
                    Console.WriteLine($"Fecha de venta: {venta.Fecha}");

                    Console.WriteLine("\nEmpleados:");
                    servicioEmpleado.ObtenerEmpleado();

                    Console.Write("Ingrese id del empleado: ");
                    if (!int.TryParse(Console.ReadLine(), out int idEmpleado))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }
                    venta.IDTerceroEmpleado = idEmpleado;

                    Console.WriteLine("\nClientes:");
                    servicioCliente.ObtenerCliente();

                    Console.Write("Ingrese id del cliente: ");
                    if (!int.TryParse(Console.ReadLine(), out int idCliente))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }
                    venta.IdTerceroCliente = idCliente;

                    servicioVenta.CrearVenta(venta);
                    Console.WriteLine("Venta creada exitosamente.");
                    break;

                case '3':
                    Console.Write("Id de la venta a actualizar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idActualizar))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    Console.Write("Nuevo id del empleado: ");
                    if (!int.TryParse(Console.ReadLine(), out int nuevoEmpleado))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    Console.Write("Nuevo id del cliente: ");
                    if (!int.TryParse(Console.ReadLine(), out int nuevoCliente))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    servicioVenta.ActualizarVenta(idActualizar, nuevoEmpleado, nuevoCliente);
                    Console.WriteLine("Venta actualizada.");
                    break;

                case '4':
                    Console.Write("ID de la venta a eliminar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    servicioVenta.EliminarVenta(idEliminar);
                    Console.WriteLine("Venta eliminada.");
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
