<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="Vistas.CambiarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Cambiar contraseña</title>
    <style type="text/css">
        .auto-style1 {
            color: #006699;
            font-weight: bold;
            font-size: x-large;
            font-family: Arial, Helvetica, sans-serif;
        }
          .auto-style2 {
        --bs-form-check-bg: var(--bs-body-bg);
        flex-shrink: 0;
        margin-top: .25em;
        vertical-align: top;
        -webkit-appearance: none;
        -moz-appearance: none;
        appearance: none;
        background-color: var(--bs-form-check-bg);
        background-image: url('var(--bs-form-check-bg-image)');
        background-repeat: no-repeat;
        background-position: center;
        background-size: contain;
        -webkit-print-color-adjust: exact;
        print-color-adjust: exact;
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="width: 50%; display: flex; flex-direction: column; align-items: center; justify-content: center;">
        <asp:Label ID="lblTitulo" runat="server" Text="Cambiar contraseña" CssClass="auto-style1"></asp:Label>

        <asp:Label ID="lblUsuario" runat="server" Text="Usuario" Style="align-self: flex-start"></asp:Label>
        <asp:TextBox ID="txtUsuario"  CssClass="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>

       <asp:Label ID="lblEmail" runat="server" Text="Email" Style="align-self: flex-start"></asp:Label>
       <asp:TextBox ID="txtEmail"  CssClass="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" CssClass="mb-3" ForeColor="#CC0000" ValidationExpression="^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$" ValidationGroup="grupo1">(*)Debe ingresar un Email válido</asp:RegularExpressionValidator>      

       <asp:Label ID="lblCalve" runat="server" Text="Nueva contraseña" Style="align-self: flex-start"></asp:Label>
       <asp:TextBox ID="txtClave" TextMode="Password" CssClass="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="revPass" runat="server" ValidationGroup="grupo1" ValidationExpression="^\d{3,8}$" ControlToValidate="txtClave" ForeColor="#CC0000" ViewStateMode="Inherit" Text="(*) Solo se permiten números con entre 3 y 8 dígitos."></asp:RegularExpressionValidator>

       <asp:Label ID="lblConfirmarClave" runat="server" Text="Confirme la contraseña" Style="align-self: flex-start"></asp:Label>
       <asp:TextBox ID="txtConfirmarClave" TextMode="Password" CssClass="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rvfConfirmar" runat="server" ControlToValidate="txtConfirmarClave" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
       <asp:CompareValidator ID="cvPass" runat="server" Text="(*)Las contraseñas no coinciden" ControlToCompare="txtClave" ControlToValidate="txtConfirmarClave" ForeColor="#CC0000" Operator="Equal" ValidationGroup="grupo1"></asp:CompareValidator>
       <asp:RegularExpressionValidator ID="revConfirmar" runat="server" ForeColor="#CC0000" ValidationExpression="^\d{3,8}$" Text="(*) Solo se permiten números con entre 3 y 8 dígitos." ControlToValidate="txtConfirmarClave"></asp:RegularExpressionValidator>

        <asp:Button ID="btnAceptar" class="btn btn-success" runat="server" Text="Aceptar" ValidationGroup="grupo1" OnClick="btnAgregar_Click" />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</div>
        



</asp:Content>
