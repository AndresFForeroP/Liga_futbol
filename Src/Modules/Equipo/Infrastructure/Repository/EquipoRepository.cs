using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Equipo.Application.Interfaces;
using Liga_futbol.Src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Liga_futbol.Src.Modules.Equipo.Infrastructure.Repository
{
    public class EquipoRepository : IEquipoRepository
    {
        private readonly AppDbContext _context;

        public EquipoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Actualizar(Domain.Entities.Equipo entidad, string nombre, int capacidad, DateTime fechaInicio, DateTime fechaFin)
        {
            entidad.Nombre = nombre;
        }

        public void Añadir(Domain.Entities.Equipo entidad)
        {
            _context.Equipo.Add(entidad);
        }

        public async Task<Domain.Entities.Equipo?> ConseguirPorId(int id)
        {
            return await _context.Equipo.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Domain.Entities.Equipo?>> ConseguirTodo() =>
            await _context.Equipo.ToListAsync();

        public void Eliminar(Domain.Entities.Equipo entidad)
        {
            _context.Equipo.Remove(entidad);
        }

        public async Task GuardarAsincronico()
        {
            await _context.SaveChangesAsync();
        }
    }
}