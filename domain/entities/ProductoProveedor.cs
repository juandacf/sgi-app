using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class ProductoProveedor
    {
        public string? Id_Proveedor {get;set;}
        public string Id_Producto {get;set;}

        ProductoProveedor(string Id_Producto, string Id_Proveedor){
            this.Id_Producto = Id_Producto;
            this.Id_Proveedor = Id_Proveedor;
        }
    }
}