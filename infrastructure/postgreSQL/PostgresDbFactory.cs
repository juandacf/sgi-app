using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.factory;
using sgi_app.domain.ports;
using sgi_app.infrastructure.repositories;

namespace sgi_app.infrastructure.postgreSQL
{
    public class PostgresDbFactory : IDbFactory
    {
        private readonly string _connectionString;

        public PostgresDbFactory(string connectionString){
            _connectionString = connectionString;
        }
        public ICountryRepository CreateCountryRepository()
        {
            return new ImpCountryRepository(_connectionString);
        }

        public IArlRepository CreateArlRepository(){
            return new ImpArlRepository(_connectionString);
        }

        public IregionRepository CreateRegionRepository(){
            return new ImpRegionRepository(_connectionString);
        }
    }
}