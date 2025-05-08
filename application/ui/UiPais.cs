using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.application.ui;
public class UiPais
{
    public static void MenuPais()
    {
        Console.Clear();
        Console.WriteLine("\n--- MENÚ PAÍS ---");
        Console.WriteLine("\n1. Monstrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.Write("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
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
                    UiLugares.MenuLugares();
                    break;
                default:
                    Console.WriteLine("Tecla no reconocida");
                    break;
            }
        }
    }
}