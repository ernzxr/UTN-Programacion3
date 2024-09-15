<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ejercicio 2</title>
    <style type="text/css">
        .auto-style1 {
            width: 60%;
            margin-left: 1%;
        }
        .auto-style3 {
            margin-left: 20px;
        }
        .auto-style5 {
            height: 83px;
            }
        .auto-style9 {
            width: 274px;
        }
        .auto-style10 {
            height: 83px;
            width: 274px;
        }
        .auto-style11 {
            width: 274px;
            height: 26px;
        }
        .auto-style13 {
            height: 26px;
        }
        .auto-style14 {
            width: 106px;
            height: 26px;
        }
        .auto-style16 {
            height: 83px;
            width: 106px;
        }
        .auto-style17 {
            width: 106px;
        }
        .auto-style18 {
            width: 53px;
            height: 26px;
        }
        .auto-style19 {
            width: 53px;
        }
        .auto-style20 {
            height: 83px;
            width: 53px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="lblProducto" runat="server" Text="Id Producto:"></asp:Label>
                    </td>
                    <td class="auto-style18">
                        <asp:DropDownList ID="ddl_Producto" runat="server">
                        <asp:ListItem Value="0">Igual a</asp:ListItem>
                        <asp:ListItem Value="1">Mayor a</asp:ListItem>
                        <asp:ListItem Value="2">Menor a</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style13">
                        <asp:TextBox class="auto-style3" ID="txtBox_Producto" runat="server" Width="280px"></asp:TextBox>
                    </td>
                    <td class="auto-style11">
                        <asp:RegularExpressionValidator ID="revIdProducto" runat="server" ControlToValidate="txtBox_Producto" ErrorMessage="Ingrese solo números" ValidationExpression="^\d+$" ValidationGroup="gpFiltrar" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="lblCategoria" runat="server" Text="Id Categoria:"></asp:Label>
                    </td>
                    <td class="auto-style19">
                        <asp:DropDownList ID="ddl_Categoria" runat="server">
                        <asp:ListItem Value="0">Igual a</asp:ListItem>
                        <asp:ListItem Value="1">Mayor a</asp:ListItem>
                        <asp:ListItem Value="2">Menor a</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox class="auto-style3" ID="txtBox_Categoria" runat="server" Width="280px"></asp:TextBox>
                    </td>
                    <td class="auto-style9">
                        <asp:RegularExpressionValidator ID="revIdCategoria" runat="server" ControlToValidate="txtBox_Categoria" ErrorMessage="Ingrese solo números" ValidationExpression="^\d+$" ValidationGroup="gpFiltrar" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">
                    </td>
                    <td class="auto-style20">
                        <asp:Button ID="btn_Filtrar" runat="server" Text="Filtrar" OnClick="btn_Filtrar_Click" ValidationGroup="gpFiltrar" />
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btn_QuitarF" runat="server" Text="Quitar filtro" OnClick="btn_QuitarF_Click" />
                    </td>
                    <td class="auto-style10">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:GridView style="margin-top: 20px;" ID="gv_Productos" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
