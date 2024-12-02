<%@ Page Title="Listado Turnos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListarTurnos.aspx.cs" Inherits="Vistas.ListarTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
    .validator-width {
        display: inline-block;
        width: 200px;
        min-height: 1.2em;
        vertical-align: top;
    }
    .form-group {
        margin-bottom: 20px;
    }

    .gridPager a,
    .gridPager span {
display: inline-block;
padding: 0px 9px;
margin-right: 4px;
border-radius: 3px;
border: solid 1px #c0c0c0;
background: #e9e9e9;
box-shadow: inset 0px 1px 0px rgba(255,255,255, .8), 0px 1px 3px rgba(0,0,0, .1);
font-size: .875em;
font-weight: bold;
text-decoration: none;
color: #717171;
text-shadow: 0px 1px 0px rgba(255,255,255, 1);
    }

    .gridPager a {
background-color: #f5f5f5;
color: #969696;
border: 1px solid #969696;
    }

.gridPager span {
background: #616161;
box-shadow: inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8);
color: #f0f0f0;
text-shadow: 0px 0px 3px rgba(0,0,0, .5);
border: 1px solid #3AC0F2;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contenedor">
    <!-- Sección de filtros para Listado de Turnos -->
    <div class="px-5 py-3 me-5 border rounded">
        <h3 class="text-center">Listado de Turnos</h3>

        <!-- Búsqueda por Estado -->
        <div class="form-group">
            <asp:Label ID="lblBuscar" runat="server" Text="Búsqueda por Estado" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control mt-2" MaxLength="50" ValidationGroup="GrupoBusqueda"></asp:TextBox>
            <div style="display: flex; gap: 10px; align-items: center;">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary mt-2" ValidationGroup="GrupoBusqueda" OnClick="btnBuscar_Click" />
                <asp:RequiredFieldValidator ID="rfvBuscar" runat="server" ControlToValidate="txtBuscar" CssClass="text-danger" Text="* Requerido" Display="Dynamic" ValidationGroup="GrupoBusqueda"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revBuscar" runat="server" ControlToValidate="txtBuscar" CssClass="text-danger" ValidationExpression="^[a-zA-ZñÑáéíóúÁÉÍÓÚ]+$" 
         ErrorMessage="Solo letras, sin espacios" Display="Dynamic" ValidationGroup="GrupoBusqueda"></asp:RegularExpressionValidator>
            </div>
        </div>

        <!-- Filtro por Legajo del Médico -->
        <div class="form-group">
            <asp:Label ID="lblLegajo" runat="server" Text="Legajo del Médico" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control mt-2" MaxLength="5" ValidationGroup="Grupo1"></asp:TextBox>
            <div style="display: flex; gap: 10px; align-items: center;">
                <asp:Button ID="btnFiltrarLegajo" runat="server" Text="Filtrar por Legajo" CssClass="btn btn-primary mt-2" ValidationGroup="Grupo1" OnClick="btnFiltrarLegajo_Click"  />
                <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" CssClass="text-danger" Text="* Requerido" Display="Dynamic" ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
            </div>
        </div>

        <!-- Filtro por DNI del Paciente -->
        <div class="form-group">
            <asp:Label ID="lblDniPaciente" runat="server" Text="DNI del Paciente" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtDniPaciente" runat="server" CssClass="form-control mt-2" MaxLength="8" ValidationGroup="Grupo2"></asp:TextBox>
            <div style="display: flex; gap: 10px; align-items: center;">
                <asp:Button ID="btnFiltrarDniPaciente" runat="server" Text="Filtrar por DNI" CssClass="btn btn-primary mt-2" ValidationGroup="Grupo2" OnClick="btnFiltrarDniPaciente_Click"  />
                <asp:RequiredFieldValidator ID="rfvDniPaciente" runat="server" ControlToValidate="txtDniPaciente" CssClass="text-danger" Text="* Requerido" Display="Dynamic" ValidationGroup="Grupo2"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revDniPaciente" runat="server" ControlToValidate="txtDniPaciente" CssClass="text-danger" ValidationExpression="^\d{8}$" Text="* DNI inválido" Display="Dynamic" ValidationGroup="Grupo2"></asp:RegularExpressionValidator>
            </div>
        </div>

        <!-- Filtro por Día -->
        <div class="form-group">
            <asp:Label ID="lblDia" runat="server" Text="Día" CssClass="form-label"></asp:Label>
            <div style="display: flex; gap: 10px; align-items: center;">
            <asp:TextBox ID="txtDia" runat="server" TextMode="Date" CssClass="form-control mt-2" ValidationGroup="Grupo3"></asp:TextBox>
            <div style="display: flex; gap: 10px; align-items: center;">
                <asp:Button ID="btnFiltrarDia" runat="server" Text="Filtrar por Día" CssClass="btn btn-primary mt-2" ValidationGroup="Grupo3" OnClick="btnFiltrarDia_Click" />
                <asp:RequiredFieldValidator ID="rfvDia" runat="server" ControlToValidate="txtDia" CssClass="text-danger" Text="* Requerido" Display="Dynamic" ValidationGroup="Grupo3"></asp:RequiredFieldValidator>
            </div>
          </div>
        </div>

        <!-- Botón para Mostrar Todos los Turnos -->
        <div class="form-group text-center mt-4">
            <asp:Button ID="btnMostrarTodo" runat="server" Text="Mostrar Todo" CssClass="btn btn-secondary" OnClick="btnMostrarTodo_Click" />
        </div>
    </div>

       <!-- Mensaje de Error -->
        <div class="form-group text-center mt-2">
            <asp:Label ID="lblMensajeError" runat="server" Text="" CssClass="text-danger" style="font-size: 14px; font-weight: bold;"></asp:Label>
        </div>

        <div class="px-5 py-3">
    
 <asp:GridView  
