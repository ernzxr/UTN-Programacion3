<%@ Page Title="Login" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
    <style type="text/css">
        .auto-style1 {
            color: #006699;
            font-weight: bold;
            font-size: x-large;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
        <script type="text/javascript">
            function checkEnter(event) {
                if (event.key === "Enter") {
                    event.preventDefault();
                    document.getElementById('<%= btnLogin.ClientID %>').click();
                }
            }
        </script>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-login" style="position: relative;">

        

        <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="form-label mb-3"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
        

        <asp:Label ID="lblPassword" runat="server" Text="Contraseña" CssClass="form-label mb-3"></asp:Label>
        <asp:TextBox ID="txtPass" TextMode="Password" CssClass="form-control" runat="server"  onkeydown="checkEnter(event)" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvActual" runat="server" ControlToValidate="txtPass" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revPass" runat="server" ValidationGroup="grupo1" ValidationExpression="^\d{3,8}$" ControlToValidate="txtPass" ForeColor="#CC0000" ViewStateMode="Inherit" Text="(*) La contraseña debe tener entre 3 y 8 caracteres numéricos."></asp:RegularExpressionValidator>

        <asp:HyperLink ID="hlPass" runat="server" NavigateUrl="~/CambiarContraseña.aspx">He olvidado mi contraseña</asp:HyperLink>

       
        <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="form-label mb-3"></asp:Label>

        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" CssClass="btn btn-primary" ValidationGroup="grupo1" />



      
    </div>
</asp:Content>

      