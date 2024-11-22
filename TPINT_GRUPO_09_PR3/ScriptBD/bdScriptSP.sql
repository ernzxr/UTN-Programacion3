USE UTN2C2024PR3CLINICA
GO

-- AGREGAR AUSENCIAS
CREATE OR ALTER PROCEDURE spAgregarAusencia
	@LEGAJO INT, @TIPO INT, @FECHA_INICIO DATE, @FECHA_FIN DATE
AS
	BEGIN
		INSERT INTO Ausencias_Medicos (Legajo_Medico_AM, Id_Tipo_Ausencia_AM, Fecha_Inicio_AM, Fecha_Fin_AM)
		VALUES (@LEGAJO, @TIPO, @FECHA_INICIO, @FECHA_FIN)
	END
GO

-- AGREGAR PACIENTES
CREATE OR ALTER PROCEDURE spAgregarPaciente
(
@DNI CHAR(8),
@NOMBRE VARCHAR(50),
@APELLIDO VARCHAR(50),
@SEXO INT,
@FECHANACIMIENTO DATE,
@NACIONALIDAD INT,
@LOCALIDAD INT,
@DIRECCION VARCHAR(100),
@CORREOELECTRONICO VARCHAR(100),
@TELEFONO VARCHAR(15),
@ESTADO BIT
)
AS
INSERT INTO Pacientes(Dni_Pa, Nombre_Pa, Apellido_Pa, Id_Genero_Pa, Fecha_Nacimiento_Pa, Id_Nacionalidad_Pa, Id_Localidad_Pa, Direccion_Pa, Email_Pa, Telefono_Pa, Estado_Pa)
VALUES (@DNI, @NOMBRE, @APELLIDO, @SEXO, @FECHANACIMIENTO, @NACIONALIDAD, @LOCALIDAD, @DIRECCION, @CORREOELECTRONICO, @TELEFONO, @ESTADO)
RETURN 
GO

CREATE OR ALTER PROCEDURE sp_ObtenerLegajoPorNombreCompleto
    @NombreCompleto VARCHAR(100)
AS
BEGIN
    SELECT Legajo_Me
    FROM Medicos
    WHERE (Nombre_Me + ' ' + Apellido_Me) = @NombreCompleto
END
GO

CREATE OR ALTER PROCEDURE spObtenerDiasLaborales
    @LegajoMedico CHAR(5)
AS
BEGIN
    SELECT Id_Dia_Semana_HM, Hora_Inicio_HM, Hora_Fin_HM 
    FROM Horarios_Medicos 
    WHERE Legajo_Medico_HM = @LegajoMedico
END
GO

CREATE OR ALTER PROCEDURE sp_ObtenerFechasAusencias
    @LegajoMedico CHAR(5)
AS
BEGIN
    SELECT Fecha_Inicio_AM, Fecha_Fin_AM
    FROM Ausencias_Medicos 
    WHERE Legajo_Medico_AM = @LegajoMedico
END
GO

CREATE OR ALTER PROCEDURE spObtenerFechasConTurnosCompletos
    @LegajoMedico CHAR(5)
AS
BEGIN
    SELECT Fecha_Tu
    FROM Turnos
    WHERE Legajo_Medico_Tu = @LegajoMedico
    GROUP BY Fecha_Tu
    HAVING COUNT(*) >= (SELECT MAX(DATEDIFF(HOUR, Hora_Inicio_HM, Hora_Fin_HM))
                        FROM Horarios_Medicos
                        WHERE Legajo_Medico_HM = @LegajoMedico)
END
GO

-- FILTRAR AUSENCIAS POR MEDICO
CREATE OR ALTER PROCEDURE spFiltrarAusenciasLegajo
	@LEGAJO CHAR(5)
AS
	BEGIN
		SELECT *
		FROM Ausencias_Medicos
		WHERE Legajo_Medico_AM = @LEGAJO
	END
GO

-- AGREGAR USUARIOS
CREATE OR ALTER PROCEDURE spAgregarUsuario
	@USUARIO VARCHAR(50), @CLAVE VARCHAR(80), @EMAIL VARCHAR(100), @TIPO INT
AS
	BEGIN
		INSERT INTO Usuarios (Usuario_Us, Clave_Us, Email_Us, Id_Tipo_Usuario_Us)
		VALUES (@USUARIO, @CLAVE, @EMAIL, @TIPO)
	END
