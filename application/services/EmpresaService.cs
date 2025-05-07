using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;

namespace sgi_app.application.services
{
    public class EmpresaService
    {
        private readonly IEmpresaRepository _repo;


        public EmpresaService(IEmpresaRepository repo){
            _repo =repo;
        }

        public void CrearEmpresa(Empresa empresa){
            _repo.Crear(empresa);
        }

        public void ObtenerEmpresa(){
            var lista = _repo.ObtenerTodos();
            foreach(var a in lista){
                Console.WriteLine($"id: {a.Id} // nombre:{a.Nombre} // Fecha Registro: {a.Fecha_Registro}");
            }
        }

        public void EliminarEmpresa(int idEmpresa){
            _repo.Eliminar(idEmpresa);
        }

        public void EditarEmpresa(Empresa empresa){
            _repo.Actualizar(empresa);
        }

    }
}