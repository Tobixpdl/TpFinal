<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebApplication1.Formulario_web2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
 
        <div class="container2">
            
            <h2>Registro</h2>

            <asp:Label runat="server" ID="lblNombres" Text="Ingrese sus nombres:"></asp:Label>
            <asp:TextBox runat="server" ID="txtNombres" AutoPostBack="true" AutoComplete="off" PlaceHolder="Nombres"></asp:TextBox>

            <asp:Label runat="server" ID="lblApellidos" Text="Ingrese sus apellidos:"></asp:Label>
            <asp:TextBox runat="server" ID="txtApellidos" AutoPostBack="true" AutoComplete="off" PlaceHolder="Apellidos"></asp:TextBox>

            <asp:Label runat="server" ID="lblDNI" Text="Ingrese su DNI:"></asp:Label>
            <asp:TextBox runat="server" ID="txtDNI" AutoPostBack="true" AutoComplete="off" PlaceHolder="DNI"></asp:TextBox>

            <asp:Label runat="server" ID="lblTelefono" Text="Ingrese su teléfono:"></asp:Label>
            <asp:TextBox runat="server" ID="txtTelefono" AutoPostBack="true" AutoComplete="off" PlaceHolder="Número telefónico"></asp:TextBox>

            <asp:Label runat="server" ID="lblMail" Text="Ingrese sus mail:"></asp:Label>
            <asp:TextBox runat="server" ID="txtMail" AutoPostBack="true" AutoComplete="off" PlaceHolder="Mail"></asp:TextBox>

            <asp:Label runat="server" ID="lblUsername" Text="Ingrese un nombre de usuario:"></asp:Label>
            <asp:TextBox runat="server" ID="txtUsername" AutoPostBack="true" AutoComplete="off" PlaceHolder="Nombre de usuario"></asp:TextBox>

            <asp:Label runat="server" ID="lblPassword" Text="Ingrese una contraseña:"></asp:Label>
            <asp:TextBox runat="server" ID="txtPassword" AutoPostBack="true" AutoComplete="off" PlaceHolder="Contraseña"></asp:TextBox>

            <asp:Label runat="server" ID="Label1" Text="Ingrese su contraseña nuevamente:"></asp:Label>
            <asp:TextBox runat="server" ID="TextBox1" AutoPostBack="true" AutoComplete="off" PlaceHolder="Contraseña"></asp:TextBox>


            <asp:Button runat="server" ID="btnEnter" Text="Ingresar"></asp:Button>

            </div>
     <style>
        .container2{
            width: 300px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #f4f4f4;
            display: flex;
            flex-direction: column;
        }

        .container2 h2 {
            text-align: center;
        }

        .container2 label {
            display: block;
            margin-bottom: 10px;
        }

        .container2 input[type="text"],
        .container2 input[type="password"] {
            width: 100%;
            padding: 5px;
            margin-bottom: 10px;
        }

        .container2 input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
        }
        
    </style>
</asp:Content>
