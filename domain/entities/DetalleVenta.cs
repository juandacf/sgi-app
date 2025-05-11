using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities;

namespace sgi_app.domain.entities;
public class DetalleVenta
{
    public int Id { get; set; }
    public int IdFacturacion { get; set; }
    public string IdProducto { get; set; }
    public int Cantidad { get; set; }
    public double Valor { get; set; }
}
