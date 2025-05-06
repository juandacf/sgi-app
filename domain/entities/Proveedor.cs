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
        public double Descuento{get;set;}
        public int DiaPago {get;set;}

        //El id personal de cada tercero será establecido a través del serial de PSQL
        public Proveedor(string Id, string Nombre, string Apellido, string Email, int Id_Tipo_Documento, int Id_Tipo_Tercero, double Descuento, int DiaPago): base(Id, Nombre, Apellido, Email, Id_Tipo_Documento, Id_Tipo_Tercero){
            this.Descuento = Descuento;
            this.DiaPago = DiaPago;
        }
    }
}