using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.services;
using sgi_app.domain.entities;

namespace sgi_app.application.ui;
public class UiProducto
{
    public static void MenuProducto()
    {
        string connectionDatabase = "server=localhost;database=miniproject;user=root;password=123456;";
        IDbFactory factory = new PostgresDbFactory(connectionDatabase);
        var servicioProducto = new ProductoService(factory.CreateProductoRepository());
        
        Console.Clear();
        Console.WriteLine("\n--- MENÚ PRODUCTO ---");
        Console.WriteLine("\n1. Monstrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.Write("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    servicioProducto.MostrarTodos();
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuProducto();
                    break;
                case '2':
                    Producto producto = new Producto();
                    Console.Write("Id producto: ");
                    producto.Id = Console.ReadLine();
                    Console.Write("Nombre producto: ");
                    producto.Nombre = Console.ReadLine();
                    Console.Write("Stock producto: ");
                    producto.Stock = int.Parse(Console.ReadLine());
                    Console.Write("Stock minimo producto: ");
                    producto.StockMinimo = int.Parse(Console.ReadLine());
                    Console.Write("Stock maximo producto: ");
                    producto.StockMaximo = int.Parse(Console.ReadLine());
                    Console.Write("Codigo de barras producto: ");
                    producto.BarCode = Console.ReadLine();
                    servicioProducto.CrearProducto(producto);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuProducto();
                    break;
                case '3':
                    Console.WriteLine("Id a actualizar: ");
                    string idA = Console.ReadLine();
                    Console.WriteLine("Nuevo stock: ");
                    servicioProducto.ActualizarProducto(idA, int.Parse(Console.ReadLine()));
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuProducto();
                    break;
                case '4':
                    Console.Write("ID a eliminar: ");
                    string idE = Console.ReadLine();
                    servicioProducto.EliminarProducto(idE);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuProducto();
                    break;
                case '0':
                    UiProductos.MenuProductos();
                    break;
                default:
                    Console.WriteLine("Tecla no reconocida");
                    break;
            }
        }
    }
}
