using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities;
public class Venta
{
    // la fecha de la venta se ingresará con el NOW() de postgresql y el id con el serial
    public int Id_factura { get; set; }
    public DateTime Fecha { get; set; }
    public int IDTerceroEmpleado { get; set; }

    public int IdTerceroCliente { get; set; }

}