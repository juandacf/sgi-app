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
    public class ImpTerceroRepository : IGenericRepository<Tercero>, ITerceroRepository
    {
        private readonly ConexionPostgresSingleton _conexion;

        public ImpTerceroRepository(string connectionString)
        {
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
        }

        public void Actualizar(Tercero entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "update tercero set nombre=@nombre, apellido=@apellido, email=@email, id_tipo_documento=@id_tipo_documento, id_tipo_tercero=@id_tipo_tercero, id_ciudad=@id_ciudad where id=@id;";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", entity.Id);
            cmd.Parameters.AddWithValue("nombre", entity.Nombre);
            cmd.Parameters.AddWithValue("apellido", entity.Apellido);
            cmd.Parameters.AddWithValue("email", entity.Email);
            cmd.Parameters.AddWithValue("id_tipo_documento", entity.Id_Tipo_Documento);
            cmd.Parameters.AddWithValue("id_tipo_tercero", entity.Id_Tipo_Tercero);
            cmd.Parameters.AddWithValue("id_ciudad", entity.Id_ciudad);
            cmd.ExecuteNonQuery();
        }

        public void Crear(Tercero entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT INTO tercero(id,nombre,apellido,email,id_tipo_documento,id_tipo_tercero,id_ciudad) VALUES(@id,@nombre,@apellido,@email,@id_tipo_documento,@id_tipo_tercero,@id_ciudad)";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", entity.Id);
            cmd.Parameters.AddWithValue("nombre", entity.Nombre);
            cmd.Parameters.AddWithValue("apellido", entity.Apellido);
            cmd.Parameters.AddWithValue("email", entity.Email);
            cmd.Parameters.AddWithValue("id_tipo_documento", entity.Id_Tipo_Documento);
            cmd.Parameters.AddWithValue("id_tipo_tercero", entity.Id_Tipo_Tercero);
            cmd.Parameters.AddWithValue("id_ciudad", entity.Id_ciudad);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int var)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(string idTercero)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "Delete from tercero where id=@idTercero";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@idTercero", idTercero);
            cmd.ExecuteNonQuery();

        }

        public List<Tercero> ObtenerTodos()
        {
            var TerceroList = new List<Tercero>();
            var connection = _conexion.ObtenerConexion();
            string query = "SELECT id,nombre,apellido,email,id_tipo_documento, id_tipo_tercero, id_ciudad from tercero";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();
            while(reader.Read()){
                TerceroList.Add(new Tercero(reader.GetString("id"), reader.GetString("nombre"), reader.GetString("apellido"), reader.GetString("email"), reader.GetInt32("id_tipo_documento"), reader.GetInt32("id_tipo_tercero"), reader.GetInt32("id_ciudad")));
            }

            return TerceroList;
        }
    }
}