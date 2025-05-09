using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;

namespace sgi_app.application.services;

public class MovCajaService
{
    private readonly IMovCajaRepository _repo;

    public MovCajaService(IMovCajaRepository repo)
    {
        _repo = repo;
    }

    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id}, Fecha: {c.Fecha}, Valor: {c.Valor}, Concepto: {c.Concepto}");
        }
    }

    public void CrearMovimientoCaja(DateTime fecha, int idtipomovcaja, double valor, string concepto)
    {
        _repo.Crear(new domain.entities.MovimientoCaja { Fecha = fecha, IdTipoMovimientoCaja = idtipomovcaja, Valor = valor, Concepto = concepto });
    }

    public void ActualizarMovCaja(int id, string concepto)
    {
        _repo.Actualizar(new MovimientoCaja {Id = id, Concepto = concepto });
    }
    
    public void EliminarMovCaja(int id)
    {
        _repo.Eliminar(id);
    }

    internal void CrearMovimientoCaja(MovimientoCaja movimientoCaja)
    {
        _repo.Crear(movimientoCaja);
    }
}
