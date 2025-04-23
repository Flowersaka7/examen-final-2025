create database ClinicaUH

go
use ClinicaUH


create table Pacientes(
ID int identity (1,1) PRIMARY KEY,
Nombre VARCHAR(100) NOT NULL,
Apellidos varchar(100) NOT NULL,
FechaNacimiento DATE NOT NULL,
Telefono Varchar(20) NOT NULL,
Email Varchar(100) unique NOT NULL,
Edad int NOT NULL
);

create table Medicos(
ID int identity(1,1) PRIMARY KEY,
Nombre Varchar(100) NOT null,
Especialidad Varchar(100) NOT NULL,
Telefono varchar(20) NOT NULL,
Email Varchar(100) UNIQUE NOT NULL
);

create table consultas (
ID INT identity(1,1) PRIMARY KEY,
PacienteID INT NOT NULL,
MedicoID INT NOT NULL,
Diagnostico TEXT NOT NULL,
FechaCita datetime NOT NULL,
NumeroConsulta Varchar(50) NOT NULL,
Estado VARCHAR(50) CHECK (Estado IN ('Pendiente','completada','Cancelada')),
FOREIGN KEY (Pacienteid) REFERENCES Pacientes(ID) ON DELETE CASCADE,
FOREIGN KEY (MedicoID) REFERENCES Medicos(ID) ON DELETE CASCADE
);


----CRUD 
---Ingresar

insert into Pacientes (Nombre, Apellidos, FechaNacimiento, Telefono, Email, Edad)
Values ('juan','Perez', '1990-05-15' '8888-9999', 'Juan.perez@example.com', 20);


insert into Consultas (PacienteID, MedicoID, Diagnostico, FechaCita, NumeroConsulta, Estado)
values (1, 1, 'Gripe', '2025-04-12 10:00:00', 'C001', 'Pendiente');

SELECT * FROM Pacientes;


