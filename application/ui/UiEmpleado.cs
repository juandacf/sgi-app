using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
using sgi_app.application.ui;
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
            var ServicioTercero = new TerceroService(factory.CreateTerceroRepository());
            var ServicioEmpleado = new EmpleadoService(factory.CreateEmpleadoRepository());
            Console.Clear();
            Console.WriteLine("\n--- MENÚ Empleados ---");
            Console.WriteLine("\n1.Ver todos \t2. Agregar Empleado\n3. Editar Empleado\t4. Eliminar Empleado \n 0. Salir");
            while(true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey();
                switch(KeyPressed.KeyChar)
                {
                    case '1':
                    Console.Clear();
                        ServicioEmpleado.ObtenerEmpleado();
                        Console.WriteLine("Por favor, oprima 0 para volver al menú");
                        break;
                    case '2':
                    Console.Clear();
                    Console.WriteLine("Por favor, ingrese el número del documento de identidad del usuario:");
                    string IdEmpleado = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el nombre del nuevo empleado");
                    string NombreEmpleado = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el apellido del nuevo empleado: ");
                    string ApellidoEmpleado = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el email del empleado: ");
                    string EmailEmpleado = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese  el Salario Base del empleado");
                    double SalarioBase = double.Parse(Console.ReadLine());
                    Empleado empleado = new Empleado(
    Id: IdEmpleado,
    Nombre: NombreEmpleado,
    Apellido: ApellidoEmpleado,
    Email: EmailEmpleado,
    Id_Tipo_Documento: 1,     
    Id_Tipo_Tercero: 2,      
    FechaIngreso: DateTime.Now,
    SalarioBase: SalarioBase,
    Id_Eps: 1,
    IdArl: 1,       
    Id_ciudad: 1   );

    Tercero tercero = new Tercero(
    Id: IdEmpleado,
    Nombre: NombreEmpleado,
    Apellido: ApellidoEmpleado,
    Email: EmailEmpleado,
    Id_Tipo_Documento: 1,    
    Id_Tipo_Tercero: 2,      
    Id_ciudad: 1          );
                        
    ServicioTercero.CrearTercero(tercero);
    ServicioEmpleado.CrearEmpleado(empleado);
Console.WriteLine("Por favor, oprima 0 para volver al menú");

                        break;
                    case '3':
                        Console.Clear();
                        ServicioEmpleado.ObtenerEmpleado();
                        Console.WriteLine("Por favor, ingrese el id del empleado que desea modificar ");
                        string IdModEmpleado = Console.ReadLine();
                        Console.WriteLine("Por favor, ingrese el nombre nuevo del nuevo empleado");
                        string NombreEmpleadoNuevo = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el apellido nuevo del nuevo empleado: ");
                    string ApellidoEmpleadoNuevo = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el email nuevo del empleado: ");
                    string EmailEmpleadoNuevo = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese  el Salario Base nuevo del empleado");
                    double SalarioBaseNuevo = double.Parse(Console.ReadLine());
                    Empleado empleadoNUevo = new Empleado(
    Id: IdModEmpleado,
    Nombre: NombreEmpleadoNuevo,
    Apellido: ApellidoEmpleadoNuevo,
    Email: EmailEmpleadoNuevo,
    Id_Tipo_Documento: 1,     
    Id_Tipo_Tercero: 2,      
    FechaIngreso: DateTime.Now,
    SalarioBase: SalarioBaseNuevo,
    Id_Eps: 1,
    IdArl: 1,       
    Id_ciudad: 1   );

    Tercero terceroNuevo = new Tercero(
    Id: IdModEmpleado,
    Nombre: NombreEmpleadoNuevo,
    Apellido: ApellidoEmpleadoNuevo,
    Email: EmailEmpleadoNuevo,
    Id_Tipo_Documento: 1,    
    Id_Tipo_Tercero: 2,      
    Id_ciudad: 1          );

    ServicioTercero.EditarTercero(terceroNuevo);
    ServicioEmpleado.EditarEmpleado(empleadoNUevo);
                        break;
                    case '4':
                    Console.Clear();
                    ServicioEmpleado.ObtenerEmpleado();
                    Console.WriteLine("Por favor, ingrese el id del empleado a eliminar: ");
                    string IdEmpleadoEliminar = Console.ReadLine();
                    ServicioTercero.EliminarTercero(IdEmpleadoEliminar);
                    ServicioEmpleado.EliminarEmpleado(IdEmpleadoEliminar);
                    Console.WriteLine("El empleado fue eliminado con éxito.");
                    Console.WriteLine("Por favor, oprima 0 para volver al menú");
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
}