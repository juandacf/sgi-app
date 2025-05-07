using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;

namespace sgi_app.domain.ports
{
    public interface ICountryRepository : IGenericRepository<Pais>
    {
        void Crear(Pais pais);
        ICountryRepository CrearCountryRepository();
    }
}