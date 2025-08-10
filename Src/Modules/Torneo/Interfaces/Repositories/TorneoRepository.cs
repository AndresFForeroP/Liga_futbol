using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Torneo.Application.Interfaces;
using Liga_futbol.Src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Liga_futbol.Src.Modules.Torneo.Interfaces.Repositories
{
    public class TorneoRepository : ITorneoRepository
    {
        private readonly AppDbContext _context;

        public TorneoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Actualizar(Domain.Entities.Torneo entidad, string nombre, int capacidad, DateTime fechaInicio, DateTime fechaFin)
        {
            entidad.Nombre = nombre;
            entidad.Capacidad = capacidad;
            entidad.FechaInicio = fechaInicio;
            entidad.FechaFin = fechaFin;
        }

        public void Añadir(Domain.Entities.Torneo entidad)
        {
            _context.Torneo.Add(entidad);
        }

        public async Task<Domain.Entities.Torneo?> ConseguirPorId(int id)
        {
            return await _context.Torneo.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Domain.Entities.Torneo?>> ConseguirTodo() =>
            await _context.Torneo.ToListAsync();

        public void Eliminar(Domain.Entities.Torneo entidad)
        {
            _context.Torneo.Remove(entidad);
        }

        public async Task GuardarAsincronico()
        {
            await _context.SaveChangesAsync();
        }
    }
}