using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;

namespace sgi_app.application.services;
public class ProductoService
{
    private readonly IProductoRepository _repo;
    public ProductoService(IProductoRepository repo)
    {
        _repo = repo;
    }
    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}, stock: {c.Stock}");
        }
    }

    public void CrearProducto(string id, string nombre, int stock, int stockmin, int stockmax, string barcode)
    {
        _repo.Crear(new domain.entities.Producto {Id = id,  Nombre= nombre, Stock = stock, StockMinimo = stockmin, StockMaximo = stockmax, BarCode = barcode});
    }

    public void ActualizarProducto(string id, int stock)
    {
        _repo.Actualizar(new Producto { Id = id, Stock = stock });
    }

    public void EliminarProducto(string id)
    {
        _repo.Eliminar(id);
    }

    internal void CrearProducto(Producto producto)
    {
        _repo.Crear(producto);
    }
}
