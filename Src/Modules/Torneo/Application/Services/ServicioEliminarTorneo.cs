using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Torneo.Application.Interfaces;

namespace Liga_futbol.Src.Modules.Torneo.Application.Services
{
    public class ServicioEliminarTorneo
    {
        private readonly ITorneoRepository _repo;

        public ServicioEliminarTorneo(ITorneoRepository _repo)
        {
            this._repo = _repo;
        }

        public Task<IEnumerable<Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo?>> ConsultarTorneos()
        {
            return _repo.ConseguirTodo();
        }
        public async Task EliminarTorneo()
        {
            int TorneoaEliminar = 0;
            Console.WriteLine("los Torneos registrados son :");
            var existentes = await _repo.ConseguirTodo();
            foreach (var Torneo in existentes)
            {
                Console.WriteLine($"- ID torneo : {Torneo?.Id} - Nombre : {Torneo?.Nombre} - Capacidad : {Torneo?.Capacidad}");
                Console.WriteLine($"- Fecha de inicio: {Torneo?.FechaInicio.ToShortDateString()} - Fecha de fin: {Torneo?.FechaFin.ToShortDateString()}");
            }
            do
            {
                TorneoaEliminar = validarid();
                if (await _repo.ConseguirPorId(TorneoaEliminar) == null)
                {
                    Console.WriteLine("El torneo no existe, ingrese un id de torneo existente");
                    Console.WriteLine("los Torneos registrados son :");
                    foreach (var Torneo in existentes)
                    {
                        Console.WriteLine($"- ID torneo : {Torneo?.Id} - Nombre : {Torneo?.Nombre} - Capacidad : {Torneo?.Capacidad} ");
                        Console.WriteLine($"- Fecha de inicio: {Torneo?.FechaInicio.ToShortDateString()} - Fecha de fin: {Torneo?.FechaFin.ToShortDateString()}");
                    }
                }
            } while (await _repo.ConseguirPorId(TorneoaEliminar) == null);
            if (await validarEliminar(TorneoaEliminar) == "si")
            {
                var torneo = await _repo.ConseguirPorId(TorneoaEliminar);
                _repo.Eliminar(torneo?? throw new InvalidOperationException("Torneo no encontrado"));
                await _repo.GuardarAsincronico();
                Console.WriteLine("Torneo eliminado exitosamente");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Eliminación cancelada");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
        private int validarid()
        {
            int id = 0;
            Console.WriteLine("Ingrese el ID del torneo que desea eliminar:");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un ID válido.");
            }
            return id;
        }
        public async Task<string> validarEliminar(int id)
        {
            Console.Clear();
            var Torneo = await _repo.ConseguirPorId(id); 
            Console.WriteLine("los datos del torneo son:");
            Console.WriteLine($"Nombre de torneo: {Torneo?.Nombre} - Capacidad torneo: {Torneo?.Capacidad} equipos");
            Console.WriteLine($"Fecha de inicio:{Torneo?.FechaInicio.ToShortDateString()} - Fecha de fin: {Torneo?.FechaFin.ToShortDateString()}");
            Console.WriteLine("Esta seguro de Eliminar el torneo?");
            Console.WriteLine("Ingrese si para Eliminar el torneo o no si desea conservarlo");
            string seguro = Console.ReadLine() ?? "";
            while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
            {
                Console.WriteLine("Valor invalido");
                Console.WriteLine("Ingrese si para eliminar el torneo o no si desea volver a ingresar los datos");
                seguro = Console.ReadLine() ?? "";
            }
            return seguro.ToLower();
        }
    }
}