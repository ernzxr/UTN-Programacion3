<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Vistas.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="carouselExampleCaptions" class="carousel slide" style="margin:100px 0 100px 0;">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="Images/imagen1.jpg" height="600px" class="d-block w-100" alt="Imagen 1">
                <div class="carousel-caption d-none d-md-block">

                    <h1 class="font-weight-bold text-white display-4">Bienvenidos a Clínica UTN</h1>
                    <p class="font-weight-bold text-white">
                        En Clínica UTN nos dedicamos a cuidar de tu salud y bienestar en un ambiente de profesionalismo y calidez. 
                                  Nuestro equipo de médicos y especialistas altamente capacitados trabaja con el compromiso de ofrecerte una atención de calidad, personalizada y basada en las mejores prácticas de la medicina moderna.
                    </p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="Images/imagen2.jpg" height="600px" class="d-block w-100" alt="Imagen 2">
                <div class="carousel-caption d-none d-md-block">
                    <h1 class="font-weight-bold text-white display-4">Nuestro Compromiso</h1>
                    <p class="font-weight-bold text-white">
                        En Clínica UTN, cada paciente es único y merece una atención especializada. 
                                Nos esforzamos en construir relaciones de confianza y ofrecer un entorno seguro y confiable, 
                                donde la prioridad siempre es tu bienestar.
                    </p>
                </div>
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>

    
</asp:Content>
