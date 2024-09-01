<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjercicioCinco.aspx.cs" Inherits="TP2.EjercicioCinco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 293px;
            margin-left: 120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="lblConfi" runat="server" Text="Elija su configuración"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblMemoria" runat="server" Text="Seleccione la cantidad de memoria"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="ddlMemoria" runat="server" Height="24px" Width="72px" AutoPostBack="True" style="margin-left: 41px">
                <asp:ListItem Value="200">2 GB</asp:ListItem>
                <asp:ListItem Value="375">4 GB</asp:ListItem>
                <asp:ListItem Value="500">6 GB</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblAccesorios" runat="server" Text="Seleccione accesorios"></asp:Label>
            <br />
            <br />
            <asp:CheckBoxList ID="cblAccesorios" runat="server" Height="16px" style="margin-left: 32px" Width="124px">
                <asp:ListItem Value="2000.50">Monitor LCD</asp:ListItem>
                <asp:ListItem Value="500.50">HD 500 GB</asp:ListItem>
                <asp:ListItem Value="1200">Grabador DVD</asp:ListItem>
            </asp:CheckBoxList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCalcularPrecio" runat="server" OnClick="btnCalcularPrecio_Click" Text="Calcular precio" />
            <br />
            <br />
            <asp:Label ID="lblPrecioFinal" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
