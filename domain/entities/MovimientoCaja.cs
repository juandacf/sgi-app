using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class MovimientoCaja
    {
        public string? Fecha {get;set;}
        public int IdTipoMovimientoCaja {get;set;}
        public double Valor {get;set;}
        public string? Concepto {get;set;}

        MovimientoCaja(string Fecha, int IdTipoMovimientoCaja, double Valor, string Concepto){
            this.Fecha = Fecha;
            this.IdTipoMovimientoCaja = IdTipoMovimientoCaja;
            this.Valor= Valor;
            this.Concepto = Concepto;
        }

    }
}