<%@ Page Title="Reporte e Informes" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReportesInformes.aspx.cs" Inherits="Vistas.ReportesInformes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
   
.row {
    display: flex;
    justify-content: space-between; 
    flex-wrap: wrap; 
}
     .col-md-4 {
         display: flex;
         justify-content: center;
         flex: 1 0 20%;
     }

.card {
    display: flex;
    flex-direction: column;
    height: 380px; 
    justify-content: space-between; 
    margin-bottom: 20px;
}

.card-body {
    display: flex;
    flex-direction: column;
    justify-content: space-between; 
    flex-grow: 1; 
    padding: 20px; 
}

.card-body .btn {
    margin-top: auto; 
    align-self: center; 
}

</style>

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
                        <h5 class="card-title"> Año y mes con mayor cantidad de turnos</h5>
                        <p class="card-text">
                           Muestra la cantidad de turnos según un año y mes seleccionados
                        </p>
                        <asp:HyperLink ID="hlMesMayorTurnos" runat="server" NavigateUrl="InformeTurnosxMes.aspx" CssClass="btn btn-primary">
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
                        <p class="card-text">
                            Analiza cuántos turnos se otorgaron en diferentes franjas horarias (por ejemplo, mañana, tarde) para cada especialidad.
                        </p>
                        <asp:HyperLink ID="hlReporteHorario" runat="server" NavigateUrl="ReporteHorarios.aspx" CssClass="btn btn-primary">
                            Consultar Reporte
                        </asp:HyperLink>
                    </div>
                </div>
            </div>

            <!-- Card 3 -->
            <div class="col-md-4">
                <div class="card text-center mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Pacientes más frecuentes por especialidad</h5>
                        <p class="card-text">
                            Los cinco pacientes con la mayor cantidad de turnos asistidos por cada especialidad médica dentro de un rango de fechas específico.
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