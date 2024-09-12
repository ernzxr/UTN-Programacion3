<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 60%;
            margin-left: 1%;
        }
        .auto-style2 {
            height: 83px;
        }
        .auto-style3 {
            margin-left: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>Id Producto:<asp:DropDownList class="auto-style3" ID="ddl_Producto" runat="server">
                        <asp:ListItem Value="0">Igual a</asp:ListItem>
                        <asp:ListItem Value="1">Mayor a</asp:ListItem>
                        <asp:ListItem Value="2">Menor a</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox class="auto-style3" ID="txtBox_Producto" runat="server" Width="280px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Id Categoria:<asp:DropDownList style="margin-left: 16px;" ID="ddl_Categoria" runat="server">
                        <asp:ListItem Value="0">Igual a</asp:ListItem>
                        <asp:ListItem Value="1">Mayor a</asp:ListItem>
                        <asp:ListItem Value="2">Menor a</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox class="auto-style3" ID="txtBox_Categoria" runat="server" Width="280px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <div style="margin-left: 325px;">
                        <asp:Button style="margin-right: 25px;" ID="btn_Filtrar" runat="server" Text="Filtrar" />
                        <asp:Button ID="btn_QuitarF" runat="server" Text="Quitar filtro" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView style="margin-top: 20px;" ID="gv_Productos" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
