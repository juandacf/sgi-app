using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class TipoDocumento
    {
        public string Descripcion {get;set;}

        public TipoDocumento(string Descripcion){
            this.Descripcion = Descripcion;
        }
    }
}