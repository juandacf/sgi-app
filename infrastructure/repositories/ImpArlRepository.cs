using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.infrastructure.repositories
{
    public class ImpArlRepository : IGenericRepository<Arl>, IArlRepository
    {
        private readonly ConexionPostgresSingleton _conexion;
public ImpArlRepository(string connectionString){
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
         }        public void Actualizar(Arl entity)
        {
            throw new NotImplementedException();
        }

        public void Crear(Arl entity)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int var)
        {
            throw new NotImplementedException();
        }

        public List<Arl> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}