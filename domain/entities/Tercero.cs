using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Tercero
    {
        public string Id {get;set;}
        public string Nombre {get;set;}
        public string Apellido {get;set;}
        public string Email {get;set;}
        public int Id_Tipo_Documento {get;set;}
        public  int Id_Tipo_Tercero {get;set;}

        public Tercero(string Id, string Nombre, string Apellido, string Email, int Id_Tipo_Documento, int Id_Tipo_Tercero ){
                    this.Id = Id;
                    this.Nombre = Nombre;
                    this.Apellido = Apellido;
                    this.Email = Email;
                    this.Id_Tipo_Documento = Id_Tipo_Documento;
                    this.Id_Tipo_Tercero = Id_Tipo_Tercero;
        }
    }
}