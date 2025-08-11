using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Equipo.Application.Services;
using Liga_futbol.Src.Modules.Equipo.Infrastructure.Repository;
using Liga_futbol.Src.Modules.Torneo.UI;
using Liga_futbol.Src.Shared.Context;
using Liga_futbol.Src.Shared.Helpers;

namespace Liga_futbol.Src.Modules.Equipo.UI
{
    public class DibujoMenuEquipo
    {
        private readonly AppDbContext? _context;
        readonly EquipoRepository repo = null!;
        readonly ServicioAgregarEquipo _serviceAgregarEquipo = null!;
        public DibujoMenuEquipo()
        {
            var context = DbContextFactory.Create();
            _context = context;
            repo = new EquipoRepository(context);
            _serviceAgregarEquipo = new ServicioAgregarEquipo(repo);
        }
        public async Task Iniciar()
        {
            int salida = 0;
            do
            {
                Dibujar();
                if (!int.TryParse(Console.ReadLine(), out salida) || salida != 1 && salida != 2 && salida != 3 && salida != 4 && salida != 9)
                {
                    Console.Clear();
                    Console.WriteLine("VALOR INGRESADO NO VALIDO");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                if (salida == 1 || salida == 2 || salida == 3 || salida == 4)
                {
                    await SiguienteMenu(salida);
                }

            }
            while (salida != 9);
            Console.Clear();
            Console.WriteLine("VOLVIENDO AL MENU ANTERIOR...");
            Thread.Sleep(2000);
            Console.Clear();
            var menuGestionEquipo = new DibujoMenuGestionEquipo();
            await menuGestionEquipo.Iniciar();
        }
        public void Dibujar()
        {
            Console.Clear();
            Console.WriteLine(Mensaje);
        }
        public async Task SiguienteMenu(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Elegiste Agregar Equipo");
                    await _serviceAgregarEquipo.RegistrarNuevoEquipo();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Elegiste Buscar Equipo");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Elegiste Eliminar Equipo");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Elegiste Actualizar Equipo");
                    break;
            }
        }
        private string Mensaje = """
╔═════════════════════════════════════════╗
║   M E N Ú  G E S T I O N  E Q U I P O   ║
╠═════════════════════════════════════════╣
║  1. Agregar Equipo                      ║
║  2. Buscar Equipo                       ║
║  3. Eliminar Equipo                     ║
║  4. Actualizar Equipo                   ║
║  9. Volver Al Menu Anterior             ║
╚═════════════════════════════════════════╝
Ingrese un numero segun lo que desea realizar
""";
    }
}