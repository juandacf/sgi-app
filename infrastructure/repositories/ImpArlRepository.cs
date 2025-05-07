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
    public class ImpArlRepository : IGenericRepository<Arl>, IArlRepository
    {
        private readonly ConexionPostgresSingleton _conexion;
public ImpArlRepository(string connectionString){
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
}       
         public void Actualizar(Arl entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "update arl set nombre=@nombre where id=@id";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("nombre", entity.Nombre);
            cmd.Parameters.AddWithValue("id", entity.Id);
            cmd.ExecuteNonQuery();
        }

        public void Crear(Arl entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT INTO arl(nombre) VALUES(@nombre)";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", entity.Nombre );
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int idArl)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "Delete from arl where id=@idArl";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@idArl", idArl );
            cmd.ExecuteNonQuery();
        }

        public List<Arl> ObtenerTodos()
        {
            var ArlList = new List<Arl>();
            var connection = _conexion.ObtenerConexion();
            string query = "SELECT id,nombre FROM arl";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                ArlList.Add(new Arl(reader.GetString("nombre"), reader.GetInt32("id")));
            }

            return ArlList;
        }
    }
}