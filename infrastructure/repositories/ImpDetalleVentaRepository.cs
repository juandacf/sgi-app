using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using sgi_app.domain.entities;
using sgi_app.domain.ports;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.infrastructure.repositories;
public class ImpDetalleVentaRepository : IGenericRepository<DetalleVenta>, IDetalleVentaRepository
{
    private readonly ConexionPostgresSingleton _conexion;

    public ImpDetalleVentaRepository(String connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }
    
    public List<DetalleVenta> ObtenerTodos()
    {
        var detalleVenta = new List<DetalleVenta>();
        var connecion = _conexion.ObtenerConexion();
        string query = "SELECT id, id_facturacion, id_producto, cantidad, valor FROM detalle_venta";
        using var cmd = new NpgsqlCommand(query, connecion);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            detalleVenta.Add(new DetalleVenta{
                Id = reader.GetInt32(0),
                IdFacturacion = reader.GetInt32(1),
                IdProducto = reader.GetString(2),
                Cantidad = reader.GetInt32(3),
                Valor = reader.GetInt32(4)
            });
        }
        return detalleVenta;
    }

    public void Crear(DetalleVenta entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO detalle_venta(id_facturacion, id_producto, cantidad, valor) VALUES (@idFacturacion, @idProducto, @cantidad, @valor);";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@idFacturacion", entity.IdFacturacion);
        cmd.Parameters.AddWithValue("@idProducto", entity.IdProducto);
        cmd.Parameters.AddWithValue("@cantidad", entity.Cantidad);
        cmd.Parameters.AddWithValue("@valor", entity.Valor);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(DetalleVenta entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE detalle_venta SET cantidad = @cantidad WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.Id);
        cmd.Parameters.AddWithValue("@cantidad", entity.Cantidad);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM detalle_venta WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
