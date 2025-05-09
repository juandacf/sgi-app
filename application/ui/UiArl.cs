using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.ui;
public class UiArl
{
    
    public static void MenuArl()
    {
    IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
     var ServicioArl = new ArlService(factory.CreateArlRepository());
        Console.Clear();
        Console.WriteLine("\n--- MENÚ ARL ---");
        Console.WriteLine("\n1. Monstrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
        Console.Write("Opción: ");
        while (true)
        {
            ConsoleKeyInfo KeyPressed = Console.ReadKey();
            switch (KeyPressed.KeyChar)
            {
                case '1':
                    ServicioArl.ObtenerArl();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Por favor, ingrese el nombre de la arl: ");
                    string NombreArl = Console.ReadLine();
                    Arl arl = new Arl(NombreArl,0);
                    ServicioArl.CrearArl(arl);
                    Console.WriteLine("La Arl ha sido creada con éxito. Presione enter para volver al menú de Arl");
                    Console.ReadKey(true);
                    MenuArl();
                    break;
                case '3':
                    Console.Clear();
                    ServicioArl.ObtenerArl();
                    Console.WriteLine("Por favor, ingrese el id del Arl que quiere editar: ");
                    int ArlId =  int.Parse(Console.ReadLine());
                    Console.WriteLine("Por favor, ingrese el nuevo nombre de la Arl");
                    string NuevoNombreArl = Console.ReadLine();
                    Arl arlEditada = new Arl(NuevoNombreArl, ArlId);
                    ServicioArl.EditarArl(arlEditada);
                    Console.WriteLine("La Arl ha sido editada con éxito. Presione enter para volver al menú de Arl");
                    Console.ReadKey(true);
                    MenuArl();
                    break;
                case '4':
                    Console.Clear();
                    ServicioArl.ObtenerArl();
                    Console.WriteLine("Por favor, ingrese el id del Arl que quiere eliminar: ");
                    int ArlIdEliminar =  int.Parse(Console.ReadLine());    
                    ServicioArl.EliminarArl(ArlIdEliminar);
                    Console.WriteLine("La Arl ha sido eliminada con éxito. Presione enter para volver al menú de Arl");
                    Console.ReadKey(true);
                    MenuArl();
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