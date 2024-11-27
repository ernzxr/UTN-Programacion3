<%@ Page Title="Mi perfil" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Vistas.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; align-items: flex-start; justify-content: space-between; padding: 20px;">
        <div class="container mt-5">
        <h2>Perfil del Médico</h2>
            <div class="text-center">
            <!-- Imagen centrada -->
            <img src="images/Card-6.jpg" alt="Imagen de perfil" class="mx-auto d-block" style="max-width: 200px; height: auto;" />
        </div>
            <asp:HyperLink ID="hlPass" runat="server" NavigateUrl="~/CambiarContraseña.aspx">Cambiar Clave</asp:HyperLink>
            <table class="table table-bordered">
                <!-- Título: Datos Médico -->
                <tr>
                    <th colspan="2" class="text-center">Datos Médico</th>
                </tr>
                <tr>
                    <td><strong>Legajo:</strong></td>
                    <td><asp:TextBox ID="txtLegajo" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Nombre:</strong></td>
                    <td><asp:TextBox ID="txtNombre" runat="server" ReadOnly="true" CssClass ="form-control"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td><strong>Apellido:</strong></td>
                     <td><asp:TextBox ID="txtApellido" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                 </tr>
                <tr>
                    <td><strong>Especialidad</strong></td>
                    <td><asp:TextBox ID="txtEspecialidad" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                 </tr>
                <tr>
                    <td><strong>Usuario:</strong></td>
                    <td><asp:TextBox ID="txtUsuario" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                </tr>

                <!-- Título: Datos Personales -->
                <tr>
                    <th colspan="2" class="text-center">Datos Personales</th>
                </tr>
                <tr>
                     <td><strong>Dni</strong></td>
                     <td><asp:TextBox ID="txtDni" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
             </tr>
                <tr>
                    <td><strong>Fecha de Nacimiento:</strong></td>
                    <td><asp:TextBox ID="txtNacimiento" runat="server" ReadOnly="true" CssClass="form-control" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Dirección:</strong></td>
                    <td><asp:TextBox ID="txtDireccion" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Localidad:</strong></td>
                    <td><asp:TextBox ID="txtLocalidad" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td><strong>Provincia:</strong></td>
                    <td><asp:TextBox ID="txtProvincia" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                </tr>

                <tr>
                    <td><strong>Nacionalidad:</strong></td>
                    <td><asp:TextBox ID="txtNacionalidad" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                </tr>

                <!-- Título: Contacto -->
                <tr>
                    <th colspan="2" class="text-center">Contacto</th>
                </tr>
                <tr>
                    <td><strong>Email:</strong></td>
                    <td><asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" CssClass="form-control" TextMode="Email"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Teléfono:</strong></td>
                    <td><asp:TextBox ID="txtTelefono" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                </tr>
            </table>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
           

           
    </div>

</div>
</asp:Content>