GO

CREATE OR ALTER PROCEDURE spAgregarMedico
(
@LEGAJO CHAR(5),
@LOCALIDAD INT,
@ESPECIALIDAD INT,
@NACIONALIDAD INT, 
@GENERO INT, 
@USUARIO VARCHAR(50),
@DNI CHAR(8),
@EMAIL VARCHAR(100),
@NOMBRE VARCHAR (50),
@APELLIDO VARCHAR(50),
@FECHANACIMIENTO DATE,
@DIRECCION VARCHAR(100),
@TELEFONO VARCHAR(15)
)
AS 
INSERT INTO Medicos(Legajo_Me,Id_Localidad_Me,Id_Especialidad_Me,Id_Nacionalidad_Me,Id_Genero_Me,Usuario_Me,DNI_Me,Email_Me,Nombre_Me,Apellido_Me,Fecha_Nacimiento_Me,Direccion_Me,Telefono_Me)
VALUES(@LEGAJO,@LOCALIDAD,@ESPECIALIDAD,@NACIONALIDAD,@GENERO,@USUARIO,@DNI,@EMAIL,@NOMBRE,@APELLIDO,@FECHANACIMIENTO,@DIRECCION,@TELEFONO)
RETURN
GO

-- FILTRAR AUSENCIAS
CREATE OR ALTER PROCEDURE spFiltrarAusenciasLegajo
@LEGAJO VARCHAR(5)
AS 
	BEGIN
		SELECT Legajo_Medico_AM, (Me.Nombre_Me + ' ' + Me.Apellido_Me) AS Nombre_Completo, 
		TAM.Descripcion_TAM, Fecha_Inicio_AM, Fecha_Fin_AM  
		FROM Ausencias_Medicos  
        INNER JOIN Tipos_Ausencias_Medicos AS TAM ON Id_Tipo_Ausencia_AM = TAM.Id_Tipo_Ausencia_TAM
        INNER JOIN Medicos AS Me ON Legajo_Medico_AM = Legajo_Me
        WHERE Legajo_Medico_AM LIKE '%' + @LEGAJO + '%'
	END
GO

CREATE OR ALTER PROCEDURE spObtenerHorariosAsignados
    @LegajoMedico CHAR(5),
    @Fecha DATE
AS
BEGIN
    SELECT Hora_Tu
    FROM Turnos
    WHERE Legajo_Medico_Tu = @LegajoMedico AND Fecha_Tu = @Fecha
END
GO

CREATE OR ALTER PROCEDURE ActualizarClave
    @Email VARCHAR(100),
    @Usuario VARCHAR(50),
    @NuevaClave VARCHAR(80)
AS
BEGIN
    UPDATE Usuarios
    SET Clave_Us = @NuevaClave
    WHERE Email_Us = @Email AND Usuario_Us = @Usuario;
END
GO

CREATE OR ALTER PROCEDURE spBajaLogicaPaciente
    @DNI CHAR(8),
    @NACIONALIDAD INT
AS
BEGIN
    UPDATE Pacientes
    SET Estado_Pa = 0
    WHERE DNI_Pa = @DNI AND Id_Nacionalidad_Pa = @NACIONALIDAD;
END
GO

CREATE OR ALTER PROCEDURE sp_ActualizarPaciente
(
@DNI CHAR(8),
@NOMBRE VARCHAR(50),
@APELLIDO VARCHAR(50),
@SEXO INT,
@FECHANACIMIENTO DATE,
@NACIONALIDAD INT,
@LOCALIDAD INT,
@DIRECCION VARCHAR(100),
@CORREOELECTRONICO VARCHAR(100),
@TELEFONO VARCHAR(15),
@ESTADO BIT
)
AS
BEGIN
UPDATE Pacientes SET 
Nombre_Pa = @NOMBRE,
Apellido_Pa = @APELLIDO,
Id_Genero_Pa = @SEXO,
Fecha_Nacimiento_Pa = @FECHANACIMIENTO,
Id_Localidad_Pa = @LOCALIDAD,
Direccion_Pa = @DIRECCION,
Email_Pa = @CORREOELECTRONICO,
Telefono_Pa = @TELEFONO,
Estado_Pa = @ESTADO
WHERE DNI_Pa = @DNI AND Id_Nacionalidad_Pa = @NACIONALIDAD
END
GO

