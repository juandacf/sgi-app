using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Empleado:Tercero
    {
        public string FechaIngreso {get;set;}
        public double SalarioBase {get;set;}
//El id personal de cada tercero será establecido a través del serial de PSQL
        public Empleado(string Id, string Nombre, string Apellido, string Email, int Id_Tipo_Documento, int Id_Tipo_Tercero, string FechaIngreso, double SalarioBase, int Id_ciudad): base(Id, Nombre, Apellido, Email, Id_Tipo_Documento, Id_Tipo_Tercero, Id_ciudad){
                this.FechaIngreso = FechaIngreso;
                this.SalarioBase = SalarioBase;
        }
    }
}