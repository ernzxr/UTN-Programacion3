<%@ Page Title="Gestión de Turnos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GestionTurnos.aspx.cs" Inherits="Vistas.GestionTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ausencias {
            display: inline-flex;
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

        .validator-width {
            display: inline-block;
            width: 200px;
            min-height: 1.2em;
            vertical-align: top;
        }
    </style>
    <script>
        function showGestionarModal() {
            var modal = document.getElementById('GestionarTurnoModal');
            var myModal = new bootstrap.Modal(modal);
            myModal.show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Turnos Pendientes de Gestion</h1>

    <div id="alertContainer" runat="server" class="alert-container position-fixed bottom-0 end-0 p-3" style="z-index: 1050;"></div>

    <asp:GridView
        DataKeyNames="Id_Turno_Tu"
        ID="gvTurnos"
        runat="server"
        CssClass="table table-bordered table-striped table-hover"
        AutoGenerateColumns="False"
        AllowPaging="True"
        PagerSettings-Mode="NumericFirstLast"
        PagerSettings-FirstPageText="Inicio"
        PagerSettings-LastPageText="Fin"
        PagerStyle-CssClass="gridPager"
        PagerStyle-HorizontalAlign="Center"
        PagerStyle-VerticalAlign="Middle"
        PagerSettings-PageButtonCount="3"
        PageSize="5" OnPageIndexChanging="gvTurnos_PageIndexChanging" OnRowDataBound="gvTurnos_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Legajo_Medico_Tu" HeaderText="Legajo Médico" />
            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
            <asp:BoundField DataField="Nombre_Completo_Paciente_Tu" HeaderText="Nombre Paciente" />
            <asp:BoundField DataField="DNI_Paciente_Tu" HeaderText="DNI del Paciente" />
            <asp:BoundField DataField="Fecha_Tu" HeaderText="Fecha del Turno" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Hora">
                <ItemTemplate>
                    <%# ((TimeSpan)Eval("Hora_Tu")).ToString(@"hh\:mm") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Ciclo_Tu" HeaderText="Estado" />
            <asp:BoundField DataField="Detalle_Ciclo_Tu" HeaderText="Detalles" />
            <asp:TemplateField HeaderText="Opciones">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlOpciones" runat="server"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button ID="btnGestionar" runat="server" Text="Gestionar" CssClass="btn btn-primary btn-sm" OnClick="btnGestionar_Click" CommandArgument='<%# Eval("Id_Turno_Tu") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="modal fade" id="GestionarTurnoModal" tabindex="-1" aria-labelledby="GestionarModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="GestionarModalLabel">Reprogramar Turno</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div style="display:flex;flex-direction:column;">
                        <asp:Label ID="lblPaciente" runat="server"></asp:Label>
                        <asp:Label ID="lblEspecialidad" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlMedicosEspecialidad" runat="server"></asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-danger" OnClick="btnGuardar_Click" />
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
