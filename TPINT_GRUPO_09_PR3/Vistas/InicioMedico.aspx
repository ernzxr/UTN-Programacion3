<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="InicioMedico.aspx.cs" Inherits="Vistas.InicioMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Inicio Usuario Médico </title>
    <style type="text/css">
    .auto-style1 {
    color: #005580;
    font-weight: bold;
    font-size: 2rem; /* Aumentar el tamaño del texto a un tamaño adecuado para un título */
    font-family: 'Georgia', 'Times New Roman', Times, serif;
}
 </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 50%; display: flex; flex-direction: column; align-items: center; justify-content: center;">
    <asp:Label ID="lblTitulo" runat="server" Text= "Panel de Control Médico" CssClass="auto-style1"></asp:Label>
    
        <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
      <!-- Card para Mis Turnos -->
      <div class="col">
        <div class="card">
          <img src="Images/Card-3.jpg" class="card-img-top" alt="Mis Turnos">
          <div class="card-body">
            <h5 class="card-title">Mis Turnos</h5>
            <p class="card-text">Consulta y administra los turnos que tienes programados. Asegúrate de estar al tanto de todas tus citas y evita conflictos de horarios.</p>
          </div>
        </div>
      </div>

      <!-- Card para Historial de Turnos -->
      <div class="col">
        <div class="card">
          <img src="Images/Card-7.jpg" class="card-img-top" alt="Historial de Turnos">
          <div class="card-body">
            <h5 class="card-title">Historial de Turnos</h5>
            <p class="card-text">Revisa el historial completo de tus turnos anteriores con los pacientes, incluyendo detalles de cada consulta para fácil referencia.</p>
          </div>
        </div>
      </div>

      <!-- Card para Mi Perfil -->
      <div class="col">
        <div class="card">
          <img src="Images/Card-6.jpg" class="card-img-top" alt="Mi Perfil">
          <div class="card-body">
            <h5 class="card-title">Mi Perfil</h5>
            <p class="card-text">Visualizala información de tu perfil profesional.</p>
          </div>
        </div>
      </div>
    </div>
    </div>

</asp:Content>
