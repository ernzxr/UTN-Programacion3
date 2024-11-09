<%@ Page Title="Modificar Datos de Médico" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ModificarDatosMedico.aspx.cs" Inherits="Vistas.ModificarDatosMedico" %>


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
    .bold-large {
    font-weight: bold;      
    font-size: 18px;        
    align-self: flex-start; 
}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div style="width: 50%; display: flex; flex-direction: column; align-items: center; justify-content: center;">
  
  <asp:Label ID="lblTitulo" runat="server" Text="Modificar Datos del Médico" CssClass="auto-style1"></asp:Label>
  <p></p>
 
 <asp:Label ID="Subtitulo" runat="server" Text="Modificar datos personales" 
           CssClass="bold-large" Style="align-self: flex-start;"> 
</asp:Label>
<p></p>
  
  <asp:Label ID="lblLegajo" runat="server" Text="Legajo" Style="align-self: flex-start"></asp:Label>
  <asp:TextBox ID="txtLegajo" class="form-control" runat="server" ></asp:TextBox>
  <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
  <asp:RegularExpressionValidator ID="revLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1">(*) Ingrese solo números.</asp:RegularExpressionValidator>

      <button type="btnDireccion" class="btn btn-secondary btn-lg" style="width: 650px; height: 50px;" >Dirección</button>
<p></p>
      <button type="btnMail" class="btn btn-secondary btn-lg" style="width: 650px; height: 50px;" >Correo Electrónico</button>
      
<p></p>
      <button type="btnTelefono" class="btn btn-secondary btn-lg" style="width: 650px; height: 50px;" >Teléfono</button>
      
<p></p>
      <button type="btnCargarHorarios" class="btn btn-primary btn-lg">Cargar días y horarios</button>
      
   </div>
</asp:Content>
