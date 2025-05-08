using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg.Sig;
using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
namespace sgi_app.application.ui;
    public class UiLugares
    {
        public static void MenuLugares()
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ LUGARES ---");
            Console.WriteLine("\n1. Ciudad \t2. Pais\n3. Region\t0. Salir");
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