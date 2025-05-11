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

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ PRODUCTO ---");
            Console.WriteLine("1. Mostrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (keyPressed.KeyChar)
            {
                case '1':
                    Console.Clear();
                    servicioProducto.MostrarTodos();
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '2':
                    Console.Clear();
                    Producto producto = new Producto();
                    
                    Console.Write("ID producto: ");
                    producto.Id = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(producto.Id))
                    {
                        Console.WriteLine("❌ El ID no puede estar vacío.");
                        break;
                    }

                    Console.Write("Nombre producto: ");
                    producto.Nombre = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(producto.Nombre))
                    {
                        Console.WriteLine("❌ El nombre del producto no puede estar vacío.");
                        break;
                    }

                    producto.Stock = ValidarNumero("Stock producto: ");
                    producto.StockMinimo = ValidarNumero("Stock mínimo producto: ");
                    producto.StockMaximo = ValidarNumero("Stock máximo producto: ");
                    
                    Console.Write("Código de barras producto: ");
                    producto.BarCode = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(producto.BarCode))
                    {
                        Console.WriteLine("❌ El código de barras no puede estar vacío.");
                        break;
                    }

                    servicioProducto.CrearProducto(producto);
                    Console.WriteLine("✅ El producto ha sido creado con éxito.");
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '3':
                    Console.Clear();
                    Console.Write("ID del producto a actualizar: ");
                    string idActualizar = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(idActualizar))
                    {
                        Console.WriteLine("❌ El ID no puede estar vacío.");
                        break;
                    }

                    Console.Write("Nuevo stock: ");
                    int nuevoStock = ValidarNumero();
                    servicioProducto.ActualizarProducto(idActualizar, nuevoStock);
                    Console.WriteLine("✅ El stock ha sido actualizado.");
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '4':
                    Console.Clear();
                    Console.Write("ID del producto a eliminar: ");
                    string idEliminar = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(idEliminar))
                    {
                        Console.WriteLine("❌ El ID no puede estar vacío.");
                        break;
                    }

                    servicioProducto.EliminarProducto(idEliminar);
                    Console.WriteLine("✅ El producto ha sido eliminado.");
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '0':
                    UiProductos.MenuProductos();
                    return;

                default:
                    Console.WriteLine("❌ Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static int ValidarNumero(string mensaje = "Ingrese un número: ")
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor) && valor >= 0)
            {
                return valor;
            }
            else
            {
                Console.WriteLine("❌ Entrada inválida. Por favor, ingrese un número válido.");
            }
        }
    }
}
