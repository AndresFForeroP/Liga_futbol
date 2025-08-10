using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_Futbol.src.InterfaceAdapters.MenuPrincipal;

namespace Liga_futbol.Src.Modules.Torneo.UI
{
    public class DibujoMenuPrincipal : InterfazMenus
    {
       public void Iniciar()
        {
            int salida = 0;
            do
            {
                Dibujar();
                if (!int.TryParse(Console.ReadLine(), out salida) || salida != 1 && salida != 2 && salida != 3 && salida != 4 && salida != 5 && salida != 9)
                {
                    Console.Clear();
                    Console.WriteLine("VALOR INGRESADO NO VALIDO");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                if (salida == 9)
                {
                    Console.WriteLine("SALIENDO DEL PROGRAMA...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.ResetColor();
                }
            }
            while (salida != 1 && salida != 2 && salida != 3 && salida != 4 && salida != 5 && salida != 9);
            SiguienteMenu(salida);
        }
        public void Dibujar()
        {
            Console.WriteLine(Mensaje);
        }
        public void SiguienteMenu(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Elegiste Crear Torneo");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Elegiste Registro Equipos");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Elegiste Registro Jugadores");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Elegiste Transferencias");
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Elegiste Estadísticas");
                    break;
            }
        }
        public string Mensaje = """
╔════════════════════════════════════╗
║    M E N Ú   P R I N C I P A L     ║
╠════════════════════════════════════╣
║  1. Crear Torneo                   ║
║  2. Registro de Equipos            ║
║  3. Registro de Jugadores          ║
║  4. Transferencias                 ║
║  5. Estadísticas                   ║
║  9. Salir                          ║
╚════════════════════════════════════╝
Ingrese un numero segun lo que desea realizar
"""; 
    }
}