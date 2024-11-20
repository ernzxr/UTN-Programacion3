<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListadoPacientes.aspx.cs" Inherits="Vistas.ListadoPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function showModal() {
            var modal = document.getElementById('UpdateModal');
            var myModal = new bootstrap.Modal(modal);
            myModal.show();
        }

        function showDeleteModal() {
            var modal = document.getElementById('DeleteConfirmModal');
            var myModal = new bootstrap.Modal(modal);
            myModal.show();
        }
    </script>

    <title>Listado de Pacientes</title>
    <style type="text/css">
        .auto-style1 {
            color: #006699;
            font-weight: bold;
            font-size: x-large;
            font-family: Arial, Helvetica, sans-serif;
        }

        .btn-azul {
            background-color: #006699;
            color: white;
            border: 1px solid #006699;
            border-radius: 0.375rem;
            padding: 0.375rem 0.75rem;
            font-size: 1rem;
            font-weight: 400;
            text-align: center;
            cursor: pointer;
            transition: background-color 0.15s ease-in-out, border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
        }

        .modal-controls {
            display: flex;
            flex-direction: column;
            align-items: flex-start;
            margin-bottom: 20px;
        }

        .modal-labels {
            margin-bottom: 15px;
        }

        .simple-pager {
            background-color: #f8f9fa; /* Fondo claro */
            border: 1px solid #ddd; /* Borde suave */
            border-radius: 4px; /* Bordes ligeramente redondeados */
            padding: 5px;
            font-family: Arial, sans-serif;
            font-size: 14px;
        }

            .simple-pager a, .simple-pager span {
                display: inline-block;
                padding: 8px 12px; /* Espaciado interno */
                color: #007bff; /* Azul Bootstrap */
                text-decoration: none; /* Sin subrayado */
                border: 1px solid transparent; /* Sin borde inicialmente */
                border-radius: 3px; /* Botones ligeramente redondeados */
                transition: background-color 0.3s ease, color 0.3s ease; /* Suavidad al interactuar */
            }

                .simple-pager a:hover {
                    background-color: #007bff; /* Fondo azul al pasar el mouse */
                    color: white; /* Texto blanco */
                }

            .simple-pager .active {
                background-color: #0056b3; /* Fondo azul oscuro */
                color: white; /* Texto blanco */
                font-weight: bold;
                border-color: #0056b3;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div style="width: 100%; display: flex; flex-direction: column; align-items: center; position: relative;">
        <div style="width: 28%; display: flex; flex-direction: column; align-items: center;">
            <asp:Label ID="lblTitulo" runat="server" Text="Listar Pacientes" CssClass="auto-style1 mb-4"></asp:Label>

            <asp:Label ID="lblDNI" runat="server" Text="Ingrese el DNI del Paciente" CssClass="mb-2"></asp:Label>
            <asp:TextBox ID="txtDNI" class="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ForeColor="#CC0000" ValidationGroup="grupo1" CssClass="auto-style2" Style="font-size: small">(*) Complete el campo.</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1" CssClass="auto-style2" Style="font-size: small">(*) Ingrese solo números.</asp:RegularExpressionValidator>
            <asp:Label ID="lblNacionalidad" runat="server" Text="Seleccione la Nacionalidad" CssClass="mb-2"></asp:Label>
            <asp:DropDownList ID="ddlNacionalidad" class="form-select" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvNacionalidad" CssClass="auto-style2" runat="server" ControlToValidate="ddlNacionalidad" ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>
            <div>
                <asp:Button ID="btnFiltrar" class="btn-azul" runat="server" Text="Filtrar" Width="150px" ValidationGroup="grupo1" OnClick="btnFiltrar_Click" />
                <asp:Button ID="btnMostrarTodo" class="btn-azul" runat="server" Text="Mostrar Todo" Width="150px" OnClick="btnMostrarTodo_Click"/>
            </div>
        </div>

        <div style="width: 100%; margin-top: 20px;">
            <asp:GridView runat="server" ID="gvPacientes" CssClass="table table-hover" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvPacientes_PageIndexChanging" PageSize="6" PagerStyle-HorizontalAlign="Center" PagerStyle-CssClass="simple-pager">
                <Columns>
                    <asp:BoundField DataField="DNI" HeaderText="DNI" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                    <asp:BoundField DataField="Fecha_De_Nacimiento" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Fecha" />
                    <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
                    <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                    <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                    <asp:BoundField DataField="Email" HeaderText="Correo Electronico" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEstado" runat="server" Checked='<%# Convert.ToBoolean(Eval("Estado")) %>' Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Modificar">
                        <ItemTemplate>
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("DNI") + "," + Eval("Nacionalidad") %>' OnCommand="btnModificar_Command1"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("DNI") + "," + Eval("Nacionalidad") %>' OnCommand="btnEliminar_Command"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="modal fade" id="UpdateModal" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="myModalLabel">Modificar Paciente</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <p>Ingrese Datos a Modificar</p>
                        <div class="modal-controls">
                            <asp:Label ID="lblDni_M" Text="DNI:" runat="server" style="margin-bottom:5px;"/>
                            <asp:Label ID="lblDNI2_M"  style="border: 1px solid #ccc; padding:8px; padding-right:372px; padding-top: 7px; padding-bottom:7px; border-radius: 5px;" runat="server" />
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblNacionalidad_M" Text="Nacionalidad:" runat="server" />
                            <asp:DropDownList style="cursor:not-allowed; padding-right:270px; padding-top: 7px; padding-bottom:7px; border-radius: 5px;" ID="ddlNacionalidad_M" runat="server" Enabled="false"></asp:DropDownList>
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblNombre_M" Text="Nombre:" runat="server" />
                            <asp:TextBox ID="txtNombre_M" runat="server" class="form-control" ValidationGroup="grupoModal"/>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre_M" ValidationGroup="grupoModal">Complete el campo</asp:RequiredFieldValidator>
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblApellido_M" Text="Apellido:" runat="server" />
                            <asp:TextBox ID="txtApellido_M" runat="server" class="form-control" />
                            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido_M" ValidationGroup="grupoModal">Complete el campo</asp:RequiredFieldValidator>
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblSexo_M" Text="Sexo:" runat="server" />
                            <asp:DropDownList class="form-select" ID="ddlSexo_M" runat="server"></asp:DropDownList>
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblFechaNacimiento_M" Text="Fecha de Nacimiento:" runat="server" />
                            <asp:TextBox ID="txtFechaNacimiento_M" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="modal-controls">
                                    <asp:Label ID="lblProvincia_M" Text="Provincia:" runat="server" />
                                    <asp:DropDownList class="form-select" ID="ddlProvincia_M" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_M_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="modal-controls">
                                    <asp:Label ID="lblLocalidad_M" Text="Localidad:" runat="server" />
                                    <asp:DropDownList class="form-select" ID="ddlLocalidad_M" runat="server"></asp:DropDownList>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="modal-controls">
                            <asp:Label ID="lblDireccion_M" Text="Direccion:" runat="server" />
                            <asp:TextBox ID="txtDireccion_M" runat="server" class="form-control" />
                            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion_M" ValidationGroup="grupoModal">Complete el campo</asp:RequiredFieldValidator>
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblEmail_M" Text="Email:" runat="server" />
                            <asp:TextBox ID="txtEmail_M" runat="server" TextMode="Email" class="form-control" />
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail_M" ValidationGroup="grupoModal">Complete el campo</asp:RequiredFieldValidator>
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblTelefono_M" Text="Telefono:" runat="server" />
                            <asp:TextBox ID="txtTelefono_M" runat="server" class="form-control" />
                            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono_M" ValidationGroup="grupoModal">Complete el campo</asp:RequiredFieldValidator>
                        </div>
                        <div class="modal-controls">
                            <asp:CheckBox ID="chkEstado_M" Text="Activo" runat="server" />
                        </div>
                        <div>
                            <asp:Label ID="lblCatch" runat="server" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button class="btn btn-primary" Text="Guardar cambios" runat="server" OnClick="btnModificarM_Click" ValidationGroup="grupoModal"/>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="DeleteConfirmModal" tabindex="-1" aria-labelledby="DeleteModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="DeleteModalLabel">Confirmar Eliminación</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <p>¿Está seguro de que desea eliminar este registro?</p>
                        <div>
                            <asp:Label ID="lblDNI_E" Text="DNI:" runat="server" />
                            <asp:TextBox ID="txtDNI_E" runat="server" ReadOnly="true" class="form-control" />
                        </div>
                        <div>
                            <asp:Label ID="lblNacionalidad_E" Text="Nacionalidad:" runat="server" />
                            <asp:DropDownList ID="ddlNacionalidad_E" runat="server" Enabled="false"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnConfirmDelete" runat="server" Text="Sí" CssClass="btn btn-danger" OnClick="btnConfirmDelete_Click" />
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">No</button>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
