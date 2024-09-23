<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarSucursal.aspx.cs" Inherits="TP5.EliminarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style5 {
            width: 290px;
        }
        .auto-style6 {
            width: 201px;
        }
        .auto-style7 {
            width: 161px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style7">
                        <asp:HyperLink ID="hlAgregarSucursal" runat="server" NavigateUrl="~/AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                    </td>
                    <td class="auto-style5">
                        <asp:HyperLink ID="hlListarSucursal" runat="server" NavigateUrl="~/ListarSucursal.aspx">Listado de Sucursales</asp:HyperLink>
                    </td>
                    <td class="auto-style6">
                        <asp:HyperLink ID="hlEliminarSucursal" runat="server" NavigateUrl="~/EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblEliminarSucursal" runat="server" Text="Eliminar Sucursal"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblIngresarSucursal" runat="server" Text="Ingresar ID sucursal: "></asp:Label>
                    </td>
                    <td class="auto-style5"><asp:TextBox ID="txtIdSucursal" Style="margin-left: 40px;" runat="server" Width="214px"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                    <asp:RequiredFieldValidator ID="rfvIdSucursal" runat="server" ControlToValidate="txtIdSucursal" ForeColor="Red">(*) Ingrese ID sucursal</asp:RequiredFieldValidator>
                    </td>
                    <td><asp:Button ID="btnEliminar" Style="margin-left: 30px;" runat="server" Text="Eliminar" OnClick="btn_Eliminar_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                    <asp:Label ID="lblResultado" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">
                        <asp:RegularExpressionValidator ID="revIdSucursal" runat="server" ControlToValidate="txtIdSucursal" ForeColor="Red" ValidationExpression="&quot;^\d+$&quot; ">(*)El ID de la sucursal debe ser un número.</asp:RegularExpressionValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
