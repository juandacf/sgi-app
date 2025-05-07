using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Misc;

namespace sgi_app.domain.entities
{
    public class Pais(string Nombre, int Id)
    {
        public string? Nombre { get; set; } = Nombre;
        public int Id {get;set;} = Id;
    }
}