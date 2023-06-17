<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mi_Perfil.aspx.cs" Inherits="WebApplication1.Mi_Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container2">
            
            <h2>Mi Perfil</h2>
            
        <div class="div-content">
            <asp:Label runat="server" ID="lblUsername" Text="Usuario:"></asp:Label>
            <asp:TextBox runat="server" ID="txtUsername" AutoPostBack="true" AutoComplete="off" PlaceHolder="Nombre de usuario"></asp:TextBox>
            <asp:Label ID="lblWrongUser" runat="server" Text="Este usuario ya existe" CssClass="lblWrong"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Cambiar nombre de usuario" CssClass="btnClickableText" />
        </div>

        <div class="div-content">
            <asp:Label runat="server" ID="lblPassword" Text="Contraseña:"></asp:Label>
            <asp:TextBox runat="server" ID="txtPassword" AutoPostBack="true" AutoComplete="off" PlaceHolder="Contraseña"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" Text="Cambiar contraseña" CssClass="btnClickableText" />
        </div>

        <div class="div-content">
            <asp:Label runat="server" ID="lblMail" Text="Ingrese sus mail:"></asp:Label>
            <asp:TextBox runat="server" ID="txtMail" AutoPostBack="true" AutoComplete="off" PlaceHolder="Mail"></asp:TextBox>
            <asp:Label ID="lblWrongMail" runat="server" Text="Mail incorrecto" CssClass="lblWrong"></asp:Label>
            <asp:Button ID="Button4" runat="server" Text="Cambiar mail" CssClass="btnClickableText" />
        </div>

        <div class="div-content">
            <asp:Label runat="server" ID="lblTelefono" Text="Teléfono:"></asp:Label>
            <asp:TextBox runat="server" ID="txtTelefono" AutoPostBack="true" AutoComplete="off" PlaceHolder="Número telefónico"></asp:TextBox>
            <asp:Label ID="lblWrongTelefono" runat="server" Text="No es posible tener ese numero" CssClass="lblWrong"></asp:Label>
            <asp:Button ID="Button5" runat="server" Text="Cambiar numero de teléfono" CssClass="btnClickableText" />
        </div>

            <div class="buttons">
                <asp:Button ID="BtnChange" runat="server" OnClick="BtnChange_Click" Text="Guardar cambios" CssClass="btnContent"/>
                <asp:Button ID="Button2" runat="server" Text="Atras" CssClass="btnContent"/>
            </div>

            <asp:Label ID="lblChangeUser" runat="server" Text="Cambios Guardados!"></asp:Label>

    </div>
    
    <style>        
         .container2{
            width: 500px;
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
        }

        .btnContent{
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 15px;
        }

        .buttons{
            display:flex;
            justify-content:space-between;
            padding-top:5px;
        }

        .lblWrong{
            color:red;        
            margin-bottom: 10px;
        }

        .lblWrongUs{
            color:red;        
        }

        .active{
            color:red;
            background:green;
        }

        .lblChanger{
            /*padding-left:200px;*/
         
        }
        .btnClickableText {
            background: none;
            border: none;
            padding: 0;
            font-size: inherit;
            font-family: inherit;
            color: blue;
            text-decoration: underline;
            cursor: pointer;
            float:right;
            font-size:10px;
        }
        
    </style>




</asp:Content>
