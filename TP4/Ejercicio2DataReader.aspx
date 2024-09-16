<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2DataReader.aspx.cs" Inherits="TP4.Ejercicio2DataReader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 125px;
        }
        .auto-style3 {
            width: 179px;
        }
        .auto-style4 {
            width: 179px;
            text-align: center;
        }
        .auto-style5 {
            width: 125px;
            text-align: center;
        }
        .auto-style6 {
            width: 270px;
        }
        .auto-style7 {
            width: 270px;
            text-align: center;
        }
        .auto-style8 {
            width: 125px;
            text-align: center;
            height: 26px;
        }
        .auto-style9 {
            width: 179px;
            text-align: center;
            height: 26px;
        }
        .auto-style10 {
            width: 270px;
            text-align: center;
            height: 26px;
        }
        .auto-style11 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style8">Id Producto:</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddl_Producto" runat="server" AutoPostBack="True" Width="80px">
                            <asp:ListItem Value="1">Igual a:</asp:ListItem>
                            <asp:ListItem Value="2">Mayor a:</asp:ListItem>
                            <asp:ListItem Value="3">Menor a:</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtBox_Producto" runat="server" Width="175px" ValidationGroup="grupo1"></asp:TextBox>
                    </td>
                    <td class="auto-style11">
                        <asp:RegularExpressionValidator ID="revProductos" runat="server" ControlToValidate="txtBox_Producto" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="grupo1">*Ingrese solo números.</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Id Categoria:</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="ddl_Categoria" runat="server" AutoPostBack="True" Width="80px">
                            <asp:ListItem Value="4">Igual a:</asp:ListItem>
                            <asp:ListItem Value="5">Mayor a:</asp:ListItem>
                            <asp:ListItem Value="6">Menor a:</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtBox_Categoria" runat="server" Width="175px" ValidationGroup="grupo1"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="revCategorias" runat="server" ControlToValidate="txtBox_Categoria" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="grupo1">*Ingrese solo números.</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="btn_Filtrar" runat="server" OnClick="btn_Filtrar_Click" Text="Filtrar" ValidationGroup="grupo1" />
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_QuitarFiltro" runat="server" Text="Quitar Filtro" OnClick="btn_QuitarFiltro_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gv_Productos" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
