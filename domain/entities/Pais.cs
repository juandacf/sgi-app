using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Pais(string Nombre)
    {
        public string? Nombre { get; set; } = Nombre;
    }
}