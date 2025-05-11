using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.application.ui;

public class UiProveedor
{
    public static void MenuProveedor()
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var ServicioProveedor =  new ProveedorService(factory.CreateProveedorRepository());
        var ServicioTercero = new TerceroService(factory.CreateTerceroRepository());
        Console.Clear();
        Console.WriteLine("\n--- MENÚ PROVEEDOR ---");
        Console.WriteLine("\n1. Monstrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.Write("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    Console.Clear();
                    ServicioProveedor.ObtenerProveedor();
                    Console.WriteLine("Por favor, presione 0:");
                    break;
                    
                case '2':
                    Console.Clear();
                    Console.WriteLine("Por favor, ingrese el número de documento del proveedor: ");
                    string IdProveedor = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el nombre del proveedor: ");
                    string NombreProveedor = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el apellido del proveedor :");
                    string ApellidoProveedor = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el email del proveedor: ");
                    string EmailProveedor = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el porcentaje de descuento del proveedor: ");
                    double DescuentoProveedor = double.Parse( Console.ReadLine());
                    Console.WriteLine("Por favor, ingrese el día del pago del proveedor: ");
                    int DiaPagoProveedor = int.Parse(Console.ReadLine());

                    Proveedor nuevoProveedor = new Proveedor(
                    IdProveedor: 1,
                    Id: IdProveedor,
                    Nombre: NombreProveedor,
                    Apellido: ApellidoProveedor,
                    Email: EmailProveedor,
                    Id_Tipo_Documento: 1,
                    Id_Tipo_Tercero: 1,
                    Descuento: DescuentoProveedor,
                    DiaPago: DiaPagoProveedor,
                    Id_ciudad: 1
);
                    Tercero terceroNuevo = new Tercero(
                    Id: IdProveedor,
                    Nombre: NombreProveedor,
                    Apellido: ApellidoProveedor,
                    Email: EmailProveedor,
                    Id_Tipo_Documento: 1,    
                    Id_Tipo_Tercero: 1,      
                    Id_ciudad: 1          
    );
                    ServicioTercero.CrearTercero(terceroNuevo);
                    ServicioProveedor.CrearProveedor(nuevoProveedor);
                    Console.WriteLine("El proveedor pudo ser creado. Por favor, presione 0:");
                    break;
                case '3':
                Console.Clear();
                ServicioProveedor.ObtenerProveedor();
                    Console.WriteLine("Por favor, ingrese el número de documento del proveedor que quiere editar: ");
                    string IdProveedorE = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el nuevo nombre del proveedor: ");
                    string NombreProveedorE = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el  nuevo apellido del proveedor :");
                    string ApellidoProveedorE = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el nuevo email del proveedor: ");
                    string EmailProveedorE = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el nuevo porcentaje de descuento del proveedor: ");
                    double DescuentoProveedorE = double.Parse( Console.ReadLine());
                    Console.WriteLine("Por favor, ingrese el nuevo día del pago del proveedor: ");
                    int DiaPagoProveedorE= int.Parse(Console.ReadLine());


                    Proveedor nuevoProveedorE = new Proveedor(
                    IdProveedor: 1,
                    Id: IdProveedorE,
                    Nombre: NombreProveedorE,
                    Apellido: ApellidoProveedorE,
                    Email: EmailProveedorE,
                    Id_Tipo_Documento: 1,
                    Id_Tipo_Tercero: 1,
                    Descuento: DescuentoProveedorE,
                    DiaPago: DiaPagoProveedorE,
                    Id_ciudad: 1
);
                    Tercero terceroNuevoE = new Tercero(
                    Id: IdProveedorE,
                    Nombre: NombreProveedorE,
                    Apellido: ApellidoProveedorE,
                    Email: EmailProveedorE,
                    Id_Tipo_Documento: 1,    
                    Id_Tipo_Tercero: 1,      
                    Id_ciudad: 1          
    );

    ServicioTercero.EditarTercero(terceroNuevoE);
    ServicioProveedor.EditarProveedor(nuevoProveedorE);
    Console.WriteLine("El proveedor pudo ser editado. Por favor, presione 0:");
                    break;
                case '4':
                Console.Clear();
                ServicioProveedor.ObtenerProveedor();
                Console.WriteLine("Por favor, ingrese el id del proveedor a eliminar: ");
                string IdAEliminar = Console.ReadLine();
                ServicioProveedor.EliminarProveedor(IdAEliminar);
                ServicioTercero.EliminarTercero(IdAEliminar);
                Console.WriteLine("El proveedor pudo ser eliminado. Por favor, presione 0:");
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
