<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarSucursal.aspx.cs" Inherits="TP5.EliminarSucursal" %>

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
             height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style2"><b style="font-size: 30px;">Eliminar Sucursal</b></td>
            </tr>
            <tr>
                <td class="auto-style2">Ingresar ID sucursal:<asp:TextBox ID="txtBox_Id" style="margin-left: 40px;" runat="server" Width="214px"></asp:TextBox>
                    <asp:Button ID="btn_Eliminar" style="margin-left: 30px;" runat="server" Text="Eliminar" OnClick="btn_Eliminar_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Validacion" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</form>
</body>
</html>
