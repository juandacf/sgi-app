using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.application.ui
{
    public class UiEmpresas
    {
        public static void MenuEmpresas()
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ EMPRESAS ---");
            Console.WriteLine("\n1. Arl \t2. Eps\n3. Empresa\t0. Salir");
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