using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.services;
using sgi_app.domain.entities;

namespace sgi_app.application.ui;

public class UiDetalleVenta
{
    public static void MenuDetalleVenta()
    {
        string connectionDatabase = "server=localhost;database=miniproject;user=root;password=123456;";
        IDbFactory factory = new PostgresDbFactory(connectionDatabase);
        var detalleVentaService = new DetalleVentaService(factory.CreateDetalleVentaRepository());

        var ventaServicio = new VentaService(factory.CreateVentaRepository());
        var servicioProducto = new ProductoService(factory.CreateProductoRepository());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ DETALLE VENTA ---");
            Console.WriteLine("\n1. Mostrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (KeyPressed.KeyChar)
            {
                case '1':
                    detalleVentaService.MostrarTodos();
                    break;

                case '2':
                    DetalleVenta detalleVenta = new DetalleVenta();

                    Console.WriteLine("\nFacturas: ");
                    ventaServicio.MostrarTodos();

                    Console.Write("\nIngrese id de la factura: ");
                    if (!int.TryParse(Console.ReadLine(), out int idFactura))
                    {
                        Console.WriteLine("ID de factura inválido.");
                        break;
                    }
                    detalleVenta.IdFacturacion = idFactura;

                    Console.WriteLine("\nProductos: ");
                    servicioProducto.MostrarTodos();

                    Console.Write("\nIngrese Id del producto: ");
                    detalleVenta.IdProducto = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(detalleVenta.IdProducto))
                    {
                        Console.WriteLine("Id del producto no puede estar vacío.");
                        break;
                    }

                    Console.Write("Cantidad de producto: ");
                    if (!int.TryParse(Console.ReadLine(), out int cantidad))
                    {
                        Console.WriteLine("Cantidad inválida.");
                        break;
                    }
                    detalleVenta.Cantidad = cantidad;

                    detalleVenta.Valor = 0;

                    detalleVentaService.CrearDetalleVenta(detalleVenta);
                    Console.WriteLine("Detalle de venta creado con éxito.");
                    break;

                case '3':
                    Console.WriteLine("\nDetalles de venta: ");
                    detalleVentaService.MostrarTodos();

                    Console.Write("Id a actualizar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idActualizar))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    Console.Write("Ingrese nueva cantidad: ");
                    if (!int.TryParse(Console.ReadLine(), out int nuevaCantidad))
                    {
                        Console.WriteLine("Cantidad inválida.");
                        break;
                    }

                    detalleVentaService.ActualizarDetalleVenta(idActualizar, nuevaCantidad);
                    Console.WriteLine("Detalle de venta actualizado.");
                    break;

                case '4':
                    Console.Write("ID a eliminar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    detalleVentaService.EliminarDetalleVenta(idEliminar);
                    Console.WriteLine("Detalle de venta eliminado.");
                    break;

                case '0':
                    UiVentaCompra.MenuVentaCompra();
                    return;

                default:
                    Console.WriteLine("Tecla no reconocida.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
