<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListarTurnos.aspx.cs" Inherits="Vistas.ListarTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Listado de Turnos</h1>
    <asp:GridView ID="gvTurnos" runat="server" CssClass="table table-bordered table-striped table-hover">
    </asp:GridView>
</asp:Content>