ID="gvTurnos" 
runat="server" 
CssClass="table table-bordered table-striped table-hover" 
AutoGenerateColumns="False" 
AllowPaging="True" 
AllowSorting="True"
OnPageIndexChanging="gvTurnos_PageIndexChanging" 
PageSize="5"
PagerSettings-Mode="NumericFirstLast" 
PagerSettings-FirstPageText="Inicio" 
PagerSettings-LastPageText="Fin" 
PagerStyle-CssClass="gridPager" 
PagerStyle-HorizontalAlign="Center" 
PagerStyle-VerticalAlign="Middle" 
PagerSettings-PageButtonCount="3">

<Columns>
    
    <asp:TemplateField HeaderText="Ciclo">
       <ItemTemplate>
          <asp:Label ID="lblCiclo" runat="server" Text='<%# Bind("Ciclo_Tu") %>'></asp:Label>
       </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Detalle ciclo">
       <ItemTemplate>
           <asp:Label ID="lblDetalleCiclo" runat="server" Text='<%# Bind("Detalle_Ciclo_Tu") %>'></asp:Label>
       </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Legajo Médico">
        <ItemTemplate>
            <asp:Label ID="lblLegajoMedico" runat="server" Text='<%# Bind("Legajo_Medico_Tu") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="DNI del Paciente">
        <ItemTemplate>
            <asp:Label ID="lblDni" runat="server" Text='<%# Bind("DNI_Paciente_Tu") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Fecha del Turno">
        <ItemTemplate>
            <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha_Tu", "{0:yyyy-MM-dd}") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Hora">
        <ItemTemplate>
            <asp:Label ID="lblHora" runat="server" Text='<%# ((TimeSpan)Eval("Hora_Tu")).ToString(@"hh\:mm") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Estado">
        <ItemTemplate>
            <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("Ciclo_Tu") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Asistencia">
        <ItemTemplate>
            <asp:Label ID="lblAsistencia" runat="server" Text='<%# Bind("Asistencia_Tu") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Observaciones">
        <ItemTemplate>
            <asp:Label ID="lblObservaciones" runat="server" Text='<%# Bind("Observaciones_Tu") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

</Columns>
</asp:GridView>

             </div>
   </div>
</asp:Content>
