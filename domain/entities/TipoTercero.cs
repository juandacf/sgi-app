using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.Replication;

namespace sgi_app.domain.entities
{
    public class TipoTercero
    {
        public string Descripcion {get;set;}

        public TipoTercero(string Descripcion){
            this.Descripcion = Descripcion;
        }


    }
}