using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;

namespace sgi_app.application.services
{
    public class ProveedorService
    {
        private readonly IProveedorRepository _repo;

        public ProveedorService(IProveedorRepository repo){
            _repo = repo;
        }

        public void CrearProveedor(Proveedor proveedor){
            _repo.Crear(proveedor);
        }
        public void ObtenerProveedor(){
            var lista = _repo.ObtenerTodos();
            foreach(var c in lista){
                Console.WriteLine($"id: {c.Id} // nombre:{c.Nombre} // apellido: {c.Apellido} // Email:{c.Email} // Día pago: {c.DiaPago}");
            }
        }
        public void EliminarProveedor(string  idProveedor){
            _repo.Eliminar(idProveedor);
        }

        public void EditarProveedor(Proveedor proveedor) {
            _repo.Actualizar(proveedor);
        }

    }
}