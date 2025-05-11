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

        IDbFactory factoryVenta = new PostgresDbFactory(connectionDatabase);
        var ventaServicio = new VentaService(factoryVenta.CreateVentaRepository());

        IDbFactory factoryProducto = new PostgresDbFactory(connectionDatabase);
        var servicioProducto = new ProductoService(factory.CreateProductoRepository());

        Console.Clear();
        Console.WriteLine("\n--- MENÚ DETALLE VENTA ---");
        Console.WriteLine("\n1. Monstrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.Write("Opción: \n");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    detalleVentaService.MostrarTodos();
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuDetalleVenta();
                    break;
                case '2':
                    DetalleVenta detalleVenta = new DetalleVenta();
                    Console.WriteLine("\nFacturas: ");
                    ventaServicio.MostrarTodos();

                    Console.Write("\nIngrese id de la factura: ");
                    detalleVenta.IdFacturacion = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nProductos: ");
                    servicioProducto.MostrarTodos();
                    Console.Write("\nIngrese Id del producto: ");
                    detalleVenta.IdProducto = Console.ReadLine();

                    Console.Write("Cantidad de producto: ");
                    detalleVenta.Cantidad = int.Parse(Console.ReadLine());
                    detalleVenta.Valor = 0;

                    detalleVentaService.CrearDetalleVenta(detalleVenta);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuDetalleVenta();
                    break;
                case '3':
                    Console.WriteLine("\nDetalles de venta: ");
                    detalleVentaService.MostrarTodos();
                    Console.WriteLine("Id a actualizar: ");
                    int idA = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese nueva cantidad: ");
                    int idB = int.Parse(Console.ReadLine());

                    detalleVentaService.ActualizarDetalleVenta(idA, idB);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuDetalleVenta();
                    break;
                case '4':
                    Console.Write("ID a eliminar: ");
                    int idE = int.Parse(Console.ReadLine());
                    detalleVentaService.EliminarDetalleVenta(idE);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuDetalleVenta();
                    break;
                case '0':
                    UiVentaCompra.MenuVentaCompra();
                    break;
                default:
                    Console.WriteLine("Tecla no reconocida");
                    break;
            }
        }
    }
}