CREATE OR ALTER PROCEDURE spObtenerLocalidadPorDNI
    @DniPaciente CHAR(8)
AS
BEGIN
    SELECT Id_Localidad_Pa
    FROM Pacientes
    WHERE DNI_Pa = @DniPaciente
END
GO

CREATE OR ALTER PROCEDURE spObtenerNacionalidadPorDNI
    @DniPaciente CHAR(8)
AS
BEGIN
    SELECT Id_Nacionalidad_Pa
    FROM Pacientes
    WHERE DNI_Pa = @DniPaciente
END
GO

CREATE OR ALTER PROCEDURE spAgregarTurno
(
@LEGAJOMEDICO CHAR(5),
@FECHA DATE,
@HORA TIME(7),
@DNIPACIENTE CHAR(8),
@IDNACIONALIDADP INT,
@ASISTENCIA BIT
)
AS
INSERT INTO Turnos(Legajo_Medico_Tu, Fecha_Tu, Hora_Tu, DNI_Paciente_Tu, Id_Nacionalidad_Paciente_Tu, Asistencia_Tu)
VALUES (@LEGAJOMEDICO, @FECHA, @HORA, @DNIPACIENTE, @IDNACIONALIDADP, @ASISTENCIA)
RETURN
GO

CREATE OR ALTER PROCEDURE spViewAusenciasMedicos
AS
SELECT 
    Legajo_Medico_AM, 
    (Me.Nombre_Me + ' ' + Me.Apellido_Me) AS Nombre_Completo, 
    TAM.Descripcion_TAM, 
    Fecha_Inicio_AM, 
    Fecha_Fin_AM
FROM 
    Ausencias_Medicos 
INNER JOIN 
    Tipos_Ausencias_Medicos AS TAM ON Id_Tipo_Ausencia_AM = TAM.Id_Tipo_Ausencia_TAM 
INNER JOIN 
    Medicos AS Me ON Legajo_Medico_AM = Legajo_Me;
GO

CREATE OR ALTER PROCEDURE spObtenerTurnos
AS
SELECT 
	Id_Turno_Tu,
	Id_Ciclo_Turno_Tu,
	CT.Descripcion_CT AS Ciclo_Tu,
	Id_Detalle_Turno_Tu,
	DT.Descripcion_DT AS Detalle_Ciclo_Tu,
	Legajo_Medico_Tu,
	Fecha_Tu,
	Hora_Tu,
	DNI_Paciente_Tu,
	Id_Nacionalidad_Paciente_Tu,
	Asistencia_Tu,
	Observaciones_Tu
FROM 
	Turnos
INNER JOIN
	Detalles_Turnos AS DT ON Id_Detalle_Turno_Tu = Id_Detalle_Turno_DT
INNER JOIN
	Ciclos_Turnos AS CT ON Id_Ciclo_Turno_Tu = Id_Ciclo_Turno_CT
GO

CREATE OR ALTER PROCEDURE spObtenerTurnosMedico
@LEGAJO CHAR(5)
AS
SELECT 
	Id_Turno_Tu,
	Id_Ciclo_Turno_Tu,
	CT.Descripcion_CT AS Ciclo_Tu,
	Id_Detalle_Turno_Tu,
	DT.Descripcion_DT AS Detalle_Ciclo_Tu,
	Legajo_Medico_Tu,
	Fecha_Tu,
	Hora_Tu,
	DNI_Paciente_Tu,
	Id_Nacionalidad_Paciente_Tu,
	Asistencia_Tu,
	Observaciones_Tu,
	Nombre_Pa + ' ' + Apellido_Pa AS [Nombre_Completo_Paciente_Tu]
FROM 
	Turnos
INNER JOIN
	Detalles_Turnos AS DT ON Id_Detalle_Turno_Tu = Id_Detalle_Turno_DT
INNER JOIN
	Ciclos_Turnos AS CT ON Id_Ciclo_Turno_Tu = Id_Ciclo_Turno_CT
INNER JOIN
	Pacientes AS Pa ON DNI_Paciente_Tu = DNI_Pa AND Id_Nacionalidad_Pa = Id_Nacionalidad_Paciente_Tu
WHERE Legajo_Medico_Tu = @LEGAJO AND Estado_Tu = 1 AND Id_Ciclo_Turno_Tu = 1
GO

