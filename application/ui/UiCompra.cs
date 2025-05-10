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

    Console.Clear();
    Console.WriteLine("\n--- MENÚ COMPRA ---");
    Console.WriteLine("\n1. Monstrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
    Console.Write("Opción: ");
    while (true)
    {
        ConsoleKeyInfo KeyPressed = Console.ReadKey();
        switch (KeyPressed.KeyChar)
        {
            case '1':
                servicioCompra.MostrarTodos();
                Console.ReadKey();
                Console.WriteLine("Ingrese una tecla");
                Console.ReadKey();
                MenuCompra();
                break;
            case '2':
                Compra compra = new Compra();
                Console.Write("\nIngrese id del proveedor: ");
                compra.IdTerceroProveedor =  int.Parse(Console.ReadLine());
                Console.Write("\nIngresa id del empleado: ");
                compra.IdTerceroEmpleado =  int.Parse(Console.ReadLine());
                compra.Fecha = DateTime.Now;
                Console.Write("\nIngrese documento compra: ");
                compra.DocumentoCompra = Console.ReadLine();
                servicioCompra.CrearCompra(compra);
                Console.WriteLine("Ingrese una tecla");
                Console.ReadKey();
                MenuCompra();
                break;
            case '3':
                Console.WriteLine("Id a actualizar: ");
                int idA = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Nuevo documento: ");
                servicioCompra.ActualizarCompra(idA, Console.ReadLine()!);
                Console.WriteLine("Ingrese una tecla");
                Console.ReadKey();
                MenuCompra();
                break;
            case '4':
                Console.Write("ID a eliminar: ");
                int idE = int.Parse(Console.ReadLine()!);
                servicioCompra.EliminarCompra(idE);
                Console.WriteLine("Ingrese una tecla");
                Console.ReadKey();
                MenuCompra();
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
