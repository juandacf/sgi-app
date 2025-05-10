using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.application.ui;
public class UiCliente
{
    public static void MenuCliente()
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var ServicioTercero = new TerceroService(factory.CreateTerceroRepository());
        var ServicioCliente = new ClienteService(factory.CreateClienteRepository());
            
        Console.Clear();
        Console.WriteLine("\n--- MENÚ CLIENTE ---");
        Console.WriteLine("\n1. Monstrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.Write("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                Console.WriteLine("Por favor, ingrese el número del documento de identidad del cliente:");
                    string IdCliente = Console.ReadLine();
                Console.WriteLine("Por favor, ingrese el nombre del nuevo cliente");
                    string NombreCliente = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el apellido del nuevo cliente: ");
                    string ApellidoCliente = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el email del cliente: ");
                    string EmailCliente = Console.ReadLine();
                    
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '0':
                    UiTerceros.MenuTerceros();
                    break;
                default:
                    Console.WriteLine("Tecla no reconocida");
                    break;
            }
        }
    }
}