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

        public void ObtenerPais(){
            var lista = _repo.ObtenerTodos();
            foreach(var p in lista){
                Console.WriteLine($"id: {p.Id} // Nombre:{p.Nombre}");
            }
        }

        public void EliminarPais(int idPais){
            _repo.Eliminar(idPais);
        }

        public void EditarPais(Pais pais){
            _repo.Actualizar(pais);
        }
    }
}