using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities;

public class Compra
{
    public int Id { get; set; }
    public int IdTerceroProveedor { get; set;}
    public int IdTerceroEmpleado { get; set;}
    public DateTime Fecha { get; set; }
    public string DocumentoCompra { get; set; }
}
