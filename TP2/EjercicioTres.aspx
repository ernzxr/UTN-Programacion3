<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjercicioTres.aspx.cs" Inherits="TP2.EjercicioTres" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>EJERCICIO 3</title>
</head>
<body>
    <form id="form1" runat="server">
        <p style="margin-left: 80px">
            <asp:LinkButton ID="lbRojo" runat="server" OnClick="lbRojo_Click">Rojo</asp:LinkButton>
        </p>
        <p style="margin-left: 80px">
            <asp:LinkButton ID="lbAzul" runat="server">Azul</asp:LinkButton>
        </p>
        <p style="margin-left: 80px">
            &nbsp;</p>
        <p style="margin-left: 80px">
            &nbsp;</p>
        <p style="margin-left: 80px">
            <asp:LinkButton ID="lblReset" runat="server" OnClick="lblReset_Click">Reset</asp:LinkButton>
        </p>
        <p style="margin-left: 80px">
            <asp:Label ID="lblMensaje" runat="server">Texto coloreado</asp:Label>
        </p>
        <p style="margin-left: 80px">
            &nbsp;</p>
    </form>
</body>
</html>
