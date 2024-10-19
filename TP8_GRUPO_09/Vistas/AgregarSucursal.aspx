<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="Vistas.AgregarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            width: 206px;
        }
        .auto-style5 {
            width: 206px;
            height: 38px;
        }
        .auto-style7 {
            height: 38px;
        }
        .auto-style17 {
            width: 206px;
            height: 34px;
        }
        .auto-style19 {
            height: 34px;
        }
        .auto-style20 {
            width: 194px;
            height: 34px;
        }
        .auto-style21 {
            width: 194px;
            height: 38px;
        }
        .auto-style22 {
            width: 194px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style17">
                        <asp:HyperLink ID="hlAgregarSucursal" runat="server" NavigateUrl="~/AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                    </td>
                    <td class="auto-style20">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ListarSucursal.aspx">Lista de Sucursales</asp:HyperLink>
                    </td>
                    <td class="auto-style19">
                        <asp:HyperLink ID="hlEliminarSucursal" runat="server" NavigateUrl="~/EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                       <asp:Label ID="lblGrupo" runat="server" Text="Grupo N° 09" Style="font-weight: bold; font-size: 20px;"></asp:Label>
                    <td class="auto-style21"></td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="lblAgregarSucursal" runat="server" Text="Agregar Sucursal" Style="font-weight:bold;"></asp:Label>
                    </td>
                    <td class="auto-style20"></td>
                    <td class="auto-style19"></td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="lblNombreSucursal" runat="server" Text="Nombre Sucursal:"></asp:Label>
                    </td>
                    <td class="auto-style20">
                        <asp:TextBox ID="txtNombreSucursal" runat="server" Width="192px" ValidationGroup="gpSuc"></asp:TextBox>
                    </td>
                    <td class="auto-style19">
                        <asp:RequiredFieldValidator ID="rfvNombreSuc" runat="server" ControlToValidate="txtNombreSucursal" ForeColor="Red" ValidationGroup="gpSuc">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
                    </td>
                    <td class="auto-style22">
                        <asp:TextBox ID="txtDescripcion" runat="server" Height="60px" Width="192px" ValidationGroup="gpSuc"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDescripcionSuc" runat="server" ControlToValidate="txtDescripcion" ForeColor="Red" ValidationGroup="gpSuc">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                    </td>
                    <td class="auto-style20">
                        <asp:DropDownList ID="ddlProvincias" runat="server" Width="192px" ValidationGroup="gpSuc">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style19">
                        <asp:RequiredFieldValidator ID="rfvProvinciasSuc" runat="server" ControlToValidate="ddlProvincias" ForeColor="Red" InitialValue="-1" ValidationGroup="gpSuc">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label>
                    </td>
                    <td class="auto-style20">
                        <asp:TextBox ID="txtDireccion" runat="server" Width="192px" ValidationGroup="gpSuc"></asp:TextBox>
                    </td>
                    <td class="auto-style19">
                        <asp:RequiredFieldValidator ID="rfvDireccionSuc" runat="server" ControlToValidate="txtDireccion" ForeColor="Red" ValidationGroup="gpSuc">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17"></td>
                    <td class="auto-style20">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" ValidationGroup="gpSuc" />
                    </td>
                    <td class="auto-style19"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
