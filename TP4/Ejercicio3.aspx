<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3.aspx.cs" Inherits="TP4.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ejercicio 3</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;Seleccionar Tema:&nbsp;
            <asp:DropDownList ID="ddlTemas" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
            &nbsp;<asp:LinkButton ID="lbVerLibros" runat="server" OnClick="lbVerLibros_Click">Ver libros</asp:LinkButton>
            <br />
        </div>
    </form>
</body>
</html>
