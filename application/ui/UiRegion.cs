using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
using sgi_app.domain.entities;
using sgi_app.domain.factory;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.ui;

namespace sgi_app.application.ui
{
    public class UiRegion
    {
        public static void MenuRegion()
        {
            IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
            var ServicioRegion = new RegionService(factory.CreateRegionRepository());
            var ServicioPais = new PaisService(factory.CreateCountryRepository());
            Console.Clear();
            Console.WriteLine("\n--- MENÚ REGIÓN ---");
            Console.WriteLine("\n1. Mostrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            while (true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey();
                switch (KeyPressed.KeyChar)
                {
                    case '1':
                        ServicioRegion.ObtenerRegion();
                        Console.WriteLine("Presione cualquier tecla para continuar");
                        Console.ReadKey();
                        MenuRegion();
                        break;

                    case '2':
                        Console.Clear();
                        ServicioPais.ObtenerPais();
                        int IdPais = SolicitarInt("id del país al que quiere anexar la región");
                        string NombreRegion = SolicitarValor("nombre de la región");

                        Region region = new Region(0, NombreRegion, IdPais);
                        ServicioRegion.CrearRegion(region);
                        Console.WriteLine("La región ha sido creada con éxito. Por favor, presione enter para volver al menú.");
                        Console.ReadKey(true);
                        MenuRegion();
                        break;

                    case '3':
                        Console.Clear();
                        ServicioRegion.ObtenerRegion();
                        int IdRegion = SolicitarInt("id de la región");
                        string NombreRegionEditable = SolicitarValor("nuevo nombre de la región");

                        Region regionEditada = new Region(IdRegion, NombreRegionEditable, 0);
                        ServicioRegion.EditarRegion(regionEditada);
                        Console.WriteLine("La región fue editada con éxito. Por favor, oprima enter para volver al menú.");
                        Console.ReadKey();
                        MenuRegion();
                        break;

                    case '4':
                        ServicioRegion.ObtenerRegion();
                        int RegionAEliminar = SolicitarInt("id de la región que desea eliminar");
                        ServicioRegion.EliminarRegion(RegionAEliminar);
                        Console.WriteLine("La región fue eliminada con éxito.");
                        break;

                    case '0':
                        UiLugares.MenuLugares();
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
