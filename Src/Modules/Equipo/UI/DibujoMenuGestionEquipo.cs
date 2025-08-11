using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Equipo.UI;

namespace Liga_futbol.Src.Modules.Torneo.UI
{
    public class DibujoMenuGestionEquipo
    {
        public async Task Iniciar()
        {
            int salida = 0;
            do
            {
                Dibujar();
                if (!int.TryParse(Console.ReadLine(), out salida) || salida != 1 && salida != 2 && salida != 3 && salida != 4 && salida != 5 && salida != 6 && salida != 9)
                {
                    Console.Clear();
                    Console.WriteLine("VALOR INGRESADO NO VALIDO");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                if (salida == 1 || salida == 2 || salida == 3 || salida == 4 || salida == 5 || salida == 6)
                {
                    await SiguienteMenu(salida);
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
        public async Task SiguienteMenu(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Elegiste Registrar Equipo");
                    var menuequipo = new DibujoMenuEquipo();
                    await menuequipo.Iniciar();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Elegiste Registrar Cuerpo Tecnico");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Elegiste Registrar Medico");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Elegiste inscripcion Torneo");
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Elegiste Notificaciones Equipo");
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Elegiste Salir De Torneo");
                    break;
            }
        }
        private string Mensaje = """
╔═════════════════════════════════════════╗
║   M E N Ú  G E S T I O N  E Q U I P O   ║
╠═════════════════════════════════════════╣
║  1. Registrar Equipo                    ║
║  2. Registrar Cuerpo Tecnico            ║
║  3. Registrar Cuerpo Medico             ║
║  4. Inscripcion Torneo                  ║
║  5. Notificaciones Equipo               ║
║  6. Salir De Torneo                     ║
║  9. Volver Al Menu Principal            ║
╚═════════════════════════════════════════╝
Ingrese un numero segun lo que desea realizar
""";
    }
}