<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReportesInformes.aspx.cs" Inherits="Vistas.ReportesInformes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container mt-5">
    <h1 class="text-center">Reportes e Informes</h1>
    <p class="text-center">Selecciona el informe o reporte que deseas consultar:</p>

    <div class="row justify-content-center">
        <!-- Card 1 -->
        <div class="col-md-4">
            <div class="card text-center mb-4">
                <div class="card-body">
                    <h5 class="card-title">Mes con Mayor Cantidad de Turnos</h5>
                    <p class="card-text">
                        Ingresa un año y descubre cuál fue el mes con más turnos registrados.
                    </p>
                    <asp:HyperLink ID="hlMesMayorTurnos" runat="server" NavigateUrl="InformeMayorTurnos.aspx" CssClass="btn btn-primary">
                        Consultar Informe
                    </asp:HyperLink>
                </div>
            </div>
        </div>

        <!-- Card 2 -->
        <div class="col-md-4">
            <div class="card text-center mb-4">
                <div class="card-body">
                    <h5 class="card-title">Distribución de turnos por franja horaria</h5>
                    <p class="card-text"> Analiza cuántos turnos se otorgaron en diferentes franjas horarías(por ejemplo, mañana, tarde) Para cada especialidad.
                    </p>
                    <asp:HyperLink ID="hlReporteHorario" runat="server" NavigateUrl="ReporteHorarios.aspx" CssClass="btn btn-primary">
                        Consultar Informe</asp:HyperLink>
                </div>
            </div>
        </div>

        <!-- Card 3 -->
        <div class="col-md-4">
            <div class="card text-center mb-4">
                <div class="card-body">
                    <h5 class="card-title">Pacientes la mayor cantidad de turnos asistidos por cada especialidad médica dentro de un rango de fechas específico.
                    </p>
                    <asp:HyperLink ID="hlTurnosEspecialidad" runat="server" NavigateUrl="ReportePacientesFrecuentes.aspx" CssClass="btn btn-primary">
                        Consultar Reporte
                    </asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
