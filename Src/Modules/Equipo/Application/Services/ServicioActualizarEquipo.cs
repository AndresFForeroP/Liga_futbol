using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Equipo.Application.Interfaces;

namespace Liga_futbol.Src.Modules.Equipo.Application.Services
{
    public class ServicioActualizarEquipo
    {
        private readonly IEquipoRepository _repo;

        public ServicioActualizarEquipo(IEquipoRepository _repo)
        {
            this._repo = _repo;
        }

        public Task<IEnumerable<Liga_futbol.Src.Modules.Equipo.Domain.Entities.Equipo?>> ConsultarEquipos()
        {
            return _repo.ConseguirTodo();
        }
        public async Task ActualizarEquipo()
        {
            int EquipoActualizar = 0;
            Console.WriteLine("los Equipos registrados son :");
            var existentes = await _repo.ConseguirTodo();
            foreach (var Equipo in existentes)
            {
                Console.WriteLine($"- ID Equipo : {Equipo?.Id} - Nombre : {Equipo?.Nombre} - Pais : {Equipo?.Pais}");
            }
            do
            {
                EquipoActualizar= validarid();
                if (await _repo.ConseguirPorId(EquipoActualizar) == null)
                {
                    Console.WriteLine("El Equipo no existe, ingrese un id de Equipo existente");
                    Console.WriteLine("los Equipos registrados son :");
                    foreach (var Equipo in existentes)
                    {
                        Console.WriteLine($"- ID Equipo : {Equipo?.Id} - Nombre : {Equipo?.Nombre} - Pais : {Equipo?.Pais}");
                    }
                }
            } while (await _repo.ConseguirPorId(EquipoActualizar) == null);
            if (await validarActualizar(EquipoActualizar) == "si")
            {
                var Equipo = await _repo.ConseguirPorId(EquipoActualizar);
                string nombre = ValidarNombre();
                while (existentes.Any(u => u?.Nombre == nombre) && Equipo?.Nombre != nombre)
                {
                    Console.WriteLine("El Equipo ya existe");
                    nombre = ValidarNombre();
                    existentes = await _repo.ConseguirTodo();
                };
                string Pais = ValidarPais();
                _repo.Actualizar(Equipo?? throw new InvalidOperationException("Equipo no encontrado"),nombre,Pais);
                await _repo.GuardarAsincronico();
                Console.WriteLine("Equipo Actualizado exitosamente");
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
            var Equipo = await _repo.ConseguirPorId(id); 
            Console.WriteLine("los datos del Equipo son:");
            Console.WriteLine($"- ID Equipo : {Equipo?.Id} - Nombre : {Equipo?.Nombre} - Pais : {Equipo?.Pais}");
            Console.WriteLine("Esta seguro de Actualizar el Equipo?");
            Console.WriteLine("Ingrese si para Actualizar el Equipo o no si desea conservarlo como esta");
            string seguro = Console.ReadLine() ?? "";
            while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
            {
                Console.WriteLine("Valor invalido");
                Console.WriteLine("Ingrese si para actualizar el Equipo o no si desea volver a ingresar los datos");
                seguro = Console.ReadLine() ?? "";
            }
            return seguro.ToLower();
        }
        private int validarid()
        {
            int id = 0;
            Console.WriteLine("Ingrese el ID del Equipo que desea Actualizar:");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un ID válido.");
            }
            return id;
        }
        private string ValidarNombre()
        {
            Console.Write("Ingrese el nombre del equipo: ");
            string nombre = Console.ReadLine() ?? "";
            while (nombre == "")
            {
                Console.Write("El nombre no puede estar vacío. Ingrese el nombre del equipo: ");
                nombre = Console.ReadLine() ?? "";
            }
            return nombre;
        }
        private string ValidarPais()
        {
            Console.Write("Ingrese el país del equipo: ");
            string pais = Console.ReadLine() ?? "";
            while (pais == "")
            {
                Console.Write("El país no puede estar vacío. Ingrese el país del equipo: ");
                pais = Console.ReadLine() ?? "";
            }
            return pais;
        }
    }
}