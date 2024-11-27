<%@ Page Title="Reportes Pacientes" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReportePacientesFrecuentes.aspx.cs" Inherits="Vistas.ReportePacientesFrecuentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Pacientes con más turnos por especialidad</title>
    <style>
        .auto-style1 {
            color: #006699;
            font-weight: bold;
            font-size: x-large;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; display: flex; justify-content: center; align-items: center; margin-bottom: 30px;">
        <asp:Label ID="lblTitulo" runat="server" Text="Pacientes con más turnos por especialidad" CssClass="auto-style1 mb-4" ForeColor="#000099"></asp:Label>
    </div>

    <div style="width: 80%; display: flex; justify-content: center; gap: 40px; position: relative;">


        <div style="flex: 1; display: flex; flex-direction: column; align-items: stretch;">

            <div style="margin-bottom: 15px;">
                <asp:Label ID="lblEspecialidad" runat="server" Text="Seleccione una especialidad" CssClass="mb-2"></asp:Label>
                <asp:DropDownList ID="ddlEspecialidad" class="form-select" runat="server" Style="width: 100%;"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEspecialidad" CssClass="auto-style2" runat="server" ControlToValidate="ddlEspecialidad"
                    ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0" Style="font-size: small; display: block;">(*) Seleccione una opción.</asp:RequiredFieldValidator>
            </div>


            <div style="display: flex; justify-content: space-between; gap: 20px; margin-bottom: 15px;">

                <div style="flex: 1;">
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicial" CssClass="mb-2"></asp:Label>
                    <asp:TextBox ID="txtFechaInicio" class="form-control" runat="server" ValidationGroup="grupo1" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" ControlToValidate="txtFechaInicio" ForeColor="#CC0000" ValidationGroup="grupo1" CssClass="auto-style2" Style="font-size: small; display: block;">(*) Complete el campo.</asp:RequiredFieldValidator>
                </div>


                <div style="flex: 1;">
                    <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Final" CssClass="mb-2"></asp:Label>
                    <asp:TextBox ID="txtFechaFin" class="form-control" runat="server" ValidationGroup="grupo1" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaFin" runat="server" ControlToValidate="txtFechaFin" ForeColor="#CC0000"
                        ValidationGroup="grupo1" CssClass="auto-style2" Style="font-size: small; display: block;">(*) Complete el campo.</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvFechaFin" runat="server" ControlToValidate="txtFechaFin" ControlToCompare="txtFechaInicio" ValidationGroup="grupo1" Operator="GreaterThanEqual" Text="(*) La fecha seleccionada debe ser mayor o igual que la fecha inicial." ForeColor="#CC0000" Style="font-size: small; display: block;"></asp:CompareValidator>
                </div>
            </div>


            <div style="display: flex; justify-content: center; margin-top: 15px;">
                <asp:Button ID="btnBuscar" class="btn btn-dark" runat="server" Text="Buscar" Width="150px" ValidationGroup="grupo1" OnClick="btnBuscar_Click" />
            </div>
        </div>


        <div style="flex: 1; display: flex; flex-direction: column; justify-content: center; align-items: stretch;">
            <asp:Label ID="lblInformeEspecialidad" runat="server" Text="" Style="margin-bottom: 15px; text-align: center;"></asp:Label>
            <asp:GridView ID="gvPacientesConMasTurnos" CssClass="table table-hover" runat="server" Style="width: 100%;"></asp:GridView>
        </div>
    </div>
</asp:Content>
