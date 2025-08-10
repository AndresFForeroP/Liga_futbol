using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_futbol.Src.Modules.Torneo.Application.Interfaces
{
    public interface ITorneoRepository
    {
        Task<Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo?> ConseguirPorId(int id);
        Task<IEnumerable<Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo?>> ConseguirTodo();
        void Añadir(Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo entidad);
        void Eliminar(Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo entidad);
        void Actualizar(Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo entidad);
        Task GuardarAsincronico();
    }
}