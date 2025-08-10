using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Torneo.Application.Services;
using Liga_futbol.Src.Modules.Torneo.Interfaces.Repositories;
using Liga_futbol.Src.Shared.Context;
using Liga_futbol.Src.Shared.Helpers;
using Liga_Futbol.src.InterfaceAdapters.MenuPrincipal;

namespace Liga_futbol.Src.Modules.Torneo.UI
{
    public class DibujoMenuTorneo
    {
        private readonly AppDbContext? _context;
        readonly TorneoRepository repo = null!;
        readonly ServicioAgregarTorneo _serviceAgregarTorneo = null!;
        readonly ServicioEliminarTorneo _serviceEliminarTorneo = null!;
        readonly ServicioBuscarTorneo _serviceBuscarTorneo = null!;
        readonly ServicioActualizarTorneo _serviceActualizarTorneo = null!;
        public DibujoMenuTorneo()
        {
            var context = DbContextFactory.Create();
            _context = context;
            repo = new TorneoRepository(context);
            _serviceAgregarTorneo = new ServicioAgregarTorneo(repo);
            _serviceEliminarTorneo = new ServicioEliminarTorneo(repo);
            _serviceBuscarTorneo = new ServicioBuscarTorneo(repo);
            _serviceActualizarTorneo = new ServicioActualizarTorneo(repo);
        }
        public async Task IniciarAsync()
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
                    Console.WriteLine("1");
                    await SiguienteMenuAsync(salida);
                }

            }
            while (salida != 9);
            Console.Clear();
            Console.WriteLine("VOLVIENDO AL MENU PRINCIPAL...");
            Thread.Sleep(2000);
            Console.Clear();
            var menuPrincipal = new DibujoMenuPrincipal();
            await menuPrincipal.Iniciar();
        }
        public void Dibujar()
        {
            Console.Clear();
            Console.WriteLine(Mensaje);
        }
        public async Task SiguienteMenuAsync(int opcion)
        {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Elegiste Agregar Torneo");
                        await _serviceAgregarTorneo.RegistrarNuevoTorneo();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Elegiste Buscar Torneo");
                        Console.WriteLine("Buscar por Id");
                        await _serviceBuscarTorneo.BuscarTorneo();
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Elegiste Eliminar Torneo");
                        await _serviceEliminarTorneo.EliminarTorneo();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Elegiste Actualizar Torneo");
                        await _serviceActualizarTorneo.ActualizarTorneo();
                        break;
                }
        }
        private string Mensaje = """
╔════════════════════════════════════╗
║       M E N Ú   T O R N E O        ║
╠════════════════════════════════════╣
║  1. Agregar Torneo                 ║
║  2. Buscar Torneo                  ║
║  3. Eliminar Torneo                ║
║  4. Actualizar Torneo              ║
║  9. Volver al Menu Principal       ║
╚════════════════════════════════════╝
Ingrese un numero segun lo que desea realizar
""";
    }
}