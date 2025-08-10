using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga_Futbol.src.InterfaceAdapters.MenuPrincipal
{
    public interface InterfazMenus
    {
        void Iniciar();
        void Dibujar();
        void SiguienteMenu(int opcion);
    }
}