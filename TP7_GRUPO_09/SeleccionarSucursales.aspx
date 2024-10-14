<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarSucursales.aspx.cs" Inherits="TP7_GRUPO_09.SeleccionarSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista de Sucursales</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style3 {
            width: 303px;
        }

        .auto-style4 {
            width: 166px;
        }

        .auto-style5 {
            width: 277px;
        }

        .auto-style6 {
            height: 26px;
        }

        .auto-style8 {
            margin-left: 0px;
        }

        .auto-style9 {
            width: 57px;
        }

        .auto-style10 {
            width: 100%;
            margin-right: 20px;
        }

        .auto-style11 {
            width: 250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1" style="padding-left: 223px;">
                <tr>
                    <td class="auto-style6">
                        <asp:HyperLink ID="hl_Listado" runat="server">Listado de Sucursales</asp:HyperLink>
                        <asp:HyperLink ID="hl_MostrarSeleccion" Style="padding-left: 200px" runat="server" NavigateUrl="~/ListadoSucursalesSeleccionadas.aspx">Mostrar sucursales seleccionadas</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="font-size: 30px;"><b>Listado de sucursales</b></p>
                    </td>
                </tr>
            </table>
            <table class="auto-style10">
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Label ID="lbl_Busqueda" runat="server" Text="Busqueda por nombre de sucursal"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtbox_Busqueda" runat="server" Width="286px" CssClass="auto-style8"></asp:TextBox>
                    </td>
                    <td class="auto-style9">
                        <asp:Button ID="btn_Buscar" runat="server" Text="Buscar" CssClass="auto-style8" OnClick="btn_Buscar_Click" />
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="revSucursales" runat="server" ControlToValidate="txtbox_Busqueda" ForeColor="Red" ValidationExpression="^[a-zA-Z]+$">(*)Error, ingrese un nombre de sucursal válido. </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" style="vertical-align: top; padding-top: 15px;">
                        <asp:DataList ID="dl_Provincias" runat="server" DataKeyField="Id_Provincia" DataSourceID="SqlDataSource1" OnItemCommand="dl_Provincias_ItemCommand" Width="92px">
                            <ItemTemplate>
                                <asp:Button ID="btnProvincias" runat="server"
                                    Text='<%# Eval("DescripcionProvincia") %>'
                                    Width="250px"
                                    CommandName="Seleccionar"
                                    CommandArgument='<%# Eval("Id_Provincia") %>' />
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BDSucursalesConnectionString %>" SelectCommand="SELECT * FROM [Provincia]"></asp:SqlDataSource>
                    </td>
                    <td colspan="3" style="padding-top: 15px;">
                        <asp:ListView ID="lvSucursales" runat="server" DataKeyNames="Id_Sucursal" GroupItemCount="3" OnPagePropertiesChanging="lvSucursales_PagePropertiesChanging">
                            <AlternatingItemTemplate>
                                <td runat="server" style="background-color: #FFFFFF; color: #284775;">
                                    <table class="auto-style11" style="width: 250px;">
                                        <tr style="height: 48px; text-align: center">
                                            <td>
                                                <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' Font-Bold="True" />
                                            </td>
                                        </tr>
                                        <tr style="height: 285px; vertical-align: central;">
                                            <td>
                                                <asp:ImageButton ID="ibtnSucursal" runat="server" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>' Width="250px" />
                                            </td>
                                        </tr>
                                        <tr style="height: 80px; vertical-align: top;">
                                            <td>
                                                <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                                            </td>
                                        </tr>
                                        <tr style="height: 32px; text-align: center">
                                            <td>
                                                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CommandArgument='<%# Eval("Id_Sucursal")+"-"+Eval("NombreSucursal")+"-"+Eval("DescripcionSucursal") %>' CommandName="eventoSeleccionar" OnCommand="btnSeleccionar_Command" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </AlternatingItemTemplate>
                            <EditItemTemplate>
                                <td runat="server" style="background-color: #999999;">Id_Sucursal:
                        <asp:Label ID="Id_SucursalLabel1" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                                    <br />
                                    NombreSucursal:
                        <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                                    <br />
                                    DescripcionSucursal:
                        <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                                    <br />
                                    Id_HorarioSucursal:
                        <asp:TextBox ID="Id_HorarioSucursalTextBox" runat="server" Text='<%# Bind("Id_HorarioSucursal") %>' />
                                    <br />
                                    Id_ProvinciaSucursal:
                        <asp:TextBox ID="Id_ProvinciaSucursalTextBox" runat="server" Text='<%# Bind("Id_ProvinciaSucursal") %>' />
                                    <br />
                                    DireccionSucursal:
                        <asp:TextBox ID="DireccionSucursalTextBox" runat="server" Text='<%# Bind("DireccionSucursal") %>' />
                                    <br />
                                    URL_Imagen_Sucursal:
                        <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                                    <br />
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                                    <br />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                                    <br />
                                </td>
                            </EditItemTemplate>
                            <EmptyDataTemplate>
                                <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                    <tr>
                                        <td>No data was returned.</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <EmptyItemTemplate>
                                <td runat="server" />
                            </EmptyItemTemplate>
                            <GroupTemplate>
                                <tr id="itemPlaceholderContainer" runat="server">
                                    <td id="itemPlaceholder" runat="server"></td>
                                </tr>
                            </GroupTemplate>
                            <InsertItemTemplate>
                                <td runat="server" style="">NombreSucursal:
                        <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                                    <br />
                                    DescripcionSucursal:
                        <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                                    <br />
                                    Id_HorarioSucursal:
                        <asp:TextBox ID="Id_HorarioSucursalTextBox" runat="server" Text='<%# Bind("Id_HorarioSucursal") %>' />
                                    <br />
                                    Id_ProvinciaSucursal:
                        <asp:TextBox ID="Id_ProvinciaSucursalTextBox" runat="server" Text='<%# Bind("Id_ProvinciaSucursal") %>' />
                                    <br />
                                    DireccionSucursal:
                        <asp:TextBox ID="DireccionSucursalTextBox" runat="server" Text='<%# Bind("DireccionSucursal") %>' />
                                    <br />
                                    URL_Imagen_Sucursal:
                        <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                                    <br />
                                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                                    <br />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                                    <br />
                                </td>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <td runat="server" style="background-color: #E0FFFF; color: #333333;">
                                    <table class="auto-style11" style="width: 250px;">
                                        <tr style="height: 48px; text-align: center">
                                            <td>
                                                <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' Font-Bold="True" />
                                            </td>
                                        </tr>
                                        <tr style="height: 285px; background-color: #FFFFFF; vertical-align: central;">
                                            <td>
                                                <asp:ImageButton ID="ibtnSucursal" runat="server" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>' Width="250px" />
                                            </td>
                                        </tr>
                                        <tr style="height: 80px; vertical-align: top;">
                                            <td>
                                                <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                                            </td>
                                        </tr>
                                        <tr style="height: 32px; text-align: center">
                                            <td>
                                                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CommandArgument='<%# Eval("Id_Sucursal")+"-"+Eval("NombreSucursal")+"-"+Eval("DescripcionSucursal") %>' CommandName="eventoSeleccionar" OnCommand="btnSeleccionar_Command" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <table runat="server">
                                    <tr runat="server">
                                        <td runat="server">
                                            <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                <tr id="groupPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                                            <asp:DataPager ID="DataPager1" runat="server" PageSize="6">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                    <asp:NumericPagerField />
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                </Fields>
                                            </asp:DataPager>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                            <SelectedItemTemplate>
                                <td runat="server" style="background-color: #E2DED6; font-weight: bold; color: #333333;">Id_Sucursal:
                        <asp:Label ID="Id_SucursalLabel" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                                    <br />
                                    NombreSucursal:
                        <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                                    <br />
                                    DescripcionSucursal:
                        <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                                    <br />
                                    Id_HorarioSucursal:
                        <asp:Label ID="Id_HorarioSucursalLabel" runat="server" Text='<%# Eval("Id_HorarioSucursal") %>' />
                                    <br />
                                    Id_ProvinciaSucursal:
                        <asp:Label ID="Id_ProvinciaSucursalLabel" runat="server" Text='<%# Eval("Id_ProvinciaSucursal") %>' />
                                    <br />
                                    DireccionSucursal:
                        <asp:Label ID="DireccionSucursalLabel" runat="server" Text='<%# Eval("DireccionSucursal") %>' />
                                    <br />
                                    URL_Imagen_Sucursal:
                        <asp:Label ID="URL_Imagen_SucursalLabel" runat="server" Text='<%# Eval("URL_Imagen_Sucursal") %>' />
                                    <br />
                                </td>
                            </SelectedItemTemplate>
                        </asp:ListView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=BDSucursales;Integrated Security=True;Trust Server Certificate=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [Id_ProvinciaSucursal], [Id_HorarioSucursal], [DireccionSucursal], [URL_Imagen_Sucursal] FROM [Sucursal]"></asp:SqlDataSource>
                    </td>
                    <td style="padding-top: 15px;">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
