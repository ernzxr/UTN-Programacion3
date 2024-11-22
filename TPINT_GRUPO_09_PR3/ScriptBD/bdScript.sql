USE master
GO

CREATE DATABASE UTN2C2024PR3CLINICA
ON 
( NAME = UTN2C2024PR3CLINICA_dat,
  FILENAME = 'D:\ernzxr\Google Drive\ernzxr\Estudio\UTN\UTN Pacheco\Tecnicatura\3er Cuatrimestre\Programación III\TP Integrador\BASE DE DATOS\UTN2C2024PR3CLINICA.mdf' )
GO

USE UTN2C2024PR3CLINICA
GO


CREATE TABLE Provincias (
	Id_Provincia_Pr INT IDENTITY(1, 1) NOT NULL,
	Cod_Provincia_Pr CHAR(3) NOT NULL,
	Descripcion_Pr VARCHAR(40) NOT NULL,
	CONSTRAINT PK_Provincias PRIMARY KEY (Id_Provincia_Pr),
	CONSTRAINT UK_Cod_Provincia UNIQUE (Cod_Provincia_Pr)
)
GO

CREATE TABLE Localidades (
	Id_Localidad_Lo INT IDENTITY (1, 1) NOT NULL,
	Cod_Localidad_Lo CHAR(5) NOT NULL,
	Id_Provincia_Lo INT NOT NULL,
	Descripcion_Lo VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Localidades PRIMARY KEY (Id_Localidad_Lo),
	CONSTRAINT FK_Localidades_Provincias FOREIGN KEY (Id_Provincia_Lo) REFERENCES Provincias(Id_Provincia_Pr),
	CONSTRAINT UK_Cod_Localidad UNIQUE (Cod_Localidad_Lo)
)
GO

CREATE TABLE Especialidades (
	Id_Especialidad_Es INT IDENTITY (1, 1) NOT NULL,
	Cod_Especialidad_Es CHAR(3) NOT NULL,
	Descripcion_Es VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Especialidades PRIMARY KEY (Id_Especialidad_Es),
	CONSTRAINT UK_Cod_Especialidad UNIQUE (Cod_Especialidad_Es)
)
GO

CREATE TABLE Tipos_Usuarios (
	Id_Tipo_Usuario_TU INT IDENTITY (1, 1) NOT NULL,
	Cod_Tipo_Usuario_TU CHAR(3) NOT NULL,
	Descripcion_TU VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Tipos_Usuarios PRIMARY KEY (Id_Tipo_Usuario_TU),
	CONSTRAINT UK_Cod_Tipo_Usuario UNIQUE (Cod_Tipo_Usuario_TU)
)
GO

CREATE TABLE Usuarios (
	Id_Usuario_Us INT IDENTITY (1, 1) NOT NULL,
	Usuario_Us VARCHAR(50) NOT NULL,
	Clave_Us VARCHAR(80) NOT NULL,
	Email_Us VARCHAR(100) NOT NULL,
	Id_Tipo_Usuario_Us INT NOT NULL,
	CONSTRAINT PK_Usuarios PRIMARY KEY (Id_Usuario_Us),
	CONSTRAINT FK_Usuarios_Tipos_Usuarios FOREIGN KEY (Id_Tipo_Usuario_Us) REFERENCES Tipos_Usuarios (Id_Tipo_Usuario_TU),
	CONSTRAINT UK_Email_Usuarios UNIQUE (Email_Us),
	CONSTRAINT UK_Usuario UNIQUE (Usuario_Us)
)
GO

CREATE TABLE Nacionalidades (
    Id_Nacionalidad_Na INT IDENTITY (1, 1) NOT NULL,
	Cod_Nacionalidad_Na CHAR(2) NOT NULL,
    Descripcion_Na VARCHAR(100) NOT NULL,
    CONSTRAINT PK_Nacionalidades PRIMARY KEY (Id_Nacionalidad_Na),
    CONSTRAINT UK_Cod_Nacionalidad UNIQUE (Cod_Nacionalidad_Na)
)
GO

CREATE TABLE Generos (
    Id_Genero_Ge INT IDENTITY (1, 1) NOT NULL,
	Cod_Genero_Ge CHAR(1) NOT NULL,
    Descripcion_Ge VARCHAR(100) NOT NULL,
    CONSTRAINT PK_Generos PRIMARY KEY (Id_Genero_Ge),
    CONSTRAINT UK_Cod_Genero UNIQUE (Cod_Genero_Ge)
)
GO

