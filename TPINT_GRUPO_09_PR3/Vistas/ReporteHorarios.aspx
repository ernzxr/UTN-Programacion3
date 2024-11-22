<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReporteHorarios.aspx.cs" Inherits="Vistas.ReporteHorarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:45%; height:auto; padding:20px; border: 2px solid black; border-radius: 15px; background-color: rgba(173, 216, 230, 0.5); box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);">
        <div style="font-size: 24px; font-weight: bold; text-align: center; margin-bottom: 20px;">Distribución de Turnos por Franja Horaria</div>
        <div style="display: flex; justify-content: space-around;">
            <div style="width: 300px; height: 300px; display: flex; flex-direction: column; align-items: center; justify-content: center;">
                <div style="display: flex; flex-direction: column; align-items: center; margin-bottom: 10px;">
                    <asp:Label Text="Seleccione Especialidad" runat="server" Style="margin-bottom: 15px;" />
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-select">
                        <asp:ListItem Text="text1" />
                        <asp:ListItem Text="text2" />
                    </asp:DropDownList>
                </div>
                <div style="display: flex; flex-direction: column; align-items: center; margin-bottom: 10px;">
                    <asp:Label Text="Seleccione Horario" runat="server" Style="margin-bottom: 15px;" />
                    <asp:DropDownList ID="ddlFranjaHoraria" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Mañana" />
                        <asp:ListItem Text="Tarde" />
                        <asp:ListItem Text="Noche" />
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnAceptar" Text="Aceptar" runat="server" class="btn btn-primary" Style="margin-top: 15px;" />
            </div>
            <div style="width: 300px; height: 300px; display: flex; flex-direction: column; align-items: center; justify-content: center;">
                <asp:Label ID="lblEspecialista" Text="Especialista" runat="server" Style="margin-bottom: 15px;" />
                <asp:Label ID="lblFranja_Horaria" Text="Franja Horaria" runat="server" Style="margin-bottom: 15px;" />
                <asp:Label ID="lblCant_Turnos" Text="Cantidad de Turnos (Porcentaje)" runat="server" Style="margin-bottom: 15px;" />
            </div>
        </div>
    </div>
</asp:Content>
