using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga_futbol.Src.Modules.Equipo.Application.Interfaces;
using Liga_futbol.Src.Modules.Torneo.Application.Interfaces;
using Liga_futbol.Src.Modules.Torneo.Application.Services;
using Liga_futbol.Src.Modules.Torneo.Interfaces.Repositories;
using Liga_futbol.Src.Shared.Context;
using Liga_futbol.Src.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Liga_futbol.Src.Modules.Equipo.Application.Services
{
    public class ServicioAgregarEquipo
    {
        private readonly IEquipoRepository _repo;

        public ServicioAgregarEquipo(IEquipoRepository _repo)
        {
            this._repo = _repo;
        }

        public Task<IEnumerable<Liga_futbol.Src.Modules.Equipo.Domain.Entities.Equipo?>> ConsultarEquipos()
        {
            return _repo.ConseguirTodo();
        }

        public async Task RegistrarNuevoEquipo()
        {
            Console.Clear();
            string nombre = ValidarNombre();
            var existentes = await _repo.ConseguirTodo();
            while (existentes.Any(u => u?.Nombre == nombre))
            {
                Console.WriteLine("El Equipo ya existe");
                nombre = ValidarNombre();
                existentes = await _repo.ConseguirTodo();
            }
            string pais = ValidarPais();
            var equipo = new Liga_futbol.Src.Modules.Equipo.Domain.Entities.Equipo
            {
                Nombre = nombre,
                Pais = pais
            };
            if (validarCreacion(equipo.Nombre, equipo.Pais).ToLower() == "si")
            {
                _repo.Añadir(equipo);
                await _repo.GuardarAsincronico();
                Console.WriteLine("Equipo agregado exitosamente");
                Console.WriteLine("Desea agregar el equipo a un Torneo?");
                string seguro = Console.ReadLine() ?? "";
                while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
                {
                    Console.WriteLine("Valor invalido");
                    Console.WriteLine("Ingrese si para agregar a un torneo o no si desea volver al menu de equipos");
                    seguro = Console.ReadLine() ?? "";
                }
                if (seguro.ToLower() == "si")
                {
                    int idtorneo = 0;
                    var dbContext = DbContextFactory.Create();
                    TorneoRepository torneoRepo = new TorneoRepository(dbContext);
                    var verTorneos = new ServicioBuscarTorneo(torneoRepo);
                    var Torneos = await torneoRepo.ConseguirTodo();
                    await verTorneos.mostrartorneosAsync();
                    do
                    {
                        idtorneo = validarentero();
                        if (!Torneos.Any(t => t?.Id == idtorneo))
                        {
                            Console.Clear();
                            Console.WriteLine("Ingrese un id de un torneo que este registrado");
                            await verTorneos.mostrartorneosAsync();
                        }
                    } while (!Torneos.Any(t => t?.Id == idtorneo));
                    var TorneosEquipo = dbContext.TorneoEquipo;
                    var nuevotorneoequipo = new Liga_futbol.Src.Modules.TorneoEquipo.Domain.Entities.TorneoEquipo
                    {
                        EquipoId = equipo.Id,
                        TorneoId = idtorneo
                    };
                    dbContext.TorneoEquipo.Add(nuevotorneoequipo);
                    dbContext.SaveChanges();
                    Console.WriteLine("Equipo agregado al Torneo");

                }
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
        private string validarCreacion(string nombre, string pais)
        {
            Console.WriteLine("los datos del equipo son:");
            Console.WriteLine($"Nombre de equipo: {nombre} - Pais Equipo: {pais}");
            Console.WriteLine("Esta seguro de agregar el equipo?");
            Console.WriteLine("Ingrese si para agregar el equipo o no si desea volver a ingresar los datos");
            string seguro = Console.ReadLine() ?? "";
            while (seguro.ToLower() != "no" && seguro.ToLower() != "si")
            {
                Console.WriteLine("Valor invalido");
                Console.WriteLine("ingrese si para agregar el torneo o no si desea volver a ingresar los datos");
                seguro = Console.ReadLine() ?? "";
            }
            return seguro;
        }
        private int validarentero()
        {
            int capacidad;
            Console.Write("Ingrese el id del torneo al cual desea agregar el equipo: ");
            while (!int.TryParse(Console.ReadLine(), out capacidad) || capacidad <= 0)
            {
                Console.Write("Id no valido. Ingrese un número entero positivo: ");
            }
            return capacidad;
        }

    }
}