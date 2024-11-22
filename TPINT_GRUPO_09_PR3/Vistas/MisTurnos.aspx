﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="Vistas.MisTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Mis Turnos</h1>
    <asp:GridView
        DataKeyNames="Id_Turno_Tu"
        ID="gvTurnos"
        runat="server"
        CssClass="table table-bordered table-striped table-hover" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Legajo_Medico_Tu" HeaderText="Legajo Médico" />
            <asp:BoundField DataField="Nombre_Completo_Paciente_Tu" HeaderText="Nombre Paciente" />
            <asp:BoundField DataField="DNI_Paciente_Tu" HeaderText="DNI del Paciente" />
            <asp:BoundField DataField="Fecha_Tu" HeaderText="Fecha del Turno" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Hora">
                <ItemTemplate>
                    <%# ((TimeSpan)Eval("Hora_Tu")).ToString(@"hh\:mm") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Ciclo_Tu" HeaderText="Estado" />
        </Columns>
    </asp:GridView>
</asp:Content>