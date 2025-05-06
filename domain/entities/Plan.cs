using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Plan
    {
        public string? Nombre {get;set;}
        public string? FechaInicio {get;set;}
        public string? FechaFin {get;set;}
        public int Descuento {get;set;}

        Plan(string Nombre, string FechaInicio, string FechaFin, int Descuento){
            this.Nombre = Nombre; 
            this.FechaInicio = FechaInicio;
            this.FechaFin = FechaFin;
            this.Descuento = Descuento;
        }
    }
}