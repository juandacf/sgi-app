using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
using sgi_app.domain.entities;
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
                Console.Clear();
                ServicioCliente.ObtenerCliente();
                Console.WriteLine("Presione 0 para volver al menú principal: ");
                    break;
                case '2': 
                Console.Clear();
                Console.WriteLine("Por favor, ingrese el número del documento de identidad del cliente:");
                    string IdCliente = Console.ReadLine();
                Console.WriteLine("Por favor, ingrese el nombre del nuevo cliente");
                    string NombreCliente = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el apellido del nuevo cliente: ");
                    string ApellidoCliente = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el email del cliente: ");
                    string EmailCliente = Console.ReadLine();

                    Cliente nuevoCliente = new Cliente(
    Id: IdCliente,
    Id_cliente: 1,
    Nombre: NombreCliente,
    Apellido: ApellidoCliente,
    Email: EmailCliente,
    Id_Tipo_Documento: 1,
    Id_Tipo_Tercero: 3,
    FechaNacimiento: DateTime.Now,
    FechaUltimaCompra: DateTime.Now,
    Id_ciudad: 1
);

 Tercero terceroNuevo = new Tercero(
    Id: IdCliente,
    Nombre: NombreCliente,
    Apellido: ApellidoCliente,
    Email: EmailCliente,
    Id_Tipo_Documento: 1,    
    Id_Tipo_Tercero: 3,      
    Id_ciudad: 1          );

    ServicioTercero.CrearTercero(terceroNuevo);
    ServicioCliente.CrearCliente(nuevoCliente);

    Console.WriteLine("El cliente fue creado con éxito. Presione 0 para continuar");
                    break;
                case '3':
                Console.Clear();
                ServicioCliente.ObtenerCliente();
                Console.WriteLine("Por favor, ingrese el id del cliente que quiere actualizar:");
                    string IdClienteNUevo = Console.ReadLine();
                Console.WriteLine("Por favor, ingrese el nombre del nuevo cliente");
                    string NombreClienteNuevo= Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el apellido del nuevo cliente: ");
                    string ApellidoClienteNuevo= Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el email del cliente: ");
                    string EmailClienteNuevo = Console.ReadLine();

                    Cliente nuevoClienteNuevo = new Cliente(
    Id: IdClienteNUevo,
    Id_cliente: 1,
    Nombre: NombreClienteNuevo,
    Apellido: ApellidoClienteNuevo,
    Email: EmailClienteNuevo,
    Id_Tipo_Documento: 1,
    Id_Tipo_Tercero: 3,
    FechaNacimiento: DateTime.Now,
    FechaUltimaCompra: DateTime.Now,
    Id_ciudad: 1
);

 Tercero terceroNuevoNuevo = new Tercero(
    Id: IdClienteNUevo,
    Nombre: NombreClienteNuevo,
    Apellido: ApellidoClienteNuevo,
    Email: EmailClienteNuevo,
    Id_Tipo_Documento: 1,    
    Id_Tipo_Tercero: 3,      
    Id_ciudad: 1          );
    ServicioTercero.EditarTercero(terceroNuevoNuevo);
ServicioCliente.EditarCliente(nuevoClienteNuevo);

                    break;
                case '4':
                Console.Clear();
                ServicioCliente.ObtenerCliente();
                Console.WriteLine("Por favor, ingrese el id del cliente que desea eliminar: ");
                string idElegido = Console.ReadLine();
                ServicioCliente.EliminarCliente(idElegido);
                Console.WriteLine("El cliente ha sido eliminado con éxtio! Presione 0 para continuar: ");
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