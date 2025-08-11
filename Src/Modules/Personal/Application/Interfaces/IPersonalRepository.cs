using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_futbol.Src.Modules.Personal.Application.Interfaces
{
    public interface IPersonalRepository
    {
        Task<Liga_futbol.Src.Modules.Personal.Domain.Entities.Personal?> ConseguirPorId(int id);
        Task<IEnumerable<Liga_futbol.Src.Modules.Personal.Domain.Entities.Personal?>> ConseguirTodo();
        void Añadir(Liga_futbol.Src.Modules.Personal.Domain.Entities.Personal entidad);
        void Eliminar(Liga_futbol.Src.Modules.Personal.Domain.Entities.Personal entidad);
        void Actualizar(Liga_futbol.Src.Modules.Personal.Domain.Entities.Personal entidad,string nombre,string pais);
        Task GuardarAsincronico();
    }
}