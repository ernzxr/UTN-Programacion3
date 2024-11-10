<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AusenciasMedicos.aspx.cs" Inherits="Vistas.AusenciasMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="ausencias m-5">
        <div class="p-5">
            <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:DropDownList ID="ddlTipoAusencia" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        </div>

        <div class="ausencias p-5">
            <asp:GridView ID="gvAusencias" runat="server"
                AllowPaging="True"
                PageSize="5"
                OnPageIndexChanging="gvAusencias_PageIndexChanging"
                CssClass="table table-bordered table-striped" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Legajo_Medico_AM" HeaderText="Legajo" />
                    <asp:BoundField DataField="Descripcion_TAM" HeaderText="Tipo de Ausencia" />
                    <asp:BoundField DataField="Fecha_Inicio_AM" HeaderText="Fecha de Inicio" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="Fecha_Fin_AM" HeaderText="Fecha de Fin" DataFormatString="{0:yyyy-MM-dd}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
