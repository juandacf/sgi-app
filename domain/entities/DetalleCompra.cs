using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public DateTime Fecha {get;set;}
        public string IdProducto{get;set;}
        public int IdCompra {get;set;}
        public int Cantidad {get;set;}
        public double Valor {get;set;}
    }
}