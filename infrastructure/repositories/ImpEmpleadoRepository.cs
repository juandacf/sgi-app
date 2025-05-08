using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;
using Npgsql;
using System.Data;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.infrastructure.repositories
{
    public class ImpEmpleadoRepository : IGenericRepository<Empleado>, IEmpleadoRepository
    {
        private readonly ConexionPostgresSingleton _conexion;

        public ImpEmpleadoRepository(string connectionString)
        {
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
        }
        public void Actualizar(Empleado entity)
        {
            throw new NotImplementedException();
        }

        public void Crear(Empleado entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT INTO empleado(id,fecha_ingreso, salario_base, id_tercero, id_eps, id_arl) VALUES(@id,@nombre,@apellido,@email,@id_tipo_documento,@id_tipo_tercero,@id_ciudad)";
        }

        public void Eliminar(string var)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int var)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}