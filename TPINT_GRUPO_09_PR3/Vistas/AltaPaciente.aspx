<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="Vistas.AltaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Alta Paciente</title>
    <style type="text/css">
        .auto-style1 {
            color: #006699;
            font-weight: bold;
            font-size: x-large;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style2 {
            --bs-form-check-bg: var(--bs-body-bg);
            flex-shrink: 0;
            margin-top: .25em;
            vertical-align: top;
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            background-color: var(--bs-form-check-bg);
            background-image: url('var(--bs-form-check-bg-image)');
            background-repeat: no-repeat;
            background-position: center;
            background-size: contain;
            -webkit-print-color-adjust: exact;
            print-color-adjust: exact;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row justify-content-md-center mb-4">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblTitulo" runat="server" Text="Agregar Paciente" CssClass="auto-style1"></asp:Label>
        </div>
        <div class="col">
        </div>
    </div>


    <%--DNI--%>
    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblDNI" runat="server" Text="DNI" CssClass="float-start"></asp:Label>
            <asp:TextBox ID="txtDNI" class="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
        </div>
        <div class="col">
            <strong>
                <asp:Label ID="lblMensajeDNI" runat="server" ForeColor="#CC0000"></asp:Label>
            </strong>
        </div>
    </div>

    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center mb-2">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1">(*) Ingrese solo números.</asp:RegularExpressionValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>




    <%--Nombre--%>
    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="float-start"></asp:Label>
            <asp:TextBox ID="txtNombre" class="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center mb-2">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="grupo1">(*) Ingrese solo letras.</asp:RegularExpressionValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>


    <%--Apellido--%>

    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblApellido" runat="server" Text="Apellido" CssClass="float-start"></asp:Label>
            <asp:TextBox ID="txtApellido" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center mb-2">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="grupo1">(*) Ingrese solo letras.</asp:RegularExpressionValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>


    <%--Sexo--%>
    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblSexo" runat="server" Text="Sexo" CssClass="float-start"></asp:Label>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center mb-5">
        <div class="col">
        </div>
        <div class="col-6">
            <div class="form-check form-check-inline">
                <asp:RadioButton ID="rbMasculino" runat="server" GroupName="Sexo" Text="Masculino" CssClass="auto-style2" Checked="true" Width="150px" />
            </div>
            <div class="form-check form-check-inline">
                <asp:RadioButton ID="rbFemenino" runat="server" GroupName="Sexo" Text="Femenino" CssClass="auto-style2" Width="150px" />
            </div>
        </div>
        <div class="col">
        </div>
    </div>


    <%--Fecha de Nacimiento--%>

    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento" CssClass="float-start"></asp:Label>
            <asp:TextBox ID="txtFechaNacimiento" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center mb-5">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>





    <%--Nacionalidad--%>
    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad" CssClass="float-start"></asp:Label>
            <asp:TextBox ID="txtNacionalidad" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center mb-2">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RegularExpressionValidator ID="revNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="grupo1">(*) Ingrese solo letras.</asp:RegularExpressionValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>



    <%--  <div class="col-md-4">
  <label for="inputState" class="form-label">State</label>
  <select id="inputState" class="form-select">
    <option selected>Choose...</option>
    <option>...</option>
  </select>
</div>--%>


    <%--Provincia--%>

    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblProvincia" runat="server" Text="Provincia" CssClass="float-start"></asp:Label>
            <asp:DropDownList ID="ddlProvincia" class="form-select" runat="server"></asp:DropDownList>
        </div>
        <div class="col">
        </div>
    </div>


    <div class="row justify-content-md-center mb-5">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>


    <%--Localidad--%>
    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblLocalidad" runat="server" Text="Localidad" CssClass="float-start"></asp:Label>
            <asp:DropDownList ID="ddlLocalidad" class="form-select" runat="server"></asp:DropDownList>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center mb-5">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>


    <%--Direccion--%>
    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblDireccion" runat="server" Text="Dirección" CssClass="float-start"></asp:Label>
            <asp:TextBox ID="txtDireccion" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col">
        </div>
    </div>


    <div class="row justify-content-md-center mb-5">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>



    <%--Correo Electronico--%>
    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblCorreoElectronico" runat="server" Text="Correo Electrónico" CssClass="float-start"></asp:Label>
            <asp:TextBox ID="txtCorreoElectronico" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center mb-5">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RequiredFieldValidator ID="rfvCorreoElectronico" runat="server" ControlToValidate="txtCorreoElectronico" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>




    <%--Telefono--%>

    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono" CssClass="float-start"></asp:Label>
            <asp:TextBox ID="txtTelefono" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>

    <div class="row justify-content-md-center mb-2">
        <div class="col">
        </div>
        <div class="col-6">
            <strong>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1">(*) Ingrese solo números.</asp:RegularExpressionValidator>
            </strong>
        </div>
        <div class="col">
        </div>
    </div>




    <div class="row mb-4">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:Button runat="server" Text="Agregar" ID="btnAgregar" class="btn btn-success" ValidationGroup="grupo1" />
        </div>
        <div class="col">
        </div>
    </div>

</asp:Content>
