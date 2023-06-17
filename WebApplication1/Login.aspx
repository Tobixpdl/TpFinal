<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


                <div class="container2">        
                    <h2>Inicio de Sesión</h2>
                    <asp:Label runat="server" ID="lblUsername" Text="Usuario:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtUsername" AutoPostBack="true" AutoComplete="off" PlaceHolder="Nombre de usuario"></asp:TextBox>

                    <asp:Label runat="server" ID="lblPassword" Text="Contraseña:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPassword" AutoPostBack="true" AutoComplete="off" PlaceHolder="Ingrese su contraseña"></asp:TextBox>

                    <asp:Button runat="server" ID="btnEnter" Text="Ingresar" OnClick="btnEnter_Click"></asp:Button>
                    <label>No tenes cuenta? </label><a href="Registro.aspx">Registrate</a>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
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
            display:block;
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
