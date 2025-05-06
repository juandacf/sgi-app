using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class DetalleCompra
    {
        public string? Date {get;set;}
        public string? IdProducto{get;set;}
        public int IdCompra {get;set;}
        public int Cantidad {get;set;}
        public int valor {get;set;}

        DetalleCompra(string Date, string IdProducto, int IdCompra, int Cantidad, int valor){
            this.Date =Date;
            this.IdProducto = IdProducto;
            this.IdCompra = IdCompra;
            this.Cantidad = Cantidad;
            this.valor = valor;
        }
    }
}