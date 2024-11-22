USE UTN2C2024PR3CLINICA
GO

CREATE OR ALTER TRIGGER tgBajaMedicoBajaTurnos
ON Medicos
AFTER UPDATE
AS
BEGIN
    UPDATE Turnos
    SET Id_Ciclo_Turno_Tu = 2,
        Id_Detalle_Turno_Tu = 2,
		Estado_Tu = 0
    FROM Turnos Tu
    INNER JOIN Inserted I ON Tu.Legajo_Medico_Tu = I.Legajo_Me
    INNER JOIN Deleted D ON I.Legajo_Me = D.Legajo_Me
    WHERE I.Estado_Me = 0 AND D.Estado_Me <> 0 AND Tu.Estado_Tu = 1 AND Tu.Id_Ciclo_Turno_Tu = 1
END
GO

CREATE OR ALTER TRIGGER tgAusenciaMedicoBajaTurnos
ON Ausencias_Medicos
AFTER INSERT
AS
BEGIN
    UPDATE Turnos
    SET Estado_Tu = 0,
        Id_Ciclo_Turno_Tu = 2,
        Id_Detalle_Turno_Tu = 2
    FROM Turnos Tu
    INNER JOIN Inserted I ON Tu.Legajo_Medico_Tu = I.Legajo_Medico_AM
    WHERE Tu.Fecha_Tu BETWEEN I.Fecha_Inicio_AM AND I.Fecha_Fin_AM 
		AND Tu.Estado_Tu = 1 AND Tu.Id_Ciclo_Turno_Tu = 1
END
GO