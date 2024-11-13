<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AsignarTurno.aspx.cs" Inherits="Vistas.AsignarTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>AsignarTurno</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Contenedor principal -->
    <div style="display: flex; flex-wrap: wrap; padding: 20px; gap: 20px;">
        
        <!-- Título -->
        <asp:Label ID="lblTitulo" runat="server" Text="Asignar Turno" 
            style="font-size: 40px; color: SkyBlue; font-weight: bold; width: 100%; margin-top: 80px; margin-bottom: 20px;"></asp:Label>

        <!-- Sección Izquierda -->
        <div style="flex: 1; display: flex; flex-direction: column; align-items: flex-start; gap: 10px; max-width: 300px;">
            <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:" 
                style="font-weight: bold;"></asp:Label>
            <asp:DropDownList ID="ddlEspecialidades" runat="server" 
                style="width: 100%; padding: 5px;" AutoPostBack="True" Font-Bold="False" OnSelectedIndexChanged="EspecialidadSeleccionada"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidades"
                InitialValue="-- Seleccionar --" ErrorMessage="Seleccione una especialidad" 
                style="color: red; font-size: 12px;"></asp:RequiredFieldValidator>

            <asp:Label ID="lblProfesional" runat="server" Text="Profesional:" 
                style="font-weight: bold;"></asp:Label>
            <asp:DropDownList ID="ddlProfesionales" runat="server" 
                style="width: 100%; padding: 5px;" AutoPostBack="True"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvProfesional" runat="server" ControlToValidate="ddlProfesionales"
                InitialValue="-- Seleccionar --" ErrorMessage="Seleccione un profesional" 
                style="color: red; font-size: 12px;"></asp:RequiredFieldValidator>

            <asp:Label ID="lblDniPaciente" runat="server" Text="Dni del paciente:" 
                style="font-weight: bold;"></asp:Label>
            <asp:TextBox ID="txtDniPaciente" runat="server" 
                style="width: 100%; padding: 5px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDniPaciente" runat="server" ControlToValidate="txtDniPaciente"
                ErrorMessage="El DNI es requerido" style="color: red; font-size: 12px;"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revDniPaciente" runat="server" ControlToValidate="txtDniPaciente"
                ErrorMessage="Formato de DNI inválido" 
                ValidationExpression="^\d{7,8}$" style="color: red; font-size: 12px;"></asp:RegularExpressionValidator>

            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Turno" 
                style="width: 150px; padding: 10px; background-color: #007bff; color: white; border: none; border-radius: 5px; cursor: pointer;" OnClick="btnAgregar_Click"></asp:Button>
            <asp:Label ID="lblMensaje" runat="server" 
                style="margin-left: 10px; color: green; font-weight: bold;"></asp:Label>
        </div>

        <!-- Sección Central -->
        <div style="flex: 1; display: flex; flex-direction: column; align-items: center; gap: 10px;">
            <asp:Label ID="lblDia" runat="server" Text="Día:" 
                style="font-weight: bold;"></asp:Label>
            <asp:TextBox ID="txtDia" runat="server" TextMode="Date" 
                style="width: 100%; padding: 5px;" AutoPostBack="True" OnTextChanged="txtDia_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDia" runat="server" ControlToValidate="txtDia"
                ErrorMessage="Seleccione un día" style="color: red; font-size: 12px;"></asp:RequiredFieldValidator>
            <asp:Label ID="lblMensajeError" runat="server" Text="" 
                style="color: red; font-size: 12px;"></asp:Label>
        </div>

        <!-- Sección Derecha -->
        <div style="flex: 1; display: flex; flex-direction: column; align-items: flex-start; gap: 10px;">
            <asp:Label ID="lblHorario" runat="server" Text="Horario:" 
                style="font-weight: bold;"></asp:Label>
            <asp:DataList ID="dlHorario" runat="server" 
                style="width: 100%; padding: 5px;" OnItemCommand="dlHorario_ItemCommand">
                <ItemTemplate>
                    <asp:Button ID="btnHorario" runat="server" Text='<%# Eval("Horario") %>' CommandArgument='<%# Eval("Horario") %>' CommandName="SeleccionarHorario" 
                        style="padding: 10px 20px; font-size: 16px; width: 150px; height: 60px;"/>
                </ItemTemplate>
            </asp:DataList>
            <asp:Label ID="lblMensajeError2" runat="server" Text="" 
           style ="color: red; font-size: 12px;"></asp:Label>
        </div>
    </div>

</asp:Content>