CREATE TABLE Medicos (
	Legajo_Me CHAR(5) NOT NULL,
	Id_Localidad_Me INT NOT NULL,
	Id_Especialidad_Me INT NOT NULL,
	Id_Nacionalidad_Me INT NOT NULL,
	Id_Genero_Me INT NOT NULL,
	Usuario_Me VARCHAR(50) NOT NULL,
	DNI_Me CHAR(8) NOT NULL,
	Email_Me VARCHAR(100) NOT NULL,
	Nombre_Me VARCHAR(50) NOT NULL,
	Apellido_Me VARCHAR(50) NOT NULL,
	Fecha_Nacimiento_Me DATE NOT NULL,
	Direccion_Me VARCHAR(100) NOT NULL,
	Telefono_Me VARCHAR(15) NOT NULL,
	Estado_Me BIT DEFAULT 1 NOT NULL,
	CONSTRAINT PK_Medicos PRIMARY KEY (Legajo_Me),
	CONSTRAINT FK_Medicos_Nacionalidades FOREIGN KEY (Id_Nacionalidad_Me) REFERENCES Nacionalidades (Id_Nacionalidad_Na),
	CONSTRAINT FK_Medicos_Localidades FOREIGN KEY (Id_Localidad_Me) REFERENCES Localidades (Id_Localidad_Lo),
	CONSTRAINT FK_Medicos_Especialidades FOREIGN KEY (Id_Especialidad_Me) REFERENCES Especialidades (Id_Especialidad_Es),
	CONSTRAINT FK_Medicos_Generos FOREIGN KEY (Id_Genero_Me) REFERENCES Generos (Id_Genero_Ge),
	CONSTRAINT FK_Medicos_Usuarios FOREIGN KEY (Usuario_Me) REFERENCES Usuarios (Usuario_Us),
	CONSTRAINT UK_Dni_Medicos UNIQUE (Id_Nacionalidad_Me, DNI_Me),
	CONSTRAINT UK_Email_Medicos UNIQUE (Email_Me),
	CONSTRAINT UK_Usuario_Medicos UNIQUE (Usuario_Me)
)
GO

CREATE TABLE Pacientes (
	DNI_Pa CHAR(8) NOT NULL,
	Id_Localidad_Pa INT NOT NULL,
	Id_Nacionalidad_Pa INT NOT NULL,
	Id_Genero_Pa INT NOT NULL,
	Email_Pa VARCHAR(100) NOT NULL,
	Nombre_Pa VARCHAR(50) NOT NULL,
	Apellido_Pa VARCHAR(50) NOT NULL,
	Fecha_Nacimiento_Pa DATE NOT NULL,
	Direccion_Pa VARCHAR(100) NOT NULL,
	Telefono_Pa VARCHAR(15) NOT NULL,
	Estado_Pa BIT DEFAULT 1 NOT NULL,
	CONSTRAINT PK_Pacientes PRIMARY KEY (DNI_Pa, Id_Nacionalidad_Pa),
	CONSTRAINT FK_Pacientes_Nacionalidades FOREIGN KEY (Id_Nacionalidad_Pa) REFERENCES Nacionalidades (Id_Nacionalidad_Na),
	CONSTRAINT FK_Pacientes_Localidades FOREIGN KEY (Id_Localidad_Pa) REFERENCES Localidades (Id_Localidad_Lo),
	CONSTRAINT FK_Pacientes_Generos FOREIGN KEY (Id_Genero_Pa) REFERENCES Generos (Id_Genero_Ge),
	CONSTRAINT UK_Email_Pacientes UNIQUE (Email_Pa)
)
GO

CREATE TABLE Dias_Semanas (
	Id_Dia_Semana_DS INT NOT NULL,
	Descripcion_DS VARCHAR(9) NOT NULL,
	CONSTRAINT PK_Dias_Semanas PRIMARY KEY (Id_Dia_Semana_DS)
)
GO

CREATE TABLE Horarios_Medicos (
	Legajo_Medico_HM CHAR(5) NOT NULL,
	Id_Dia_Semana_HM INT NOT NULL,
	Hora_Inicio_HM TIME(0) NOT NULL,
	Hora_Fin_HM TIME(0) NOT NULL,
	CONSTRAINT PK_Horarios_Medicos PRIMARY KEY (Legajo_Medico_HM, Id_Dia_Semana_HM),
	CONSTRAINT FK_Horarios_Meds_Medicos FOREIGN KEY (Legajo_Medico_HM) REFERENCES Medicos (Legajo_Me),
	CONSTRAINT FK_Horarios_Medicos_Dias_Semanas FOREIGN KEY (Id_Dia_Semana_HM) REFERENCES Dias_Semanas (Id_Dia_Semana_DS),
	CONSTRAINT CK_Hora_Fin CHECK (Hora_Fin_HM > Hora_Inicio_HM)
)
GO

CREATE TABLE Tipos_Ausencias_Medicos (
    Id_Tipo_Ausencia_TAM INT IDENTITY (1, 1) NOT NULL,
    Cod_Tipo_Ausencia_TAM CHAR(2) NOT NULL,
    Descripcion_TAM VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Tipos_Ausencias_Medicos PRIMARY KEY (Id_Tipo_Ausencia_TAM),
    CONSTRAINT UK_Cod_Tipo_Ausencia UNIQUE (Cod_Tipo_Ausencia_TAM)
)
GO

