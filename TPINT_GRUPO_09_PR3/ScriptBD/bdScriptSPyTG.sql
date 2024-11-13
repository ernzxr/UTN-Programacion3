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
CREATE PROCEDURE spAgregarPaciente
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

CREATE PROCEDURE sp_ObtenerLegajoPorNombreCompleto
    @NombreCompleto VARCHAR(100)
AS
BEGIN
    SELECT Legajo_Me
    FROM Medicos
    WHERE (Nombre_Me + ' ' + Apellido_Me) = @NombreCompleto
END
GO

CREATE PROCEDURE spObtenerDiasLaborales
    @LegajoMedico CHAR(5)
AS
BEGIN
    SELECT Id_Dia_Semana_HM, Hora_Inicio_HM, Hora_Fin_HM 
    FROM Horarios_Medicos 
    WHERE Legajo_Medico_HM = @LegajoMedico
END
GO

CREATE PROCEDURE sp_ObtenerFechasAusencias
    @LegajoMedico CHAR(5)
AS
BEGIN
    SELECT Fecha_Inicio_AM, Fecha_Fin_AM
    FROM Ausencias_Medicos 
    WHERE Legajo_Medico_AM = @LegajoMedico
END
GO

CREATE PROCEDURE spObtenerFechasConTurnosCompletos
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