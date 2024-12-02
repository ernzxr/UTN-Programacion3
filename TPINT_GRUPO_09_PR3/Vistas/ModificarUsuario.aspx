<%@ Page Title="Modificar Usuario" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="Vistas.ModificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- ID del Usuario -->
    <div>
        <asp:Label ID="lblIdUsuario" runat="server" Text="ID del Usuario:" AssociatedControlID="txtIdUsuario"></asp:Label>
        <asp:TextBox ID="txtIdUsuario" runat="server" CssClass="form-control mt-2" ValidationGroup="grupo1" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvId" runat="server" ControlToValidate="txtIdUsuario" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
    </div>

    <div>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar Usuario" CssClass="btn btn-primary" ValidationGroup="grupo1" OnClick="btnBuscar_Click" />
    </div>

    <div>
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
    </div>

    <div style="margin-top: 10px;"></div> <!-- Espacio adicional entre los formularios -->

    <!-- Modificación de datos -->
    <asp:Panel ID="pnlModificacion" runat="server" Visible="False">
        
        <div>
            <asp:Label ID="lblUsuario" runat="server" Text="Nuevo Usuario:" AssociatedControlID="txtUsuario"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control mt-2" ValidationGroup="grupo1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ForeColor="#CC0000"  Display="Dynamic" ValidationGroup="grupo2">(*) Complete el campo.</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="cvExisteUsuario" OnServerValidate="cvExisteUsuario_ServerValidate" runat="server" ForeColor="#CC0000" ValidationGroup="grupo2" ControlToValidate="txtUsuario"  Display="Dynamic" Text="(*) El usuario ingresado ya existe."></asp:CustomValidator>

        </div>

        <div>
            <asp:Label ID="lblPassword" runat="server" Text="Nueva Contraseña:" AssociatedControlID="txtPassword"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mt-2" TextMode="Password" ValidationGroup="grupo1" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="txtPassword" ForeColor="#CC0000"  Display="Dynamic" ValidationGroup="grupo2">(*) Complete el campo.</asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="revPass" runat="server" ValidationGroup="grupo2" ValidationExpression="^\d{3,8}$" ControlToValidate="txtPassword" ForeColor="#CC0000"  Display="Dynamic" ViewStateMode="Inherit" Text="(*) Solo se permiten números con entre 3 y 8 dígitos."></asp:RegularExpressionValidator>
        </div>

        <div>
            <asp:Label ID="lblEmail" runat="server" Text="Nuevo Email:" AssociatedControlID="txtEmail"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mt-2" ValidationGroup="grupo1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ForeColor="#CC0000" ValidationGroup="grupo2">(*) Complete el campo.</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" CssClass="mb-3" ForeColor="#CC0000" ValidationExpression="^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$"  Display="Dynamic" ValidationGroup="grupo2">(*)Debe ingresar un Email válido</asp:RegularExpressionValidator>
            <asp:CustomValidator ID="cvExisteEmail" OnServerValidate="cvExisteEmail_ServerValidate" runat="server" ForeColor="#CC0000" ValidationGroup="grupo2" ControlToValidate="txtEmail"  Display="Dynamic" Text="(*) El email ingresado ya existe."></asp:CustomValidator>

        </div>

        <div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" ValidationGroup="grupo2" OnClick="btnGuardar_Click" />
        </div>

        <div>
            <asp:Label ID="lblResultado" runat="server" ForeColor="Green"></asp:Label>
        </div>

    </asp:Panel>

</asp:Content>