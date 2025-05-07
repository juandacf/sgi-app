using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using sgi_app.domain.entities;
using sgi_app.domain.ports;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.infrastructure.repositories
{
    public class ImpCountryRepository:IGenericRepository<Pais>, ICountryRepository
    {
         private readonly ConexionPostgresSingleton _conexion;

         public ImpCountryRepository(string connectionString){
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
         }

        public void Actualizar(Pais pais)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "update pais set nombre=@nombre where id=@id";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("nombre", pais.Nombre);
            cmd.Parameters.AddWithValue("id", pais.Id);
            cmd.ExecuteNonQuery();
        }

        

        public void Crear(Pais pais)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT into pais(nombre) VALUES(@nombre)";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", pais.Nombre);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int idPais)
        {
             var connection = _conexion.ObtenerConexion();
             string query = "Delete from pais where id=@idPais";
             using var cmd = new NpgsqlCommand(query, connection);
             cmd.Parameters.AddWithValue("@idPais", idPais);
             cmd.ExecuteNonQuery();
        }

        public List<Pais> ObtenerTodos()
        {
            var clientes = new List<Pais>();
            var connection = _conexion.ObtenerConexion();
            string query = "SELECT id,nombre FROM pais";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while(reader.Read()) {
                clientes.Add(new Pais(reader.GetString("nombre"), reader.GetInt32("id")));
            }
            return clientes;
        }


    }
}