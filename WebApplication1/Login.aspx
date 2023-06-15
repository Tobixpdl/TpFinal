<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
        <div class="container2">
            <h2>Inicio de Sesión</h2>
            <label for="txtUsername">Usuario:</label>
            <input type="text" id="txtUsername" runat="server" />

            <label for="txtPassword">Contraseña:</label>
            <input type="password" id="txtPassword" runat="server" />

            <input type="submit" value="Iniciar Sesión" runat="server" />
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
