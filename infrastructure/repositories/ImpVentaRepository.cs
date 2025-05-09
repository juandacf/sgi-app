using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;
using sgi_app.infrastructure.postgreSQL;
using Npgsql;

namespace sgi_app.infrastructure.repositories;
public class ImpVentaRepository : IGenericRepository<Venta>, IVentaRepository
{
    private readonly ConexionPostgresSingleton _conexion;

    public ImpVentaRepository(String connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }

    public List<Venta> ObtenerTodos()
    {
        var venta = new List<Venta>();
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT id_factura, fecha, id_tercero_empleado, id_tercero_cliente FROM venta";
        using var cmd = new NpgsqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            venta.Add(new Venta
            {
                Id_factura = reader.GetInt32(0),
                Fecha = reader.GetDateTime(1),
                IDTerceroEmpleado = reader.GetInt32(2),
                IdTerceroCliente = reader.GetInt32(3),
            });
        }
        return venta;
    }
    public void Crear(Venta entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO venta(fecha, id_tercero_empleado, id_tercero_cliente) VALUES (@fecha, @idTerceroEmpleado, @idTerceroCliente);";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@fecha", entity.Fecha);
        cmd.Parameters.AddWithValue("@idTerceroEmpleado", entity.IDTerceroEmpleado);
        cmd.Parameters.AddWithValue("@idTerceroCliente", entity.IdTerceroCliente);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Venta entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE venta SET id_tercero_empleado = @idTerceroEmpleado, id_tercero_cliente = @idTerceroCliente WHERE id_factura = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.Id_factura);
        cmd.Parameters.AddWithValue("@idTerceroEmpleado", entity.IDTerceroEmpleado);
        cmd.Parameters.AddWithValue("@idTerceroCliente", entity.IdTerceroCliente);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM venta WHERE id_factura = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
