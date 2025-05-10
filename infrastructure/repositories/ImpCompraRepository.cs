using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using sgi_app.domain.entities;
using sgi_app.domain.ports;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.infrastructure.repositories;

public class ImpCompraRepository : IGenericRepository<Compra>, ICompraRepository
{
    private readonly ConexionPostgresSingleton _conexion;
    public ImpCompraRepository(string connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }

    public List<Compra> ObtenerTodos()
    {
        var compra = new List<Compra>();
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT id, id_tercero_proveedor, id_tercero_empleado, fecha, documento_compra FROM compra;";
        using var cmd = new NpgsqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            compra.Add(new Compra{
                Id = reader.GetInt32(0),
                IdTerceroProveedor = reader.GetInt32(1),
                IdTerceroEmpleado = reader.GetInt32(2),
                Fecha = reader.GetDateTime(3),
                DocumentoCompra = reader.GetString(4)
            });
        }
        return compra;
    }

    public void Crear(Compra entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO compra(id_tercero_proveedor, id_tercero_empleado, fecha, documento_compra) VALUES (@idTerceroProveedor, @idTerceroEmpleado, @fecha, @documentoCompra);";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@idTerceroProveedor", entity.IdTerceroProveedor);
        cmd.Parameters.AddWithValue("@idTerceroEmpleado", entity.IdTerceroEmpleado);
        cmd.Parameters.AddWithValue("@fecha", entity.Fecha);
        cmd.Parameters.AddWithValue("@documentoCompra", entity.DocumentoCompra);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Compra entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE compra SET documento_compra = @documentoCompra WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.Id);
        cmd.Parameters.AddWithValue("@documentoCompra", entity.DocumentoCompra);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM compra WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
