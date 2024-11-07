<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo Usuario"></asp:Label>
            <div>
                <asp:TextBox ID="txtPassword" runat="server" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
        </div>
        <div class="col">
        </div>
    </div>
</asp:Content>
