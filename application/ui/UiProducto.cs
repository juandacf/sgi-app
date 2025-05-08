using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.application.ui
{
    public class UiProducto
    {
        public static void MenuProductos()
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ PRODUCTOS ---");
            Console.WriteLine("\n1. Producto\t\t2. Proveedor\t\t3. Plan\n4. Plan Producto\t5. ProductoProveedor\n0. Salir");
            while(true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey();
                switch(KeyPressed.KeyChar)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case '0':
                        UiMainMenu.MainMenu();
                        break;
                    default:
                        Console.WriteLine("Tecla no reconocida");
                        break;
                }
            }
        }
    }
}