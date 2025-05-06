using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities;

namespace sgi_app.domain.entities
{
    public class DetalleVenta
    {
        public int IdFacturacion {get;set;}
        public string? IdProducto {get;set;}
        public int Cantidad {get;set;}
        public int Valor {get;set;}

        DetalleVenta(int IdFacturacion, string IdProducto, int Cantidad, int Valor){
            this.IdFacturacion =IdFacturacion;
            this.IdProducto = IdProducto;
            this.Cantidad = Cantidad;
            this.Valor = Valor;
        }


    }
}