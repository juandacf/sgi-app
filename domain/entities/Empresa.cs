using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Empresa
    {
        public string Nombre {get;set;}
        public int Id_ciudad {get;set;}
        public string Fecha_Registro{get;set;}
        Empresa(string Nombre, int Id_ciudad, string Fecha_Registro ){
            this.Nombre = Nombre;
            this.Id_ciudad = Id_ciudad;
            this.Fecha_Registro =  Fecha_Registro;
        }
    }
}