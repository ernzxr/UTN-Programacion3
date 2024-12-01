<%@ Page Title="Listado, Modificación y Baja de Médicos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListadoMedicos.aspx.cs" Inherits="Vistas.ListadoMedicos" %>


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
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div style="width: 100%; display: flex; flex-direction: column; align-items: center; position: relative;">
        <div style="width: 28%; display: flex; flex-direction: column; align-items: center;">
            <asp:Label ID="lblTitulo" runat="server" Text="Listado, Modificación y Baja de Médicos" CssClass="auto-style1 mb-4"></asp:Label>

            <asp:Label ID="lblLegajo" runat="server" Text="Ingrese el legajo del médico" CssClass="mb-2"></asp:Label>
            <asp:TextBox ID="txtLegajo" class="form-control" runat="server" ValidationGroup="grupo1" MaxLength="5"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationGroup="grupo1" CssClass="auto-style2" Style="font-size: small">(*) Complete el campo.</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1" CssClass="auto-style2" Style="font-size: small">(*) Ingrese solo números.</asp:RegularExpressionValidator>

            <div>
                <asp:Button ID="btnFiltrar" class="btn-azul" runat="server" Text="Filtrar" Width="150px" ValidationGroup="grupo1" OnClick="btnFiltrar_Click" />
                <asp:Button ID="btnMostrarTodo" class="btn-azul" runat="server" Text="Mostrar Todo" Width="150px" OnClick="btnMostrarTodo_Click" />
            </div>
            <asp:Label ID="lblError_Filtrar" runat="server" />
        </div>

        <div style="width: 100%; margin-top: 20px;">
            <asp:GridView runat="server" ID="gvMedicos" OnRowDataBound="gvMedicos_RowDataBound" CssClass="table table-hover" AutoGenerateColumns="False" AllowPaging="True" PageSize="6" PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="gvMedicos_PageIndexChanging">
                <Columns>
                    <asp:BoundField AccessibleHeaderText="Legajo" DataField="Legajo" HeaderText="Legajo" />
                    <asp:TemplateField HeaderText="Especialidad">
                        <ItemTemplate>
                            <asp:Label ID="lblEspecialidad" Text='<%# Eval("Id_Especialidad") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DNI" HeaderText="DNI" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:TemplateField HeaderText="Genero">
                        <ItemTemplate>
                            <asp:Label ID="lblGenero" Text='<%# Eval("Id_Genero") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Fecha_De_Nacimiento" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Fecha" />
                    <asp:TemplateField HeaderText="Nacionalidad">
                        <ItemTemplate>
                            <asp:Label ID="lblNacionalidad" Text='<%# Eval("Id_Nacionalidad") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia">
                        <ItemTemplate>
                            <asp:Label ID="lblProvincia" Text='<%# Eval("Id_Localidad") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Localidad">
                        <ItemTemplate>
                            <asp:Label ID="lblLocalidad" Text='<%# Eval("Id_Localidad") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
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
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("Legajo") %>' OnCommand="btnModificar_Command1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Legajo") %>' OnCommand="btnEliminar_Command" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="modal fade" id="UpdateModal" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="myModalLabel">Modificar Médico</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <p>Ingrese Datos a Modificar</p>
                        <div class="modal-controls">
                            <asp:Label ID="lblLegajo_M" Text="Legajo:" runat="server" Style="margin-bottom: 5px;" />
                            <asp:TextBox ID="txtLegajo_M" runat="server" ReadOnly="true" class="form-control" />
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="Especialidad_M" Text="Especialidad:" runat="server" />
                            <asp:DropDownList class="form-select" ID="ddlEspecialidad_M" runat="server"></asp:DropDownList>
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblDNI_M" Text="DNI:" runat="server" />
                            <asp:TextBox ID="txtDNI_M" runat="server" class="form-control" />
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblNacionalidad_M" Text="Nacionalidad:" runat="server" />
                            <asp:DropDownList ID="ddlNacionalidad_M" class="form-select" runat="server"></asp:DropDownList>
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblNombre_M" Text="Nombre:" runat="server" />
                            <asp:TextBox ID="txtNombre_M" runat="server" class="form-control" />
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblApellido_M" Text="Apellido:" runat="server" />
                            <asp:TextBox ID="txtApellido_M" runat="server" class="form-control" />
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblSexo_M" Text="Sexo:" runat="server" />
                            <asp:DropDownList ID="ddlSexo_M" class="form-select" runat="server"></asp:DropDownList>
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
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblEmail_M" Text="Email:" runat="server" />
                            <asp:TextBox ID="txtEmail_M" runat="server" TextMode="Email" class="form-control" />
                        </div>
                        <div class="modal-controls">
                            <asp:Label ID="lblTelefono_M" Text="Telefono:" runat="server" />
                            <asp:TextBox ID="txtTelefono_M" runat="server" class="form-control" />
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
                        <asp:Button class="btn btn-primary" Text="Guardar cambios" runat="server" OnClick="btnModificarM_Click" ValidationGroup="grupoModal" />
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
                            <asp:Label ID="lblLegajo_E" Text="Legajo:" runat="server" />
                            <asp:TextBox ID="txtLegajo_E" runat="server" ReadOnly="true" class="form-control" />
                            <asp:Label ID="lblMensaje_E" Text="" runat="server" />
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

