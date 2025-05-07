using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;

namespace sgi_app.application.services
{
    public class ArlService
    {
        private readonly IArlRepository _repo;

        public ArlService(IArlRepository repo){
            _repo =repo;
        }

        public void CrearArl(Arl arl){
            _repo.Crear(arl);
        }

        public void ObtenerArl(){
            var lista = _repo.ObtenerTodos();
            foreach(var a in lista){
                Console.WriteLine($"id: {a.Id} // nombre:{a.Nombre}");
            }
        }

        public void EliminarArl(int idArl){
            _repo.Eliminar(idArl);
        }

        public void EditarArl(Arl arl){
            _repo.Actualizar(arl);
        }
    }
}