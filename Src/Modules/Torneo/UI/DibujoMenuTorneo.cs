using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_Futbol.src.InterfaceAdapters.MenuPrincipal;

namespace Liga_futbol.Src.Modules.Torneo.UI
{
    public class DibujoMenuTorneo : InterfazMenus
    {
        public void Iniciar()
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
                    SiguienteMenu(salida);
                }

            }
            while (salida != 9);
            Console.Clear();
            Console.WriteLine("VOLVIENDO AL MENU PRINCIPAL...");
            Thread.Sleep(2000);
            Console.Clear();
            var menuPrincipal = new DibujoMenuPrincipal();
            menuPrincipal.Iniciar();
        }
        public void Dibujar()
        {
            Console.Clear();
            Console.WriteLine(Mensaje);
        }
        public void SiguienteMenu(int opcion)
        {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Elegiste Agregar Torneo");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Elegiste Buscar Torneo");
                        Console.WriteLine("Buscar por Id");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Elegiste Eliminar Torneo");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Elegiste Actualizar Torneo");
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