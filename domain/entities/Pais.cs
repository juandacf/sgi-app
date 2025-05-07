using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Misc;

namespace sgi_app.domain.entities
{
    public class Pais
    {
        public string Nombre { get; set; } 
        public int Id {get;set;} 

        public Pais(String Nombre, int Id){
            this.Nombre = Nombre;
            this.Id = Id;
        }
    }
}