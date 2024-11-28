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
    SELECT Id_Dia_Semana_HM, Hora_Inicio_HM, Hora_Fin_HM, Descripcion_DS AS DescripcionDia
    FROM Horarios_Medicos 
	INNER JOIN Dias_Semanas ON Id_Dia_Semana_HM = Id_Dia_Semana_DS
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
    WHERE Legajo_Medico_Tu = @LegajoMedico AND Fecha_Tu = @Fecha AND Estado_Tu = 1
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
	Nombre_Pa + ' ' + Apellido_Pa AS [Nombre_Completo_Paciente_Tu],
	Es.Descripcion_Es AS Especialidad
FROM 
	Turnos
INNER JOIN
	Detalles_Turnos AS DT ON Id_Detalle_Turno_Tu = Id_Detalle_Turno_DT
INNER JOIN
	Ciclos_Turnos AS CT ON Id_Ciclo_Turno_Tu = Id_Ciclo_Turno_CT
INNER JOIN
	Pacientes AS Pa ON DNI_Paciente_Tu = DNI_Pa AND Id_Nacionalidad_Pa = Id_Nacionalidad_Paciente_Tu
INNER JOIN 
	Medicos AS Me ON Legajo_Medico_Tu = Me.Legajo_Me
INNER JOIN
	Especialidades AS Es ON Me.Id_Especialidad_Me = Es.Id_Especialidad_Es
WHERE Id_Ciclo_Turno_Tu = 2
GO

CREATE OR ALTER PROCEDURE spObtenerTurnosPendientesCount
AS
SELECT COUNT(*) AS TotalTurnos
FROM Turnos
WHERE Id_Ciclo_Turno_Tu = 2;
GO

-- REPORTE: 5 PACIENTES CON MAS TURNOS POR ESPECIALIDAD
CREATE OR ALTER PROCEDURE spObtener5PacientesConMasTurnos
@IdEspecialidad INT,
@FechaInicio DATE,
@FechaFinal DATE
AS
BEGIN
SELECT TOP 5 Pacientes.Nombre_Pa + ' ' + Pacientes.Apellido_Pa AS Nombre_Completo, COUNT(Turnos.Fecha_Tu) AS Turnos_Asistidos
FROM Turnos INNER JOIN Pacientes
ON Turnos.DNI_Paciente_Tu = Pacientes.DNI_Pa AND Turnos.Id_Nacionalidad_Paciente_Tu = Pacientes.Id_Nacionalidad_Pa
INNER JOIN Medicos
ON Turnos.Legajo_Medico_Tu = Medicos.Legajo_Me
WHERE Medicos.Id_Especialidad_Me = @IdEspecialidad AND Turnos.Fecha_Tu BETWEEN @FechaInicio AND @FechaFinal
AND Turnos.Asistencia_Tu = 1
GROUP BY Pacientes.Nombre_Pa, Pacientes.Apellido_Pa
ORDER BY Turnos_Asistidos DESC, Pacientes.Apellido_Pa, Pacientes.Nombre_Pa
END
GO

--EXEC spObtener5PacientesConMasTurnos 1, '2024-06-01', '2024-06-30'

CREATE OR ALTER PROCEDURE spBuscarTurnos
    @Busqueda NVARCHAR(255)
AS
BEGIN
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
WHERE 
        CAST(Id_Turno_Tu AS NVARCHAR) LIKE '%' + @Busqueda + '%' OR
        CAST(Id_Ciclo_Turno_Tu AS NVARCHAR) LIKE '%' + @Busqueda + '%' OR
        CT.Descripcion_CT LIKE '%' + @Busqueda + '%' OR
        CAST(Id_Detalle_Turno_Tu AS NVARCHAR) LIKE '%' + @Busqueda + '%' OR
        DT.Descripcion_DT LIKE '%' + @Busqueda + '%' OR
        Legajo_Medico_Tu LIKE '%' + @Busqueda + '%' OR
        CONVERT(VARCHAR, Fecha_Tu, 120) LIKE '%' + @Busqueda + '%' OR
        CONVERT(VARCHAR, Hora_Tu, 120) LIKE '%' + @Busqueda + '%' OR
        DNI_Paciente_Tu LIKE '%' + @Busqueda + '%' OR
        CAST(Id_Nacionalidad_Paciente_Tu AS NVARCHAR) LIKE '%' + @Busqueda + '%' OR
        CAST(Asistencia_Tu AS NVARCHAR) LIKE '%' + @Busqueda + '%' OR
        Observaciones_Tu LIKE '%' + @Busqueda + '%'
END
GO


CREATE OR ALTER PROCEDURE spFiltrarTurnosPorLegajo
    @LegajoMedico CHAR(5)
