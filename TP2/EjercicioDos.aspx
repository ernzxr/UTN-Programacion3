<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjercicioDos.aspx.cs" Inherits="TP2.EjercicioDos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EJERCICIO</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCiudad" runat="server" Text="Ciudad: "></asp:Label>
            <asp:DropDownList ID="ddlCiudad" runat="server" AutoPostBack="True">
                <asp:ListItem Value="Zona Norte">Gral. Pacheco</asp:ListItem>
                <asp:ListItem Value="Zona Oeste">San Miguel</asp:ListItem>
                <asp:ListItem Value="Zona Sur">Boedo</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            Temas:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:CheckBoxList ID="chbTemas" runat="server" style="margin-left: 72px">
                <asp:ListItem>Ciencias</asp:ListItem>
                <asp:ListItem>Literatura</asp:ListItem>
                <asp:ListItem>Historia</asp:ListItem>
            </asp:CheckBoxList>
&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <asp:Button ID="btnVer" runat="server" Text="Ver resumen" OnClick="btnVer_Click" />
    </form>
</body>
</html>
