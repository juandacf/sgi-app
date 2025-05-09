using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class MovimientoCaja
    {
        public int Id { get; set;}
        public DateTime Fecha {get;set;}
        public int IdTipoMovimientoCaja {get;set;}
        public double Valor {get;set;}
        public string Concepto {get;set;}

    }
}