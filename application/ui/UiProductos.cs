using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.application.ui
{
    public class UiProductos
    {
        public static void MenuProductos()
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ PRODUCTOS ---");
            Console.WriteLine("\n1. Producto\t\t2. Plan\n0. Salir");
            while(true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey();
                switch(KeyPressed.KeyChar)
                {
                    case '1':
                        UiProducto.MenuProducto();
                        break;
                    case '2':
                        UiPlan.MenuPlan();
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