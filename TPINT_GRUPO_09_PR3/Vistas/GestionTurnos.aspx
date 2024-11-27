<%@ Page Title="Gestión de Turnos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GestionTurnos.aspx.cs" Inherits="Vistas.GestionTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Turnos Pendientes de Gestion</h1>
    <asp:GridView
        DataKeyNames="Id_Turno_Tu"
        ID="gvTurnos"
        runat="server"
        CssClass="table table-bordered table-striped table-hover" AutoGenerateColumns="False">
        <columns>
            <asp:BoundField DataField="Legajo_Medico_Tu" HeaderText="Legajo Médico" />
            <asp:BoundField DataField="Nombre_Completo_Paciente_Tu" HeaderText="Nombre Paciente" />
            <asp:BoundField DataField="DNI_Paciente_Tu" HeaderText="DNI del Paciente" />
            <asp:BoundField DataField="Fecha_Tu" HeaderText="Fecha del Turno" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Hora">
                <itemtemplate>
                    <%# ((TimeSpan)Eval("Hora_Tu")).ToString(@"hh\:mm") %>
                </itemtemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Ciclo_Tu" HeaderText="Estado" />
        </columns>
    </asp:GridView>
</asp:Content>
