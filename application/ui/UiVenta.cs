using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.services;
using sgi_app.domain.entities;
using Google.Protobuf;

namespace sgi_app.application.ui;
public class UiVenta
{
    public static void MenuVenta()
    {
        string connectionDatabase = "server=localhost;database=miniproject;user=root;password=123456;";
        IDbFactory factory = new PostgresDbFactory(connectionDatabase);
        var servicioVenta = new VentaService(factory.CreateVentaRepository());

        IDbFactory factoryTercero = new PostgresDbFactory(connectionDatabase);
        var servicioTercero = new TerceroService(factoryTercero.CreateTerceroRepository());

        Console.Clear();
        Console.WriteLine("\n--- MENÚ VENTA ---");
        Console.WriteLine("\n1. Monstrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.WriteLine("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    servicioVenta.MostrarTodos();
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuVenta();
                    break;
                case '2':
                    Venta venta = new Venta();
                    venta.Fecha = DateTime.Now;
                    Console.WriteLine("Fecha ingresada: " + venta.Fecha);
                    servicioTercero.ObtenerTerceros();
                    Console.WriteLine("Ingrese id del empleado: ");
                    venta.IDTerceroEmpleado = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese id del cliente: ");
                    venta.IdTerceroCliente = int.Parse(Console.ReadLine());
                    servicioVenta.CrearVenta(venta);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuVenta();
                    break;
                case '3':
                
                    Console.WriteLine("Id a actualizar: ");
                    int idA = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese id del empleado: ");
                    int idTerceroEmpleado = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese id del cliente: ");
                    servicioVenta.ActualizarVenta(idA , idTerceroEmpleado, int.Parse(Console.ReadLine()!));
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuVenta();
                    break;
                case '4':
                    Console.Write("ID a eliminar: ");
                    int idE = int.Parse(Console.ReadLine());
                    servicioVenta.EliminarVenta(idE);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuVenta();
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