CREATE OR ALTER PROCEDURE spObtenerTurnosMedicoTodos
@LEGAJO CHAR(5)
AS
SELECT 
	Id_Turno_Tu,
	Id_Ciclo_Turno_Tu,
	CT.Descripcion_CT AS Ciclo_Tu,
	Id_Detalle_Turno_Tu,
	DT.Descripcion_DT AS Detalle_Ciclo_Tu,
	Legajo_Medico_Tu,
	Fecha_Tu,
	Hora_Tu,
	DNI_Paciente_Tu,
	Id_Nacionalidad_Paciente_Tu,
	Asistencia_Tu,
	Observaciones_Tu,
	Nombre_Pa + ' ' + Apellido_Pa AS [Nombre_Completo_Paciente_Tu]
FROM 
	Turnos
INNER JOIN
	Detalles_Turnos AS DT ON Id_Detalle_Turno_Tu = Id_Detalle_Turno_DT
INNER JOIN
	Ciclos_Turnos AS CT ON Id_Ciclo_Turno_Tu = Id_Ciclo_Turno_CT
INNER JOIN
	Pacientes AS Pa ON DNI_Paciente_Tu = DNI_Pa AND Id_Nacionalidad_Pa = Id_Nacionalidad_Paciente_Tu
WHERE Legajo_Medico_Tu = @LEGAJO AND Id_Ciclo_Turno_CT != 1 AND Id_Ciclo_Turno_CT != 2
GO

CREATE OR ALTER PROCEDURE spObtenerTurnosMedicoFiltrados
@LEGAJO CHAR(5),
@FILTRO INT
AS
SELECT 
	Id_Turno_Tu,
	Id_Ciclo_Turno_Tu,
	CT.Descripcion_CT AS Ciclo_Tu,
	Id_Detalle_Turno_Tu,
	DT.Descripcion_DT AS Detalle_Ciclo_Tu,
	Legajo_Medico_Tu,
	Fecha_Tu,
	Hora_Tu,
	DNI_Paciente_Tu,
	Id_Nacionalidad_Paciente_Tu,
	Asistencia_Tu,
	Observaciones_Tu,
	Nombre_Pa + ' ' + Apellido_Pa AS [Nombre_Completo_Paciente_Tu]
FROM 
	Turnos
INNER JOIN
	Detalles_Turnos AS DT ON Id_Detalle_Turno_Tu = Id_Detalle_Turno_DT
INNER JOIN
	Ciclos_Turnos AS CT ON Id_Ciclo_Turno_Tu = Id_Ciclo_Turno_CT
INNER JOIN
	Pacientes AS Pa ON DNI_Paciente_Tu = DNI_Pa AND Id_Nacionalidad_Pa = Id_Nacionalidad_Paciente_Tu
WHERE Legajo_Medico_Tu = @LEGAJO AND Id_Ciclo_Turno_CT = @FILTRO
GO

CREATE OR ALTER PROCEDURE spObtenerTurnosPendientes
AS
SELECT 
	Id_Turno_Tu,
	Id_Ciclo_Turno_Tu,
	CT.Descripcion_CT AS Ciclo_Tu,
	Id_Detalle_Turno_Tu,
	DT.Descripcion_DT AS Detalle_Ciclo_Tu,
	Legajo_Medico_Tu,
	Fecha_Tu,
	Hora_Tu,
	DNI_Paciente_Tu,
	Id_Nacionalidad_Paciente_Tu,
	Asistencia_Tu,
	Observaciones_Tu,
	Nombre_Pa + ' ' + Apellido_Pa AS [Nombre_Completo_Paciente_Tu]
FROM 
	Turnos
INNER JOIN
	Detalles_Turnos AS DT ON Id_Detalle_Turno_Tu = Id_Detalle_Turno_DT
INNER JOIN
	Ciclos_Turnos AS CT ON Id_Ciclo_Turno_Tu = Id_Ciclo_Turno_CT
INNER JOIN
	Pacientes AS Pa ON DNI_Paciente_Tu = DNI_Pa AND Id_Nacionalidad_Pa = Id_Nacionalidad_Paciente_Tu
WHERE Id_Ciclo_Turno_Tu = 2
GO

CREATE OR ALTER PROCEDURE spObtenerTurnosPendientesCount
AS
SELECT COUNT(*) AS TotalTurnos
FROM Turnos
WHERE Id_Ciclo_Turno_Tu = 2;
GO