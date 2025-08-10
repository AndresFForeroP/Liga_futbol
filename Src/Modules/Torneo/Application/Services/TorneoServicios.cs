using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Torneo.Application.Interfaces;

namespace Liga_futbol.Src.Modules.Torneo.Application.Services
{
    public class TorneoServicios
    {
        private readonly ITorneoRepository _repo;

        public TorneoServicios(ITorneoRepository _repo)
        {
            this._repo = _repo;
        }

        public Task<IEnumerable<Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo?>> ConsultarTorneos()
        {
            return _repo.ConseguirTodo();
        }

        public async Task RegistrarNuevoTorneo()
        {
            Console.Clear();
            string nombre = validarnombre();
            var existentes = await _repo.ConseguirTodo();
            while (existentes.Any(u => u?.Nombre == nombre))
            {
                Console.WriteLine("El Torneo ya existe");
                nombre = validarnombre();
                existentes = await _repo.ConseguirTodo();
            }
            ;
            int capacidad = validarcapacidad();
            DateTime fechaInicio = validarfechainicio();
            DateTime fechaFin = validarfechafin(fechaInicio);
            var torneo = new Liga_futbol.Src.Modules.Torneo.Domain.Entities.Torneo
            {
                Nombre = nombre,
                Capacidad = capacidad,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin
            };
            if (validarCreacion(torneo.Nombre, torneo.Capacidad, torneo.FechaInicio, torneo.FechaFin).ToLower() == "si")
            {
                _repo.Añadir(torneo);
                _repo?.GuardarAsincronico();
                Console.WriteLine("Torneo agregado exitosamente");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Volviendo al menu anterior...");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
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
        public string validarCreacion(string nombre, int capacidad, DateTime fechaInicio, DateTime fechaFin)
        {
            Console.WriteLine("los datos del torneo son:");
            Console.WriteLine($"Nombre de torneo: {nombre} - Capacidad torneo: {capacidad} equipos");
            Console.WriteLine($"Fecha de inicio:{fechaInicio.ToShortDateString()} - Fecha de fin: {fechaFin.ToShortDateString()}");
            Console.WriteLine("Esta seguro de agregar el torneo?");
            Console.WriteLine("Ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
            string seguro = Console.ReadLine() ?? "";
            while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
            {
                Console.WriteLine("Valor invalido");
                Console.WriteLine("Ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
                seguro = Console.ReadLine() ?? "";
            }
            return seguro;
        }
    }
}