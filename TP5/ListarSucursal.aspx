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

        .auto-style3 {
            width: 276px;
        }
        .auto-style5 {
            width: 276px;
            height: 21px;
        }
        .auto-style7 {
            height: 21px;
        }
        .auto-style8 {
            margin-left: 106px;
        }
        .auto-style13 {
            width: 323px;
        }
        .auto-style14 {
            width: 323px;
            height: 21px;
        }
        .auto-style15 {
            width: 147px;
        }
        .auto-style16 {
            width: 147px;
            height: 21px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style13">
                        <asp:HyperLink ID="hlAgregarSucursal" runat="server" NavigateUrl="~/AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                    </td>
                    <td class="auto-style15">
                        <asp:HyperLink ID="hlListarSucursal" runat="server" NavigateUrl="~/ListarSucursal.aspx">Listado de Sucursales</asp:HyperLink>
                    </td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hlEliminarSucursal" runat="server" NavigateUrl="~/EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="lblListado" runat="server" Text="Listado de sucursales"></asp:Label>
                    </td>
                    <td class="auto-style16"></td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style7"></td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="lblBusqueda" runat="server" Text="Busqueda ingrese Id Sucursal: "></asp:Label>
                    </td>
                    <td class="auto-style15">
                        <asp:TextBox ID="txtBuscarSucursal" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSucursal" runat="server" ControlToValidate="txtBuscarSucursal" ForeColor="Red">(*) Ingrese ID sucursal</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="auto-style8" />
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
