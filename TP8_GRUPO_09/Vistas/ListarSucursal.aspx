<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarSucursal.aspx.cs" Inherits="Vistas.ListarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 852px;
            height: 265px;
        }
        .auto-style2 {
            margin-left: 68px;
        }
        .auto-style3 {
            text-align: center;
            height: 162px;
        }
        .auto-style4 {
            text-align: center;
            width: 283px;
            height: 24px;
        }
        .auto-style14 {
            width: 283px;
            height: 24px;
        }
        .auto-style15 {
            width: 284px;
            height: 24px;
        }
        .auto-style16 {
            width: 283px;
            height: 25px;
        }
        .auto-style17 {
            width: 284px;
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
                        <asp:HyperLink ID="hlAgregar" runat="server" NavigateUrl="~/AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                    </td>
                    <td class="auto-style14">
                        <asp:HyperLink ID="hlListado" runat="server" NavigateUrl="~/ListarSucursal.aspx">Listado Sucursal</asp:HyperLink>
                    </td>
                    <td class="auto-style15">
                        <asp:HyperLink ID="hlEliminar" runat="server" NavigateUrl="~/EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:Label ID="lblListadoSucursales" runat="server" Style="font-weight: bold" Text="Listado Sucursales"></asp:Label>
                    </td>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:Label ID="lblBusqueda" runat="server" Text="Búsqueda ingrese ID sucursal: "></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:TextBox ID="txtIdSucursal" runat="server" Width="230px"></asp:TextBox>
                    </td>
                    <td class="auto-style17">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" />
                        <asp:Button ID="btnMostrarTodos" runat="server" CssClass="auto-style2" Text="Mostrar todos" OnClick="btnMostrarTodos_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style16">
                        <asp:RegularExpressionValidator ID="revID" runat="server" ControlToValidate="txtIdSucursal" ForeColor="#FF3300" ValidationExpression="^\d+$">(*)&quot;El ID de la sucursal debe ser un número.&quot; </asp:RegularExpressionValidator>
                    </td>
                    <td class="auto-style17">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="3">
                        <asp:GridView ID="gvSucursales" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
