using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Misc;

namespace sgi_app.domain.entities
{
    public class Producto
    {
        public string Id {get;set;}
        public string Nombre {get;set;}
        public int Stock {get;set;}
        public int StockMinimo {get;set;}
        public int StockMaxinmo {get;set;}
        // public string? CreatedAt {get;set;}
        // public string? UpdatedAt {get;set;}
        public string BarCode {get;set;}

        //El CreatedAT/UpdatedAt se hará con el método nativo de postgres NOW();

        Producto(string Id, string Nombre, int Stock, int StockMinimo, int StockMaxinmo, string BarCode){
                this.Id = Id;
                this.Nombre = Nombre;
                this.Stock = Stock;
                this.StockMinimo = StockMinimo;
                this.StockMaxinmo= StockMaxinmo;
                this.BarCode = BarCode;
        }
    }
}