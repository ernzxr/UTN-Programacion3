<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarSucursal.aspx.cs" Inherits="TP5.ListarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 172px;
        }

        .auto-style3 {
            width: 210px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:HyperLink ID="hlAgregarSucursal" runat="server" NavigateUrl="~/AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                    </td>
                    <td class="auto-style3">
                        <asp:HyperLink ID="hlListarSucursal" runat="server" NavigateUrl="~/ListarSucursal.aspx">Listado de Sucursales</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlEliminarSucursal" runat="server" NavigateUrl="~/EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtBuscarSucursal" runat="server"></asp:TextBox>
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnMostrarTodo" runat="server" Text="Mostrar Todo" OnClick="btnMostrarTodo_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <div>
                <asp:GridView ID="gvSucursales" runat="server">
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
