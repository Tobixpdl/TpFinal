<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-wrapper">
               <div class="container1">
                   <div class="inner-container1">
                       <h6>DEFAULT USER</h6>
                       <h7>USUARIO:<span>usuario0</span></h7>
                       <h7>CONTRASEÑA:<span>1234</span></h7>
                   </div>
               </div>
                <div class="container2">        
                    <h2>Inicio de Sesión</h2>

                    <asp:Label runat="server" ID="lblUsername" Text="Usuario:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtUsername" AutoComplete="off" PlaceHolder="Nombre de usuario" Text="usuario0"></asp:TextBox>                  

                    <asp:Label runat="server" ID="lblPassword" Text="Contraseña:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPassword" AutoComplete="off" TextMode="Password" PlaceHolder="Ingrese su contraseña" Text="1234"></asp:TextBox>

                    <asp:Button runat="server" ID="btnEnter" Text="Ingresar" OnClick="btnEnter_Click"></asp:Button>
                    <label>No tenes cuenta? </label><a href="Registro.aspx">Registrate</a>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
               </div>
        </div>

   <style>
       .container-wrapper {
            display: flex;
            justify-content: center; /* Center the flex items horizontally */
            align-items: center; /* Center the flex items vertically */
        }

        .container1 {
            max-width: 170px;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #f4f4f4;
            display: flex;
            flex-direction: column;
        }

        .container1 h7{
            justify-content:space-between;
        }

        .container1 span{
           color:mediumvioletred;
        }

        .container2 {
            max-width: 300px;
            margin-left: 20px; /* Add a margin to create space between container1 and container2 */
            padding: 10px;
            border: 1px solid #ccc;
            background-color: #f4f4f4;
            display: flex;
            flex-direction: column;
        }

        .container2 h2 {
            text-align: center;
        }

        .container2 label {
            display: flex;
            justify-content: space-between;
        }

        .container2 input[type="text"],
        .container2 input[type="password"] {
            text-decoration: none;
            width: 100%;
            padding: 5px;
            margin-bottom: 10px;
        }

        .container2 input[type="text"]:focus,
        .container2 input[type="password"]:focus {
            border: 2px solid green;
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
