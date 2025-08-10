DROP DATABASE IF EXISTS LigaFutbol;
CREATE DATABASE LigaFutbol;
USE LigaFutbol;

-- Tabla Torneo
CREATE TABLE IF NOT EXISTS Torneo (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Capacidad INT NOT NULL,
    Nombre VARCHAR(100),
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL
);

-- Tabla Equipo
CREATE TABLE IF NOT EXISTS Equipo (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Pais VARCHAR(100) NOT NULL
);

-- Relación N:M entre Torneo y Equipo
CREATE TABLE IF NOT EXISTS TorneoEquipo (
    TorneoId INT,
    EquipoId INT,
    PRIMARY KEY (TorneoId, EquipoId),
    FOREIGN KEY (TorneoId) REFERENCES Torneo(Id),
    FOREIGN KEY (EquipoId) REFERENCES Equipo(Id)
);

-- Tabla Persona
CREATE TABLE IF NOT EXISTS Persona (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Edad INT NOT NULL,
    Pais VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Telefono VARCHAR(15) NOT NULL
);

-- Tabla Jugador (sin referencia directa a Equipo)
CREATE TABLE IF NOT EXISTS Jugador (
    Id INT PRIMARY KEY,
    Posicion VARCHAR(50) NOT NULL,
    Dorsal INT NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (Id) REFERENCES Persona(Id)
);

-- Tabla intermedia JugadorEquipo (historial o vínculo actual)
CREATE TABLE IF NOT EXISTS JugadorEquipo (
    JugadorId INT,
    EquipoId INT,
    FechaInicio DATE NOT NULL,
    FechaFin DATE DEFAULT NULL,
    PRIMARY KEY (JugadorId, EquipoId),
    FOREIGN KEY (JugadorId) REFERENCES Jugador(Id),
    FOREIGN KEY (EquipoId) REFERENCES Equipo(Id)
);

-- Tabla Transferencia
CREATE TABLE IF NOT EXISTS Transferencia (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    JugadorId INT NOT NULL,
    EquipoOrigenId INT NOT NULL,
    EquipoDestinoId INT NOT NULL,
    Tipo VARCHAR(14) NOT NULL,
    Precio DECIMAL(10, 2),
    Fecha DATE NOT NULL,
    FOREIGN KEY (JugadorId) REFERENCES Jugador(Id),
    FOREIGN KEY (EquipoOrigenId) REFERENCES Equipo(Id),
    FOREIGN KEY (EquipoDestinoId) REFERENCES Equipo(Id)
);

-- Estadísticas del jugador
CREATE TABLE IF NOT EXISTS EstadisticasJugador (
    JugadorId INT PRIMARY KEY,
    Goles INT DEFAULT 0,
    GolesEnContra INT DEFAULT 0,
    Asistencias INT DEFAULT 0,
    TarjetasAmarillas INT DEFAULT 0,
    TarjetasRojas INT DEFAULT 0,
    FOREIGN KEY (JugadorId) REFERENCES Jugador(Id)
);

-- Personal del equipo
CREATE TABLE IF NOT EXISTS Personal (
    Id INT PRIMARY KEY,
    Tipo VARCHAR(14) NOT NULL,
    EquipoId INT NOT NULL,
    FOREIGN KEY (Id) REFERENCES Persona(Id),
    FOREIGN KEY (EquipoId) REFERENCES Equipo(Id)
);

-- Notificaciones de equipo
CREATE TABLE IF NOT EXISTS Notificacion (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Precio DECIMAL(10, 2),
    EquipoId INT,
    JugadorId INT,
    Tipo VARCHAR(14) NOT NULL,
    Fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (EquipoId) REFERENCES Equipo(Id),
    FOREIGN KEY (JugadorId) REFERENCES Jugador(Id)
);