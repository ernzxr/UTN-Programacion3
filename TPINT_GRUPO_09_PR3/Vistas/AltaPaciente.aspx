<%@ Page Title="Pacientes" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="Vistas.AltaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Alta Paciente</title>
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
                <h1>Agregar Paciente</h1>

                <div class="form-group">
                    <asp:Label ID="lblDNI" runat="server" Text="DNI" Style="align-self: flex-start"></asp:Label>
                    <asp:TextBox ID="txtDNI" class="form-control" runat="server" ValidationGroup="grupo1" MaxLength="8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1">(*) Ingrese solo números.</asp:RegularExpressionValidator>
                    <asp:Label ID="lblMensajeDNI" runat="server" CssClass="mb-2" ForeColor="#CC0000" Text=""></asp:Label>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" Style="align-self: flex-start"></asp:Label>
                    <asp:TextBox ID="txtNombre" class="form-control" runat="server" ValidationGroup="grupo1" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revNombre" CssClass="mb-3" runat="server" ControlToValidate="txtNombre" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="grupo1">(*) Ingrese solo letras.</asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido" Style="align-self: flex-start"></asp:Label>
                    <asp:TextBox ID="txtApellido" class="form-control" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revApellido" CssClass="mb-3" runat="server" ControlToValidate="txtApellido" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="grupo1">(*) Ingrese solo letras.</asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblSexo" runat="server" Text="Sexo" Style="align-self: flex-start"></asp:Label>
                    <asp:DropDownList ID="ddlSexo" class="form-select" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvSexo" CssClass="mb-5" runat="server" ControlToValidate="ddlSexo" ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento" Style="align-self: flex-start"></asp:Label>
                    <asp:TextBox ID="txtFechaNacimiento" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaNacimiento" CssClass="mb-5" runat="server" ControlToValidate="txtFechaNacimiento" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad" Style="align-self: flex-start"></asp:Label>
                    <asp:DropDownList ID="ddlNacionalidad" class="form-select" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" CssClass="mb-5" runat="server" ControlToValidate="ddlNacionalidad" ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia" Style="align-self: flex-start"></asp:Label>
                    <asp:DropDownList ID="ddlProvincia" class="form-select" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvProvincia" CssClass="mb-5" runat="server" ControlToValidate="ddlProvincia" ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblLocalidad" runat="server" Text="Localidad" Style="align-self: flex-start"></asp:Label>
                    <asp:DropDownList ID="ddlLocalidad" class="form-select" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvLocalidad" CssClass="mb-5" runat="server" ControlToValidate="ddlLocalidad" ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección" Style="align-self: flex-start"></asp:Label>
                    <asp:TextBox ID="txtDireccion" class="form-control" runat="server" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDireccion" CssClass="mb-5" runat="server" ControlToValidate="txtDireccion" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblCorreoElectronico" runat="server" Text="Correo Electrónico" Style="align-self: flex-start"></asp:Label>
                    <asp:TextBox ID="txtCorreoElectronico" class="form-control" runat="server" TextMode="Email" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCorreoElectronico" CssClass="mb-5" runat="server" ControlToValidate="txtCorreoElectronico" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono" Style="align-self: flex-start"></asp:Label>
                    <asp:TextBox ID="txtTelefono" class="form-control" runat="server" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1">(*) Ingrese solo números.</asp:RegularExpressionValidator>
                </div>
                <div class="form-group full-width">
                    <asp:Button ID="btnAgregar" class="btn btn-success" runat="server" Text="Agregar" ValidationGroup="grupo1" OnClick="btnAgregar_Click" />
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
