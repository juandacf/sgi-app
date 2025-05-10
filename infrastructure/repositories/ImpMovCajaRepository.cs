using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;
using sgi_app.infrastructure.postgreSQL;
using Npgsql;

namespace sgi_app.infrastructure.repositories;

public class ImpMovCajaRepository : IGenericRepository<MovimientoCaja>, IMovCajaRepository
{
    private readonly ConexionPostgresSingleton _conexion;
    public ImpMovCajaRepository(String connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }
    public List<MovimientoCaja> ObtenerTodos()
    {
        var movCaja = new List<MovimientoCaja>();
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT id, fecha, id_tipo_movimiento_caja, valor, concepto FROM movimiento_caja";
        using var cmd = new NpgsqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            movCaja.Add(new MovimientoCaja
            {
                Id = reader.GetInt32(0),
                Fecha = reader.GetDateTime(1),
                IdTipoMovimientoCaja = reader.GetInt32(2),
                Valor = reader.GetDouble(3),
                Concepto = reader.GetString(4)
            });
        }
        return movCaja;
    }

    public void Crear(MovimientoCaja entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO movimiento_caja(fecha, id_tipo_movimiento_caja, valor, concepto) VALUES (@fecha, @idTipoMov, @valor, @concepto)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@fecha", entity.Fecha);
        cmd.Parameters.AddWithValue("@idTipoMov", entity.IdTipoMovimientoCaja);
        cmd.Parameters.AddWithValue("@valor", entity.Valor);
        cmd.Parameters.AddWithValue("@concepto", entity.Concepto);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(MovimientoCaja entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE movimiento_caja SET concepto = @concepto WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.Id);
        cmd.Parameters.AddWithValue("@concepto", entity.Concepto);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM movimiento_caja WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

}
