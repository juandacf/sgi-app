using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.application.ui
{
    public class UiTerceros
    {
        public static void MenuTerceros()
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ TERCEROS ---");
            Console.WriteLine("\n1. Menu Tercero \t2. Tipo Terceros\t0. Salir");
            while(true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey();
                switch(KeyPressed.KeyChar)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Tecla no reconocida");
                        break;
                }
            }
        }
    }
}