using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;
using sgi_app.infrastructure.postgreSQL;
using Npgsql;

namespace sgi_app.infrastructure.repositories;
public class ImpPlanRepository : IGenericRepository<Plan>, IPlanRepository
{
    private readonly ConexionPostgresSingleton _conexion;
    public ImpPlanRepository(String connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }
    public List<Plan> ObtenerTodos()
    {
        var plan = new List<Plan>();
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT id, nombre, fecha_inicio, fecha_fin, dcto FROM plan;";
        using var cmd = new NpgsqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            plan.Add(new Plan
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                FechaInicio = reader.GetDateTime(2),
                FechaFin = reader.GetDateTime(3),
                Dcto = reader.GetDouble(4)
            });
        }
        return plan;
    }
    public void Crear(Plan entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO plan(nombre, fecha_inicio, fecha_fin, dcto) VALUES (@nombre, @fechaInicio, @fechaFin, @dcto)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", entity.Nombre);
        cmd.Parameters.AddWithValue("@fechaInicio", entity.FechaInicio);
        cmd.Parameters.AddWithValue("@fechaFin", entity.FechaFin);
        cmd.Parameters.AddWithValue("@dcto", entity.Dcto);
        cmd.ExecuteNonQuery();
    }
    public void Actualizar(Plan entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE plan SET nombre = @nombre WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.Id);
        cmd.Parameters.AddWithValue("@nombre", entity.Nombre);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM plan WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
