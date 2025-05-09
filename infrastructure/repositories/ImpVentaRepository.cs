using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;
using sgi_app.infrastructure.postgreSQL;
using Npgsql;

namespace sgi_app.infrastructure.repositories;
public class ImpVentaRepository : IGenericRepository<Venta>, IVentaRepository
{
    private readonly ConexionPostgresSingleton _conexion;

    public ImpVentaRepository(String connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }

    public List<Venta> ObtenerTodos()
    {
        var venta = new List<Venta>();
        var connection = _conexion.ObetenerConexion();

    }
}
