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
        var servicioTercero = new TerceroService(factory.CreateTerceroRepository());
        var servicioCliente = new ClienteService(factory.CreateClienteRepository());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ CLIENTE ---");
            Console.WriteLine("\n1. Mostrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Console.WriteLine();

            switch (keyPressed.KeyChar)
            {
                case '1':
                    Console.Clear();
                    servicioCliente.ObtenerCliente();
                    Console.WriteLine("Presione cualquier tecla para volver al menú...");
                    Console.ReadKey(true);
                    break;

                case '2':
                    Console.Clear();
                    Console.Write("Ingrese el número de documento del cliente: ");
                    string idCliente = Console.ReadLine();

                    Console.Write("Ingrese el nombre del cliente: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Ingrese el apellido del cliente: ");
                    string apellido = Console.ReadLine();

                    Console.Write("Ingrese el correo electrónico del cliente: ");
                    string email = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(idCliente) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(email))
                    {
                        Console.WriteLine("❌ Todos los campos son obligatorios.");
                    }
                    else
                    {
                        Cliente nuevoCliente = new Cliente(
                            Id: idCliente,
                            Id_cliente: 1,
                            Nombre: nombre,
                            Apellido: apellido,
                            Email: email,
                            Id_Tipo_Documento: 1,
                            Id_Tipo_Tercero: 3,
                            FechaNacimiento: DateTime.Now,
                            FechaUltimaCompra: DateTime.Now,
                            Id_ciudad: 1
                        );

                        Tercero nuevoTercero = new Tercero(
                            Id: idCliente,
                            Nombre: nombre,
                            Apellido: apellido,
                            Email: email,
                            Id_Tipo_Documento: 1,
                            Id_Tipo_Tercero: 3,
                            Id_ciudad: 1
                        );

                        servicioTercero.CrearTercero(nuevoTercero);
                        servicioCliente.CrearCliente(nuevoCliente);
                        Console.WriteLine("✅ Cliente creado con éxito.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey(true);
                    break;

                case '3':
                    Console.Clear();
                    servicioCliente.ObtenerCliente();

                    Console.Write("Ingrese CC del cliente a actualizar: ");
                    string idActualizar = Console.ReadLine();

                    Console.Write("Nuevo nombre: ");
                    string nombreNuevo = Console.ReadLine();

                    Console.Write("Nuevo apellido: ");
                    string apellidoNuevo = Console.ReadLine();

                    Console.Write("Nuevo email: ");
                    string emailNuevo = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(idActualizar) || string.IsNullOrWhiteSpace(nombreNuevo) || string.IsNullOrWhiteSpace(apellidoNuevo) || string.IsNullOrWhiteSpace(emailNuevo))
                    {
                        Console.WriteLine("❌ Todos los campos son obligatorios.");
                    }
                    else
                    {
                        Cliente clienteActualizado = new Cliente(
                            Id: idActualizar,
                            Id_cliente: 1,
                            Nombre: nombreNuevo,
                            Apellido: apellidoNuevo,
                            Email: emailNuevo,
                            Id_Tipo_Documento: 1,
                            Id_Tipo_Tercero: 3,
                            FechaNacimiento: DateTime.Now,
                            FechaUltimaCompra: DateTime.Now,
                            Id_ciudad: 1
                        );

                        Tercero terceroActualizado = new Tercero(
                            Id: idActualizar,
                            Nombre: nombreNuevo,
                            Apellido: apellidoNuevo,
                            Email: emailNuevo,
                            Id_Tipo_Documento: 1,
                            Id_Tipo_Tercero: 3,
                            Id_ciudad: 1
                        );

                        servicioTercero.EditarTercero(terceroActualizado);
                        servicioCliente.EditarCliente(clienteActualizado);
                        Console.WriteLine("✅ Cliente actualizado con éxito.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey(true);
                    break;

                case '4':
                    Console.Clear();
                    servicioCliente.ObtenerCliente();

                    Console.Write("Ingrese el ID del cliente que desea eliminar: ");
                    string idEliminar = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(idEliminar))
                    {
                        Console.WriteLine("❌ El ID no puede estar vacío.");
                    }
                    else
                    {
                        servicioCliente.EliminarCliente(idEliminar);
                        Console.WriteLine("✅ Cliente eliminado con éxito.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey(true);
                    break;

                case '0':
                    UiTerceros.MenuTerceros();
                    return;

                default:
                    Console.WriteLine("❌ Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}
