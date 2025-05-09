using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;

namespace sgi_app.domain.factory //Este archivo nos permite utilizar las clases 
{
    public interface IDbFactory 
    {
      ICountryRepository  CreateCountryRepository();
      IArlRepository CreateArlRepository();
      IregionRepository CreateRegionRepository();
      ICiudadRepository CreateCiudadRepository();
      IEmpresaRepository CreateEmpresaRepository();
      ITerceroRepository CreateTerceroRepository();
      IEmpleadoRepository CreateEmpleadoRepository();
      IEpsRepository CreateEpsRepository();
      IMovCajaRepository CreateMovCajaRepository();
      IVentaRepository CreateVentaRepository();
      IClienteRepository CreateClienteRepository();
      ICompraRepository CreateCompraRepository();
    }
}