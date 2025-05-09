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
    public class ImpRegionRepository : IGenericRepository<Region>, IregionRepository
    {
        private readonly ConexionPostgresSingleton _conexion;
        public ImpRegionRepository(string connectionString)
        {
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
        }
        public void Actualizar(Region entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "update region set nombre=@nombre where id=@id;";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", entity.Nombre);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.ExecuteNonQuery();
        }

        public void Crear(Region entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT INTO region(nombre, id_pais) VALUES(@nombre,@id_pais)";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("nombre", entity.Nombre);
            cmd.Parameters.AddWithValue("id_pais", entity.Id_pais);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int idRegion)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "Delete from region where id=@idRegion";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@idRegion", idRegion);
            cmd.ExecuteNonQuery();
        }

        public List<Region> ObtenerTodos()
        {
            var RegionList = new List<Region>();
            var connection = _conexion.ObtenerConexion();
            string query = "SELECT id,id_pais,nombre from region";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader =  cmd.ExecuteReader();
            while(reader.Read()){
                RegionList.Add(new Region(reader.GetInt32("id"), reader.GetString("nombre"),reader.GetInt32("id_pais") ));
            }
            return RegionList;
        }
    }
}