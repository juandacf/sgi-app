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
            Console.WriteLine("\n1. Compra\t\t2. Detalle Compra\n3. Venta\t\t4. Detalle Venta\n5. Movimiento Caja\t0. Salir");
            while(true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey();
                switch(KeyPressed.KeyChar)
                {
                    case '1':
                        UiCompra.MenuCompra();
                        break;
                    case '2':
                        UiDetalleCompra.MenuDetalleCompra();
                        break;
                    case '3':
                        UiVenta.MenuVenta();
                        break;
                    case '4':
                        UiDetalleVenta.MenuDetalleVenta();
                        break;
                    case '5':
                        UiMovimientoCaja.MenuMovimientoCaja();
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