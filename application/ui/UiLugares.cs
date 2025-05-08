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
                    UiCiudad.MenuCiudad();
                    break;
                case '2':
                    UiPais.MenuPais();
                    break;
                case '3':
                    UiRegion.MenuRegion();
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