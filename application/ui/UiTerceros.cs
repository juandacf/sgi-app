using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.ui;

namespace sgi_app.application.ui
{
    public class UiTerceros
    {
        public static void MenuTerceros()
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ TERCEROS ---");
            Console.WriteLine("\n1. Gestionar Clientes \t2. Gestionar Proveedores\n3. Gestionar Empleados\t0. Salir");
            while(true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey();
                switch(KeyPressed.KeyChar)
                {
                    case '1':
                        UiCliente.MenuCliente();
                        break;
                    case '2':
                        UiProveedor.MenuProveedor();
                        break;
                    case '3':
                        UiEmpleado.MenuEmpleados();
                        break;
                    case '4':
                        UiTerceroTelefono.MenuTerceroTelefono();
                        break;
                    case '5':
                        UiCliente.MenuCliente();
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