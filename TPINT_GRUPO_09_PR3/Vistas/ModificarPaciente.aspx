<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs" Inherits="Vistas.ModificarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #006699;
            font-weight: bold;
            font-size: x-large;
            font-family: Arial, Helvetica, sans-serif;
        }

        .btn-azul {
            background-color: #006699;
            color: white;
            border: 1px solid #006699;
            border-radius: 0.375rem;
            padding: 0.375rem 0.75rem;
            font-size: 1rem;
            font-weight: 400;
            text-align: center;
            cursor: pointer;
            transition: background-color 0.15s ease-in-out, border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; display: flex; flex-direction: column; align-items: center; position: relative;">
    <div style="width: 28%; display: flex; flex-direction: column; align-items: center;">
        <asp:Label ID="lblTitulo" runat="server" Text="Modificar Paciente" CssClass="auto-style1 mb-4"></asp:Label>

        <asp:Label ID="lblDNI" runat="server" Text="Ingrese el DNI del Paciente" CssClass="mb-2"></asp:Label>
        <asp:TextBox ID="txtDNI" class="form-control" runat="server" ValidationGroup="grupo1" MaxLength="8"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ForeColor="#CC0000" ValidationGroup="grupo1" CssClass="auto-style2" Style="font-size: small">(*) Complete el campo.</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1" CssClass="auto-style2" Style="font-size: small">(*) Ingrese solo números.</asp:RegularExpressionValidator>
        <asp:Label ID="lblNacionalidad" runat="server" Text="Seleccione la Nacionalidad" CssClass="mb-2"></asp:Label>
        <asp:DropDownList ID="ddlNacionalidad" class="form-select" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvNacionalidad" CssClass="auto-style2" runat="server" ControlToValidate="ddlNacionalidad" ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>
        <div>
            <asp:Button ID="btnFiltrar" CssClass="btn-azul" runat="server" Text="Filtrar" Width="150px" ValidationGroup="grupo1" OnClick="btnFiltrar_Click" />
            <asp:Button ID="btnMostrarTodo" CssClass="btn-azul" runat="server" Text="Mostrar Todo" Width="150px" OnClick="btnMostrarTodo_Click" />
        </div>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>

    <div style="width: 100%; margin-top: 20px;">
        <asp:GridView runat="server" ID="gvPacientes" CssClass="table table-hover"></asp:GridView>
    </div>
</div>
</asp:Content>
