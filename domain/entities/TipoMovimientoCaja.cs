using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class TipoMovimientoCaja
    {
        public string Nombre {get;set;}
        public bool Tipo {get;set;}

        TipoMovimientoCaja(string Nombre, bool Tipo ){
            this.Nombre = Nombre;
            this.Tipo = Tipo;
        }
    }
}