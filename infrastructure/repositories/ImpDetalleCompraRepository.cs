using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using sgi_app.domain.entities;
using sgi_app.domain.ports;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.infrastructure.repositories;
public class ImpDetalleCompraRepository : IGenericRepository<DetalleCompra>, IDetalleCompraRepository
{
    private readonly ConexionPostgresSingleton _conexion;

    public ImpDetalleCompraRepository(string connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }

    public List<DetalleCompra> ObtenerTodos()
    {
        var detalleCompra = new List<DetalleCompra>();
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT id, fecha, id_producto, id_compra, cantidad, valor FROM detalle_compra";
        using var cmd = new NpgsqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            detalleCompra.Add(new DetalleCompra{
                Id = reader.GetInt32(0),
                Fecha = reader.GetDateTime(1),
                IdProducto = reader.GetString(2),
                IdCompra = reader.GetInt32(3),
                Cantidad = reader.GetInt32(4),
                Valor = reader.GetDouble(5)
            });
        }
        return detalleCompra;
    }

    public void Crear(DetalleCompra entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO detalle_compra(fecha, id_producto, id_compra, cantidad, valor) VALUES (@fecha, @idProducto, @idCompra, @cantidad, @valor);";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@fecha", entity.Fecha);
        cmd.Parameters.AddWithValue("@idProducto", entity.IdProducto);
        cmd.Parameters.AddWithValue("@idCompra", entity.IdCompra);
        cmd.Parameters.AddWithValue("@cantidad", entity.Cantidad);
        cmd.Parameters.AddWithValue("@valor", entity.Valor);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(DetalleCompra entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE detalle_compra SET cantidad = @cantidad WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.Id);
        cmd.Parameters.AddWithValue("@cantidad", entity.Cantidad);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM detalle_compra WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
