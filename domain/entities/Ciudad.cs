using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.Replication;

namespace sgi_app.domain.entities
{
    public class Ciudad
    {
        public int Id {get;set;}
        public string Nombre {get;set;} 
        public int Id_Region {get;set;} 

        public Ciudad(int Id, string Nombre, int Id_Region){
            this.Id = Id;
            this.Nombre = Nombre;
            this.Id_Region = Id_Region;
        }

        
    }
}