using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.domain.entities;

namespace sgi_app.application.services
{
    public class ClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService (IClienteRepository repo){
            _repo = repo;
        }

        public void CrearCliente(Cliente cliente){
            _repo.Crear(cliente);
        }

        public void ObtenerCliente(){
            var lista = _repo.ObtenerTodos();
            foreach(var c in lista){
                Console.WriteLine($"id: {c.Id_cliente} // nombre:{c.Nombre} // apellido: {c.Apellido} // Email:{c.Email} // Fecha Nacimiento:{c.FechaNacimiento}");
            }
        }

        public void EliminarCliente(int idCliente){
            _repo.Eliminar(idCliente);
        }

        public void EditarCliente(Cliente cliente) {
            _repo.Actualizar(cliente);
        }
    }
}