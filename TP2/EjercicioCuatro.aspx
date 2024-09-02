<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjercicioCuatro.aspx.cs" Inherits="TP2.EjercicioCuatro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EJERCICIO 4</title>
    </head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnValidar" runat="server" Text="Validar" OnClick="btnValidar_Click" />
    </form>
</body>
</html>
