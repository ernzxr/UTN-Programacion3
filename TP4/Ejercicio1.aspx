<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 269px;
        }
        .auto-style3 {
            width: 222px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblInicio" runat="server" Text="DESTINO INICIO"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblProvInicio" runat="server" Text="PROVINCIA:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlProvinciaInicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaInicio_SelectedIndexChanged">
                            <asp:ListItem>-- Seleccionar --</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProvinciaInicio" runat="server" InitialValue="-- Seleccionar --" ControlToValidate="ddlProvinciaInicio">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblLocalidadInicio" runat="server" Text="LOCALIDAD:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlLocalidadInicio" runat="server">
                            <asp:ListItem>-- Seleccionar --</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLocalidadInicio" runat="server" InitialValue="-- Seleccionar --" ControlToValidate="ddlLocalidadInicio">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblFinal" runat="server" Text="DESTINO FINAL"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblProvFinal" runat="server" Text="PROVINCIA:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlProvinciaDestino" runat="server">
                            <asp:ListItem>-- Seleccionar --</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProvinciaDestino" runat="server" InitialValue="-- Seleccionar --" ControlToValidate="ddlProvinciaInicio">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblLocalidadFinal" runat="server" Text="LOCALIDAD:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlLocalidadDestino" runat="server">
                            <asp:ListItem>-- Seleccionar --</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLocalidadDestino" runat="server" InitialValue="-- Seleccionar --" ControlToValidate="ddlProvinciaDestino">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
