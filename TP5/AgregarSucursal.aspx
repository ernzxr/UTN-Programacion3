<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="TP5.Agregar" %>

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
            height: 30px;
        }

        .auto-style3 {
            height: 40px;
        }

        .auto-style4 {
            height: 30px;
            width: 251px;
        }

        .auto-style5 {
            height: 40px;
            width: 251px;
        }

        .auto-style6 {
            font-size: xx-large;
        }

        .auto-style7 {
            font-size: x-large;
        }

        .auto-style8 {
            font-size: large;
        }

        .auto-style9 {
            height: 30px;
            width: 231px;
        }

        .auto-style10 {
            height: 40px;
            width: 231px;
        }

        .auto-style11 {
            height: 30px;
            width: 251px;
            text-align: right;
        }

        .auto-style12 {
            height: 30px;
            width: 231px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style11">
                        <asp:HyperLink ID="hlAgregarSucursal" runat="server" NavigateUrl="~/AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                    </td>
                    <td class="auto-style12">
                        <asp:HyperLink ID="hlListarSucursal" runat="server" NavigateUrl="~/ListarSucursal.aspx">Listado de Sucursales</asp:HyperLink>
                    </td>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="hlEliminarSucursal" runat="server" NavigateUrl="~/EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style6"><strong>GRUPO&nbsp; Nº 9</strong></span>&nbsp;</td>
                    <td class="auto-style10"></td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style7"><strong>Agregar Sucursal</strong></span></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style8">Nombre Sucursal:</span></td>
                    <td class="auto-style9">
                        <br />
                        <asp:TextBox ID="txtNombreSucursal" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <br />
                        <asp:RequiredFieldValidator ID="rfvNombreSucursal" runat="server" ControlToValidate="txtNombreSucursal">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style8">&nbsp;Descripción:</span></td>
                    <td class="auto-style9">
                        <br />
                        <asp:TextBox ID="txtDescripcionSucursal" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <br />
                        <asp:RequiredFieldValidator ID="rfvDescripcionSucursal" runat="server" ControlToValidate="txtDescripcionSucursal">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style8">Provincia:</span></td>
                    <td class="auto-style9">
                        <br />
                        <asp:DropDownList ID="ddlProvincias" runat="server" Height="18px" Width="205px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <br />
                        <asp:RequiredFieldValidator ID="rfvProvincias" runat="server" ControlToValidate="ddlProvincias" InitialValue="-- Seleccionar Provincia --">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style8">Dirección:</span></td>
                    <td class="auto-style9">
                        <br />
                        <asp:TextBox ID="txtDireccionSucursal" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <br />
                        <asp:RequiredFieldValidator ID="rfvDireccionSucursal" runat="server" ControlToValidate="txtDireccionSucursal">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
                    </td>
                    <td class="auto-style9">
                        <br />
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                    </td>
                    <td class="auto-style2">
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
