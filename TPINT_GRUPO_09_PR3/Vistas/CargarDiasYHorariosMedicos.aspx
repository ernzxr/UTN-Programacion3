<%@ Page Title="Carga horarios médicos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CargarDiasYHorariosMedicos.aspx.cs" Inherits="Vistas.CargarDiasYHorariosMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
    .auto-style1 {
        color: #006699;
        font-weight: bold;
        font-size: x-large;
        font-family: Arial, Helvetica, sans-serif;
    }

    .auto-style2 {
        --bs-form-check-bg: var(--bs-body-bg);
        flex-shrink: 0;
        margin-top: .25em;
        vertical-align: top;
        -webkit-appearance: none;
        -moz-appearance: none;
        appearance: none;
        background-color: var(--bs-form-check-bg);
        background-image: url('var(--bs-form-check-bg-image)');
        background-repeat: no-repeat;
        background-position: center;
        background-size: contain;
        -webkit-print-color-adjust: exact;
        print-color-adjust: exact;
    }
        .horizontal-checkbox {
        font-size: 20px; 
        color: black;    
        padding: 10px;   
         }


        .horizontal-checkbox input[type="checkbox"] {
        width: 25px;   
        height: 25px;  
        margin-right: 10px; 
        vertical-align: middle; 
        }

        .horizontal-checkbox label {
         margin-right: 20px;
         }

        .label-negro-negrita{
         color: black;
         font-size: 20px;
         font-family: Arial, sans-serif;
         }
  
</style>
</asp:Content>
        
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: %; display: flex; flex-direction: column; align-items: center; justify-content: center;">
    
    <asp:Label ID="lblTitulo" runat="server" Text="Cargar días y horarios médicos" CssClass="auto-style1"></asp:Label>
    <p></p>
    <p></p>
    <div style="display: flex; align-items: center; justify-content: flex-start; gap: 10px;">
     <asp:Label ID="lblLegajo" runat="server" Text="Legajo" Style="align-self: flex-start" CssClass="label-negro-negrita" ></asp:Label>
     <asp:TextBox ID="txtLegajo" class="form-control" runat="server" ValidationGroup="grupo1" Width="600px" style="display:inline-block" AutoPostBack="True" MaxLength="5" OnTextChanged="txtLegajo_TextChanged"></asp:TextBox>
     <asp:Button ID="btnCancelarLegajo" runat="server" Text="Cancelar" style="display:inline-block;height: 40px; width: 150px; padding-left: -10px; background-color: #007bff; color: white; border: none; border-radius: 5px; cursor: pointer" OnClick="btnCancelarLegajo_Click" /> 
    </div>
   
    <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1">(*) Ingrese solo números.</asp:RegularExpressionValidator>
    
        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="red"></asp:Label>
        <p></p>
    

       <asp:Label ID="Subtitulo" runat="server" Text="Seleccione días de trabajo" CssClass="bold-large label-negro-negrita" Style="align-self: flex-start;"></asp:Label> 
       <p></p>
     
       <asp:CheckBoxList ID="cklDias" runat="server" RepeatDirection="Horizontal" CssClass="horizontal-checkbox" Style="font-size: 18px; color: black; padding: 10px;" AutoPostBack="True">
       <asp:ListItem Value="1">Lunes</asp:ListItem>
       <asp:ListItem Value="2">Martes</asp:ListItem>
       <asp:ListItem Value="3">Miércoles</asp:ListItem>
       <asp:ListItem Value="4">Jueves</asp:ListItem>
       <asp:ListItem Value="5">Viernes</asp:ListItem>
       <asp:ListItem Value="6">Sábado</asp:ListItem>
       <asp:ListItem Value="7">Domingo</asp:ListItem>
       </asp:CheckBoxList>
    
               
        <p></p>
        <p></p>
       <asp:Label ID="lblHoraEntrada" runat="server" Text="Ingrese hora de entrada (HH:mm:ss)" Style="align-self: flex-start" CssClass="label-negro-negrita" ></asp:Label>
       <asp:TextBox ID="txtHoraEntrada" class="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfvHoraEntrada" runat="server" ControlToValidate="txtHoraEntrada" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="revHoraEntrada" runat="server" ControlToValidate="txtHoraEntrada" ForeColor="#CC0000" ValidationExpression="^([0-1][0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$" ValidationGroup="grupo1">(*) El horario ingresado no es válido.Por favor ingrese un horario en formato HH:mm:ss </asp:RegularExpressionValidator>

       <asp:Label ID="lblHoraSalida" runat="server" Text="Ingrese hora de salida (HH:mm:ss)" Style="align-self: flex-start" CssClass="label-negro-negrita"></asp:Label>
       <asp:TextBox ID="txtHoraSalida" class="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfvHoraSalida" runat="server" ControlToValidate="txtHoraSalida" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="revHoraSalida" runat="server" ControlToValidate="txtHoraSalida" ForeColor="#CC0000" ValidationExpression="^([0-1][0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$" ValidationGroup="grupo1">(*) El horario ingresado no es válido.Por favor ingrese un horario en formato HH:mm:ss </asp:RegularExpressionValidator>
    
       <p></p> 
       <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" Text="Guardar" style="display:inline-block; width: 150px; padding: 10px; background-color: #007bff; color: white; border: none; border-radius: 5px; cursor: pointer" ValidationGroup="grupo1" OnClick="btnGuardar_Click" />
        
    </div>

</asp:Content>