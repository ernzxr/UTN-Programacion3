<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjercicioCuatro.aspx.cs" Inherits="TP2.EjercicioCuatro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EJERCICIO 4</title>
    <style type="text/css">
        .auto-style1 {
            width: 104px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>lblUsuario
                </td>
                <td class="auto-style1">txtUsuario
                </td>
            </tr>
            <tr>
                <td>lblPassword
                </td>
                <td class="auto-style1">txtPassword
                </td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style1">
                    <asp:Button ID="btnValidar" runat="server" Text="Validar" OnClick="btnValidar_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
