using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_futbol.Src.Modules.Torneo.UI
{
    public class DibujoSaludo
    {
        public void Iniciar()
        {
            Console.WriteLine(Saludo);
        }
        private string Saludo = """
        ╔════════════════════════════════════════════════════╗
        ║                                                    ║
        ║       ⚽ BIENVENIDO AL SISTEMA DE GESTIÓN ⚽       ║
        ║                                                    ║
        ║            🏆  LIGA DE FÚTBOL LOCAL  🏆            ║
        ║                                                    ║
        ╚════════════════════════════════════════════════════╝
        """;
    }
}