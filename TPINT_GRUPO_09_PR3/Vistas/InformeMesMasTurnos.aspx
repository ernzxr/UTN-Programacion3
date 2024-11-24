<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="InformeMesMasTurnos.aspx.cs" Inherits="Vistas.InformeMesMasTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblAnios" runat="server" Text="Seleccione un año" CssClass="form-label mb-3"></asp:Label>
    <asp:DropDownList ID="ddlAnios" runat="server" CssClass="form-control mt-3" ValidationGroup="gpAgregar"  AutoPostBack="true">
        Style="width:auto; min-width: 150px; max-width: 100%; display: inline-block;">
    </asp:DropDownList>
    </asp:Content>
