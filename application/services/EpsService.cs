using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;

namespace sgi_app.application.services;
public class EpsService
{
    private readonly IEpsRepository _repo;

    public EpsService(IEpsRepository repo)
    {
        _repo = repo;
    }

    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}");
        }
    }

    public void CrearEps(string nombre)
    {
        _repo.Crear(new domain.entities.Eps {Nombre = nombre});
    }

    public void ActualizarEps(int id, string nombre)
    {
        _repo.Actualizar(new Eps { Id = id, Nombre = nombre });
    }

    public void EliminarEps(int id)
    {
        _repo.Eliminar(id);
    }

    internal void CrearEps(Eps eps)
    {
        _repo.Crear(eps);
    }
}
