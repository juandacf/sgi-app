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

        public ICiudadRepository CreateCiudadRepository(){
            return new ImpCiudadRepository(_connectionString);
        }

        public IEmpresaRepository CreateEmpresaRepository() {
            return new ImpEmpresaRepository(_connectionString);
        }

        public ITerceroRepository CreateTerceroRepository(){
            return new ImpTerceroRepository(_connectionString);
        }

        public IEmpleadoRepository CreateEmpleadoRepository(){
            return new ImpEmpleadoRepository(_connectionString);
        }

        public IEpsRepository CreateEpsRepository(){
            return new ImpEpsRepository(_connectionString);
        }

        public IMovCajaRepository CreateMovCajaRepository(){
            return new ImpMovCajaRepository(_connectionString);
        }

        public IVentaRepository CreateVentaRepository(){
            return new ImpVentaRepository(_connectionString);
        }
        
        public IClienteRepository CreateClienteRepository(){
            return new ImpClienteRepository(_connectionString);
        }
        
        public ICompraRepository CreateCompraRepository(){
            return new ImpCompraRepository(_connectionString);
        }
        public IProveedorRepository CreateProveedorRepository(){
            return new ImpProveedorRepository(_connectionString);
        }
        public IPlanRepository CreatePlanRepository(){
            return new ImpPlanRepository(_connectionString);
        }

    }
}