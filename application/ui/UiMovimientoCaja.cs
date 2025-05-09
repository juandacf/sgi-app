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

        Console.Clear();
        Console.WriteLine("\n--- MENÚ MOVIMIENTO CAJA ---");
        Console.WriteLine("\n1. Monstrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.WriteLine("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    movCajaService.MostrarTodos();
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuMovimientoCaja();
                    break;
                case '2':
                    MovimientoCaja movCaja = new MovimientoCaja();
                    movCaja.Fecha = DateTime.Now;
                    Console.WriteLine("Fecha ingresada: " + movCaja.Fecha);
                    while(true)
                    {
                        Console.WriteLine("1. Entrada\t2. Salida\t3. Ventas\n4. Reembolso\t5. Devolucion");
                        ConsoleKeyInfo key = Console.ReadKey();
                        switch(key.KeyChar)
                        {
                            case '1':
                                movCaja.IdTipoMovimientoCaja = 1;
                                break;
                            case '2':
                                movCaja.IdTipoMovimientoCaja = 2;
                                break;
                            case '3':
                                movCaja.IdTipoMovimientoCaja = 3;
                                break;
                            case '4':
                                movCaja.IdTipoMovimientoCaja = 4;
                                break;
                            case '5':
                                movCaja.IdTipoMovimientoCaja = 5;
                                break;
                            default:
                                Console.WriteLine("Ingrese un caracter válido");
                                break;
                        }
                        break;
                    }
                    Console.Write("\nIngrese valor del movimiento: ");
                    movCaja.Valor = double.Parse(Console.ReadLine()!);
                    Console.WriteLine("\nIngrese concepto del movimiento: ");
                    movCaja.Concepto = Console.ReadLine();
                    movCajaService.CrearMovimientoCaja(movCaja);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuMovimientoCaja();
                    break;
                case '3':
                    Console.WriteLine("Id a actualizar: ");
                    int idA = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Nuevo concepto: ");
                    movCajaService.ActualizarMovCaja(idA, Console.ReadLine()!);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuMovimientoCaja();
                    break;
                case '4':
                    Console.Write("ID a eliminar: ");
                    int idE = int.Parse(Console.ReadLine()!);
                    movCajaService.EliminarMovCaja(idE);
                    Console.WriteLine("Ingrese una tecla");
                    Console.ReadKey();
                    MenuMovimientoCaja();
                    break;
                case '0':
                    UiVentaCompra.MenuVentaCompra();
                    break;
                default:
                    Console.WriteLine("Tecla no reconocida");
                    break;
            }
        }
    }
}
