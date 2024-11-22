<%@ Page Title="Carga horarios médicos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CargarDiasYHorariosMedicos.aspx.cs" Inherits="Vistas.CargarDiasYHorariosMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
      
        .auto-style1 {
            color: #006699;
            font-weight: normal;
            font-size: x-large;
            font-family: Arial, Helvetica, sans-serif;
        }

     
        .label-titulo {
            font-size: 18px;
            font-weight: normal;
            color: black;
            font-family: Arial, sans-serif;
            margin-bottom: 15px;
        }
               
        .form-control-custom {
            width: 100%;
            max-width: 600px; 
            margin-bottom: 20px;
        }
               
        .horizontal-checkbox {
            font-size: 18px;
            color: black;
            padding: 10px;
            display: flex;
            flex-wrap: wrap; 
            gap: 20px; 
            font-family: Arial, sans-serif;
        }

        .horizontal-checkbox input[type="checkbox"] {
            width: 25px;
            height: 25px;
            margin-right: 10px; 
            vertical-align: middle;
        }
                
        .horizontal-checkbox label {
            margin-right: 30px; 
            font-family:  Arial, sans-serif; 
            font-size: 15px;
            color: black; 
        }

        .btn-custom {
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            padding: 10px 20px;
            width: 150px;
            margin-top: 20px;
        }

       
        .validator-custom {
            color: #CC0000;
            font-size: 12px;
            margin-top: 5px;
        }

        .label-container {
            display: flex;
            flex-direction: column;
            align-items: flex-start;
            width: 100%;
            max-width: 800px;
        }

       .label-ddl {
            font-size: 18px;
            font-weight: normal;
            color: black;
            font-family: Arial, sans-serif;
            margin-bottom: 15px;
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
     <asp:TextBox ID="txtLegajo" class="form-control" runat="server" ValidationGroup="grupo1" Width="800px" style="display:inline-block" AutoPostBack="True" MaxLength="5" OnTextChanged="txtLegajo_TextChanged"></asp:TextBox>
     <asp:Button ID="btnCancelarLegajo" runat="server" Text="Cancelar" style="display:inline-block;height: 40px; width: 150px; padding-left: -10px; background-color: #007bff; color: white; border: none; border-radius: 5px; cursor: pointer" OnClick="btnCancelarLegajo_Click" /> 
    </div>
   
    <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationGroup="grupo1">(*) Complete el campo.</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revLegajo" runat="server" ControlToValidate="txtLegajo" ForeColor="#CC0000" ValidationExpression="^\d+$" ValidationGroup="grupo1">(*) Ingrese solo números.</asp:RegularExpressionValidator>
    
        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="red"></asp:Label>
        <p></p>
    

       <asp:Label ID="Subtitulo" runat="server" Text="Seleccione días de trabajo" CssClass="bold-large label-negro-negrita" Style="align-self: flex-start;"></asp:Label> 
       <p></p>
     
       <asp:CheckBoxList ID="cklDias" runat="server" RepeatDirection="Horizontal" CssClass="horizontal-checkbox" Style= "font-size: 10px; color: black; padding: 10px;" AutoPostBack="True">
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
       
         <asp:Label ID="lblMsjeErrorCargaHorario" runat="server" Text="" ForeColor="red"></asp:Label>
      
        <div style="display: flex; justify-content: space-between; gap: 10px; width: 100%;">
            <div style="width: 48%;"> 
                <asp:Label ID="lblHEntrada" runat="server" Text="Hora de Entrada" Style="align-self: flex-start"></asp:Label>
                <asp:DropDownList ID="ddlHEntrada" class="form-select" runat="server" Style="width: 100%;"  OnSelectedIndexChanged="ddlHEntrada_SelectedIndexChanged"  AutoPostBack="True"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvHEntrada" CssClass="mb-5" runat="server" ControlToValidate="ddlHEntrada" ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>
            </div>

            <div style="width: 48%;"> 
                <asp:Label ID="lblHSalida" runat="server" Text="Hora de Salida" Style="align-self: flex-start"></asp:Label>
                 <asp:DropDownList ID="ddlHSalida" class="form-select" runat="server" Style="width: 100%;" OnSelectedIndexChanged="ddlHSalida_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></asp:DropDownList> 
                
                <asp:RequiredFieldValidator ID="rfvHSalida" CssClass="mb-5" runat="server" ControlToValidate="ddlHSalida" ForeColor="#CC0000" ValidationGroup="grupo1" InitialValue="0">(*) Seleccione una opción.</asp:RequiredFieldValidator>
            </div>
        </div>
       <p></p> 
       <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" Text="Guardar" style="display:inline-block; width: 150px; padding: 10px; background-color: #007bff; color: white; border: none; border-radius: 5px; cursor: pointer" ValidationGroup="grupo1" OnClick="btnGuardar_Click" />



    </div>

</asp:Content>