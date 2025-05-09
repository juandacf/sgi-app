using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.services;
using sgi_app.domain.entities;

namespace sgi_app.application.ui;
public class UiEps
{
    public static void MenuEps()
    {
        string connectionDatabase = "server=localhost;database=miniproject;user=root;password=123456;";
        IDbFactory factory = new PostgresDbFactory(connectionDatabase);
        var servicioEps = new EpsService(factory.CreateEpsRepository());

        Console.Clear();
        Console.WriteLine("\n--- MENÚ EPS ---");
        Console.WriteLine("\n1. Monstrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.WriteLine("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    servicioEps.MostrarTodos();
                    Console.WriteLine("Ingrese una tecla");
                    break;
                case '2':
                    Eps eps = new Eps();
                    Console.Write("Nombre: ");
                    eps.Nombre = Console.ReadLine();
                    servicioEps.CrearEps(eps);
                    Console.WriteLine("Ingrese una tecla");
                    break;
                case '3':
                    Console.WriteLine("Id a actualizar: ");
                    int idA = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Nuevo nombre: ");
                    servicioEps.ActualizarEps(idA, Console.ReadLine()!);
                    Console.WriteLine("Ingrese una tecla");
                    break;
                case '4':
                    Console.Write("ID a eliminar: ");
                    int idE = int.Parse(Console.ReadLine()!);
                    servicioEps.EliminarEps(idE);
                    Console.WriteLine("Ingrese una tecla");
                    break;
                case '0':
                    UiEmpresas.MenuEmpresas();
                    break;
                default:
                    Console.WriteLine("Tecla no reconocida");
                    break;
            }
        }
    }
}
