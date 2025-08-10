using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_futbol.Src.Modules.Torneo.Application.Interfaces
{
    public interface ITorneoRepository
    {
        Task<Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo?> ConseguirPorId(int id);
        Task<IEnumerable<<Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo?>> ConseguirTodo();
    }
}