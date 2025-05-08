using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Empleado:Tercero
    {
        public DateTime FechaIngreso {get;set;}
        public double SalarioBase {get;set;}

        public int IdEps {get;set;}

        public int IdArl {get;set;}
//El id personal de cada tercero será establecido a través del serial de PSQL
        public Empleado(string Id, string Nombre, string Apellido, string Email, int Id_Tipo_Documento, int Id_Tipo_Tercero, DateTime FechaIngreso, double SalarioBase, int Id_Eps, int IdArl, int Id_ciudad): base(Id, Nombre, Apellido, Email, Id_Tipo_Documento, Id_Tipo_Tercero, Id_ciudad){
                this.FechaIngreso = FechaIngreso;
                this.SalarioBase = SalarioBase;
                this.IdEps = Id_Eps;
                this.IdArl = IdArl;
        }
    }
}