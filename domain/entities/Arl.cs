using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Arl
    {
        public int Id {get;set;}
        public string Nombre {get;set;}

        public Arl(string Nombre, int Id){
            this.Nombre = Nombre;
            this.Id = Id;
        }
    }
}