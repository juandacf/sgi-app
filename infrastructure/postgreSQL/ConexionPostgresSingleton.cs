using System;
using Npgsql;

namespace sgi_app.infrastructure.postgreSQL
{
public class ConexionPostgresSingleton
{
private static ConexionPostgresSingleton _instancia;
private readonly string _connectionString;
private NpgsqlConnection _conexion;
private ConexionPostgresSingleton(string connectionString)
{
_connectionString = connectionString;
}
public static ConexionPostgresSingleton Instancia(string connectionString)
{
_instancia ??= new ConexionPostgresSingleton(connectionString);
return _instancia;
}
public NpgsqlConnection ObtenerConexion()
{
_conexion ??= new NpgsqlConnection(_connectionString);

if (_conexion.State != System.Data.ConnectionState.Open)
_conexion.Open();

return _conexion;
}

        internal object ObetenerConexion()
        {
            throw new NotImplementedException();
        }
    }
}