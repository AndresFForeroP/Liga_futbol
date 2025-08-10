using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Torneo.Application.Interfaces;

namespace Liga_futbol.Src.Modules.Torneo.Application.Services
{
    public class ServicioActualizarTorneo
    {
        private readonly ITorneoRepository _repo;

        public ServicioActualizarTorneo(ITorneoRepository _repo)
        {
            this._repo = _repo;
        }

        public Task<IEnumerable<Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo?>> ConsultarTorneos()
        {
            return _repo.ConseguirTodo();
        }
        public async Task ActualizarTorneo()
        {
            int TorneoActualizar = 0;
            Console.WriteLine("los Torneos registrados son :");
            var existentes = await _repo.ConseguirTodo();
            foreach (var Torneo in existentes)
            {
                Console.WriteLine($"- ID torneo : {Torneo?.Id} - Nombre : {Torneo?.Nombre} - Capacidad : {Torneo?.Capacidad} ");
            }
            do
            {
                TorneoActualizar= validarid();
                if (await _repo.ConseguirPorId(TorneoActualizar) == null)
                {
                    Console.WriteLine("El torneo no existe, ingrese un id de torneo existente");
                    Console.WriteLine("los Torneos registrados son :");
                    foreach (var Torneo in existentes)
                    {
                        Console.WriteLine($"ID torneo : {Torneo?.Id} - Nombre : {Torneo?.Nombre} - Capacidad : {Torneo?.Capacidad}");
                    }
                }
            } while (await _repo.ConseguirPorId(TorneoActualizar) == null);
            if (await validarActualizar(TorneoActualizar) == "si")
            {
                var torneo = await _repo.ConseguirPorId(TorneoActualizar);
                string nombre = validarnombre();
                while (existentes.Any(u => u?.Nombre == nombre) && torneo?.Nombre != nombre)
                {
                    Console.WriteLine("El Torneo ya existe");
                    nombre = validarnombre();
                    existentes = await _repo.ConseguirTodo();
                };
                int capacidad = validarcapacidad();
                DateTime fechaInicio = validarfechainicio();
                DateTime fechaFin = validarfechafin(fechaInicio);
                _repo.Actualizar(torneo?? throw new InvalidOperationException("Torneo no encontrado"),nombre, capacidad, fechaInicio, fechaFin);
                await _repo.GuardarAsincronico();
                Console.WriteLine("Torneo Actualizado exitosamente");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Actualizacion cancelada");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
        public async Task<string> validarActualizar(int id)
        {
            Console.Clear();
            var Torneo = await _repo.ConseguirPorId(id); 
            Console.WriteLine("los datos del torneo son:");
            Console.WriteLine($"Nombre de torneo: {Torneo?.Nombre} - Capacidad torneo: {Torneo?.Capacidad} equipos");
            Console.WriteLine($"Fecha de inicio: {Torneo?.FechaInicio.ToShortDateString()} - Fecha de fin: {Torneo?.FechaFin.ToShortDateString()}");
            Console.WriteLine("Esta seguro de Actualizar el torneo?");
            Console.WriteLine("Ingrese si para Actualizar el torneo o no si desea conservarlo como esta");
            string seguro = Console.ReadLine() ?? "";
            while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
            {
                Console.WriteLine("Valor invalido");
                Console.WriteLine("Ingrese si para actualizar el torneo o no si desea volver a ingresar los datos");
                seguro = Console.ReadLine() ?? "";
            }
            return seguro.ToLower();
        }
        private int validarid()
        {
            int id = 0;
            Console.WriteLine("Ingrese el ID del torneo que desea Actualizar:");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un ID válido.");
            }
            return id;
        }
        private string validarnombre()
        {
            Console.Write("Ingrese el nombre del torneo: ");
            string nombre = Console.ReadLine() ?? "";
            while (nombre == "")
            {
                Console.Write("El nombre no puede estar vacío. Ingrese el nombre del torneo: ");
                nombre = Console.ReadLine() ?? "";
            }
            return nombre;
        }
        private int validarcapacidad()
        {
            int capacidad;
            Console.Write("Ingrese la capacidad del torneo: ");
            while (!int.TryParse(Console.ReadLine(), out capacidad) || capacidad <= 0)
            {
                Console.Write("Capacidad inválida. Ingrese un número entero positivo: ");
            }
            return capacidad;
        }
        private DateTime validarfechainicio()
        {
            DateTime fechaInicio;
            Console.Write("Ingrese la fecha de inicio del torneo (dd/mm/yyyy): ");
            while (!DateTime.TryParse(Console.ReadLine(), out fechaInicio))
            {
                Console.Write("Fecha inválida. Ingrese una fecha válida (dd/mm/yyyy): ");
            }
            return fechaInicio;
        }
        private DateTime validarfechafin(DateTime fechaInicio)
        {
            DateTime fechaFin;
            Console.Write("Ingrese la fecha de fin del torneo (dd/mm/yyyy): ");
            while (!DateTime.TryParse(Console.ReadLine(), out fechaFin) || fechaFin <= fechaInicio)
            {
                Console.Write("Fecha inválida. Ingrese una fecha válida posterior a la fecha de inicio: ");
            }
            return fechaFin;
        }
    }
}