AS
BEGIN
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
  FROM Turnos
  INNER JOIN
	Detalles_Turnos AS DT ON Id_Detalle_Turno_Tu = Id_Detalle_Turno_DT
  INNER JOIN
	Ciclos_Turnos AS CT ON Id_Ciclo_Turno_Tu = Id_Ciclo_Turno_CT
  WHERE Legajo_Medico_Tu = @LegajoMedico
END
GO


CREATE OR ALTER PROCEDURE spFiltrarTurnosPorDni
    @DniPaciente CHAR(8)
AS
BEGIN
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
  FROM Turnos
  INNER JOIN
	Detalles_Turnos AS DT ON Id_Detalle_Turno_Tu = Id_Detalle_Turno_DT
  INNER JOIN
	Ciclos_Turnos AS CT ON Id_Ciclo_Turno_Tu = Id_Ciclo_Turno_CT
  WHERE DNI_Paciente_Tu = @DniPaciente
END
GO


CREATE OR ALTER PROCEDURE spFiltrarTurnosPorDia
    @Fecha DATE
AS
BEGIN
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
  FROM Turnos
  INNER JOIN
	Detalles_Turnos AS DT ON Id_Detalle_Turno_Tu = Id_Detalle_Turno_DT
  INNER JOIN
	Ciclos_Turnos AS CT ON Id_Ciclo_Turno_Tu = Id_Ciclo_Turno_CT
  WHERE Fecha_Tu = @Fecha
END
GO

CREATE OR ALTER PROCEDURE spObtenerHorariosMedicos
@Legajo CHAR(5)
AS
BEGIN
SELECT @Legajo AS Legajo, Descripcion_DS, Hora_Inicio_HM, Hora_Fin_HM
FROM Horarios_Medicos RIGHT JOIN Dias_Semanas
ON Id_Dia_Semana_HM = Id_Dia_Semana_DS AND Legajo_Medico_HM = @Legajo
END
GO

CREATE OR ALTER PROCEDURE spActualizarHorariosMedicos
@Legajo CHAR(5),
@Dia INT,
@HoraInicio TIME(0),
@HoraFin TIME(0)
AS
BEGIN
IF EXISTS (SELECT 1 FROM Horarios_Medicos WHERE Legajo_Medico_HM = @Legajo AND Id_Dia_Semana_HM = @Dia)
BEGIN
UPDATE Horarios_Medicos
SET Hora_Inicio_HM = @HoraInicio,
Hora_Fin_HM = @HoraFin
WHERE Legajo_Medico_HM = @Legajo AND Id_Dia_Semana_HM = @Dia
END
ELSE
BEGIN
INSERT INTO Horarios_Medicos (Legajo_Medico_HM, Id_Dia_Semana_HM, Hora_Inicio_HM, Hora_Fin_HM)
VALUES (@Legajo, @Dia, @HoraInicio, @HoraFin)
END
END
GO

CREATE OR ALTER PROCEDURE spBajaLogicaMedico
    @LEGAJO CHAR(5)
AS  
BEGIN
    UPDATE Medicos
    SET Estado_Me = 0
    WHERE Legajo_Me = @LEGAJO
END
GO

