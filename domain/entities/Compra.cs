using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Compra
    {
        // el id se asignará en postgresql

        public string? IdTerceroProveedor {get;set;}
        public string? IDTerceroEmpleado {get;set;}

        public Compra(string IdTerceroProveedor, string IDTerceroEmpleado){
            this.IdTerceroProveedor = IdTerceroProveedor;
            this.IDTerceroEmpleado =   IDTerceroEmpleado;
        }
    }
}