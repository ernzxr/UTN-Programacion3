USE UTN2C2024PR3CLINICA
GO

CREATE PROCEDURE ActualizarContrasena
    @Email NVARCHAR(50),
    @Usuario NVARCHAR(50),
    @NuevaContrasena NVARCHAR(50)
AS
BEGIN
    UPDATE Usuarios
    SET Clave_Us = @NuevaContrasena
    WHERE Email_Us = @Email AND Id_Usuario_Us = @Usuario;
END;