using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Empresa
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public int Id_ciudad {get;set;}     
        public DateTime Fecha_Registro{get;set;}
        public Empresa(int Id, string Nombre, int Id_ciudad, DateTime Fecha_Registro ){
            this.Id = Id;
            this.Nombre = Nombre;
            this.Id_ciudad = Id_ciudad;
            this.Fecha_Registro =  Fecha_Registro;
        }
    }
}