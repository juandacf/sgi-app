using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.services;
using sgi_app.domain.entities;

namespace sgi_app.application.ui;
public class UiPlan
{
    public static void MenuPlan()
    {
        string connectionDatabase = "server=localhost;database=miniproject;user=root;password=123456;";
        IDbFactory factory = new PostgresDbFactory(connectionDatabase);
        var servicioPlan = new PlanService(factory.CreatePlanRepository());

        Console.Clear();
        Console.WriteLine("\n--- MENÚ PLAN ---");
        Console.WriteLine("\n1. Monstrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.Write("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    servicioPlan.MostrarTodos();
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuPlan();
                    break;
                case '2':
                    Plan plan = new Plan();
                    Console.Write("\nNombre plan: ");
                    plan.Nombre = Console.ReadLine();
                    plan.FechaInicio = DateTime.Now;
                    Console.Write($"\nLa fecha inicia el dia de hoy {plan.FechaInicio}");
                    Console.Write("\nIngrese la cantidad de dias hasta que el plan se acabe: ");
                    int diasParaSumar = int.Parse(Console.ReadLine()); // Puedes cambiar este valor por la cantidad de días que desees
                    DateTime fechaFutura = plan.FechaInicio.AddDays(diasParaSumar);
                    Console.Write("Ingrese el valor del descuento del 1 al 100%: ");
                    plan.Dcto = double.Parse(Console.ReadLine());
                    servicioPlan.CrearPlan(plan);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuPlan();
                    break;
                case '3':
                    Console.WriteLine("Id a actualizar: ");
                    int idA = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Nuevo nombre: ");
                    servicioPlan.ActualizarPlan(idA, Console.ReadLine()!);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuPlan();
                    break;
                case '4':
                    Console.Write("ID a eliminar: ");
                    int idE = int.Parse(Console.ReadLine()!);
                    servicioPlan.EliminarPlan(idE);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuPlan();
                    break;
                case '0':
                    UiProductos.MenuProductos();
                    break;
                default:
                    Console.WriteLine("Tecla no reconocida");
                    break;
            }
        }
    }
}
