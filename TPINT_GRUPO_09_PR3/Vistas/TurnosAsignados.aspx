<%@ Page Title="Turnos Asignados" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TurnosAsignados.aspx.cs" Inherits="Vistas.TurnosAsignados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TurnosAsignados</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="width: 100%; display: flex; flex-direction: column; align-items: flex-start; padding: 20px;">
    
    <!-- Título -->
    <asp:Label ID="lblTitulo" runat="server" Text="Turnos asignados" 
        style="font-size: 40px; color: steelblue; font-weight: bold; margin-bottom: 20px;"></asp:Label>

    <!-- Sección Izquierda -->
    <div style="width: 30%; display: flex; flex-direction: column; align-items: flex-start; padding-right: 20px;">
        
        <!-- Aplicar Filtros -->
        <asp:Label ID="lblAplicarFiltro" runat="server" Text="Aplicar filtros" 
            style="font-size: 25px; color: gray; font-weight: bold; margin-bottom: 20px;"></asp:Label>
        
        <!-- DNI del Paciente -->
        <asp:Label ID="lblDniPaciente" runat="server" Text="DNI del paciente" 
            style="font-weight: bold; margin-bottom: 5px;"></asp:Label>
        <asp:TextBox ID="txtDniPaciente" runat="server" 
            style="width: 100%; padding: 5px; margin-bottom: 5px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDniPaciente" runat="server" ControlToValidate="txtDniPaciente"
            ErrorMessage="El campo DNI es requerido" 
            style="color: red; font-size: 12px; margin-bottom: 5px;"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revDniPaciente" runat="server" ControlToValidate="txtDniPaciente"
            ErrorMessage="Ingrese un DNI válido (solo números)" 
            ValidationExpression="^\d{7,8}$" 
            style="color: red; font-size: 12px; margin-bottom: 20px;"></asp:RegularExpressionValidator>

        <!-- Día -->
        <asp:Label ID="lblDia" runat="server" Text="Día" 
            style="font-weight: bold; margin-bottom: 5px;"></asp:Label>
        <asp:TextBox ID="txtDia" runat="server" TextMode="Date" 
            style="width: 100%; padding: 5px; margin-bottom: 5px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDia" runat="server" ControlToValidate="txtDia"
            ErrorMessage="Seleccione un día" 
            style="color: red; font-size: 12px; margin-bottom: 20px;"></asp:RequiredFieldValidator>
    </div>

    <!-- Sección Derecha (Botones de filtro) -->
    <div style="width: 50%; display: flex; align-items: flex-end; gap: 10px; margin-left: 20px;">
        <asp:Button ID="btnFiltrarDni" runat="server" Text="Filtrar DNI" 
            style="padding: 10px 15px; font-size: 14px; cursor: pointer;" />
        <asp:Button ID="btnFiltrarDia" runat="server" Text="Filtrar Día" 
            style="padding: 10px 15px; font-size: 14px; cursor: pointer;" />
        <asp:Button ID="btnMostrarTodo" runat="server" Text="Mostrar todo" 
            style="padding: 10px 15px; font-size: 14px; cursor: pointer;" />
    </div>

    <!-- Sección Central (GridView para Turnos) -->
    <div style="width: 100%; margin-top: 40px;">
        <asp:GridView ID="grdTurnos" runat="server" 
            style="width: 100%; border-collapse: collapse; border: 1px solid #ddd; text-align: left;">
        </asp:GridView>
    </div>
</div>

</asp:Content>
