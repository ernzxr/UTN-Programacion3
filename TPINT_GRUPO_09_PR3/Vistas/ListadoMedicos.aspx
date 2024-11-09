<%@ Page Title="Listado de Médicos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListadoMedicos.aspx.cs" Inherits="Vistas.ListadoMedicos" %>


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
  
  <asp:Label ID="lblTitulo" runat="server" Text="Listado de Médicos" CssClass="auto-style1"></asp:Label>
  
  <asp:Label ID="lblLegajo" runat="server" Text="Legajo" Style="align-self: flex-start"></asp:Label>
  <asp:TextBox ID="txtLegajo" class="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
  <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
  <asp:RegularExpressionValidator ID="revLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1">(*) Ingrese solo números.</asp:RegularExpressionValidator>
  <div style="display: flex; gap: 10px;"> 
    <button type="btnFiltrar" class="btn btn-primary btn-lg">Filtrar</button>
    <button type="btnMostrarTodos" class="btn btn-primary btn-lg">MostrarTodos</button>
   </div> 
   
   <div style="width: 100%; margin-top: 20px;">
    <asp:GridView runat="server" ID="gvMedicos" CssClass="table table-hover"></asp:GridView>
   </div>
      
 </div>
</asp:Content>
