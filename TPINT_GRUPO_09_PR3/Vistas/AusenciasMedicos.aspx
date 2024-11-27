<%@ Page Title="Ausentismo Médico" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AusenciasMedicos.aspx.cs" Inherits="Vistas.AusenciasMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ausencias {
            display: inline-flex;
        }

        .gridPager a,
        .gridPager span {
            display: inline-block;
            padding: 0px 9px;
            margin-right: 4px;
            border-radius: 3px;
            border: solid 1px #c0c0c0;
            background: #e9e9e9;
            box-shadow: inset 0px 1px 0px rgba(255,255,255, .8), 0px 1px 3px rgba(0,0,0, .1);
            font-size: .875em;
            font-weight: bold;
            text-decoration: none;
            color: #717171;
            text-shadow: 0px 1px 0px rgba(255,255,255, 1);
        }

        .gridPager a {
            background-color: #f5f5f5;
            color: #969696;
            border: 1px solid #969696;
        }

        .gridPager span {
            background: #616161;
            box-shadow: inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8);
            color: #f0f0f0;
            text-shadow: 0px 0px 3px rgba(0,0,0, .5);
            border: 1px solid #3AC0F2;
        }

        .validator-width {
            display: inline-block;
            width: 200px;
            min-height: 1.2em;
            vertical-align: top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex;">
        <div class="px-5 py-3 me-5 border rounded">
            <h3 class="text-center">Agregar Ausencia</h3>
            <div class="form-group mt-3">
                <asp:Label ID="lbLegajo" runat="server" Text="Legajo" CssClass="form-label" AssociatedControlID="txtLegajo"></asp:Label>
                <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control mt-3" ValidationGroup="gpAgregar" MaxLength="5"></asp:TextBox>
                <div style="text-align: left;">
                    <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ValidationGroup="gpAgregar" CssClass="text-danger" Text="* Debe ingresar un legajo" Font-Bold="True" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revSoloNumeros" runat="server" Text="* Un legajo contiene 5 números" ControlToValidate="txtLegajo" CssClass="text-danger" ValidationGroup="gpAgregar" Font-Bold="True" Display="Dynamic" ValidationExpression="^\d{5}$"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group mt-3">
                <asp:Label ID="lbTipo" runat="server" Text="Tipo" CssClass="form-label" AssociatedControlID="ddlTipoAusencia"></asp:Label>
                <div style="text-align: left;">
                    <asp:DropDownList ID="ddlTipoAusencia" runat="server" CssClass="form-control mt-3" ValidationGroup="gpAgregar"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTipoAusencia" runat="server" Text="* Elija un tipo de ausencia" ControlToValidate="ddlTipoAusencia" InitialValue="Elegir una opción" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group mt-3" style="width: 344px;">
                <asp:Label ID="lbFechas" runat="server" Text="Inicio y Fin" CssClass="form-label"></asp:Label>
                <div style="display: flex;" class="mt-3">
                    <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control me-4" Width="160" ValidationGroup="gpAgregar"></asp:TextBox>
                    <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control" Width="160" ValidationGroup="gpAgregar"></asp:TextBox>
                </div>
                <div style="text-align: left;">
                    <asp:CompareValidator ID="cvFechaInicioFin" runat="server" ControlToValidate="txtFechaFin" ControlToCompare="txtFechaInicio" Operator="GreaterThanEqual" Type="Date" ValidationGroup="gpAgregar" Text="* La Fecha de Fin no puede ser menor a la Fecha de Inicio" Font-Bold="True" Display="Dynamic" CssClass="text-danger validator-width"></asp:CompareValidator>
                </div>
                <div style="display: flex; flex-direction: column; text-align: left;">
                    <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" Text="* Elija una fecha de inicio" ControlToValidate="txtFechaInicio" Display="Dynamic" ValidationGroup="gpAgregar" Font-Bold="True" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvFechaFin" runat="server" Text="* Elija una fecha de fin" ControlToValidate="txtFechaFin" Display="Dynamic" ValidationGroup="gpAgregar" Font-Bold="True" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary mt-5" OnClick="btnGuardar_Click" ValidationGroup="gpAgregar" />
        </div>

        <div>
            <div class="my-4" style="display: flex;">
                <asp:TextBox ID="txtFiltrarLegajo" runat="server" CssClass="text-center form-control" Width="70" TextMode="SingleLine"></asp:TextBox>
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary mx-4" OnClick="btnFiltrar_Click" />
                <asp:Button ID="btnMostrarTodo" runat="server" Text="Mostrar Todos" CssClass="btn btn-primary" OnClick="btnMostrarTodo_Click" />
            </div>
            <asp:GridView ID="gvAusencias" runat="server"
                AllowPaging="True"
                DataKeyNames="Legajo_Medico_AM"
                PageSize="5"
                OnPageIndexChanging="gvAusencias_PageIndexChanging"
                CssClass="table table-bordered"
                AutoGenerateColumns="False" Width="860" AllowCustomPaging="False" PagerSettings-Mode="NumericFirstLast" PagerSettings-FirstPageText="Inicio" PagerSettings-LastPageText="Fin" PagerStyle-CssClass="gridPager" PagerStyle-HorizontalAlign="Center" PagerStyle-VerticalAlign="Middle" PagerSettings-PageButtonCount="3">
                <Columns>
                    <asp:BoundField DataField="Legajo_Medico_AM" HeaderText="Legajo" HeaderStyle-Width="90" />
                    <asp:BoundField DataField="Nombre_Completo" HeaderText="Nombre Completo" HeaderStyle-Width="240" />
                    <asp:BoundField DataField="Descripcion_TAM" HeaderText="Tipo de Ausencia" HeaderStyle-Width="250" />
                    <asp:BoundField DataField="Fecha_Inicio_AM" HeaderText="Fecha de Inicio" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-Width="140" />
                    <asp:BoundField DataField="Fecha_Fin_AM" HeaderText="Fecha de Fin" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-Width="140" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
