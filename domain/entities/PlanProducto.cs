using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.Replication;

namespace sgi_app.domain.entities
{
    public class PlanProducto
    {
        public int IdPlan {get;set;}
        public string IdProducto {get;set;}

        PlanProducto(int IdPlan, string IdProducto){
            this.IdPlan = IdPlan;
            this.IdProducto = IdProducto;
        }
    }
}