-- Deshabilitar temporalmente las comprobaciones de clave foránea.
SET FOREIGN_KEY_CHECKS = 0;

-- Truncar las tablas para empezar de cero.
TRUNCATE TABLE Transferencia;
TRUNCATE TABLE Notificacion;
TRUNCATE TABLE EstadisticasJugador;
TRUNCATE TABLE Personal;
TRUNCATE TABLE JugadorEquipo;
TRUNCATE TABLE TorneoEquipo;
TRUNCATE TABLE Jugador;
TRUNCATE TABLE Persona;
TRUNCATE TABLE Torneo;
TRUNCATE TABLE Equipo;

-- Habilitar nuevamente las comprobaciones de clave foránea.
SET FOREIGN_KEY_CHECKS = 1;

--
-- Inserts para la tabla `Torneo`
--
INSERT INTO Torneo (Id, Capacidad, Nombre, FechaInicio, FechaFin) VALUES
(1, 10, 'Copa de Campeones', '2025-08-01', '2026-05-31'),
(2, 8, 'Liga Nacional de Élite', '2025-09-15', '2026-06-15'),
(3, 12, 'Torneo de Invierno', '2025-11-01', '2026-03-15');

--
-- Inserts para la tabla `Equipo`
--
INSERT INTO Equipo (Id, Nombre, Pais) VALUES
(1, 'Águilas Doradas', 'Colombia'),
(2, 'Leones Rojos', 'España'),
(3, 'Tigres Azules', 'Alemania'),
(4, 'Serpientes Verdes', 'Brasil'),
(5, 'Halcones Plateados', 'Argentina'),
(6, 'Osos Blancos FC', 'Canadá'),
(7, 'Panteras Negras', 'México');

--
-- Inserts para la tabla `Persona`
-- (Jugadores: 1-10, Personal: 11-14)
--
INSERT INTO Persona (Id, Nombre, Edad, Pais, Email, Telefono) VALUES
(1, 'Lionel Messi', 38, 'Argentina', 'messi@example.com', '5491112345678'),
(2, 'Cristiano Ronaldo', 40, 'Portugal', 'ronaldo@example.com', '351931234567'),
(3, 'Kylian Mbappé', 26, 'Francia', 'mbappe@example.com', '33611223344'),
(4, 'Erling Haaland', 24, 'Noruega', 'haaland@example.com', '4790123456'),
(5, 'Pedri González', 23, 'España', 'pedri@example.com', '34600112233'),
(6, 'Vinícius Júnior', 25, 'Brasil', 'vinicius@example.com', '5521998765432'),
(7, 'Kevin De Bruyne', 34, 'Bélgica', 'k.debruyne@example.com', '32475987654'),
(8, 'Mohamed Salah', 33, 'Egipto', 'm.salah@example.com', '201012345678'),
(9, 'Jude Bellingham', 22, 'Inglaterra', 'j.bellingham@example.com', '447812345678'),
(10, 'Jamal Musiala', 22, 'Alemania', 'j.musiala@example.com', '4917698765432'),
(11, 'Carlo Ancelotti', 65, 'Italia', 'c.ancelotti@example.com', '393339876543'),
(12, 'Dr. Marco Rossi', 45, 'Italia', 'm.rossi@example.com', '393451234567'),
(13, 'Pep Guardiola', 54, 'España', 'p.guardiola@example.com', '34678112233'),
(14, 'Dra. Ana Lopez', 40, 'México', 'a.lopez@example.com', '525512345678');

--
-- Inserts para la tabla `Jugador`
--
INSERT INTO Jugador (Id, Posicion, Dorsal, Precio) VALUES
(1, 'DELANTERO', 10, 50000000.00),
(2, 'DELANTERO', 7, 30000000.00),
(3, 'DELANTERO', 9, 20000000.00),
(4, 'DELANTERO', 9, 18000000.00),
(5, 'CENTROCAMPISTA', 8, 10000000.00),
(6, 'DELANTERO', 11, 15000000.00),
(7, 'CENTROCAMPISTA', 17, 90000000.00),
(8, 'DELANTERO', 10, 85000000.00),
(9, 'CENTROCAMPISTA', 5, 12000000.00),
(10, 'CENTROCAMPISTA', 14, 11000000.00);

--
-- Inserts para la tabla `Personal`
--
INSERT INTO Personal (Id, Tipo, EquipoId) VALUES
(11, 'TECNICO', 2),
(12, 'MEDICO', 2),
(13, 'TECNICO', 3),
(14, 'MEDICO', 7);

--
-- Inserts para la tabla `TorneoEquipo`
--
INSERT INTO TorneoEquipo (TorneoId, EquipoId) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5),
(2, 2), (2, 3), (2, 4), (2, 5), (2, 6),
(3, 1), (3, 3), (3, 5), (3, 6), (3, 7);

--
-- Inserts para la tabla `JugadorEquipo`
--
INSERT INTO JugadorEquipo (JugadorId, EquipoId, FechaInicio, FechaFin) VALUES
(1, 1, '2024-07-01', '2025-07-31'),
(1, 5, '2025-08-01', NULL),
(2, 3, '2025-01-01', NULL),
(3, 2, '2024-08-15', NULL),
(4, 3, '2023-07-01', '2025-07-31'),
(4, 4, '2025-08-01', NULL),
(5, 2, '2022-07-01', NULL),
(6, 4, '2021-07-01', NULL),
(7, 3, '2025-08-10', NULL),
(8, 6, '2025-08-12', NULL),
(9, 2, '2024-08-01', NULL),
(10, 7, '2025-08-15', NULL);

--
-- Inserts para la tabla `Transferencia`
--
INSERT INTO Transferencia (JugadorId, EquipoOrigenId, EquipoDestinoId, Tipo, Precio, Fecha) VALUES
(1, 1, 5, 'COMPRA', 25000000.00, '2025-08-01'),
(4, 3, 4, 'COMPRA', 10000000.00, '2025-08-01'),
(7, 5, 3, 'COMPRA', 75000000.00, '2025-08-10'),
(8, 2, 6, 'PRESTAMO', 5000000.00, '2025-08-12'),
(9, 4, 2, 'COMPRA', 10000000.00, '2025-08-01');

--
-- Inserts para la tabla `EstadisticasJugador`
--
INSERT INTO EstadisticasJugador (JugadorId, Goles, Asistencias, TarjetasAmarillas, TarjetasRojas) VALUES
(1, 15, 8, 2, 0),
(2, 25, 5, 5, 1),
(3, 30, 10, 3, 0),
(4, 28, 7, 4, 0),
(5, 5, 12, 6, 0),
(6, 18, 9, 2, 0),
(7, 10, 15, 8, 0),
(8, 22, 6, 3, 0),
(9, 7, 11, 4, 1),
(10, 12, 13, 2, 0);

--
-- Inserts para la tabla `Notificacion`
--
INSERT INTO Notificacion (Precio, EquipoId, JugadorId) VALUES
(25000000.00, 5, 1),
(10000000.00, 4, 4),
(75000000.00, 3, 7),
(5000000.00, 6, 8),
(10000000.00, 2, 9);
