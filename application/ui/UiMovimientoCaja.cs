using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.services;
using sgi_app.domain.entities;
using System.Text.RegularExpressions;

namespace sgi_app.application.ui;
public class UiMovimientoCaja
{
    public static void MenuMovimientoCaja()
    {
        string connectionDatabase = "server=localhost;database=miniproject;user=root;password=123456;";
        IDbFactory factory = new PostgresDbFactory(connectionDatabase);
        var movCajaService = new MovCajaService(factory.CreateMovCajaRepository());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ MOVIMIENTO CAJA ---");
            Console.WriteLine("1. Mostrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (keyPressed.KeyChar)
            {
                case '1':
                    Console.Clear();
                    movCajaService.MostrarTodos();
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '2':
                    Console.Clear();
                    MovimientoCaja movCaja = new MovimientoCaja();
                    movCaja.Fecha = DateTime.Now;
                    Console.WriteLine("Fecha asignada automáticamente: " + movCaja.Fecha.ToString("g"));

                    bool tipoValido = false;
                    while (!tipoValido)
                    {
                        Console.WriteLine("\nSeleccione el tipo de movimiento:");
                        Console.WriteLine("1. Entrada\t2. Salida\t3. Ventas\n4. Reembolso\t5. Devolución");
                        ConsoleKeyInfo key = Console.ReadKey();
                        Console.WriteLine();

                        if (int.TryParse(key.KeyChar.ToString(), out int tipo) && tipo >= 1 && tipo <= 5)
                        {
                            movCaja.IdTipoMovimientoCaja = tipo;
                            tipoValido = true;
                        }
                        else
                        {
                            Console.WriteLine("❌ Opción inválida. Intente nuevamente.");
                        }
                    }

                    Console.Write("\nIngrese el valor del movimiento: ");
                    if (double.TryParse(Console.ReadLine(), out double valor))
                    {
                        movCaja.Valor = valor;
                    }
                    else
                    {
                        Console.WriteLine("❌ Valor inválido. Operación cancelada.");
                        Console.ReadKey();
                        break;
                    }

                    Console.Write("Ingrese el concepto del movimiento: ");
                    string concepto = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(concepto))
                    {
                        Console.WriteLine("❌ El concepto no puede estar vacío.");
                        Console.ReadKey();
                        break;
                    }

                    movCaja.Concepto = concepto;
                    movCajaService.CrearMovimientoCaja(movCaja);
                    Console.WriteLine("✅ Movimiento creado exitosamente.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '3':
                    Console.Clear();
                    Console.Write("Ingrese el ID del movimiento a actualizar: ");
                    if (int.TryParse(Console.ReadLine(), out int idActualizar))
                    {
                        Console.Write("Ingrese el nuevo concepto: ");
                        string nuevoConcepto = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nuevoConcepto))
                        {
                            movCajaService.ActualizarMovCaja(idActualizar, nuevoConcepto);
                            Console.WriteLine("✅ Movimiento actualizado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("❌ El concepto no puede estar vacío.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '4':
                    Console.Clear();
                    Console.Write("Ingrese el ID del movimiento a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        movCajaService.EliminarMovCaja(idEliminar);
                        Console.WriteLine("✅ Movimiento eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("❌ ID inválido.");
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case '0':
                    UiVentaCompra.MenuVentaCompra();
                    return;

                default:
                    Console.WriteLine("❌ Opción no reconocida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
