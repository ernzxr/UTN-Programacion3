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

        
        <asp:Label ID="lblActual" runat="server" Text="Contraseña actual" Style="align-self: flex-start"></asp:Label>
        <asp:TextBox ID="txtActual" TextMode="Password" CssClass="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvActual" runat="server" ControlToValidate="txtActual" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="rfvPActual" runat="server" ControlToValidate="txtActual" CssClass="mb-3" ForeColor="#CC0000" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$" ValidationGroup="grupo1">(*) La contraseña debe tener al menos 8 caracteres, una letra mayúscula, una minúscula y un número.</asp:RegularExpressionValidator>

       <asp:Label ID="lblNueva" runat="server" Text="Nueva contraseña" Style="align-self: flex-start"></asp:Label>
       <asp:TextBox ID="txtNueva" TextMode="Password" CssClass="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfvNueva" runat="server" ControlToValidate="txtNueva" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNueva" CssClass="mb-3" ForeColor="#CC0000" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$" ValidationGroup="grupo1">(*) La contraseña debe tener al menos 8 caracteres, una letra mayúscula, una minúscula y un número.</asp:RegularExpressionValidator>

       <asp:Label ID="lblConfirme" runat="server" Text="Confirme la contraseña" Style="align-self: flex-start"></asp:Label>
       <asp:TextBox ID="txtConfirme" TextMode="Password" CssClass="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtConfirme" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtConfirme" CssClass="mb-3" ForeColor="#CC0000" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$" ValidationGroup="grupo1">(*) La contraseña debe tener al menos 8 caracteres, una letra mayúscula, una minúscula y un número.</asp:RegularExpressionValidator>      
            
        <asp:Button ID="btnConfirmar" class="btn btn-success" runat="server" Text="Confirmar" ValidationGroup="grupo1" OnClick="btnAgregar_Click" />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</div>
        



</asp:Content>
