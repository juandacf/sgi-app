using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Region
    {
        public string Nombre {get;set;}
        public int Id_pais {get;set;}

        Region(string Nombre, int Id_Pais){
            this.Nombre = Nombre;
            this.Id_pais = Id_Pais;
        }
    }
}