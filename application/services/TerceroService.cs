using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;

namespace sgi_app.application.services
{
    public class TerceroService
    {
        private readonly ITerceroRepository _repo;

        public TerceroService(ITerceroRepository repo){
            _repo = repo;
        }

        public void CrearTercero(Tercero tercero){
            _repo.Crear(tercero);
        }

        public void ObtenerTerceros(){
            var lista = _repo.ObtenerTodos();
            foreach(var c in lista){
                Console.WriteLine($"id: {c.Id} // nombre:{c.Nombre} // apellido: {c.Apellido} // Email:{c.Email}");
            }
        }

        public void EliminarTercero(string idTercero){
            _repo.Eliminar(idTercero);
        }

        public void EditarTercero(Tercero tercero) {
            _repo.Actualizar(tercero);
        }
    }
}