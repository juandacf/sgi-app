using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;

namespace sgi_app.application.services
{
    public class PaisService
    {
        private readonly ICountryRepository _repo;

        public PaisService(ICountryRepository repo){
            _repo =repo;
        }

        public void CrearPais(Pais pais){
            _repo.Crear(pais);
        }
    }
}