using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Torneo.Application.Interfaces;

namespace Liga_futbol.Src.Modules.Torneo.Application.Services
{
    public class ServicioBuscarTorneo
    {
        private readonly ITorneoRepository _repo;

        public ServicioBuscarTorneo(ITorneoRepository _repo)
        {
            this._repo = _repo;
        }

        public Task<IEnumerable<Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo?>> ConsultarTorneos()
        {
            return _repo.ConseguirTodo();
        }
        public async Task BuscarTorneo()
        {
            int idtorneo = validarid();
            if (await _repo.ConseguirPorId(idtorneo) == null)
            {
                Console.Clear();
                Console.WriteLine("No existe ningun torneo con ese id");
                Thread.Sleep(1500);
                string respuesta = await validarVerTorneos(idtorneo);
                if (respuesta == "si")
                {
                    await mostrartorneosAsync();
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
                var torneo = await _repo.ConseguirPorId(idtorneo);
                Console.WriteLine("los datos del torneo son :");
                Console.WriteLine($"ID torneo : {torneo?.Id} - Nombre : {torneo?.Nombre} - Capacidad : {torneo?.Capacidad}");
                Console.WriteLine($"- Fecha de inicio: {torneo?.FechaInicio.ToShortDateString()} - Fecha de fin: {torneo?.FechaFin.ToShortDateString()}");
            }
        }
        public async Task mostrartorneosAsync()
        {
            var existentes = await _repo.ConseguirTodo();
            foreach (var Torneo in existentes)
            {
                Console.WriteLine($"ID torneo : {Torneo?.Id} - Nombre : {Torneo?.Nombre} - Capacidad : {Torneo?.Capacidad}");
                Console.WriteLine($"- Fecha de inicio: {Torneo?.FechaInicio.ToShortDateString()} - Fecha de fin: {Torneo?.FechaFin.ToShortDateString()}");
            }
        }
        private int validarid()
        {
            int id = 0;
            Console.WriteLine("Ingrese el ID del torneo que desea buscar:");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un ID válido.");
            }
            return id;
        }
        public async Task<string> validarVerTorneos(int id)
        {
            Console.Clear();
            var Torneo = await _repo.ConseguirPorId(id); 
            Console.WriteLine("Desea Ver Los Torneos existentes?");
            string seguro = Console.ReadLine() ?? "";
            while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
            {
                Console.WriteLine("Valor invalido");
                Console.WriteLine("Ingrese si para ver los torneos existes o no para salir");
                seguro = Console.ReadLine() ?? "";
            }
            return seguro.ToLower();
        }
    }
}