<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="InicioAdmin.aspx.cs" Inherits="Vistas.InicioAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Inico Admin </title>
    <style type="text/css">
        .auto-style1 {
        color: #005580;
        font-weight: bold;
        font-size: 3rem; /* Aumentar el tamaño del texto a un tamaño adecuado para un título */
        font-family: 'Georgia', 'Times New Roman', Times, serif;
    }
     </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 50%; display: flex; flex-direction: column; align-items: center; justify-content: center;">
    <asp:Label ID="lblTitulo" runat="server" Text= "Panel de Administración" CssClass="auto-style1"></asp:Label>
            
        <div class="row row-cols-2 row-cols-md-2 g-4">
                  <!-- Card para Médicos -->
                  <div class="col">
                    <div class="card">
                      <img src="Images/Card-1.jpg" class="card-img-top" alt="Médico">
                      <div class="card-body">
                        <h5 class="card-title">Médicos</h5>
                        <p class="card-text">En esta sección puedes ver todos los usuarios tipo médico registrados en el sistema. Podrás gestionar sus datos, visualizar su especialidad y otros detalles importantes.</p>
                      </div>
                    </div>
                  </div>
  
                  <!-- Card para Pacientes -->
                  <div class="col">
                    <div class="card">
                      <img src="Images/Card-2.jpg" class="card-img-top" alt="Pacientes">
                      <div class="card-body">
                        <h5 class="card-title">Pacientes</h5>
                        <p class="card-text">Aquí podrás ver todos los pacientes registrados en el sistema, junto con su historial médico y citas. Administra su información de manera eficiente.</p>
                      </div>
                    </div>
                  </div>

                  <!-- Card para Turnos -->
                  <div class="col">
                    <div class="card">
                      <img src="Images/Card-3.jpg" class="card-img-top" alt="Turnos">
                      <div class="card-body">
                        <h5 class="card-title">Turnos</h5>
                        <p class="card-text">En esta sección puedes gestionar los turnos de los pacientes con los médicos disponibles, asegurándote de que todo esté organizado y sin conflictos.</p>
                      </div>
                    </div>
                  </div>

                  <!-- Card para Reportes e Informes -->
                  <div class="col">
                    <div class="card">
                      <img src="Images/Card-4.jpg" class="card-img-top" alt="Informes y Reportes">
                      <div class="card-body">
                        <h5 class="card-title">Reportes e Informes</h5>
                        <p class="card-text">Accede a todos los informes y reportes generados por el sistema. Puedes visualizar estadísticas, informes médicos y otros documentos importantes.</p>
                      </div>
                    </div>
                  </div>
    </div>
    </div>
</asp:Content>

