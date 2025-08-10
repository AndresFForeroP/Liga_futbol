using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Torneo.Application.Interfaces;
using Liga_futbol.Src.Modules.Torneo.Application.Services;
using Liga_futbol.Src.Modules.Torneo.Interfaces.Repositories;
using Liga_futbol.Src.Modules.Torneo.UI;
using Liga_futbol.Src.Shared.Context;
using Liga_futbol.Src.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // var dbContext = DbContextFactory.Create();
        // Console.WriteLine("DbContext creado exitosamente.");
        // var equipo = dbContext.Jugador.Include(e => e.Persona).ToList();
        // foreach (var item in equipo)
        // {
        //     Console.WriteLine($"{item.Persona.Nombre}");
        // }
        // var Program = new Program();
        // await Program.iniciar();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        var saludo = new DibujoSaludo();
        var menuPrincipal = new DibujoMenuPrincipal();
        saludo.Iniciar();
        await menuPrincipal.Iniciar();
    }
}