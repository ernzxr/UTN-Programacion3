<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjercicioCuatroErrorValidacion.aspx.cs" Inherits="TP2.EjercicioCuatroErrorValidacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnIngresoUsuario" runat="server" OnClick="btnIngresoUsuario_Click" Text="Reintentar" />
            <br />
        </div>
    </form>
</body>
</html>
