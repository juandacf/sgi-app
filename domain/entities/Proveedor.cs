using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Misc;
using sgi_app.domain;

namespace sgi_app.domain.entities
{
    public class Proveedor: Tercero
    {
        public int IdProveedor {get;set;}
        public double Descuento{get;set;}
        public int DiaPago {get;set;}

        
        public Proveedor(int IdProveedor, string Id, string Nombre, string Apellido, string Email, int Id_Tipo_Documento, int Id_Tipo_Tercero, double Descuento, int DiaPago, int Id_ciudad): base(Id, Nombre, Apellido, Email, Id_Tipo_Documento, Id_Tipo_Tercero, Id_ciudad){
            this.IdProveedor = IdProveedor;
            this.Descuento = Descuento;
            this.DiaPago = DiaPago;
        }
    }
}