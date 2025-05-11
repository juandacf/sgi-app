using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.services;
using sgi_app.domain.entities;

namespace sgi_app.application.ui;

public class UiDetalleCompra
{
    public static void MenuDetalleCompra()
    {
        string connectionDatabase = "server=localhost;database=miniproject;user=root;password=123456;";
        IDbFactory factory = new PostgresDbFactory(connectionDatabase);
        var detalleCompraService = new DetalleCompraService(factory.CreateDetalleCompraRepository());
        var compraService = new CompraService(factory.CreateCompraRepository());
        var servicioProducto = new ProductoService(factory.CreateProductoRepository());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ DETALLE COMPRA ---");
            Console.WriteLine("\n1. Mostrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (KeyPressed.KeyChar)
            {
                case '1':
                    detalleCompraService.MostrarTodos();
                    break;

                case '2':
                    DetalleCompra detalleCompra = new DetalleCompra
                    {
                        Fecha = DateTime.Now
                    };

                    Console.WriteLine("\nProductos: ");
                    servicioProducto.MostrarTodos();

                    Console.Write("\nIngrese Id del producto: ");
                    detalleCompra.IdProducto = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(detalleCompra.IdProducto))
                    {
                        Console.WriteLine("Id de producto no puede estar vacío.");
                        break;
                    }

                    Console.WriteLine("\nCompra: ");
                    compraService.MostrarTodos();

                    Console.Write("\nIngrese id de la compra: ");
                    if (!int.TryParse(Console.ReadLine(), out int idCompra))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }
                    detalleCompra.IdCompra = idCompra;

                    Console.Write("Cantidad de producto: ");
                    if (!int.TryParse(Console.ReadLine(), out int cantidad))
                    {
                        Console.WriteLine("Cantidad inválida.");
                        break;
                    }
                    detalleCompra.Cantidad = cantidad;

                    // Aquí podrías calcular el valor si lo deseas
                    detalleCompra.Valor = 0;

                    detalleCompraService.CrearDetalleCompra(detalleCompra);
                    Console.WriteLine("Detalle de compra creado con éxito.");
                    break;

                case '3':
                    Console.WriteLine("\nDetalles de venta: ");
                    detalleCompraService.MostrarTodos();

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

                    detalleCompraService.ActualizarDetalleCompra(idActualizar, nuevaCantidad);
                    Console.WriteLine("Detalle de compra actualizado.");
                    break;

                case '4':
                    Console.Write("ID a eliminar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }
                    detalleCompraService.EliminarDetalleCompra(idEliminar);
                    Console.WriteLine("Detalle de compra eliminado.");
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
