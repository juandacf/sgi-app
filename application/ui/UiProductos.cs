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
            Console.WriteLine("\n1. Producto\t\t2. Proveedor\n3. Plan\t\t\t4. Plan Producto\n5. ProductoProveedor\t0. Salir");
            while(true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey();
                switch(KeyPressed.KeyChar)
                {
                    case '1':
                        UiProducto.MenuProducto();
                        break;
                    case '2':
                        UiProveedor.MenuProveedor();
                        break;
                    case '3':
                        UiPlan.MenuPlan();
                        break;
                    case '4':
                        UiPlanProducto.MenuPlanProducto();
                        break;
                    case '5':
                        UiProductoProveedor.MenuProductoProveedor();
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