<%@ Page Title="Eliminar Médico" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BajaMedicos.aspx.cs" Inherits="Vistas.BajaMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

<asp:Label ID="lblTitulo" runat="server" Text="Eliminar Médico" CssClass="auto-style1"></asp:Label>

<asp:Label ID="lblLegajo" runat="server" Text="Legajo" Style="align-self: flex-start"></asp:Label>
<asp:TextBox ID="txtLegajo" class="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="revLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationExpression="^\d+$" >(*) Ingrese solo números.</asp:RegularExpressionValidator>
<asp:Button ID="btnBaja" class="btn btn-success" runat="server" Text="Dar de baja" />

<asp:Label ID="lblMensaje" runat="server"  Style="align-self: flex-start"></asp:Label>

  
    </div>



</asp:Content>
