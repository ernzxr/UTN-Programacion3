<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReportePorcentajeAusencias.aspx.cs" Inherits="Vistas.ReportePorcentajeAusencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Porcentaje de ausencias</title>
 <style type="text/css">
     .auto-style1 {
         color: #006699;
         font-weight: bold;
         font-size: x-large;
         font-family: Arial, Helvetica, sans-serif;
     }
    </style>
</asp:Content>
        

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblTitulo" runat="server" Text="Reporte de porcentaje de ausencias de pacientes a turnos" Font-Size="Large"></asp:Label>
<br />

     <!-- Fecha inicio -->
      <div class="form-group">
     <asp:Label ID="lblDia" runat="server" Text="Fecha Inicio" CssClass="form-label"></asp:Label>
     <div style="display: flex; gap: 10px; align-items: center;">
     <asp:TextBox ID="txtInicio" runat="server" TextMode="Date" CssClass="form-control mt-2" ValidationGroup="Grupo1"></asp:TextBox>
     <div style="display: flex; gap: 10px; align-items: center;">
         <asp:RequiredFieldValidator ID="rfvInicio" runat="server" ControlToValidate="txtInicio" CssClass="text-danger" Text="(*) Campo requerido" Display="Dynamic" ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
     </div>
   </div>
 </div>
     <!-- Fecha fin-->
     <div class="form-group">
    <asp:Label ID="lblFin" runat="server" Text="Fecha Fin" CssClass="form-label"></asp:Label>
    <div style="display: flex; gap: 10px; align-items: center;">
    <asp:TextBox ID="txtFin" runat="server" TextMode="Date" CssClass="form-control mt-2" ValidationGroup="Grupo1"></asp:TextBox>
    <div style="display: flex; gap: 10px; align-items: center;">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFin" CssClass="text-danger" Text="(*) Campo requerido" Display="Dynamic" ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
        <asp:CompareValidator  ID="cvFecha" runat="server" ControlToValidate="txtFin" CssClass="text-danger"   ControlToCompare="txtInicio"  Operator="GreaterThan"  Type="Date" Text="La fecha fin debe ser mayor que la fecha inicio." Display="Dynamic" ValidationGroup="Grupo1" > </asp:CompareValidator>

    </div>
  </div>
</div>

         <div class="form-group text-center mt-4">
        <asp:Button ID="btnGenerar" runat="server" Text="Generar reporte" CssClass="btn btn-primary mt-2" OnClick="btnGenerar_Click"  ValidationGroup="Grupo1" />
    </div>

<asp:GridView 
    DataKeyNames="Id_Turno_Tu" 
    ID="gvTurnos" 
    runat="server" 
    CssClass="table table-bordered table-striped table-hover" 
    ShowHeaderWhenEmpty="true"
    EmptyDataText="No hay turnos disponibles"
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
        <asp:TemplateField HeaderText="Legajo Médico">
            <ItemTemplate>
                <asp:Label ID="lblLegajo" runat="server" Text='<%# Bind("Legajo_Medico_Tu") %>'></asp:Label>
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
    

    <!-- Resumen -->
    <div class="summary mt-3">
         <asp:Label ID="lblTotalTurnos" runat="server" Text=""></asp:Label>
          <asp:Label ID="lblTurnosAusentes" runat="server" Text=""></asp:Label>
          <asp:Label ID="lblPorcentaje" runat="server" Text="" ></asp:Label>
          
    </div>


     </asp:Content>


