using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;

namespace sgi_app.application.services;

public class CompraService
{
    private readonly ICompraRepository _repo;

    public CompraService(ICompraRepository repo)
    {
        _repo = repo;
    }

    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"Id: {c.Id}, Id proveedor: {c.IdTerceroProveedor}, Id empleado: {c.IdTerceroEmpleado}, Documento Compra: {c.DocumentoCompra}");
        }
    }

    public void CrearCompra(int idTerceroProveedor, int idTerceroEmpleado, DateTime fecha, string documentoCompra)
    {
        _repo.Crear(new domain.entities.Compra { IdTerceroProveedor = idTerceroProveedor, IdTerceroEmpleado = idTerceroEmpleado, Fecha = fecha, DocumentoCompra = documentoCompra });
    }

    public void ActualizarCompra(int id, string documentoCompra)
    {
        _repo.Actualizar(new Compra { Id = id, DocumentoCompra = documentoCompra });
    }

    public void EliminarCompra(int id)
    {
        _repo.Eliminar(id);
    }

    internal void CrearCompra(Compra compra)
    {
        _repo.Crear(compra);
    }
}
