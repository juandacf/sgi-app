using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using Npgsql;
using sgi_app.application.services;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.domain.entities;

namespace sgi_app.application.ui;

    public class UiCiudad
    {
        public static void MenuCiudad(){
            string connectionDatabase = "server=localhost;database=miniproject;user=root;password=123456;";
            IDbFactory factory = new PostgresDbFactory(connectionDatabase);
            var servicioCiudad = new CiudadService(factory.CreateCiudadRepository());

            Console.Clear();
            Console.WriteLine("\n--- MENÚ CIUDADES ---");
            Console.WriteLine("\n1. Monstrar todas\t2. Crear nueva\n3. Actualizar\t\t4. Eliminar\n0. Salir");
            Console.Write("Opción: ");
            while(true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey();
                switch(KeyPressed.KeyChar)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
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
        
    }