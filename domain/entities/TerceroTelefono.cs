using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class TerceroTelefono
    {
        public int Numero {get;set;}
        public string? TipoTelefono {get;set;}
        public string? IdTercero {get;set;}

        public TerceroTelefono(int Numero, string TipoTelefono,  string IdTercero){
            this.Numero = Numero;
            this.TipoTelefono = TipoTelefono;
            this.IdTercero = IdTercero;
        }
    }
}