<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ModificarHorariosMedicos.aspx.cs" Inherits="Vistas.ModificarHorariosMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Modificar Horarios Medicos</title>
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
        <asp:Label ID="lblTitulo" runat="server" Text="Modificar Horarios Medicos" CssClass="auto-style1 mb-2" ForeColor="#000099"></asp:Label>
    </div>

    <div style="width: 25%; display: flex; flex-direction: column; align-items: center; justify-content: center;">
        <asp:Label ID="lblLegajo" runat="server" CssClass="mb-4" Text="Ingrese legajo:"></asp:Label>
        <asp:TextBox ID="txtLegajo" runat="server" class="form-control" MaxLength="5"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ValidationGroup="grupo1" ForeColor="#CC0000" ControlToValidate="txtLegajo" Font-Size="Small" Text="(*) Ingrese un legajo."></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revLegajo" runat="server" CssClass="mb-2" ValidationExpression="^\d+$" ForeColor="#CC0000" Text="(*) Ingrese solo números." ValidationGroup="grupo1" ControlToValidate="txtLegajo" Font-Size="Small"></asp:RegularExpressionValidator>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary mb-4" ValidationGroup="grupo1" OnClick="btnBuscar_Click" Width="150" />

        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

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
    </div>
</asp:Content>
