using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace sgi_app.application.ui;

public class UiMainMenu
{
    public static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
        Console.Write("\n1. Lugares\t2. Empresas\t3. Tercero\n4. Venta/Compra\t5. Producto");
        Console.WriteLine("\n0. Salir");
        Console.Write("\nOpción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    UiLugares.MenuLugares();
                    break;
                case '2':
                    UiEmpresas.MenuEmpresas();
                    break;
                case '3':
                    UiTerceros.MenuTerceros();
                    break;
                case '4':
                    ui.UiVentaCompra.MenuVentaCompra();
                    break;
                case '5':
                    UiProducto.MenuProductos();
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"Tecla no reconocida {KeyPressed.KeyChar}");
                    break;
            }
        }
    }
}