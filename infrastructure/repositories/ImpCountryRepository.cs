using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using sgi_app.domain.entities;
using sgi_app.domain.ports;
using sgi_app.infrastructure.postgreSQL;

namespace sgi_app.infrastructure.repositories
{
    public class ImpCountryRepository:IGenericRepository<Pais>, ICountryRepository
    {
         private readonly ConexionPostgresSingleton _conexion;

         public ImpCountryRepository(string connectionString){
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
         }

        public void Actualizar(Pais entity)
        {
            throw new NotImplementedException();
        }

        public ICountryRepository CrearCountryRepository()
        {
            throw new NotImplementedException();
        }

        public void Crear(Pais pais)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT into pais(nombre) VALUES(@nombre)";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", pais.Nombre);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int var)
        {
            throw new NotImplementedException();
        }

        public List<Pais> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

       
    }
}