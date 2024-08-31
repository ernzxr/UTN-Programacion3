<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjercicioCuatro.aspx.cs" Inherits="TP2.EjercicioCuatro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EJERCICIO 4</title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>lblUsuario
                </td>
                <td>txtUsuario
                </td>
            </tr>
            <tr>
                <td>lblPassword
                </td>
                <td>txtPassword
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnValidar" runat="server" Text="Validar" OnClick="btnValidar_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
