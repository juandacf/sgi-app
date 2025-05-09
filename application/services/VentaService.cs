using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;

namespace sgi_app.application.services;

public class VentaService
{
    private readonly IVentaRepository _repo;

    public VentaService(IVentaRepository repo)
    {
        _repo = repo;
    }

    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id_factura}, fecha: {c.Fecha}, Id Empleado = {c.IDTerceroEmpleado}, Id Cliente = {c.IdTerceroCliente}");
        }
    }

    public void CrearVenta(DateTime fecha, int idTerceroEmpleado, int idTerceroCliente)
    {
        _repo.Crear(new domain.entities.Venta { Fecha = fecha, IDTerceroEmpleado = idTerceroEmpleado, IdTerceroCliente = idTerceroCliente });
    }

    public void ActualizarVenta(int id, int idTerceroEmpleado, int idTerceroCliente)
    {
        _repo.Actualizar(new Venta { Id_factura = id, IDTerceroEmpleado = idTerceroEmpleado, IdTerceroCliente = idTerceroCliente });
    }

    public void EliminarVenta(int id)
    {
        _repo.Eliminar(id);
    }

    internal void CrearVenta(Venta venta)
    {
        _repo.Crear(venta);
    }
}
