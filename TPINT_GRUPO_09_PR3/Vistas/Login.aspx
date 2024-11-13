<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="main-login" style="position:relative;">
        
            <!-- <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo Usuario" CssClass="form-label mb-3"></asp:Label> -->
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="form-label mb-3"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label ID="lblPassword" runat="server" Text="Contraseña" CssClass="form-label mb-3"></asp:Label>
            <asp:TextBox ID="txtPass" TextMode="Password" CssClass="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvActual" runat="server" ControlToValidate="txtPass" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
            <!--<asp:RegularExpressionValidator ID="rfvPActual" runat="server" ControlToValidate="txtPass" CssClass="mb-3" ForeColor="#CC0000" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)" ValidationGroup="grupo1">(*) La contraseña .</asp:RegularExpressionValidator> -->
             <asp:Label ID="lblError" runat="server" Text="" CssClass="form-label mb-3"></asp:Label>

            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
