USE UTN2C2024PR3CLINICA
GO

CREATE PROCEDURE ActualizarClave
    @Email VARCHAR(100),
    @Usuario VARCHAR(50),
    @NuevaClave VARCHAR(80)
AS
BEGIN
    UPDATE Usuarios
    SET Clave_Us = @NuevaClave
    WHERE Email_Us = @Email AND Id_Usuario_Us = @Usuario;
END;