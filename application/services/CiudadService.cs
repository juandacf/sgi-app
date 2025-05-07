using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;

namespace sgi_app.application.services
{
    public class CiudadService
    {
        private readonly ICiudadRepository _repo;

        public CiudadService(ICiudadRepository repo){
            _repo = repo;
        }

        public void CrearCiudad(Ciudad ciudad){
            _repo.Crear(ciudad);
        }

        public void ObtenerCiudad(){
            var lista = _repo.ObtenerTodos();
            foreach(var c in lista){
                Console.WriteLine($"id: {c.Id} // nombre:{c.Nombre}");
            }
        }

        public void EliminarCiudad(int idCiudad){
            _repo.Eliminar(idCiudad);
        }

        public void EditarCiudad (Ciudad ciudad) {
            _repo.Actualizar(ciudad);
        }
    }
}