CREATE TABLE Ausencias_Medicos (
	Legajo_Medico_AM CHAR(5) NOT NULL,
	Id_Tipo_Ausencia_AM INT NOT NULL,
	Fecha_Inicio_AM DATE NOT NULL,
	Fecha_Fin_AM DATE NOT NULL,
	CONSTRAINT PK_Ausencias_Medicos PRIMARY KEY (Legajo_Medico_AM, Fecha_Inicio_AM),
	CONSTRAINT FK_AM_TAM FOREIGN KEY (Id_Tipo_Ausencia_AM) REFERENCES Tipos_Ausencias_Medicos (Id_Tipo_Ausencia_TAM),
	CONSTRAINT FK_AM_Medicos FOREIGN KEY (Legajo_Medico_AM) REFERENCES Medicos (Legajo_Me),
	CONSTRAINT CK_Fecha_Fin CHECK (Fecha_Fin_AM >= Fecha_Inicio_AM)
)
GO

CREATE TABLE Ciclos_Turnos (
	Id_Ciclo_Turno_CT INT IDENTITY(1, 1) NOT NULL,
	Cod_Ciclo_Turno_CT CHAR(3) NOT NULL,
	Descripcion_CT VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Ciclos_Turnos PRIMARY KEY (Id_Ciclo_Turno_CT),
	CONSTRAINT UK_Cod_Ciclo_Turno UNIQUE (Cod_Ciclo_Turno_CT)
)
GO

CREATE TABLE Detalles_Turnos (
	Id_Detalle_Turno_DT INT IDENTITY(1, 1) NOT NULL,
	Cod_Detalle_Turno_DT CHAR(3) NOT NULL,
	Descripcion_DT VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Detalles_Turnos PRIMARY KEY (Id_Detalle_Turno_DT),
	CONSTRAINT UK_Cod_Detalle_Turno UNIQUE (Cod_Detalle_Turno_DT)
)
GO

CREATE TABLE Turnos (
	Id_Turno_Tu INT IDENTITY(1, 1) NOT NULL,
	Id_Ciclo_Turno_Tu INT DEFAULT 1 NOT NULL ,
	Id_Detalle_Turno_Tu INT DEFAULT 1 NOT NULL,
	Legajo_Medico_Tu CHAR(5) NOT NULL,
	Fecha_Tu DATE NOT NULL,
	Hora_Tu TIME(0) NOT NULL,
	DNI_Paciente_Tu CHAR(8) NOT NULL,
	Id_Nacionalidad_Paciente_Tu INT NOT NULL,
	Asistencia_Tu BIT DEFAULT 0 NOT NULL,
	Observaciones_Tu VARCHAR(255) DEFAULT 'Sin observaciones',
	Estado_Tu BIT DEFAULT 1 NOT NULL,
	CONSTRAINT PK_Turnos PRIMARY KEY (Id_Turno_Tu),
	CONSTRAINT FK_Turnos_Medicos FOREIGN KEY (Legajo_Medico_Tu) REFERENCES Medicos (Legajo_Me),
	CONSTRAINT FK_Turnos_Pacientes FOREIGN KEY (DNI_Paciente_Tu, Id_Nacionalidad_Paciente_Tu) REFERENCES Pacientes (DNI_Pa, Id_Nacionalidad_Pa),
	CONSTRAINT FK_Turnos_CT FOREIGN KEY (Id_Ciclo_Turno_Tu) REFERENCES Ciclos_Turnos (Id_Ciclo_Turno_CT),
	CONSTRAINT FK_Turnos_DT FOREIGN KEY (Id_Detalle_Turno_Tu) REFERENCES Detalles_Turnos (Id_Detalle_Turno_DT),
	CONSTRAINT UK_Fecha_Hora_Paciente UNIQUE (Fecha_Tu, Hora_Tu, Id_Nacionalidad_Paciente_Tu, DNI_Paciente_Tu)
)
GO

-- CARGA DE DATOS PARA PROVINCIAS
INSERT INTO Provincias (Cod_Provincia_Pr, Descripcion_Pr) VALUES 
('BUE', 'Buenos Aires'),
('CAT', 'Catamarca'),
('CHA', 'Chaco'),
('CHU', 'Chubut'),
('CBA', 'Córdoba'),
('COR', 'Corrientes'),
('ERI', 'Entre Ríos'),
('FOR', 'Formosa'),
('JUJ', 'Jujuy'),
('LPA', 'La Pampa'),
('LRI', 'La Rioja'),
('MEN', 'Mendoza'),
('MIS', 'Misiones'),
('NEU', 'Neuquén'),
('RNE', 'Río Negro'),
('SAL', 'Salta'),
('SJU', 'San Juan'),
('SLS', 'San Luis'),
('SCR', 'Santa Cruz'),
('SFE', 'Santa Fe'),
('SDE', 'Santiago del Estero'),
('TDF', 'Tierra del Fuego'),
('TUC', 'Tucumán'),
('CAB', 'Ciudad Autónoma de Buenos Aires')
GO

