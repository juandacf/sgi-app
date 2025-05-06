using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Venta
    {
        // la fecha de la venta se ingresará con el NOW() de postgresql y el id con el serial

        public string? IDTerceroEmpleado {get;set;}

        public string? IdTerceroCliente {get;set;}

        Venta(string IDTerceroEmpleado, string IdTerceroCliente){
            this.IDTerceroEmpleado = IDTerceroEmpleado;
            this.IdTerceroCliente = IdTerceroCliente;
        }


    }
}