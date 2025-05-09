using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;
using sgi_app.infrastructure.postgreSQL;
using Npgsql;

namespace sgi_app.infrastructure.repositories;

public class ImpEpsRepository : IGenericRepository<Eps>, IEpsRepository
{
    private readonly ConexionPostgresSingleton _conexion;
    public ImpEpsRepository(String connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }
    public List<Eps> ObtenerTodos()
    {
        var eps = new List<Eps>();
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT id, nombre FROM eps";
        using var cmd = new NpgsqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            eps.Add(new Eps
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1)
            });
        }
        return eps;
    }

    public void Crear(Eps entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO eps(nombre) VALUES (@nombre)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", entity.Nombre);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Eps entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE eps SET nombre = @nombre WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.Id);
        cmd.Parameters.AddWithValue("@nombre", entity.Nombre);
        cmd.ExecuteNonQuery();
    }
    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
            string query = "DELETE FROM eps WHERE id = @id";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
    }
}