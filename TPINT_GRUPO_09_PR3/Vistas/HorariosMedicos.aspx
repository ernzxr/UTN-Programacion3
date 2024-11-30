<%@ Page Title="Modificar Horarios Médicos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HorariosMedicos.aspx.cs" Inherits="Vistas.ModificarHorariosMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Horarios Médicos</title>
    <style>
        .auto-style1 {
            color: #006699;
            font-weight: bold;
            font-size: x-large;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style2 {
            font-size: small;
        }
    </style>
    <script>
        function showDeleteModal() {
            var modal = document.getElementById('DeleteConfirmModal');
            var myModal = new bootstrap.Modal(modal);
            myModal.show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center align-items-center mb-3">
        <h5 id="lblTitulo" class="text-primary mb-0">Alta, Baja, Modificación y Listado de Horarios Médicos</h5>
    </div>

    <div class="d-flex justify-content-center">
        <div class="card shadow-sm p-3" style="width: 300px;">
            <div class="mb-3">
                <asp:Label ID="lblIngresar" runat="server" Text="Ingrese un legajo" class="form-label"></asp:Label>
                <asp:TextBox ID="txtLegajo" runat="server" class="form-control" MaxLength="5"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ValidationGroup="grupo1" ForeColor="#CC0000" ControlToValidate="txtLegajo" Font-Size="Small" Text="(*) Complete el campo." Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revLegajo" runat="server" ValidationExpression="^\d+$" ForeColor="#CC0000" Text="(*) Ingrese solo números." ValidationGroup="grupo1" ControlToValidate="txtLegajo" Font-Size="Small" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="d-flex justify-content-center">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary w-100" ValidationGroup="grupo1" OnClick="btnBuscar_Click" />
            </div>
        </div>
    </div>

    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="text-danger d-block mt-3" ForeColor="#CC0000"></asp:Label>
    <div class="text-center">
        <asp:GridView ID="gvHorariosMedicos" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" OnRowEditing="gvHorariosMedicos_RowEditing" OnRowCancelingEdit="gvHorariosMedicos_RowCancelingEdit" OnRowUpdating="gvHorariosMedicos_RowUpdating" OnRowDeleting="gvHorariosMedicos_RowDeleting" Width="150px" VerticalAlign="Middle">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Edit" CssClass="btn btn-secondary btn-sm" Width="100px" />
                    </ItemTemplate>
                    <EditItemTemplate>

                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CommandName="Update" CssClass="btn btn-success btn-sm" Width="100px" ValidationGroup="grupo2" />

                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary btn-sm" Text="Cancelar" CommandName="Cancel" Width="100px" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm" Text="Eliminar" Width="100px" CommandName="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
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
                        <asp:TextBox ID="eit_txtHoraInicio" class="form-control" runat="server" Text='<%# Eval("Hora_Inicio_HM") %>' TextMode="Time"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtHoraInicio" runat="server" ControlToValidate="eit_txtHoraInicio" ValidationGroup="grupo2" Text="(*) Complete el campo." Font-Size="X-Small" ForeColor="#CC0000" ></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="customHoraInicio" runat="server" ControlToValidate="eit_txtHoraInicio" ValidationGroup="grupo2" Text="(*) Ingrese solo horas." ForeColor="#CC0000" Font-Size="X-Small" OnServerValidate="customHoraInicio_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hora Salida">
                    <ItemTemplate>
                        <asp:Label ID="it_lblHoraFin" runat="server" Text='<%# Eval("Hora_Fin_HM") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="eit_txtHoraFin" class="form-control" runat="server" Text='<%# Eval("Hora_Fin_HM") %>' TextMode="Time"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtHoraFin" runat="server" ControlToValidate="eit_txtHoraFin" ValidationGroup="grupo2" Text="(*) Complete el campo." Font-Size="X-Small" ForeColor="#CC0000" ></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="customHoraFin" runat="server" ControlToValidate="eit_txtHoraFin" Text="(*) Ingrese solo horas." Font-Size="X-Small" ForeColor="#CC0000" OnServerValidate="customHoraFin_ServerValidate" ValidationGroup="grupo2"></asp:CustomValidator>
                        <asp:CompareValidator ID="cvHoraFin" runat="server" ControlToValidate="eit_txtHoraFin" ControlToCompare="eit_txtHoraInicio" Operator="GreaterThan" ForeColor="#CC0000" Font-Size="X-Small" Text="(*) La hora seleccionada debe ser mayor a la hora de entrada." ValidationGroup="grupo2" Display="Dynamic"></asp:CompareValidator>
                    </EditItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

        <div class="modal fade" id="DeleteConfirmModal" tabindex="-1" aria-labelledby="DeleteModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="DeleteModalLabel">Confirmar Eliminación</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <p>¿Está seguro de que desea eliminar este horario medico?</p>
                        <div class="modal-footer">
                            <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Sí" CssClass="btn btn-danger" OnClick="btnConfirmarEliminar_Click" />
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">No</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
