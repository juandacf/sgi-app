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
    public class ImpProveedorRepository : IGenericRepository<Proveedor>, IProveedorRepository
    {
        private readonly ConexionPostgresSingleton _conexion;

        public ImpProveedorRepository(string connectionString)
        {
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
        }

        public void Actualizar(Proveedor entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "update proveedor set descuento=@descuento, dia_pago=@dia_pago where id=@id;";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@descuento", entity.Descuento);
            cmd.Parameters.AddWithValue("@dia_pago", entity.DiaPago);
            cmd.Parameters.AddWithValue("@id", entity.IdProveedor);
            cmd.ExecuteNonQuery();
        }

        public void Crear(Proveedor entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "insert into proveedor(descuento, dia_pago, id_tercero) values(@descuento, @dia_pago, @id_tercero);";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@descuento", entity.Descuento);
            cmd.Parameters.AddWithValue("@dia_pago", entity.DiaPago);
            cmd.Parameters.AddWithValue("@id_tercero", entity.Id);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int var)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "Delete from proveedor where id=@var";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@var", var);
            cmd.ExecuteNonQuery();
        }

        public List<Proveedor> ObtenerTodos()
        {
            var connection = _conexion.ObtenerConexion();
            var ProveedorList = new List<Proveedor>();
            string query = "SELECT t.Id as id_tercero, t.nombre, t.apellido, t.email, t.Id_tipo_documento, t.Id_tipo_tercero, t.Id_ciudad, p.Id as id_proveedor, p.descuento, p.dia_pago, p.Id_tercero  FROM tercero as t inner join proveedor as p on p.id_tercero = t.Id;";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();
             while(reader.Read()){
                ProveedorList.Add(new Proveedor(reader.GetInt32("id_proveedor"), reader.GetString("id_tercero"), reader.GetString("nombre"), reader.GetString("apellido"), reader.GetString("email"), reader.GetInt32("Id_Tipo_Documento"), reader.GetInt32("Id_Tipo_Tercero"), reader.GetDouble("descuento"), reader.GetInt32("dia_pago"), reader.GetInt32("Id_ciudad")  ));
             }
            return ProveedorList;
        }
    }
}