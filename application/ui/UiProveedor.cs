using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.application.ui
{
    public class UiProveedor
    {
        public static void MenuProveedor()
        {
            IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
            var ServicioProveedor = new ProveedorService(factory.CreateProveedorRepository());
            var ServicioTercero = new TerceroService(factory.CreateTerceroRepository());
            Console.Clear();
            Console.WriteLine("\n--- MENÚ PROVEEDOR ---");
            Console.WriteLine("\n1. Mostrar todos\t2. Crear nuevo\n3. Actualizar\t\t4. Eliminar\n0. Salir");
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

                        string IdProveedor = SolicitarValor("número de documento del proveedor");
                        string NombreProveedor = SolicitarValor("nombre del proveedor");
                        string ApellidoProveedor = SolicitarValor("apellido del proveedor");
                        string EmailProveedor = SolicitarValor("email del proveedor");
                        double DescuentoProveedor = SolicitarDouble("porcentaje de descuento del proveedor");
                        int DiaPagoProveedor = SolicitarInt("día del pago del proveedor");

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
                        string IdProveedorE = SolicitarValor("número de documento del proveedor que quiere editar");
                        string NombreProveedorE = SolicitarValor("nuevo nombre del proveedor");
                        string ApellidoProveedorE = SolicitarValor("nuevo apellido del proveedor");
                        string EmailProveedorE = SolicitarValor("nuevo email del proveedor");
                        double DescuentoProveedorE = SolicitarDouble("nuevo porcentaje de descuento del proveedor");
                        int DiaPagoProveedorE = SolicitarInt("nuevo día del pago del proveedor");

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
                        string IdAEliminar = SolicitarValor("id del proveedor a eliminar");
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

        private static string SolicitarValor(string campo)
        {
            string valor;
            do
            {
                Console.WriteLine($"Por favor, ingrese el {campo}: ");
                valor = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(valor))
                {
                    Console.WriteLine("Este campo es obligatorio. Intente nuevamente.");
                }
            } while (string.IsNullOrWhiteSpace(valor));

            return valor;
        }

        private static double SolicitarDouble(string campo)
        {
            double valor;
            while (true)
            {
                Console.WriteLine($"Por favor, ingrese el {campo}: ");
                if (double.TryParse(Console.ReadLine(), out valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Intente nuevamente.");
                }
            }
        }

        private static int SolicitarInt(string campo)
        {
            int valor;
            while (true)
            {
                Console.WriteLine($"Por favor, ingrese el {campo}: ");
                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Intente nuevamente.");
                }
            }
        }
    }
}
