using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Equipo.Application.Interfaces;

namespace Liga_futbol.Src.Modules.Equipo.Application.Services
{
    public class ServicioEliminarEquipo
    {
        private readonly IEquipoRepository _repo;

        public ServicioEliminarEquipo(IEquipoRepository _repo)
        {
            this._repo = _repo;
        }

        public Task<IEnumerable<Liga_futbol.Src.Modules.Equipo.Domain.Entities.Equipo?>> ConsultarEquipos()
        {
            return _repo.ConseguirTodo();
        }
        public async Task EliminarEquipo()
        {
            int EquipoaEliminar = 0;
            Console.WriteLine("los Equipos registrados son :");
            var existentes = await _repo.ConseguirTodo();
            foreach (var Equipo in existentes)
            {
                Console.WriteLine($"- ID Equipo : {Equipo?.Id} - Nombre : {Equipo?.Nombre} - Pais : {Equipo?.Pais}");    
            }
            do
            {
                EquipoaEliminar = validarid();
                if (await _repo.ConseguirPorId(EquipoaEliminar) == null)
                {
                    Console.WriteLine("El Equipo no existe, ingrese un id de Equipo existente");
                    Console.WriteLine("los Equipos registrados son :");
                    foreach (var Equipo in existentes)
                    {
                        Console.WriteLine($"- ID Equipo : {Equipo?.Id} - Nombre : {Equipo?.Nombre} - Pais : {Equipo?.Pais}");
                    }
                }
            } while (await _repo.ConseguirPorId(EquipoaEliminar) == null);
            if (await validarEliminar(EquipoaEliminar) == "si")
            {
                var Equipo = await _repo.ConseguirPorId(EquipoaEliminar);
                _repo.Eliminar(Equipo?? throw new InvalidOperationException("Equipo no encontrado"));
                await _repo.GuardarAsincronico();
                Console.WriteLine("Equipo eliminado exitosamente");
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
            Console.WriteLine("Ingrese el ID del Equipo que desea eliminar:");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un ID válido.");
            }
            return id;
        }
        public async Task<string> validarEliminar(int id)
        {
            Console.Clear();
            var Equipo = await _repo.ConseguirPorId(id); 
            Console.WriteLine("los datos del Equipo son:");
            Console.WriteLine($"- ID Equipo : {Equipo?.Id} - Nombre : {Equipo?.Nombre} - Pais : {Equipo?.Pais}");
            Console.WriteLine("Esta seguro de Eliminar el Equipo?");
            Console.WriteLine("Ingrese si para Eliminar el Equipo o no si desea conservarlo");
            string seguro = Console.ReadLine() ?? "";
            while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
            {
                Console.WriteLine("Valor invalido");
                Console.WriteLine("Ingrese si para eliminar el Equipo o no si desea volver a ingresar los datos");
                seguro = Console.ReadLine() ?? "";
            }
            return seguro.ToLower();
        }
    }
}