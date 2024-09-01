<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjercicioDos.aspx.cs" Inherits="TP2.EjercicioDos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EJERCICIO</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 349px">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
&nbsp;<asp:TextBox ID="txtNombre" runat="server" style="margin-left: 4px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server" style="margin-left: 6px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblCiudad" runat="server" Text="Ciudad: "></asp:Label>
            <asp:DropDownList ID="ddlCiudad" runat="server" AutoPostBack="True" style="margin-left: 49px">
                <asp:ListItem>Seleccione una opcion</asp:ListItem>
                <asp:ListItem Value="Zona Norte">Gral. Pacheco</asp:ListItem>
                <asp:ListItem Value="Zona Oeste">San Miguel</asp:ListItem>
                <asp:ListItem Value="Zona Sur">Boedo</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Temas:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:CheckBoxList ID="chbTemas" runat="server" style="margin-left: 72px">
                <asp:ListItem>Ciencias</asp:ListItem>
                <asp:ListItem>Literatura</asp:ListItem>
                <asp:ListItem>Historia</asp:ListItem>
            </asp:CheckBoxList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVer" runat="server" Text="Ver resumen" OnClick="btnVer_Click" />
        </div>
    </form>
</body>
</html>
