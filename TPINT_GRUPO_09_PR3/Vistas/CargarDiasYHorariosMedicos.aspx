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
        .horizontal-radio label{
         
        margin-right: 30px; 
        display: inline-block; 
        vertical-align: middle; 
        }
  
</style>
</asp:Content>
        
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: %; display: flex; flex-direction: column; align-items: center; justify-content: center;">
    
    <asp:Label ID="lblTitulo" runat="server" Text="Cargar días y horarios médicos" CssClass="auto-style1"></asp:Label>
    <p></p>
    <p></p>
    
    <asp:Label ID="lblLegajo" runat="server" Text="Legajo" Style="align-self: flex-start"></asp:Label>
    <asp:TextBox ID="txtLegajo" class="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1">(*) Ingrese solo números.</asp:RegularExpressionValidator>

       <asp:Label ID="Subtitulo" runat="server" Text="Seleccione días de trabajo" 
        CssClass="bold-large" Style="align-self: flex-start;"> 
      </asp:Label>
    <p></p>
       <asp:RadioButtonList ID="rblDias" runat="server" RepeatDirection="Horizontal" CssClass="horizontal-radio label"  > 
       <asp:ListItem Text="Lunes" Value="1" />
       <asp:ListItem Text="Martes" Value="2" />
       <asp:ListItem Text="Miércoles" Value="3" />
       <asp:ListItem Text="Jueves" Value="4" />
       <asp:ListItem Text="Viernes" Value="5" />
       <asp:ListItem Text="Sábado" Value="6" />
       <asp:ListItem Text="Domingo" Value="7" />
       </asp:RadioButtonList>
       
        <p></p>
        <p></p>
       <asp:Label ID="lblHoraEntrada" runat="server" Text="Ingrese hora de entrada" Style="align-self: flex-start"></asp:Label>
       <asp:TextBox ID="txtHoraEntrada" class="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfvHoraEntrada" runat="server" ControlToValidate="txtHoraEntrada" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="revHoraEntrada" runat="server" ControlToValidate="txtHoraEntrada" ForeColor="#CC0000" ValidationExpression="^([0-1][0-9]|2[0-3]):([0-5][0-9])$" ValidationGroup="grupo1">(*) El horario ingresado no es válido.Por favor ingrese un horario en formato HH:mm </asp:RegularExpressionValidator>

       <asp:Label ID="lblHoraSalida" runat="server" Text="Ingrese hora de salida" Style="align-self: flex-start"></asp:Label>
       <asp:TextBox ID="txtHoraSalida" class="form-control" runat="server" ValidationGroup="grupo1"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfvHoraSalida" runat="server" ControlToValidate="txtHoraSalida" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="revHoraSalida" runat="server" ControlToValidate="txtHoraSalida" ForeColor="#CC0000" ValidationExpression="^([0-1][0-9]|2[0-3]):([0-5][0-9])$" ValidationGroup="grupo1">(*) El horario ingresado no es válido.Por favor ingrese un horario en formato HH:mm </asp:RegularExpressionValidator>
    
       <p></p>
       <asp:Button ID="btnAceptar" class="btn btn-success" runat="server" Text="Aceptar" />

    </div>

</asp:Content>
