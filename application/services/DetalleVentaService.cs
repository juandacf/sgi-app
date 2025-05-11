using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;
using System.Configuration;

namespace sgi_app.application.services;
public class DetalleVentaService
{
    private readonly IDetalleVentaRepository _repo;
    public DetalleVentaService(IDetalleVentaRepository repo)
    {
        _repo = repo;
    }

    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id}, Id_Facturacion: {c.IdFacturacion}, Id_Producto: {c.IdProducto}, Cantidad: {c.Cantidad}, Valor: {c.Valor}");
        }
    }

    public void CrearDetalleVentaRepository(int id_facturacion, string id_producto, int cantidad, double valor)
    {
        _repo.Crear(new domain.entities.DetalleVenta { IdFacturacion = id_facturacion, IdProducto = id_producto, Cantidad = cantidad, Valor = valor});
    }

    public void ActualizarDetalleVenta(int id, int cantidad)
    {
        _repo.Actualizar(new DetalleVenta { Id = id, Cantidad = cantidad});
    }

    public void EliminarDetalleVenta(int id)
    {
        _repo.Eliminar(id);
    }

    internal void CrearDetalleVenta(DetalleVenta detalleVenta)
    {
        _repo.Crear(detalleVenta);
    }
}
