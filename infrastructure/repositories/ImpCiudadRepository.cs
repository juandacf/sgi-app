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
    public class ImpCiudadRepository: IGenericRepository<Ciudad>, ICiudadRepository
    {
        private readonly ConexionPostgresSingleton _conexion;

        public ImpCiudadRepository(string connectionString){
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
        }

        public void Crear(Ciudad ciudad){
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT into ciudad(nombre, id_region) VALUES(@nombre, @id_region)";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", ciudad.Nombre);
            cmd.Parameters.AddWithValue("@id_region", ciudad.Id_Region);
            cmd.ExecuteNonQuery();

        }
        public void Actualizar(Ciudad ciudad){
            var connection = _conexion.ObtenerConexion();
            string query = "update ciudad set nombre=@nombre where id=@id";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", ciudad.Id);
            cmd.Parameters.AddWithValue("@nombre", ciudad.Nombre);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar (int idCiudad){
             var connection = _conexion.ObtenerConexion();
             string query = "Delete from ciudad where id=@idCiudad";
             using var cmd = new NpgsqlCommand(query, connection);
             cmd.Parameters.AddWithValue("@idCiudad", idCiudad);
             cmd.ExecuteNonQuery();
        }

        public List<Ciudad> ObtenerTodos() {
            var ciudades = new List<Ciudad>();
            var connection = _conexion.ObtenerConexion();
            string query = "SELECT id,nombre,id_region FROM ciudad;";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while(reader.Read()) {
                ciudades.Add(new Ciudad(reader.GetInt32("id"), reader.GetString("nombre"), reader.GetInt32("id_region")));
            }
            return ciudades;
        }
    }
}