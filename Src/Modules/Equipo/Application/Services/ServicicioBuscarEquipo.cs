using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Equipo.Application.Interfaces;

namespace Liga_futbol.Src.Modules.Equipo.Application.Services
{
    public class ServicicioBuscarEquipo
    {
        private readonly IEquipoRepository _repo;

        public ServicicioBuscarEquipo(IEquipoRepository _repo)
        {
            this._repo = _repo;
        }

        public Task<IEnumerable<Liga_futbol.Src.Modules.Equipo.Domain.Entities.Equipo?>> ConsultarEquipos()
        {
            return _repo.ConseguirTodo();
        }
        public async Task BuscarEquipo()
        {
            int idEquipo = validarid();
            if (await _repo.ConseguirPorId(idEquipo) == null)
            {
                Console.Clear();
                Console.WriteLine("No existe ningun Equipo con ese id");
                Thread.Sleep(1500);
                string respuesta = await validarVerEquipos(idEquipo);
                if (respuesta == "si")
                {
                    await mostrarEquiposAsync();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                var Equipo = await _repo.ConseguirPorId(idEquipo);
                Console.WriteLine("los datos del Equipo son :");
                Console.WriteLine($"ID Equipo : {Equipo?.Id} - Nombre : {Equipo?.Nombre}");
            }
        }
        public async Task mostrarEquiposAsync()
        {
            var existentes = await _repo.ConseguirTodo();
            foreach (var Equipo in existentes)
            {
                Console.WriteLine($"ID Equipo : {Equipo?.Id} - Nombre : {Equipo?.Nombre}");
            }
        }
        private int validarid()
        {
            int id = 0;
            Console.WriteLine("Ingrese el ID del Equipo que desea buscar:");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un ID válido.");
            }
            return id;
        }
        public async Task<string> validarVerEquipos(int id)
        {
            Console.Clear();
            var Equipo = await _repo.ConseguirPorId(id); 
            Console.WriteLine("Desea Ver Los Equipos existentes?");
            string seguro = Console.ReadLine() ?? "";
            while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
            {
                Console.WriteLine("Valor invalido");
                Console.WriteLine("Ingrese si para ver los Equipos existes o no para salir");
                seguro = Console.ReadLine() ?? "";
            }
            return seguro.ToLower();
        }
    }
}