<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="InformeTurnosxMes.aspx.cs" Inherits="Vistas.InformeTurnosxMes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Cantidad de turnos segun un mes y año ingresados. </title>
 <style>
     .auto-style1 {
         color: #006699;
         font-weight: bold;
         font-size: x-large;
         font-family: Arial, Helvetica, sans-serif;
     }
 </style>
</asp:Content>

        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div style="width: 100%; display: flex; justify-content: center; align-items: center; margin-bottom: 30px;">
                <asp:Label ID="lblTitulo" runat="server" Text="Cantidad de turnos segun un mes y año ingresados" CssClass="auto-style1 mb-4" ForeColor="#000099"></asp:Label>
            </div>

            <div style="width: 80%; display: flex; justify-content: center; gap: 40px; position: relative;">


          <div style="flex: 1;">
           <asp:Label ID="lblAnio" runat="server" Text="Seleccione un año" CssClass="mb-2"></asp:Label>
           <asp:DropDownList ID="ddlAnio" class="form-select" runat="server" Style="width: 100%;"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvAnio" CssClass="auto-style2" runat="server" ControlToValidate="ddlAnio"  ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0" Style="font-size: small; display: block;">(*) Seleccione una opción.</asp:RequiredFieldValidator>
                                              
         </div>

        <div style="flex: 1;">
          <asp:Label ID="lblMes" runat="server" Text="Seleccione un mes" CssClass="mb-2"></asp:Label>
          <asp:DropDownList ID="ddlMes" class="form-select" runat="server" Style="width: 100%;"></asp:DropDownList>
          <asp:RequiredFieldValidator ID="rfvMes" CssClass="auto-style2" runat="server" ControlToValidate="ddlMes"  ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0" Style="font-size: small; display: block;">(*) Seleccione una opción.</asp:RequiredFieldValidator>

    </div>
         </div>
         <div style="display: flex; justify-content: center; margin-top: 15px;">
         <asp:Button ID="btnBuscar" class="btn btn-dark" runat="server" Text="Buscar" Width="150px" ValidationGroup="grupo1" OnClick="btnBuscar_Click" />
   </div>
         <div style="flex: 1; display: flex; flex-direction: column; justify-content: center; align-items: stretch;">
         <asp:Label ID="lblInformeTurnosxMes" runat="server" Text="" Style="margin-bottom: 15px; text-align: center;"></asp:Label>
         <asp:GridView ID="gvTurnosxMes" CssClass="table table-hover" runat="server" Style="width: 100%;"></asp:GridView>
   </div>

    </asp:Content>



  
