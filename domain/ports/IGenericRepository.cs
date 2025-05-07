using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.ports
{
    public interface IGenericRepository<T> // En esta declaración de la interfaz, la T simboliza cualquier tipo deobjeto. Cuando se implementa, en la interfaz específica del repositorio de cada clase, se debe especificar con el nombre de la clase.
    {
        List<T> ObtenerTodos();
        void  Crear(T entity);
        void Actualizar(T entity);
        void Eliminar (int var);
    }


}