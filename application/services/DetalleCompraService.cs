using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;

namespace sgi_app.application.services;
public class DetalleCompraService
{
    private readonly IDetalleCompraRepository _repo;

    public DetalleCompraService(IDetalleCompraRepository repo)
    {
        _repo = repo;
    }

    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id}, Id_Compra: {c.IdCompra}, Id_Producto: {c.IdProducto}, Cantidad: {c.Cantidad}, Valor: {c.Valor}");
        }
    }

    public void CrearDetalleCompra(DetalleCompra detalleCompra)
    {
        _repo.Crear(detalleCompra);
    }

    public void ActualizarDetalleCompra(int id, int cantidad)
    {
        _repo.Actualizar(new DetalleCompra { Id = id, Cantidad = cantidad});
    }

    public void EliminarDetalleCompra(int id)
    {
        _repo.Eliminar(id);
    }

    internal void CrearDetalleVenta(DetalleCompra detalleCompra)
    {
        _repo.Crear(detalleCompra);
    }
}
