using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;

namespace sgi_app.application.services;
public class PlanService
{
    private readonly IPlanRepository _repo;

    public PlanService(IPlanRepository repo)
    {
        _repo = repo;
    }

    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}, fechaInicio: {c.FechaInicio}, fechaFin: {c.FechaFin}, Descuento: {c.Dcto}");
        }
    }

    public void CrearPlan(string nombre, DateTime fechaInicio, DateTime fechaFin, double dcto)
    {
        _repo.Crear(new domain.entities.Plan {Nombre = nombre, FechaInicio = fechaInicio, FechaFin = fechaFin, Dcto = dcto});
    }

    public void ActualizarPlan(int id, string nombre)
    {
        _repo.Actualizar(new Plan { Id = id, Nombre = nombre });
    }

    public void EliminarPlan(int id)
    {
        _repo.Eliminar(id);
    }

    internal void CrearPlan(Plan plan)
    {
        _repo.Crear(plan);
    }
}
