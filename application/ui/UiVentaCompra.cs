using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.application.ui
{
    public class UiVentaCompra
    {
        public static void MenuVentaCompra()
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ VENTA / COMPRA ---");
            Console.WriteLine("\n1. Compra\t2. Detalle Compra\n3. Venta\t4. Detalle Venta\n0. Salir");
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