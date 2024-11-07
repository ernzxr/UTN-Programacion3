<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-login">
        <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo Usuario" CssClass="form-label mb-3"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mb-3" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" CssClass="btn btn-primary mb-3" />
    </div>
</asp:Content>
