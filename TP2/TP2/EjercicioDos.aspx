<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjercicioDos.aspx.cs" Inherits="TP2.EjercicioDos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCiudad" runat="server" Text="Ciudad: "></asp:Label>
            <asp:DropDownList ID="ddlCiudad" runat="server" AutoPostBack="True">
                <asp:ListItem Value="zona norte">Gral. Pacheco</asp:ListItem>
                <asp:ListItem Value="zona oeste">San Miguel</asp:ListItem>
                <asp:ListItem Value="zona sur">Boedo</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnVer" runat="server" Text="Ver resumen" OnClick="btnVer_Click" />
    </form>
</body>
</html>
