using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Liga_futbol.Src.Modules.Personal.Infrastructure.Repository
{
    public class PersonalRepository
    {
        private readonly AppDbContext _context;

        public PersonalRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Actualizar(Domain.Entities.Personal entidad, string nombre, string pais)
        {
            // entidad.Nombre = nombre;
            // entidad.Pais = pais;
        }

        public void Añadir(Domain.Entities.Personal entidad)
        {
            _context.Personal.Add(entidad);
        }

        public async Task<Domain.Entities.Personal?> ConseguirPorId(int id)
        {
            return await _context.Personal.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Domain.Entities.Personal?>> ConseguirTodo() =>
            await _context.Personal.ToListAsync();

        public void Eliminar(Domain.Entities.Personal entidad)
        {
            _context.Personal.Remove(entidad);
        }

        public async Task GuardarAsincronico()
        {
            await _context.SaveChangesAsync();
        }
    }
}