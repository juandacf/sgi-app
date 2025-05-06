using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.Replication;

namespace sgi_app.domain.entities
{
    public class Ciudad
    {
        public string Nombre {get;set;}
        public int Id_Pais {get;set;}

        Ciudad(string Nombre, int Id_Pais){
            this.Nombre = Nombre;
            this.Id_Pais = Id_Pais;
        }
    }
}