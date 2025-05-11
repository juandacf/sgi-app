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

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ PLAN ---");
            Console.WriteLine("1. Mostrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (keyPressed.KeyChar)
            {
                case '1':
                    Console.Clear();
                    servicioPlan.MostrarTodos();
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '2':
                    Console.Clear();
                    Plan plan = new Plan();
                    Console.Write("\nNombre del plan: ");
                    plan.Nombre = Console.ReadLine();
                    plan.FechaInicio = DateTime.Now;
                    Console.WriteLine($"\nLa fecha de inicio es el día de hoy: {plan.FechaInicio}");

                    int diasParaSumar;
                    while (true)
                    {
                        Console.Write("\nIngrese la cantidad de días hasta que el plan se acabe: ");
                        if (int.TryParse(Console.ReadLine(), out diasParaSumar) && diasParaSumar > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("❌ Por favor, ingrese un número válido mayor que 0.");
                        }
                    }

                    DateTime fechaFutura = plan.FechaInicio.AddDays(diasParaSumar);
                    Console.WriteLine($"Fecha de finalización: {fechaFutura}");

                    double descuento;
                    while (true)
                    {
                        Console.Write("\nIngrese el valor del descuento (de 1 a 100): ");
                        if (double.TryParse(Console.ReadLine(), out descuento) && descuento >= 1 && descuento <= 100)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("❌ Descuento inválido. Debe estar entre 1 y 100.");
                        }
                    }

                    plan.Dcto = descuento;
                    servicioPlan.CrearPlan(plan);
                    Console.WriteLine("✅ El plan ha sido creado con éxito.");
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '3':
                    Console.Clear();
                    Console.Write("ID del plan a actualizar: ");
                    if (int.TryParse(Console.ReadLine(), out int idActualizar))
                    {
                        Console.Write("Nuevo nombre del plan: ");
                        string nuevoNombre = Console.ReadLine();
                        servicioPlan.ActualizarPlan(idActualizar, nuevoNombre);
                        Console.WriteLine("✅ El plan ha sido actualizado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '4':
                    Console.Clear();
                    Console.Write("ID del plan a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        servicioPlan.EliminarPlan(idEliminar);
                        Console.WriteLine("✅ El plan ha sido eliminado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '0':
                    UiProductos.MenuProductos();
                    return;

                default:
                    Console.WriteLine("❌ Opción no válida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
