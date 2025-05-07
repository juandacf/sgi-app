using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Eps
    {
        public string Nombre {get;set;}

        //El ID será puesto por el serial de PostgreSQL
        Eps(string Nombre){
            this.Nombre = Nombre;
        }
    }
}