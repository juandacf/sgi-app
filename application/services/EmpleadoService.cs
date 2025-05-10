using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;

namespace sgi_app.application.services
{
    public class EmpleadoService
    {
        private readonly IEmpleadoRepository _repo;

        public EmpleadoService(IEmpleadoRepository repo){
            _repo = repo;
        }

        public void CrearEmpleado(Empleado empleado){
            _repo.Crear(empleado);
        }

        public void ObtenerEmpleado(){
            var lista = _repo.ObtenerTodos();
            foreach(var c in lista){
                Console.WriteLine($"id: {c.Id} // nombre:{c.Nombre} // apellido: {c.Apellido} // Email:{c.Email} // Salario:{c.SalarioBase}");
            }
        }
        public void EliminarEmpleado(string idEmpleado){
            _repo.Eliminar(idEmpleado);
        }

        public void EditarEmpleado(Empleado empleado) {
            _repo.Actualizar(empleado);
        }
    }
}