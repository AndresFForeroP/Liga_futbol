using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_futbol.Src.Modules.Equipo.Application.Interfaces
{
    public interface IEquipoRepository
    {
        Task<Liga_futbol.Src.Modules.Equipo.Domain.Entities.Equipo?> ConseguirPorId(int id);
        Task<IEnumerable<Liga_futbol.Src.Modules.Equipo.Domain.Entities.Equipo?>> ConseguirTodo();
        void Añadir(Liga_futbol.Src.Modules.Equipo.Domain.Entities.Equipo entidad);
        void Eliminar(Liga_futbol.Src.Modules.Equipo.Domain.Entities.Equipo entidad);
        void Actualizar(Liga_futbol.Src.Modules.Equipo.Domain.Entities.Equipo entidad,string nombre,string pais);
        Task GuardarAsincronico();
    }
}