<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ModificarHorariosMedicos.aspx.cs" Inherits="Vistas.ModificarHorariosMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblLegajo" runat="server" Text="Ingrese legajo:"></asp:Label>
    <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />

    <div class="text-center">
        <asp:GridView ID="gvHorariosMedicos" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowEditing="gvHorariosMedicos_RowEditing" OnRowCancelingEdit="gvHorariosMedicos_RowCancelingEdit" OnRowUpdating="gvHorariosMedicos_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="Legajo">
                    <ItemTemplate>
                        <asp:Label ID="it_lblLegajo" runat="server" Text='<%# Eval("Legajo") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="eit_lblLegajo" runat="server" Text='<%# Eval("Legajo") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Día">
                    <ItemTemplate>
                        <asp:Label ID="it_lblDia" runat="server" Text='<%# Eval("Descripcion_DS") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="eit_lblDia" runat="server" Text='<%# Eval("Descripcion_DS") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hora Entrada">
                    <ItemTemplate>
                        <asp:Label ID="it_lblHoraInicio" runat="server" Text='<%# Eval("Hora_Inicio_HM") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="eit_txtHoraInicio" runat="server" Text='<%# Eval("Hora_Inicio_HM") %>' TextMode="Time"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hora Salida">
                    <ItemTemplate>
                        <asp:Label ID="it_lblHoraFin" runat="server" Text='<%# Eval("Hora_Fin_HM") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="eit_txtHoraFin" runat="server" Text='<%# Eval("Hora_Fin_HM") %>' TextMode="Time"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
