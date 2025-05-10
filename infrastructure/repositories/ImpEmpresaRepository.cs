using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf;
using Npgsql;
using sgi_app.domain.entities;
using sgi_app.domain.ports;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.infrastructure.repositories
{
    public class ImpEmpresaRepository : IGenericRepository<Empresa>, IEmpresaRepository
    {
        private readonly ConexionPostgresSingleton _conexion;

        public ImpEmpresaRepository (string connectionString){
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
         }

        public void Actualizar(Empresa empresa)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "update empresa set nombre=@nombre where id=@id;";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", empresa.Nombre);
            cmd.Parameters.AddWithValue("@ciudad_id", empresa.Id_ciudad);
            cmd.Parameters.AddWithValue("@id", empresa.Id);
            cmd.ExecuteNonQuery();

        }

        public void Crear(Empresa entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT into empresa(nombre,ciudad_id,fecha_registro) VALUES(@nombre,@ciudad_id, NOW())";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", entity.Nombre);
            cmd.Parameters.AddWithValue("@ciudad_id", entity.Id_ciudad);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int idEmpresa)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "Delete from empresa where id=@idEmpresa";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);
            cmd.ExecuteNonQuery();
        }

        public List<Empresa> ObtenerTodos()
        {
            var Empresas = new List<Empresa>();
            var connection = _conexion.ObtenerConexion();
            string query = "SELECT id,nombre,ciudad_id,fecha_registro FROM empresa";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while(reader.Read()){
                Empresas.Add(new Empresa(reader.GetInt32("id"), reader.GetString("nombre"), reader.GetInt32("ciudad_id"), reader.GetDateTime("fecha_registro")));
            }
            return Empresas;
        }
    }
}