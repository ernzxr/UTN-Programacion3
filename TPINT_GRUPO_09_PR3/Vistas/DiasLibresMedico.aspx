<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DiasLibresMedico.aspx.cs" Inherits="Vistas.DiasLibresMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
    <asp:DropDownList ID="ddlTipoAusencia" runat="server"></asp:DropDownList>
    <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date"></asp:TextBox>
    <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date"></asp:TextBox>
</asp:Content>
