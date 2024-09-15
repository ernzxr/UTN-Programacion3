<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3_b.aspx.cs" Inherits="TP4.Ejercicio3_b" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <b>Listado de libros:<br />
            </b><br />
            <asp:GridView ID="gv_Libros" runat="server">
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
