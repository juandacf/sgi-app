using System;
using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.application.ui
{
    public class UiEmpleado
    {
        public static void MenuEmpleados()
        {
            IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
            var servicioTercero = new TerceroService(factory.CreateTerceroRepository());
            var servicioEmpleado = new EmpleadoService(factory.CreateEmpleadoRepository());

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- MENÚ EMPLEADOS ---");
                Console.WriteLine("1. Ver todos\t\t2. Agregar Empleado");
                Console.WriteLine("3. Editar Empleado\t4. Eliminar Empleado");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");

                ConsoleKeyInfo keyPressed = Console.ReadKey();
                Console.WriteLine();

                switch (keyPressed.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        servicioEmpleado.ObtenerEmpleado();
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case '2':
                        Console.Clear();
                        Console.Write("Número de documento: ");
                        string idEmpleado = Console.ReadLine()!;
                        if (string.IsNullOrWhiteSpace(idEmpleado))
                        {
                            Console.WriteLine("ID no puede estar vacío.");
                            break;
                        }

                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine()!;
                        if (string.IsNullOrWhiteSpace(nombre))
                        {
                            Console.WriteLine("Nombre no puede estar vacío.");
                            break;
                        }

                        Console.Write("Apellido: ");
                        string apellido = Console.ReadLine()!;
                        if (string.IsNullOrWhiteSpace(apellido))
                        {
                            Console.WriteLine("Apellido no puede estar vacío.");
                            break;
                        }

                        Console.Write("Email: ");
                        string email = Console.ReadLine()!;
                        
                        Console.Write("Salario Base: ");
                        if (!double.TryParse(Console.ReadLine(), out double salarioBase))
                        {
                            Console.WriteLine("Salario inválido.");
                            break;
                        }

                        Empleado nuevoEmpleado = new Empleado(
                            Id: idEmpleado,
                            IdEmpleado: 1,
                            Nombre: nombre,
                            Apellido: apellido,
                            Email: email,
                            Id_Tipo_Documento: 1,
                            Id_Tipo_Tercero: 2,
                            FechaIngreso: DateTime.Now,
                            SalarioBase: salarioBase,
                            Id_Eps: 1,
                            IdArl: 1,
                            Id_ciudad: 1
                        );

                        Tercero nuevoTercero = new Tercero(
                            Id: idEmpleado,
                            Nombre: nombre,
                            Apellido: apellido,
                            Email: email,
                            Id_Tipo_Documento: 1,
                            Id_Tipo_Tercero: 2,
                            Id_ciudad: 1
                        );

                        servicioTercero.CrearTercero(nuevoTercero);
                        servicioEmpleado.CrearEmpleado(nuevoEmpleado);
                        Console.WriteLine("Empleado creado correctamente. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case '3':
                        Console.Clear();
                        servicioEmpleado.ObtenerEmpleado();

                        Console.Write("ID del empleado a modificar: ");
                        string idModificar = Console.ReadLine()!;
                        if (string.IsNullOrWhiteSpace(idModificar))
                        {
                            Console.WriteLine("ID inválido.");
                            break;
                        }

                        Console.Write("Nuevo nombre: ");
                        string nuevoNombre = Console.ReadLine()!;
                        Console.Write("Nuevo apellido: ");
                        string nuevoApellido = Console.ReadLine()!;
                        Console.Write("Nuevo email: ");
                        string nuevoEmail = Console.ReadLine()!;
                        if (!nuevoEmail.Contains("@") || !nuevoEmail.Contains("."))
                        {
                            Console.WriteLine("Email inválido.");
                            break;
                        }

                        Console.Write("Nuevo salario base: ");
                        if (!double.TryParse(Console.ReadLine(), out double nuevoSalario))
                        {
                            Console.WriteLine("Salario inválido.");
                            break;
                        }

                        Empleado empleadoMod = new Empleado(
                            Id: idModificar,
                            IdEmpleado: 1,
                            Nombre: nuevoNombre,
                            Apellido: nuevoApellido,
                            Email: nuevoEmail,
                            Id_Tipo_Documento: 1,
                            Id_Tipo_Tercero: 2,
                            FechaIngreso: DateTime.Now,
                            SalarioBase: nuevoSalario,
                            Id_Eps: 1,
                            IdArl: 1,
                            Id_ciudad: 1
                        );

                        Tercero terceroMod = new Tercero(
                            Id: idModificar,
                            Nombre: nuevoNombre,
                            Apellido: nuevoApellido,
                            Email: nuevoEmail,
                            Id_Tipo_Documento: 1,
                            Id_Tipo_Tercero: 2,
                            Id_ciudad: 1
                        );

                        servicioTercero.EditarTercero(terceroMod);
                        servicioEmpleado.EditarEmpleado(empleadoMod);
                        Console.WriteLine("Empleado actualizado correctamente.");
                        Console.ReadKey();
                        break;

                    case '4':
                        Console.Clear();
                        servicioEmpleado.ObtenerEmpleado();

                        Console.Write("CC del empleado a eliminar: ");
                        string idEliminar = Console.ReadLine()!;
                        if (string.IsNullOrWhiteSpace(idEliminar))
                        {
                            Console.WriteLine("ID inválido.");
                            break;
                        }

                        servicioTercero.EliminarTercero(idEliminar);
                        servicioEmpleado.EliminarEmpleado(idEliminar);
                        Console.WriteLine("Empleado eliminado correctamente. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case '0':
                        UiTerceros.MenuTerceros();
                        return;

                    default:
                        Console.WriteLine("Opción no reconocida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
