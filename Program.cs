using Liga_futbol.Src.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var dbContext = DbContextFactory.Create();
        Console.WriteLine("DbContext creado exitosamente.");
        var equipo = dbContext.Jugador.Include(e => e.Persona).ToList();
        foreach (var item in equipo)
        {
            Console.WriteLine($"{item.Persona.Nombre}");
        }
    }
}