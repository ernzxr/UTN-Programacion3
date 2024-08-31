<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjercicioUno.aspx.cs" Inherits="TP2.EjercicioUno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>EJERCICIO 1</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblProducto1" runat="server" Text="Ingrese nombre del producto:"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtProducto1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCantidad1" runat="server" Text="Cantidad:"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txtCantidad1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblProducto2" runat="server" Text="Ingrese nombre del producto:"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtProducto2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCantidad2" runat="server" Text="Cantidad: "></asp:Label>
&nbsp;
            <asp:TextBox ID="txtCantidad2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnTabla" runat="server" OnClick="btnTabla_Click" Text="Generar tabla" />
            <br />
            <br />
            <asp:Label ID="lblTabla" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblErrorDescripcion" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