CREATE OR ALTER PROCEDURE spActualizarMedico
(
@LEGAJO CHAR(5),
@ESPECIALIDAD INT,
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
UPDATE Medicos SET 
Legajo_Me = @LEGAJO,
Id_Especialidad_Me = @ESPECIALIDAD,
DNI_Me = @DNI,
Nombre_Me = @NOMBRE,
Apellido_Me = @APELLIDO,
Id_Genero_Me = @SEXO,
Fecha_Nacimiento_Me = @FECHANACIMIENTO,
Id_Localidad_Me = @LOCALIDAD,
Direccion_Me = @DIRECCION,
Email_Me = @CORREOELECTRONICO,
Telefono_Me = @TELEFONO,
Estado_Me = @ESTADO
WHERE Legajo_Me = @LEGAJO
END
GO

CREATE OR ALTER PROCEDURE spBuscarTurnosMedico
    @LEGAJO CHAR(5),
    @Busqueda NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

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
    WHERE 
        Legajo_Medico_Tu = @LEGAJO AND
        (
            CAST(Id_Turno_Tu AS NVARCHAR) LIKE '%' + @Busqueda + '%' OR
            CAST(Id_Ciclo_Turno_Tu AS NVARCHAR) LIKE '%' + @Busqueda + '%' OR
            CT.Descripcion_CT LIKE '%' + @Busqueda + '%' OR
            CAST(Id_Detalle_Turno_Tu AS NVARCHAR) LIKE '%' + @Busqueda + '%' OR
            DT.Descripcion_DT LIKE '%' + @Busqueda + '%' OR
            Legajo_Medico_Tu LIKE '%' + @Busqueda + '%' OR
            CONVERT(VARCHAR, Fecha_Tu, 120) LIKE '%' + @Busqueda + '%' OR
            CONVERT(VARCHAR, Hora_Tu, 120) LIKE '%' + @Busqueda + '%' OR
            DNI_Paciente_Tu LIKE '%' + @Busqueda + '%' OR
            CAST(Id_Nacionalidad_Paciente_Tu AS NVARCHAR) LIKE '%' + @Busqueda + '%' OR
            CAST(Asistencia_Tu AS NVARCHAR) LIKE '%' + @Busqueda + '%' OR
            Observaciones_Tu LIKE '%' + @Busqueda + '%'
        )
END
GO


CREATE OR ALTER PROCEDURE spFiltrarTurnosMedicoPorDniFecha
    @DniPaciente CHAR(8),
    @Fecha DATE,
    @LegajoMedico CHAR(5)
AS
BEGIN
    SET NOCOUNT ON;

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
    WHERE 
        Legajo_Medico_Tu = @LegajoMedico AND
        DNI_Paciente_Tu = @DniPaciente AND
        Fecha_Tu = @Fecha;
END
GO

CREATE OR ALTER PROCEDURE spEliminarHorariosMedicos
@Legajo CHAR(5),
@Dia INT
AS
BEGIN
UPDATE Horarios_Medicos SET
Legajo_Medico_HM = @Legajo,
Id_Dia_Semana_HM = @Dia,
Hora_Inicio_HM = NULL,
Hora_Fin_HM = NULL
WHERE Legajo_Medico_HM = @Legajo AND  Id_Dia_Semana_HM = @Dia
END
GO

CREATE OR ALTER PROCEDURE spCancelarTurnoGestion
@IDTURNO INT
AS
BEGIN
UPDATE Turnos SET
Id_Ciclo_Turno_Tu = 5
WHERE Id_Turno_Tu = @IDTURNO
END
GO

CREATE OR ALTER PROCEDURE spObtenerTurnoPorId
    @IDTURNO INT
AS
BEGIN
	SET NOCOUNT ON
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
		Nombre_Pa + ' ' + Apellido_Pa AS [Nombre_Completo_Paciente_Tu],
		Es.Descripcion_Es AS Especialidad,
		Es.Id_Especialidad_Es AS Id_Especialidad
	FROM 
		Turnos
	INNER JOIN
		Detalles_Turnos AS DT ON Id_Detalle_Turno_Tu = Id_Detalle_Turno_DT
	INNER JOIN
		Ciclos_Turnos AS CT ON Id_Ciclo_Turno_Tu = Id_Ciclo_Turno_CT
	INNER JOIN
		Pacientes AS Pa ON DNI_Paciente_Tu = DNI_Pa AND Id_Nacionalidad_Pa = Id_Nacionalidad_Paciente_Tu
	INNER JOIN 
		Medicos AS Me ON Legajo_Medico_Tu = Me.Legajo_Me
	INNER JOIN
		Especialidades AS Es ON Me.Id_Especialidad_Me = Es.Id_Especialidad_Es
    WHERE 
        Id_Turno_Tu = @IDTURNO
END
GO

CREATE OR ALTER PROCEDURE spActualizarTurnoMedico
(
    @LegajoMedico CHAR(5),
    @DniPaciente CHAR(8),
    @Fecha DATE,
    @Hora TIME(0),
    @Asistencia BIT,
    @Observaciones VARCHAR(255)
)
AS
BEGIN
    UPDATE Turnos
    SET 
        Asistencia_Tu = @Asistencia,
        Observaciones_Tu = @Observaciones,
        Id_Ciclo_Turno_Tu = (SELECT Id_Ciclo_Turno_CT FROM Ciclos_Turnos WHERE Descripcion_CT = 'Terminado'),
        Id_Detalle_Turno_Tu = (SELECT Id_Detalle_Turno_DT FROM Detalles_Turnos WHERE Descripcion_DT = 'No Aplica')
    WHERE 
        Legajo_Medico_Tu = @LegajoMedico AND
        DNI_Paciente_Tu = @DniPaciente AND
        Fecha_Tu = @Fecha AND
        Hora_Tu = @Hora
END
GO

CREATE OR ALTER PROCEDURE spContarTurnosPorMesYAnio
    @Anio INT,
    @Mes INT
AS
BEGIN
    SELECT COUNT(*) AS TotalTurnos
    FROM Turnos
    WHERE YEAR(Fecha_Tu) = @Anio AND MONTH(Fecha_Tu) = @Mes AND Estado_Tu = 1; 
END
GO