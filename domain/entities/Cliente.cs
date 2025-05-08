using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Cliente: Tercero
    {
        public string FechaNacimiento {get;set;}
        public string FechaUltimaCompra {get;set;}
//El id personal de cada tercero será establecido a través del serial de PSQL
        Cliente(string Id, string Nombre, string Apellido, string Email, int Id_Tipo_Documento, int Id_Tipo_Tercero, string FechaNacimiento, string FechaUltimaCompra, int Id_ciudad):base(Id, Nombre, Apellido, Email, Id_Tipo_Documento, Id_Tipo_Tercero, Id_ciudad){
                this.FechaNacimiento = FechaNacimiento;
                this.FechaUltimaCompra = FechaUltimaCompra;
        }
    }
}