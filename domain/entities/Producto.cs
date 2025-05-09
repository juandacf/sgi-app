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
        public string BarCode {get;set;}
    }
}