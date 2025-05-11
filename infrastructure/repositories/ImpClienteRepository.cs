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
    public class ImpClienteRepository : IGenericRepository<Cliente>, IClienteRepository
    {
        private readonly ConexionPostgresSingleton _conexion;

        public ImpClienteRepository(string connectionString)
        {
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
        }

        public void Actualizar(Cliente entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "update cliente set id_tercero= @id_tercero where id_tercero=@id_tercero";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id_tercero", entity.Id);
            cmd.ExecuteNonQuery();
        }

        public void Crear(Cliente entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "insert into cliente(id_tercero, fecha_nacimiento, fecha_ultima_compra) values (@id_tercero, @fecha_nacimiento, @fecha_ultima_compra);";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id_tercero", entity.Id);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", entity.FechaNacimiento);
            cmd.Parameters.AddWithValue("@fecha_ultima_compra", entity.FechaUltimaCompra);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(string id_cliente)
        {
            
            var connection = _conexion.ObtenerConexion();
            string query = "delete from cliente where id_tercero=@id";;
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id_cliente);
            cmd.ExecuteNonQuery();
        }
        public void Eliminar(int idCliente)
        {
            throw new NotImplementedException();
        }


        public List<Cliente> ObtenerTodos()
        {
            var connection = _conexion.ObtenerConexion();
            var ListaClientes = new List<Cliente>();
            string query = "select t.ID as id_tercero, t.nombre, t.apellido, t.email, t.Id_tipo_documento, t.Id_tipo_tercero, t.Id_ciudad, c.id as id_cliente, c.fecha_nacimiento, c.fecha_ultima_compra  from tercero as t inner join cliente as c on t.id = c.Id_tercero;";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();
            while(reader.Read()){
                ListaClientes.Add(new Cliente(reader.GetString("id_tercero"), reader.GetInt32("id_cliente"), reader.GetString("nombre"), reader.GetString("apellido"), reader.GetString("Email"), reader.GetInt32("Id_tipo_documento"), reader.GetInt32("Id_tipo_tercero"), reader.GetDateTime("fecha_nacimiento"), reader.GetDateTime ("fecha_ultima_compra"), reader.GetInt32("Id_ciudad")  ));
            }
            return ListaClientes;
        }
    }
}