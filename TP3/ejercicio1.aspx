﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ejercicio1.aspx.cs" Inherits="TP3.ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ejercicio 1</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 160px;
        }

        .auto-style3 {
            width: 178px;
        }
        .auto-style4 {
            width: 160px;
            height: 26px;
            text-align: justify;
        }
        .auto-style5 {
            width: 178px;
            height: 26px;
            text-align: center;
        }
        .auto-style6 {
            height: 26px;
        }
        .auto-style7 {
            width: 160px;
            height: 23px;
        }
        .auto-style8 {
            width: 178px;
            height: 23px;
            text-align: center;
        }
        .auto-style9 {
            height: 23px;
        }
        .auto-style10 {
            width: 178px;
            text-align: center;
        }
        .auto-style11 {
            width: 160px;
            text-align: center;
        }
        .auto-style12 {
            width: 160px;
            text-align: justify;
        }
        .auto-style13 {
            width: 160px;
            height: 98px;
        }
        .auto-style14 {
            width: 178px;
            height: 98px;
        }
        .auto-style15 {
            height: 98px;
        }
        .auto-style16 {
            margin-left: 0px;
        }
        .auto-style17 {
            width: 160px;
            height: 30px;
        }
        .auto-style18 {
            width: 178px;
            text-align: center;
            height: 30px;
        }
        .auto-style19 {
            height: 30px;
        }
        .auto-style20 {
            width: 160px;
            text-align: justify;
            height: 29px;
        }
        .auto-style21 {
            width: 178px;
            text-align: center;
            height: 29px;
        }
        .auto-style22 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style7"></td>
                    <td class="auto-style8">
                        <asp:Label ID="lblHeaderLocalidad" runat="server" Text="Localidades"></asp:Label>
                    </td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="lblLocalidad" runat="server" Text="Nombre de la localidad:"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtLocalidad" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="txtLocalidad" ErrorMessage="Debe ingresar una localidad." ValidationGroup="gpLocalidad" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cusvLocalidad" runat="server" ErrorMessage="La localidad ingresada ya existe." OnServerValidate="cusvLocalidad_ServerValidate" ValidationGroup="gpLocalidad" ControlToValidate="txtLocalidad" ForeColor="Red">*</asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17"></td>
                    <td class="auto-style18">
                        <asp:Button ID="btnGuardarLocalidad" runat="server" Text="Guardar Localidad" ValidationGroup="gpLocalidad" />
                    </td>
                    <td class="auto-style19">
                        <asp:Label ID="lblLocalidadGuardada" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Label ID="lblHeaderUsuario" runat="server" Text="Usuarios"></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblUsuario" runat="server" Text="Nombre de usuario:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Debe ingresar un usuario." ValidationGroup="gpUsuario" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Debe ingresar una contraseña." ValidationGroup="gpUsuario" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="lblCheckPassword" runat="server" Text="Repetir contraseña:"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtCheckPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCheckPassword" runat="server" ControlToValidate="txtCheckPassword" ErrorMessage="Debe repetir la contraseña." ValidationGroup="gpUsuario" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtCheckPassword" ErrorMessage="Las contraseñas no coinciden." ValidationGroup="gpUsuario" ForeColor="Red">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="lblEmail" runat="server" Text="Correo electrónico:"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Debe ingresar un email." ValidationGroup="gpUsuario" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email invalido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="gpUsuario" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="lblCP" runat="server" Text="CP:"></asp:Label>
                    </td>
                    <td class="auto-style21">
                        <asp:TextBox ID="txtCP" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style22">
                        <asp:RequiredFieldValidator ID="rfvCP" runat="server" ControlToValidate="txtCP" ErrorMessage="Debe ingresar un código postal." ValidationGroup="gpUsuario" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCP" runat="server" ControlToValidate="txtCP" ForeColor="Red" ValidationExpression="^\d{4}$" ValidationGroup="gpUsuario" ErrorMessage="El CP deben ser 4 números.">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblLocalidades" runat="server" Text="Localidades"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ddlLocalidades" runat="server" AutoPostBack="True">
                            <asp:ListItem>-- Seleccione Localidad --</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style6">
                        <asp:RequiredFieldValidator ID="rfvLocalidades" runat="server" ControlToValidate="ddlLocalidades" ErrorMessage="Debe seleccionar una localidad." InitialValue="-- Seleccione Localidad --" ValidationGroup="gpUsuario" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Button ID="btnGuardarUsuario" runat="server" Text="Guardar Usuario" ValidationGroup="gpUsuario" CssClass="auto-style16" Height="28px" OnClick="btnGuardarUsuario_Click" Width="150px" />
                    </td>
                    <td>
                        <asp:Label ID="lblUsuarioGuardado" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Button ID="btnInicio" runat="server" Text="Ir a inicio .aspx" OnClick="btnInicio_Click" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>
                        <asp:ValidationSummary ID="vsLocalidad" runat="server" HeaderText="Localidad:" ValidationGroup="gpLocalidad" />
                        <asp:ValidationSummary ID="vsUsuario" runat="server" HeaderText="Usuario:" ValidationGroup="gpUsuario" Height="94px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13"></td>
                    <td class="auto-style14"></td>
                    <td class="auto-style15">
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
