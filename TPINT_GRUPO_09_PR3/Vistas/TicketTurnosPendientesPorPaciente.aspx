  <%@ Page Title="Ticket de Turnos Programados" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TicketTurnosPendientesPorPaciente.aspx.cs" Inherits="Vistas.TicketTurnosPendientesPorPaciente" %>

  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <style type="text/css">
          .validator-width {
              display: inline-block;
              width: 200px;
              min-height: 1.2em;
              vertical-align: top;
          }

          .form-group {
              margin-bottom: 20px;
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
            
           .ticket-container {
            border: none;  /* Elimina el borde alrededor del ticket */
            }
            h3 {
               font-weight: normal;  /* Quitar negrita del h3 */
               font-family: 'Arial', sans-serif;  /* Tipografía más suave y moderna */
               font-size: 1rem;  /* Reducir tamaño del título */
                }

            .subtle-text {
               font-weight: normal;  /* Eliminar negrita del texto */
               font-family: 'Verdana', sans-serif;  /* Tipografía más ligera */
               font-size: 0.9rem;  /* Reducir tamaño del subtítulo */
               color: #555;  /* Color de texto más suave (gris oscuro) */
      
            </style>
             
  </asp:Content>
          
              
             

  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <div class="px-5 py-3 me-5 ticket-container">
          <h3 class="text-center">Ticket de PROGRAMACION de TURNOS</h3>

             <!-- Título y nombre del paciente -->
           <div class="text-center">
              <h4 id="lblNomClinica" class="subtle-text">Centro: Clinica UTN - Córdoba 1100, Buenos Aires, Argentina</h4>
            </div>
          
          <P></P>
           
        <!-- Ticket de PROGRAMACION de TURNOS por Paciente -->
          <div class="px-5 py-3 me-5 border rounded">
           

              <!-- Filtro por DNI y Nacionalidad del Paciente -->
       
              <div class="form-group">
                  <asp:Label ID="lblDniPaciente" runat="server" Text="DNI del Paciente" CssClass="form-label"></asp:Label>
                  <asp:TextBox ID="txtDniPaciente" runat="server" CssClass="form-control mt-2" MaxLength="8"></asp:TextBox>
                  <div style="display: flex; gap: 10px; align-items: center;">
                      <asp:RequiredFieldValidator ID="rfvDniPaciente" runat="server" ControlToValidate="txtDniPaciente" CssClass="text-danger" Text="* Requerido" Display="Dynamic" ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="revDniPaciente" runat="server" ControlToValidate="txtDniPaciente" CssClass="text-danger" ValidationExpression="^\d{8}$" Text="* DNI inválido" Display="Dynamic" ValidationGroup="Grupo1"></asp:RegularExpressionValidator>
                  </div>
              </div>

              <div style="margin-bottom: 15px;">
                  <asp:Label ID="lblNacionalidad" runat="server" Text="Seleccione una Nacionalidad" CssClass="mb-2"></asp:Label>
                  <asp:DropDownList ID="ddlNacionalidad" class="form-select" runat="server" Style="width: 100%;"></asp:DropDownList>
                  <asp:RequiredFieldValidator ID="rfvNacionalidad" CssClass="auto-style2" runat="server" ControlToValidate="ddlNacionalidad"
                      ForeColor="#CC0000" ValidationGroup="Grupo1" InitialValue="0" Style="font-size: small; display: block;">(*) Seleccione una opción.</asp:RequiredFieldValidator>
              </div>
          </div>
      
          <asp:Button ID="btnFiltrarPaciente" runat="server" Text="Turnos Programados" CssClass="btn btn-primary mt-2" ValidationGroup="Grupo1" OnClick="btnFiltrarPaciente_Click" />
          <asp:Label ID="lblError_Filtrar" runat="server" Text=""></asp:Label>

          <!-- Botón Imprimir Ticket de los Turnos -->
          <div class="form-group text-center mt-4">
          <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="btn btn-secondary" OnClientClick="ocultarBusquedaParaImpresion();" OnClick="btnImprimir_Click" />
          </div>
      </div>

      <asp:GridView
          ID="gvTicketTurnos"
          runat="server"
          CssClass="table table-bordered table-striped table-hover"
          AutoGenerateColumns="False"
          AllowPaging="True"
          AllowSorting="True"
          OnPageIndexChanging="gvTicketTurno_PageIndexChanging"
          PageSize="5"
          PagerSettings-Mode="NumericFirstLast"
          PagerSettings-FirstPageText="Inicio"
          PagerSettings-LastPageText="Fin"
          PagerStyle-CssClass="gridPager"
          PagerStyle-HorizontalAlign="Center"
          PagerStyle-VerticalAlign="Middle"
          PagerSettings-PageButtonCount="3">

          <Columns>

              <asp:BoundField DataField="FECHA" DataFormatString="{0:dd-MM-yyyy}" HeaderText="FECHA" />

              <asp:TemplateField HeaderText="TURNO">
                  <ItemTemplate>
              <asp:Label ID="lblHora" runat="server" Text='<%# ((TimeSpan)Eval("TURNO")).ToString(@"hh\:mm") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
                  

              <asp:TemplateField HeaderText="ESPECIALIDAD">
                  <ItemTemplate>
                      <asp:Label ID="lblEspecialidad" runat="server" Text='<%# Eval("ESPECIALIDAD") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>

              <asp:TemplateField HeaderText="PROFESIONAL">
                  <ItemTemplate>
                      <asp:Label ID="lblNombreyApellido" runat="server" Text='<%# Eval("PROFESIONAL") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
      </asp:GridView>


   </asp:Content>

