<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarSucursales.aspx.cs" Inherits="TP7_GRUPO_09.SeleccionarSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1"  style="padding-left:223px;">
                <tr>
                    <td class="auto-style6">
                        <asp:HyperLink ID="hl_Listado" runat="server">Listado de Sucursales</asp:HyperLink>
                        <asp:HyperLink ID="hl_MostrarSeleccion" style="padding-left:200px" runat="server" NavigateUrl="~/ListadoSucursalesSeleccionadas.aspx">Mostrar sucursales seleccionadas</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="font-size:30px;"><b>Listado de sucursales</b></p>
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
                        <asp:Button ID="btn_Buscar" runat="server" Text="Buscar" CssClass="auto-style8" />
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="revSucursales" runat="server" ControlToValidate="txtbox_Busqueda" ForeColor="Red" ValidationExpression="^[a-zA-Z]+$">(*)Error, ingrese un nombre de sucursal válido. </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:DataList ID="dl_Provincias" runat="server">
                            <ItemTemplate>
                                <asp:Button ID="btn_Provincias" runat="server" Text='<%# Eval("DescripcionProvincia") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td colspan="3" style="padding-top:15px;" >
            <asp:ListView ID="lvSucursales" runat="server" DataKeyNames="Id_Sucursal" GroupItemCount="3" OnPagePropertiesChanging="lvSucursales_PagePropertiesChanging">
                <AlternatingItemTemplate>
                    <td runat="server" style="background-color: #FFFFFF;color: #284775;">
                        <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                            <br />
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>' />
                            <br />
                            <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                            <br />
                            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CommandArgument='<%# Eval("Id_Sucursal")+"-"+Eval("NombreSucursal")+"-"+Eval("DescripcionSucursal") %>' CommandName="eventoSeleccionar" OnCommand="btnSeleccionar_Command" />
                        <br /></td>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <td runat="server" style="background-color: #999999;">Id_Sucursal:
                        <asp:Label ID="Id_SucursalLabel1" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                        <br />NombreSucursal:
                        <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                        <br />DescripcionSucursal:
                        <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                        <br />Id_HorarioSucursal:
                        <asp:TextBox ID="Id_HorarioSucursalTextBox" runat="server" Text='<%# Bind("Id_HorarioSucursal") %>' />
                        <br />Id_ProvinciaSucursal:
                        <asp:TextBox ID="Id_ProvinciaSucursalTextBox" runat="server" Text='<%# Bind("Id_ProvinciaSucursal") %>' />
                        <br />DireccionSucursal:
                        <asp:TextBox ID="DireccionSucursalTextBox" runat="server" Text='<%# Bind("DireccionSucursal") %>' />
                        <br />URL_Imagen_Sucursal:
                        <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        <br /></td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
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
                        <br />DescripcionSucursal:
                        <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                        <br />Id_HorarioSucursal:
                        <asp:TextBox ID="Id_HorarioSucursalTextBox" runat="server" Text='<%# Bind("Id_HorarioSucursal") %>' />
                        <br />Id_ProvinciaSucursal:
                        <asp:TextBox ID="Id_ProvinciaSucursalTextBox" runat="server" Text='<%# Bind("Id_ProvinciaSucursal") %>' />
                        <br />DireccionSucursal:
                        <asp:TextBox ID="DireccionSucursalTextBox" runat="server" Text='<%# Bind("DireccionSucursal") %>' />
                        <br />URL_Imagen_Sucursal:
                        <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        <br /></td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="background-color: #E0FFFF;color: #333333;">
                        <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                        <br />
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>' />
                        <br />
                        <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                        <br />
                        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CommandArgument='<%# Eval("Id_Sucursal")+"-"+Eval("NombreSucursal")+"-"+Eval("DescripcionSucursal") %>' CommandName="eventoSeleccionar" OnCommand="btnSeleccionar_Command" />
                        </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
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
                    <td runat="server" style="background-color: #E2DED6;font-weight: bold;color: #333333;">Id_Sucursal:
                        <asp:Label ID="Id_SucursalLabel" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                        <br />NombreSucursal:
                        <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                        <br />DescripcionSucursal:
                        <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                        <br />Id_HorarioSucursal:
                        <asp:Label ID="Id_HorarioSucursalLabel" runat="server" Text='<%# Eval("Id_HorarioSucursal") %>' />
                        <br />Id_ProvinciaSucursal:
                        <asp:Label ID="Id_ProvinciaSucursalLabel" runat="server" Text='<%# Eval("Id_ProvinciaSucursal") %>' />
                        <br />DireccionSucursal:
                        <asp:Label ID="DireccionSucursalLabel" runat="server" Text='<%# Eval("DireccionSucursal") %>' />
                        <br />URL_Imagen_Sucursal:
                        <asp:Label ID="URL_Imagen_SucursalLabel" runat="server" Text='<%# Eval("URL_Imagen_Sucursal") %>' />
                        <br /></td>
                </SelectedItemTemplate>
            </asp:ListView>
                        pa</td>
                    <td style="padding-top:15px;" >
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
