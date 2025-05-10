using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.application.ui;
public class UiEmpresa
{
    public static void MenuEmpresa()
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var ServicioEmpresa = new EmpresaService(factory.CreateEmpresaRepository());
        var ServicioCiudad = new CiudadService(factory.CreateCiudadRepository());
        Console.Clear();
        Console.WriteLine("\n--- MENÚ EMPRESA ---");
        Console.WriteLine("\n1. Monstrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.Write("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    Console.Clear();
                    ServicioEmpresa.ObtenerEmpresa();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Por favor, ingrese el nombre de la empresa:");
                    string NombreEmpresa =Console.ReadLine();
                    ServicioCiudad.ObtenerCiudad();
                    Console.WriteLine("Por favor, ingrese el id de la ciudad: ");
                    int IdCiudad = int.Parse(Console.ReadLine());
                    Empresa empresa = new Empresa(0, NombreEmpresa, IdCiudad,DateTime.Now );
                    ServicioEmpresa.CrearEmpresa(empresa);
                    Console.WriteLine("La empresa ha sido añadida con éxito.");
                    break;
                case '3':
                    Console.Clear();
                    ServicioEmpresa.ObtenerEmpresa();
                    Console.WriteLine("Por favor, ingresa el id de la empresa que quieres actualizar: ");
                    int IdEmpresaActualizar = int.Parse(Console.ReadLine());
                    Console.WriteLine("Por favor, ingresa el nuevo nombre de la empresa: ");
                    string NuevoNombre = Console.ReadLine();
                    Empresa empresanueva = new Empresa(IdEmpresaActualizar, NuevoNombre,1, DateTime.Now);
                    ServicioEmpresa.EditarEmpresa(empresanueva);
                    Console.WriteLine("La actualización de la empresa fue exitosa: ");
                    break;
                case '4':
                    Console.Clear();
                    ServicioEmpresa.ObtenerEmpresa();
                    Console.WriteLine("Por favor ingrese el id de la empresa que quiere borrar:");
                    int EmpresaBorrarID = int.Parse(Console.ReadLine());
                    ServicioEmpresa.EliminarEmpresa(EmpresaBorrarID);
                    break;
                case '0':
                    UiEmpresas.MenuEmpresas();
                    break;
                default:
                    Console.WriteLine("Tecla no reconocida");
                    break;
            }
        }
    }
}
