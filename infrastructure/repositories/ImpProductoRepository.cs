using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;
using sgi_app.infrastructure.postgreSQL;
using Npgsql;

namespace sgi_app.infrastructure.repositories;

public class ImpProductoRepository : IGenericRepository<Producto>, IProductoRepository
{
    private readonly ConexionPostgresSingleton _conexion;
    public ImpProductoRepository(String connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }

    public List<Producto> ObtenerTodos(){
        var producto = new List<Producto>();
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT id, nombre, stock, stock_min, stock_mac, barcode FROM producto;";
        using var cmd = new NpgsqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            producto.Add(new Producto
            {
                Id = reader.GetString(0),
                Nombre = reader.GetString(1),
                Stock = reader.GetInt32(2),
                StockMinimo = reader.GetInt32(3),
                StockMaximo = reader.GetInt32(4),
                BarCode = reader.GetString(5)
            });
        }
        return producto;
    }

    public void Crear(Producto entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO producto(id, nombre, stock, stock_min, stock_mac, barcode) VALUES (@id, @nombre, @stock, @stockmin, @stockmac, @barcode)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.Id);
        cmd.Parameters.AddWithValue("@nombre", entity.Nombre);
        cmd.Parameters.AddWithValue("@stock", entity.Stock);
        cmd.Parameters.AddWithValue("@stockmin", entity.StockMinimo);
        cmd.Parameters.AddWithValue("@stockmac", entity.StockMaximo);
        cmd.Parameters.AddWithValue("@barcode", entity.BarCode);
        cmd.ExecuteNonQuery();
    }
    public void Actualizar(Producto entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE producto SET stock = @stock WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.Id);
        cmd.Parameters.AddWithValue("@stock", entity.Stock);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int var)
        {
            throw new NotImplementedException();
        }

    public void Eliminar(string id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM producto WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