-- CARGA DE DATOS PARA LOCALIDADES
INSERT INTO Localidades (Cod_Localidad_Lo, Descripcion_Lo, Id_Provincia_Lo) VALUES 
('BUE01', 'La Plata', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'BUE')),
('BUE02', 'Mar del Plata', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'BUE')),
('BUE03', 'Bragado', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'BUE')),
('BUE04', 'General Pacheco', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'BUE')),
('CAT01', 'San Fernando del Valle', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'CAT')),
('CAT02', 'Belén', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'CAT')),
('CHA01', 'Resistencia', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'CHA')),
('CHA02', 'Roque Sáenz Peña', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'CHA')),
('CHU01', 'Rawson', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'CHU')),
('CHU02', 'Trelew', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'CHU')),
('CBA01', 'Córdoba', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'CBA')),
('CBA02', 'Villa Carlos Paz', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'CBA')),
('COR01', 'Corrientes', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'COR')),
('COR02', 'Goya', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'COR')),
('ERI01', 'Paraná', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'ERI')),
('ERI02', 'Concordia', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'ERI')),
('FOR01', 'Formosa', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'FOR')),
('FOR02', 'Clorinda', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'FOR')),
('JUJ01', 'San Salvador de Jujuy', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'JUJ')),
('JUJ02', 'Palpalá', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'JUJ')),
('LPA01', 'Santa Rosa', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'LPA')),
('LPA02', 'General Pico', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'LPA')),
('LRI01', 'La Rioja', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'LRI')),
('LRI02', 'Chilecito', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'LRI')),
('MEN01', 'Mendoza', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'MEN')),
('MEN02', 'San Rafael', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'MEN')),
('MIS01', 'Posadas', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'MIS')),
('MIS02', 'Oberá', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'MIS')),
('NEU01', 'Neuquén', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'NEU')),
('NEU02', 'San Martín de los Andes', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'NEU')),
('RNE01', 'Viedma', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'RNE')),
('RNE02', 'Bariloche', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'RNE')),
('SAL01', 'Salta', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SAL')),
('SAL02', 'Tartagal', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SAL')),
('SJU01', 'San Juan', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SJU')),
('SJU02', 'Jáchal', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SJU')),
('SLS01', 'San Luis', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SLS')),
('SLS02', 'Villa Mercedes', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SLS')),
('SCR01', 'Río Gallegos', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SCR')),
('SCR02', 'Caleta Olivia', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SCR')),
('SFE01', 'Santa Fe', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SFE')),
('SFE02', 'Rosario', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SFE')),
('SDE01', 'Santiago del Estero', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SDE')),
('SDE02', 'La Banda', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'SDE')),
('TDF01', 'Ushuaia', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'TDF')),
('TDF02', 'Río Grande', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'TDF')),
('TUC01', 'San Miguel de Tucumán', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'TUC')),
('TUC02', 'Concepción', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'TUC')),
('CAB01', 'Palermo', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'CAB')),
('CAB02', 'Recoleta', (SELECT Id_Provincia_Pr FROM Provincias WHERE Cod_Provincia_Pr = 'CAB'))
GO

-- CARGA DE DATOS PARA ESPECIALIDADES
INSERT INTO Especialidades (Cod_Especialidad_Es, Descripcion_Es) VALUES 
('MED', 'Medicina General'),
('CAR', 'Cardiología'),
('DER', 'Dermatología'),
('NEU', 'Neurología'),
('PED', 'Pediatría'),
('PSY', 'Psiquiatría'),
('GIN', 'Gineco-Obstetricia'),
('ONC', 'Oncología'),
('ORT', 'Ortopedia'),
('OTO', 'Otorrinolaringología'),
('PSR', 'Psicología'),
('REH', 'Rehabilitación'),
('TRA', 'Traumatología'),
('CIR', 'Cirugía General'),
('FIS', 'Fisiatría'),
('NUT', 'Nutrición'),
('INM', 'Inmunología'),
('URO', 'Urología'),
('NEF', 'Nefrología'),
('INF', 'Infectología'),
('ADO', 'Adicciones'),
('RAD', 'Radiología'),
('END', 'Endocrinología'),
('ALO', 'Alergología'),
('GER', 'Geriatría'),
('PNE', 'Neumonología'),
('HEM', 'Hematología'),
('GEN', 'Genética Médica')
GO

-- CARGA DE DATOS PARA TIPO DE USUARIOS
INSERT INTO Tipos_Usuarios (Cod_Tipo_Usuario_TU, Descripcion_TU) VALUES
('ADM', 'Administrador'),
('MED', 'Médico')
GO

-- CARGA DE USUARIOS
INSERT INTO Usuarios (Usuario_Us, Clave_Us, Email_Us, Id_Tipo_Usuario_Us) VALUES
('admin', '123', 'admin@clinica.com.ar', 1),
('medico', '123', 'medico@clinica.com.ar', 2),
('riveiro', '123', 'riveiro@clinica.com.ar', 2),
('chenagil', '123', 'chenagil@clinica.com.ar', 2),
('lavia', '123', 'lavia@clinica.com.ar', 2),
('luques', '123', 'luques@clinica.com.ar', 2),
('reyesgorbaran', '123', 'reyesgorbaran@clinica.com.ar', 2),
('leon', '123', 'leon@clinica.com.ar', 2),
('sanchez', '123', 'dsanchez@clinica.com.ar', 2),
('hernandez', '123', 'mhernandez@clinica.com.ar', 2),
('clopez', '123', 'clopez@clinica.com.ar', 2),
('rjimenez', '123', 'rjimenez@clinica.com.ar', 2),
('mperez', '123', 'mperez@clinica.com.ar', 2),
('erodriguez', '123', 'erodriguez@clinica.com.ar', 2),
('egarcia', '123', 'egarcia@clinica.com.ar', 2),
('lfernandez', '123', 'lfernandez@clinica.com.ar', 2)
GO

-- CARGA DE DATOS PARA NACIONALIDADES
INSERT INTO Nacionalidades (Cod_Nacionalidad_Na, Descripcion_Na) VALUES
('AR', 'Argentina'),
('BO', 'Bolivia'),
('BR', 'Brasil'),
('CL', 'Chile'),
('CO', 'Colombia'),
('CR', 'Costa Rica'),
('CU', 'Cuba'),
('DO', 'República Dominicana'),
('EC', 'Ecuador'),
('SV', 'El Salvador'),
('GT', 'Guatemala'),
('HN', 'Honduras'),
('MX', 'México'),
('NI', 'Nicaragua'),
('PA', 'Panamá'),
('PY', 'Paraguay'),
('PE', 'Perú'),
('PR', 'Puerto Rico'),
('UR', 'Uruguay'),
('VE', 'Venezuela')
GO

-- CARGA DE DATOS PARA GENEROS
INSERT INTO Generos (Cod_Genero_Ge, Descripcion_Ge) VALUES
('M', 'Masculino'),
('F', 'Femenino'),
('X', 'Otro')
GO

-- CARGA DE DATOS PARA MEDICOS
INSERT INTO Medicos (Usuario_Me, Legajo_Me, Id_Localidad_Me, Id_Especialidad_Me, Id_Nacionalidad_Me, DNI_Me, Email_Me, Nombre_Me, Apellido_Me, Id_Genero_Me, Fecha_Nacimiento_Me, Direccion_Me, Telefono_Me)
VALUES
('medico','11111', 1, 2, 1, '20202020', 'jperez@gmail.com', 'Juan', 'Pérez', 1, '1985-05-15', 'Av. Siempre Viva 123', '1123456789'),
('riveiro','29878', 3, 3, 1, '38553293', 'riveiro@gmail.com', 'Ernesto José', 'Riveiro', 1, '1995-03-08', 'Calle 2367', '2342458560'),
('chenagil','33333', 2, 1, 1, '40404040', 'chenagil@gmail.com', 'Facundo Tomas', 'Chena Gil', 1, '1978-01-10', 'Calle 123', '1145678901'),
('lavia','44444', 4, 2, 1, '50505050', 'lavia@gmail.com', 'Gabriela Beatriz', 'Lavia', 2, '1982-09-20', 'Av. Libertador 234', '1156789012'),
('luques','55555', 5, 3, 1, '60606060', 'luques@gmail.com', 'Victoria Abril', 'Luques', 2, '1988-12-11', 'Calle Primavera 567', '1167890123'),
('reyesgorbaran','66666', 6, 1, 1, '70707070', 'reyesgorbaran@gmail.com', 'María Victoria', 'Reyes Gorbarán', 2, '1995-03-14', 'Calle Luna 890', '1178901234'),
('leon','77777', 7, 2, 1, '80808080', 'leon@gmail.com', 'Justina', 'Leon', 2, '1987-08-30', 'Av. Tucumán 234', '1189012345'),
('sanchez','88888', 8, 3, 8, '90909090', 'dsanchez@gmail.com', 'Daniel', 'Sánchez', 1, '1980-04-25', 'Calle Sol 123', '1190123456'),
('hernandez','99999', 9, 1, 9, '10101010', 'mhernandez@gmail.com', 'Martín', 'Hernández', 1, '1992-06-18', 'Calle del Mar 456', '1201234567'),
('clopez','10000', 10, 2, 10, '11111111', 'clopez@gmail.com', 'Carmen', 'López', 2, '1993-11-05', 'Av. Buenos Aires 123', '1212345678'),
('rjimenez','20000', 11, 3, 1, '12121212', 'rjimenez@gmail.com', 'Roberto', 'Jiménez', 1, '1986-07-13', 'Calle Rivadavia 789', '1223456789'),
('mperez','30000', 12, 1, 2, '13131313', 'mperez@gmail.com', 'Mercedes', 'Pérez', 2, '1984-09-22', 'Av. San Martín 456', '1234567890'),
('erodriguez','40000', 13, 2, 3, '14141414', 'erodriguez@gmail.com', 'Esteban', 'Rodríguez', 3, '1994-01-02', 'Calle de los Árboles 567', '1245678901'),
('egarcia','50000', 14, 3, 4, '15151515', 'egarcia@gmail.com', 'Elena', 'García', 3, '1983-06-25', 'Calle Azul 890', '1256789012'),
('lfernandez','60000', 15, 1, 5, '16161616', 'lfernandez@gmail.com', 'Luis', 'Fernández', 1, '1991-04-03', 'Calle del Sol 321', '1267890123')
GO

-- CARGA DIAS DE LA SEMANA
INSERT INTO Dias_Semanas (Id_Dia_Semana_DS, Descripcion_DS) VALUES
(1,'Lunes'),
(2,'Martes'),
(3,'Miercoles'),
(4,'Jueves'),
(5,'Viernes'),
(6,'Sabado'),
(7,'Domingo')
GO

-- CARGA TIPOS DE AUSENCIAS
INSERT INTO Tipos_Ausencias_Medicos (Cod_Tipo_Ausencia_TAM, Descripcion_TAM) VALUES
('VA', 'Vacaciones'),
('FR', 'Franco semanal'),
('DE', 'Día de estudio'),
('JM', 'Justificativo médico'),
('TA', 'Trabajo administrativo'),
('DA', 'Día adicional por emergencias'),
('OT', 'Otros')
GO

-- CARGA DE AUSENCIAS
INSERT INTO Ausencias_Medicos (Legajo_Medico_AM, Id_Tipo_Ausencia_AM, Fecha_Inicio_AM, Fecha_Fin_AM)
VALUES
('11111', 1, '2024-11-28', '2024-11-29'),
('11111', 2, '2024-12-01', '2024-12-05'),
('29878', 3, '2024-11-15', '2024-11-17'),
('33333', 4, '2024-10-05', '2024-10-06'),
('44444', 1, '2024-09-20', '2024-09-22')
GO

-- CARGA DE HORARIOS
INSERT INTO Horarios_Medicos (Legajo_Medico_HM, Id_Dia_Semana_HM, Hora_Inicio_HM, Hora_Fin_HM)
VALUES
-- Juan
('11111', 1, '08:00', '12:00'),
('11111', 2, '08:00', '12:00'),
('11111', 3, '08:00', '12:00'),
('11111', 4, '08:00', '12:00'),
('11111', 5, '08:00', '12:00'), 
-- Ernesto
('29878', 1, '09:00', '13:00'),
('29878', 2, '09:00', '13:00'),
('29878', 3, '09:00', '13:00'),
('29878', 4, '09:00', '13:00'),
('29878', 5, '09:00', '13:00'),
-- Facundo
('33333', 1, '10:00', '14:00'),
('33333', 2, '10:00', '14:00'),
('33333', 3, '10:00', '14:00'),
('33333', 4, '10:00', '14:00'),
('33333', 5, '10:00', '14:00'),
-- Gabriela
('44444', 1, '08:00', '12:00'),
('44444', 2, '08:00', '12:00'),
('44444', 3, '08:00', '12:00'),
('44444', 4, '08:00', '12:00'),
('44444', 5, '08:00', '12:00'),
-- Victoria
('55555', 1, '07:00', '11:00'),
('55555', 2, '07:00', '11:00'),
('55555', 3, '07:00', '11:00'),
('55555', 4, '07:00', '11:00'),
('55555', 5, '07:00', '11:00'),
-- María
('66666', 1, '08:00', '12:00'),
('66666', 2, '08:00', '12:00'),
('66666', 3, '08:00', '12:00'),
('66666', 4, '08:00', '12:00'),
('66666', 5, '08:00', '12:00'),
-- Leon
('77777', 1, '09:00', '13:00'),
('77777', 2, '09:00', '13:00'),
('77777', 3, '09:00', '13:00'),
('77777', 4, '09:00', '13:00'),
('77777', 5, '09:00', '13:00'),
-- Daniel
('88888', 1, '10:00', '14:00'),
('88888', 2, '10:00', '14:00'),
('88888', 3, '10:00', '14:00'),
('88888', 4, '10:00', '14:00'),
('88888', 5, '10:00', '14:00'),
-- Martín
('99999', 1, '08:00', '12:00'),
('99999', 2, '08:00', '12:00'),
('99999', 3, '08:00', '12:00'),
('99999', 4, '08:00', '12:00'),
('99999', 5, '08:00', '12:00'),
-- Carmen
('10000', 1, '09:00', '13:00'),
('10000', 2, '09:00', '13:00'),
('10000', 3, '09:00', '13:00'),
('10000', 4, '09:00', '13:00'),
('10000', 5, '09:00', '13:00'),
-- Roberto
('20000', 1, '08:00', '12:00'),
('20000', 2, '08:00', '12:00'),
('20000', 3, '08:00', '12:00'),
('20000', 4, '08:00', '12:00'),
('20000', 5, '08:00', '12:00'),
-- Mercedes
('30000', 1, '08:00', '12:00'),
('30000', 2, '08:00', '12:00'),
('30000', 3, '08:00', '12:00'),
('30000', 4, '08:00', '12:00'),
('30000', 5, '08:00', '12:00'),
-- Esteban
('40000', 1, '07:00', '11:00'),
('40000', 2, '07:00', '11:00'),
('40000', 3, '07:00', '11:00'),
('40000', 4, '07:00', '11:00'),
('40000', 5, '07:00', '11:00'),
-- Elena
('50000', 1, '10:00', '14:00'),
('50000', 2, '10:00', '14:00'),
('50000', 3, '10:00', '14:00'),
('50000', 4, '10:00', '14:00'),
('50000', 5, '10:00', '14:00'),
-- Luis
('60000', 1, '09:00', '13:00'),
('60000', 2, '09:00', '13:00'),
('60000', 3, '09:00', '13:00'),
('60000', 4, '09:00', '13:00'),
('60000', 5, '09:00', '13:00');
GO

-- CARGA DE PACIENTES
INSERT INTO Pacientes (DNI_Pa, Id_Localidad_Pa, Id_Nacionalidad_Pa, Id_Genero_Pa, Email_Pa, Nombre_Pa, Apellido_Pa, Fecha_Nacimiento_Pa, Direccion_Pa, Telefono_Pa)
VALUES
('30303030', 2, 1, 2, 'amarcos@gmail.com', 'Ana', 'Marcos', '1995-02-17', 'Calle Rio 123', '1134567890'),
('32323232', 4, 2, 1, 'bluma@gmail.com', 'Bruno', 'Luna', '1988-04-25', 'Calle Nube 234', '1145678901'),
('34343434', 3, 1, 2, 'cromero@gmail.com', 'Carla', 'Romero', '1992-06-30', 'Av. Libertador 123', '1156789012'),
('35353535', 5, 3, 1, 'dmendez@gmail.com', 'Damián', 'Méndez', '1985-10-10', 'Calle Primavera 567', '1167890123'),
('36363636', 6, 1, 2, 'efranco@gmail.com', 'Elena', 'Franco', '1990-03-21', 'Calle Sol 890', '1178901234'),
('37373737', 2, 1, 1, 'fgomez@gmail.com', 'Fernando', 'Gómez', '1994-12-05', 'Av. Siempre Viva 234', '1189012345'),
('38383838', 7, 2, 2, 'gperalta@gmail.com', 'Gabriela', 'Peralta', '1991-07-19', 'Calle Tucumán 456', '1190123456'),
('39393939', 8, 3, 1, 'hlopez@gmail.com', 'Hernán', 'López', '1987-01-27', 'Av. Rivadavia 789', '1201234567'),
('40404040', 9, 1, 2, 'idelgado@gmail.com', 'Isabel', 'Delgado', '1986-11-10', 'Calle Luna 321', '1212345678'),
('41414141', 10, 2, 1, 'jgonzalez@gmail.com', 'Jorge', 'González', '1992-08-14', 'Calle Azul 567', '1223456789'),
('42424242', 11, 1, 2, 'kleiva@gmail.com', 'Karina', 'Leiva', '1993-03-18', 'Calle del Mar 234', '1234567890'),
('43434343', 12, 3, 1, 'lramirez@gmail.com', 'Luis', 'Ramírez', '1985-09-09', 'Av. San Martín 456', '1245678901'),
('44444444', 13, 1, 2, 'mgutierrez@gmail.com', 'María', 'Gutiérrez', '1989-05-29', 'Calle de los Árboles 678', '1256789012'),
('45454545', 14, 2, 1, 'ncarrasco@gmail.com', 'Nicolás', 'Carrasco', '1990-07-22', 'Av. Buenos Aires 890', '1267890123'),
('46464646', 15, 1, 2, 'orivero@gmail.com', 'Olivia', 'Rivero', '1995-10-17', 'Calle del Sol 234', '1278901234')
GO

-- CARGA DE DATOS PARA LOS CICLOS DE UN TURNO
INSERT INTO Ciclos_Turnos (Cod_Ciclo_Turno_CT, Descripcion_CT) VALUES 
('ACT', 'Activo'),
('PEN', 'Pendiente'),
('REP', 'Reprogramado'),
('TER', 'Terminado'),
('CAN', 'Cancelado')
GO

-- CARGA DE DATOS PARA ESPECIFICAR DETALLES SEGUN EL CICLO
INSERT INTO Detalles_Turnos (Cod_Detalle_Turno_DT, Descripcion_DT) VALUES 
('N/A', 'No Aplica'),
('AUS', 'Ausencia Medico'),
('SOL', 'Solicitud de Reprogramacion'),
('CAN', 'Cancelacion Administrativa')
GO

-- CARGA DE TURNOS
INSERT INTO Turnos (Legajo_Medico_Tu, Fecha_Tu, Hora_Tu, Id_Ciclo_Turno_Tu, Id_Detalle_Turno_Tu, Id_Nacionalidad_Paciente_Tu, DNI_Paciente_Tu, Estado_Tu, Asistencia_Tu)
VALUES
-- Médico 1
('11111', '2024-11-15', '08:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('11111', '2024-11-29', '08:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('11111', '2024-11-14', '08:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('11111', '2024-11-13', '09:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('11111', '2024-11-12', '09:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('11111', '2024-11-11', '08:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('11111', '2024-11-18', '08:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0 
-- Médico 2
('29878', '2024-11-16', '11:00', 4, 1, 1, '30303030', 1, 0), -- Ciclo 'TER' (No aplica), Estado 1
('29878', '2024-11-30', '11:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('29878', '2024-11-15', '11:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('29878', '2024-11-14', '11:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('29878', '2024-11-13', '11:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('29878', '2024-11-12', '11:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('29878', '2024-11-19', '11:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0 
-- Médico 3
('33333', '2024-11-17', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('33333', '2024-12-01', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('33333', '2024-11-16', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('33333', '2024-11-15', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('33333', '2024-11-14', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('33333', '2024-11-13', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('33333', '2024-11-20', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 4				
('44444', '2024-11-18', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('44444', '2024-12-02', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('44444', '2024-11-17', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('44444', '2024-11-16', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('44444', '2024-11-15', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('44444', '2024-11-14', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('44444', '2024-11-21', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 5				
('55555', '2024-11-19', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('55555', '2024-12-03', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('55555', '2024-11-18', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('55555', '2024-11-17', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('55555', '2024-11-16', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('55555', '2024-11-15', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('55555', '2024-11-22', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 6	
('66666', '2024-11-20', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('66666', '2024-12-04', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('66666', '2024-11-19', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('66666', '2024-11-18', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('66666', '2024-11-17', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('66666', '2024-11-16', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('66666', '2024-11-23', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 7				
('77777', '2024-11-21', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('77777', '2024-12-05', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('77777', '2024-11-20', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('77777', '2024-11-19', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('77777', '2024-11-18', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('77777', '2024-11-17', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('77777', '2024-11-24', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 8				
('88888', '2024-11-22', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('88888', '2024-12-06', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('88888', '2024-11-21', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('88888', '2024-11-20', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('88888', '2024-11-19', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('88888', '2024-11-18', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('88888', '2024-11-25', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 9				
('99999', '2024-11-23', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('99999', '2024-12-07', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('99999', '2024-11-22', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('99999', '2024-11-21', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('99999', '2024-11-20', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('99999', '2024-11-19', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('99999', '2024-11-26', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 10
('10000', '2024-11-24', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('10000', '2024-12-08', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('10000', '2024-11-23', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('10000', '2024-11-22', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('10000', '2024-11-21', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('10000', '2024-11-20', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('10000', '2024-11-27', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 11				
('20000', '2024-11-25', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('20000', '2024-12-09', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('20000', '2024-11-24', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('20000', '2024-11-23', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('20000', '2024-11-22', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('20000', '2024-11-21', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('20000', '2024-11-28', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 12				
('30000', '2024-11-26', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('30000', '2024-12-10', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('30000', '2024-11-25', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('30000', '2024-11-24', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('30000', '2024-11-23', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('30000', '2024-11-22', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('30000', '2024-11-29', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 13				
('40000', '2024-11-27', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('40000', '2024-12-11', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('40000', '2024-11-26', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('40000', '2024-11-25', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('40000', '2024-11-24', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('40000', '2024-11-23', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('40000', '2024-11-30', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 14				
('50000', '2024-11-28', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('50000', '2024-12-12', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('50000', '2024-11-27', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('50000', '2024-11-26', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('50000', '2024-11-25', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('50000', '2024-11-24', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('50000', '2024-12-01', '10:00', 5, 4, 1, '46464646', 0, 0), -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
-- Médico 15				
('60000', '2024-11-29', '10:00', 4, 1, 1, '30303030', 1, 1), -- Ciclo 'TER' (No aplica), Estado 1
('60000', '2024-12-13', '10:00', 1, 1, 2, '45454545', 1, 0), -- Ciclo 'ACT' (No aplica), Estado 1
('60000', '2024-11-28', '10:00', 2, 2, 3, '39393939', 0, 0), -- Ciclo 'PEN' (Ausencia Médica), Estado 0
('60000', '2024-11-27', '10:00', 3, 2, 2, '38383838', 0, 0), -- Ciclo 'REP' (Ausencia Médica), Estado 0 
('60000', '2024-11-26', '10:00', 3, 3, 2, '32323232', 0, 0), -- Ciclo 'REP' (Solicitud de Reprogramacion), Estado 0 
('60000', '2024-11-25', '10:00', 5, 2, 1, '37373737', 0, 0), -- Ciclo 'CAN' (Ausencia Médica), Estado 0 
('60000', '2024-12-02', '10:00', 5, 4, 1, '46464646', 0, 0) -- Ciclo 'CAN' (Cancelacion Administrativa), Estado 0
GO