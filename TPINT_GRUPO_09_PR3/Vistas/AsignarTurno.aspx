<%@ Page Title="Turnos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AsignarTurno.aspx.cs" Inherits="Vistas.AsignarTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.min.js"></script>
    <title>AsignarTurno</title>
    <script>
        let diasLaborables = [];
        let diasAusencias = [];

        function cargarDatePicker(dias) {
            diasLaborables = dias;  // Guardar los días laborales en la variable global
            $(".datepicker").datepicker("refresh");  // Refrescar el DatePicker para que reconozca los días laborables
        }

        function cargarAusencias(dias) {
            diasAusencias = dias;
            $(".datepicker").datepicker("refresh");
        }

        $(document).ready(function () {
            // Función para establecer los días laborables desde el backend

            // Inicializa el DatePicker
            $(".datepicker").datepicker({
                dateFormat: "dd/mm/yy", // Formato de fecha
                changeMonth: true,      // Permitir cambiar de mes
                changeYear: true,       // Permitir cambiar de año
                minDate: 0,             // Fecha mínima: hoy
                maxDate: "+1y",         // Fecha máxima: 1 año a partir de hoy
                showAnim: "fadeIn",     // Animación al mostrar
                beforeShowDay: function (date) {
                    const dayOfWeek = date.getDay(); // Día de la semana (0 = Domingo, 6 = Sábado)
                    const isLaborable = diasLaborables[dayOfWeek]; // Verifica si el día es laborable
                    // Convertimos la fecha a formato "yyyy-mm-dd" para compararla
                    const dateString = $.datepicker.formatDate("yy-mm-dd", date);

                    // Verificamos si la fecha está en el arreglo de fechas excepcionales
                    const esExcepcional = diasAusencias.includes(dateString);
                    return [isLaborable && !esExcepcional]; // Solo permite días laborables
                }
            });
        });

    </script>
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
                style="width: 100%; padding: 5px;" AutoPostBack="True" OnSelectedIndexChanged="ddlProfesionales_SelectedIndexChanged"></asp:DropDownList>
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
                Style="font-weight: bold;"></asp:Label>
            <asp:TextBox ID="txtDia" runat="server" CssClass="datepicker" Style="width: 100%; padding: 5px;" AutoPostBack="True" OnTextChanged="txtDia_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDia" runat="server" ControlToValidate="txtDia"
                ErrorMessage="Seleccione un día" Style="color: red; font-size: 12px;"></asp:RequiredFieldValidator>
            <asp:Label ID="lblMensajeError" runat="server" Text=""
                Style="color: red; font-size: 12px;"></asp:Label>
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
