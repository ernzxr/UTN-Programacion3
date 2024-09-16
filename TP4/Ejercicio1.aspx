<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ejercicio 1</title>
    <style type="text/css">
        .auto-style4 {
            width: 50%;
            margin-left: 150px;
        }

        .auto-style8 {
            height: 34px;
        }

        .auto-style10 {
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style4">
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="lblInicio" runat="server" Text="DESTINO INICIO"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblProvInicio" runat="server" Text="PROVINCIA:" Font-Size="Medium"></asp:Label>
                    <asp:DropDownList ID="ddlProvinciaInicio" style="margin-left:70px;" runat ="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaInicio_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblLocalidadInicio" runat="server" Text="LOCALIDAD:"></asp:Label>
                    <asp:DropDownList ID="ddlLocalidadInicio" style="margin-left:65px;" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="lblFinal" runat="server" Text="DESTINO FINAL"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblProvFinal" runat="server" Text="PROVINCIA:"></asp:Label>
                    <asp:DropDownList ID="ddlProvinciaDestino" style="margin-left:70px;" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlProvinciaDestino_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblLocalidadFinal" runat="server" Text="LOCALIDAD:"></asp:Label>
                    <asp:DropDownList ID="ddlLocalidadDestino" style="margin-left:65px;" runat="server" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
