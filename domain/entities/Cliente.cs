using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Cliente: Tercero
    {

        public int Id_cliente {get;set;}
        public DateTime FechaNacimiento {get;set;}
        public DateTime FechaUltimaCompra {get;set;}

        public string IdTercero {get;set;}
        public Cliente(string Id, int Id_cliente, string Nombre, string Apellido, string Email, int Id_Tipo_Documento, int Id_Tipo_Tercero, DateTime FechaNacimiento, DateTime FechaUltimaCompra, int Id_ciudad):base(Id, Nombre, Apellido, Email, Id_Tipo_Documento, Id_Tipo_Tercero, Id_ciudad){
                this.Id_cliente = Id_cliente;
                this.FechaNacimiento = FechaNacimiento;
                this.FechaUltimaCompra = FechaUltimaCompra;
                this.IdTercero = IdTercero;

        }
    }
}