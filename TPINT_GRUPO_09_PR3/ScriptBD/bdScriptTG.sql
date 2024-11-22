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