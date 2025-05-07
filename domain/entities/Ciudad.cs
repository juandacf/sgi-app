using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.Replication;

namespace sgi_app.domain.entities
{
    public class Ciudad(string Nombre, int Id_Pais)
    {
        public string Nombre {get;set;} = Nombre;
        public int Id_Pais {get;set;} = Id_Pais;

        
    }
}