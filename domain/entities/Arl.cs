using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Arl
    {
        public string? Nombre {get;set;}

        Arl(string Nombre){
            this.Nombre = Nombre;
        }
    }
}