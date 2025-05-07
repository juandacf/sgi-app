using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;

namespace sgi_app.application.services
{
    public class RegionService
    {
        private readonly IregionRepository _repo;

        public RegionService(IregionRepository repo){
            _repo =repo;
        }

        public void CrearRegion(Region region){
            _repo.Crear(region);
        }
        public void ObtenerRegion(){
            var lista = _repo.ObtenerTodos();
            foreach(var r in lista){
                Console.WriteLine($"id: {r.Id} // Nombre:{r.Nombre}");
            }
        }
        public void EliminarRegion(int idRegion){
            _repo.Eliminar(idRegion);
        }

        public void EditarRegion(Region region){
            _repo.Actualizar(region);
        }

    }
}