<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjercicioCinco.aspx.cs" Inherits="TP2.EjercicioCinco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 293px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="lblConfi" runat="server" Text="Elija su configuracion"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblMemoria" runat="server" Text="Seleccione la cantidad de memoria"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="ddlMemoria" runat="server" Height="24px" Width="177px">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblAccesorios" runat="server" Text="Seleccione accesorios"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="lblPrecioFinal" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
