<%@ Page Title="Alta Médicos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AltaMedicos.aspx.cs" Inherits="Vistas.AltaMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
         body {
     font-family: Arial, Helvetica, sans-serif;
 }

 .form-container {
     display: grid;
     grid-template-columns: 1fr 1fr;
     gap: 20px;
     width: 90%;
     margin: 0 auto;
     padding: 20px;
     background-color: #f9f9f9;
     border: 1px solid #ddd;
     border-radius: 10px;
     box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
 }

 .form-container h1 {
     grid-column: span 2;
     text-align: center;
     color: #006699;
     font-size: 1.8rem;
     font-weight: bold;
     margin-bottom: 20px;
 }

 .form-group {
     display: flex;
     flex-direction: column;
 }

 .form-group label {
     margin-bottom: 5px;
     font-weight: bold;
 }

 .form-group input,
 .form-group select,
 .form-group button {
     padding: 10px;
     font-size: 1rem;
     border: 1px solid #ccc;
     border-radius: 5px;
 }

 .form-group button {
     background-color: #28a745;
     color: white;
     border: none;
     cursor: pointer;
     transition: background-color 0.3s ease;
 }

 .form-group button:hover {
     background-color: #218838;
 }

 .form-group span {
     color: #cc0000;
     font-size: 0.9rem;
 }

 .btn-container {
     grid-column: span 2;
     display: flex;
     justify-content: center;
 }

 .form-container .full-width {
     grid-column: span 2;
 }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server" class="form-container">
        <ContentTemplate>
            <h1>Agregar Medico</h1>

            <div class="form-group">
                <h3>Datos de Usuario</h3>

                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" Style="align-self: flex-start"></asp:Label>
                <asp:TextBox ID="txtUsuario" class="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rev" runat="server" ControlToValidate="txtUsuario" ValidationGroup="gpAgregar" Text="*El usuario solo debe contener letras minúsculas" ValidationExpression="^[a-z]+$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ForeColor="#CC0000" ValidationGroup="gpAgregar">(*) Complete el campo.</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvExisteUsuario" OnServerValidate="cvExisteUsuario_ServerValidate" runat="server" ForeColor="#CC0000" ValidationGroup="gpAgregar" ControlToValidate="txtUsuario" Text="(*) El usuario ingresado ya existe"></asp:CustomValidator>
               

                <asp:Label ID="lblPassword" runat="server" Text="Contraseña" Style="align-self: flex-start"></asp:Label>
                <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password"  ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ForeColor="#CC0000" ValidationGroup="gpAgregar">(*) Complete el campo.</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" ForeColor="Red" ValidationExpression="^\d{3,8}$" ValidationGroup="gpAgregar" Text="(*) Solo se permiten números con entre 3 y 8 dígitos."></asp:RegularExpressionValidator>

                <asp:Label ID="lblRepetirPassword" runat="server" Text="Repetir Contraseña" Style="align-self: flex-start"></asp:Label>
                <asp:TextBox ID="txtPasswordRepetida" class="form-control" runat="server" TextMode="Password" ValidationExpression="^\d{3,8}$" Text="(*) Solo se permiten números con entre 3 y 8 dígitos." ValidationGroup="gpAgregar"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRepetirPassword" runat="server" ControlToValidate="txtPasswordRepetida" ForeColor="#CC0000" ValidationGroup="gpAgregar">(*) Complete el campo.</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvPassword" runat="server" ForeColor="#CC0000" ValidationGroup="gpAgregar" ControlToValidate="txtPasswordRepetida" ControlToCompare="txtPassword" >(*) Las claves no coinciden.></asp:CompareValidator>
            </div>

            <div class="form-group">
                <h3>Datos Médicos</h3>

                <asp:Label ID="lblLegajo" runat="server" Text="Legajo" Style="align-self: flex-start"></asp:Label>
                <asp:TextBox ID="txtLegajo" class="form-control" runat="server" ValidationGroup="gpAgregar" MaxLength="5"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ValidationGroup="gpAgregar" ForeColor="#CC0000">(*) Complete el campo.</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="gpAgregar">(*) Ingrese solo números.</asp:RegularExpressionValidator>
                <asp:CustomValidator ID="cvExisteLegajo" OnServerValidate="cvExisteLegajo_ServerValidate" runat="server" ForeColor="#CC0000" ValidationGroup="gpAgregar" ControlToValidate="txtUsuario" >(*) El legajo ingresado ya existe.></asp:CustomValidator>

                <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad" Style="align-self: flex-start"></asp:Label>
                <asp:DropDownList ID="ddlEspecialidad" class="form-select" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEspecialidad" CssClass="mb-5" runat="server" ControlToValidate="ddlEspecialidad" ForeColor="#CC0000" ValidationGroup="gpAgregar" InitialValue="0" >(*) Seleccione una opción.</asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <h3>Datos Personales</h3>

                <asp:Label ID="lblDNI" runat="server" Text="DNI" Style="align-self: flex-start"></asp:Label>
                <asp:TextBox ID="txtDNI" class="form-control" runat="server"  MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ForeColor="#CC0000" ValidationGroup="gpAgregar">(*) Complete el campo.</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="gpAgregar">(*) Ingrese solo números.</asp:RegularExpressionValidator>
                <asp:Label ID="lblMensajeDNI" runat="server" CssClass="mb-2" ForeColor="#CC0000" Text=""></asp:Label>

                <asp:Label ID="lblNombre" runat="server" Text="Nombre" Style="align-self: flex-start"></asp:Label>
                <asp:TextBox ID="txtNombre" class="form-control" runat="server" ValidationGroup="gpAgregar"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ForeColor="#CC0000" ValidationGroup="gpAgregar">(*) Complete el campo.</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revNombre" CssClass="mb-3" runat="server" ControlToValidate="txtNombre" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="gpAgregar">(*) Ingrese solo letras.</asp:RegularExpressionValidator>

                <asp:Label ID="lblApellido" runat="server" Text="Apellido" Style="align-self: flex-start"></asp:Label>
                <asp:TextBox ID="txtApellido" class="form-control" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ValidationGroup="gpAgregar" ForeColor="#CC0000" >(*) Complete el campo.</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revApellido" CssClass="mb-3" runat="server" ControlToValidate="txtApellido" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="gpAgregar">(*) Ingrese solo letras.</asp:RegularExpressionValidator>


                <asp:Label ID="lblSexo" runat="server" Text="Sexo" Style="align-self: flex-start"></asp:Label>
                <asp:RadioButtonList ID="rblGenero" runat="server" RepeatDirection="Horizontal" CssClass="horizontal-radio label" TabIndex="2">
                    <asp:ListItem Text="Masculino" Value="1" />
                    <asp:ListItem Text="Femenino" Value="2" />
                    <asp:ListItem Text="Otro" Value="3" />
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="rfvGenero" runat="server" ControlToValidate="rblGenero" ValidationGroup="gpAgregar" ForeColor="#CC0000">(*) Seleccione una opción.</asp:RequiredFieldValidator>

                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento" Style="align-self: flex-start"></asp:Label>
                <asp:TextBox ID="txtFechaNacimiento" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFechaNacimiento" CssClass="mb-5" runat="server" ControlToValidate="txtFechaNacimiento" ForeColor="#CC0000" ValidationGroup="gpAgregar">(*) Complete el campo.</asp:RequiredFieldValidator>

                <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad" Style="align-self: flex-start"></asp:Label>
                <asp:DropDownList ID="ddlNacionalidad" class="form-select" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvNacionalidad" CssClass="mb-5" runat="server" ControlToValidate="ddlNacionalidad" ForeColor="#CC0000" ValidationGroup="gpAgregar" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <h3>Datos de Contacto</h3>


                <asp:Label ID="lblProvincia" runat="server" Text="Provincia" Style="align-self: flex-start"></asp:Label>
                <asp:DropDownList ID="ddlProvincia" class="form-select" runat="server" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvProvincia" CssClass="mb-5" runat="server" ControlToValidate="ddlProvincia" ForeColor="#CC0000" ValidationGroup="gpAgregar" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>

                <asp:Label ID="lblLocalidad" runat="server" Text="Localidad" Style="align-self: flex-start"></asp:Label>
                <asp:DropDownList ID="ddlLocalidad" class="form-select" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvLocalidad" CssClass="mb-5" runat="server" ControlToValidate="ddlLocalidad" ForeColor="#CC0000" ValidationGroup="gpAgregar" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>


                <asp:Label ID="lblDireccion" runat="server" Text="Dirección" Style="align-self: flex-start"></asp:Label>
                <asp:TextBox ID="txtDireccion" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDireccion" CssClass="mb-5" runat="server" ControlToValidate="txtDireccion" ForeColor="#CC0000" ValidationGroup="gpAgregar">(*) Complete el campo.</asp:RequiredFieldValidator>

                <asp:Label ID="lblCorreoElectronico" runat="server" Text="Correo Electrónico" Style="align-self: flex-start"></asp:Label>
                <asp:TextBox ID="txtCorreoElectronico" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCorreoElectronico" CssClass="mb-5" runat="server" ControlToValidate="txtCorreoElectronico" ForeColor="#CC0000" ValidationGroup="gpAgregar">(*) Complete el campo.</asp:RequiredFieldValidator>

                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono" Style="align-self: flex-start"></asp:Label>
                <asp:TextBox ID="txtTelefono" class="form-control" runat="server" MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ForeColor="#CC0000" ValidationGroup="gpAgregar" Display="Dynamic">(*) Complete el campo.</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="gpAgregar">(*) Ingrese solo números.</asp:RegularExpressionValidator>
            </div>

            <div class="form-group full-width">
                <asp:Button ID="btnAgregar" class="btn btn-success" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CausesValidation="true" ValidationGroup="gpAgregar" />
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
