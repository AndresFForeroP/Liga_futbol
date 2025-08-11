using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Torneo.UI;

namespace Liga_futbol.Src.Modules.Personal.UI
{
    public class DibujoMenuTecnico
    {
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
                    SiguienteMenu(salida);
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
        public void SiguienteMenu(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Elegiste Agregar Cuerpo Tecnico");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Elegiste Buscar Cuerpo Tecnico");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Elegiste Eliminar Cuerpo Tecnico");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Elegiste Actualizar Cuerpo Tecnico");
                    break;
            }
        }
        private string Mensaje = """
╔═════════════════════════════════════════╗
║   M E N Ú  C U E R P O  T E C N I C O   ║
╠═════════════════════════════════════════╣
║  1. Agregar Cuerpo Tecnico              ║
║  2. Buscar Cuerpo Tecnico               ║
║  3. Eliminar Cuerpo Tecnico             ║
║  4. Actualizar Cuerpo Tecnico           ║
║  9. Volver Al Menu Anterior             ║
╚═════════════════════════════════════════╝
Ingrese un numero segun lo que desea realizar
""";
    }
}