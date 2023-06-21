<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mi_Perfil.aspx.cs" Inherits="WebApplication1.Mi_Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   <div class="container2">
            
            <h2>Mi Perfil</h2>

        <asp:Label ID="lblUserBorrado" runat="server" Text="El usuario fue eliminado" CssClass="userErased"></asp:Label>
            
        <div class="div-content">
            <asp:Label runat="server" ID="lblUsername" Text="Usuario:"></asp:Label>
            <asp:TextBox runat="server" ID="txtUsername" AutoPostBack="true"  AutoComplete="off" PlaceHolder="Nombre de usuario"></asp:TextBox>
            <asp:Label ID="lblWrongUser" runat="server" Text="Este usuario ya existe" CssClass="lblWrong"></asp:Label>
            <asp:Button ID="BtnChangeUser" runat="server" OnClick="Button1_Click" Text="Cambiar nombre de usuario" CssClass="btnClickableText"/>
        </div>

        <div class="div-content">
            <asp:Label runat="server" ID="lblPassword" Text="Contraseña:"></asp:Label>
            <asp:TextBox runat="server" ID="txtPassword" AutoPostBack="true"  AutoComplete="off" PlaceHolder="Contraseña"></asp:TextBox>
            <asp:Button ID="btnChangePass" runat="server" OnClick="btnChangePass_Click" Text="Cambiar contraseña" CssClass="btnClickableText" />
        </div>

        <div class="div-content">
            <asp:Label runat="server" ID="lblMail" Text="Ingrese sus mail:"></asp:Label>
            <asp:TextBox runat="server" ID="txtMail" AutoPostBack="true"  AutoComplete="off" PlaceHolder="Mail"></asp:TextBox>
            <asp:Label ID="lblWrongMail" runat="server" Text="Mail incorrecto" CssClass="lblWrong"></asp:Label>
            <asp:Button ID="btnChangeMail" runat="server" OnClick="btnChangeMail_Click" Text="Cambiar mail" CssClass="btnClickableText" />
        </div>

        <div class="div-content">
            <asp:Label runat="server" ID="lblTelefono" Text="Teléfono:"></asp:Label>
            <asp:TextBox runat="server" ID="txtTelefono" AutoPostBack="true"  AutoComplete="off" PlaceHolder="Número telefónico"></asp:TextBox>
            <asp:Label ID="lblWrongTelefono" runat="server" Text="No es posible tener ese numero" CssClass="lblWrong"></asp:Label>
            <asp:Button ID="btnChangePhone" runat="server" OnClick="btnChangePhone_Click" Text="Cambiar numero de teléfono" CssClass="btnClickableText" />
        </div>

            <div class="buttons">
                <asp:Button ID="BtnChange" runat="server" OnClick="BtnChange_Click" Text="Guardar cambios" CssClass="btnContent"/>
                <a href="Default.aspx" class="btnContent">Atras</a>
            </div>
            <div class="eraseButtons">
                   <asp:Button ID="btnEliminarUser" runat="server" Text="Borrar usuario" CssClass="btnErase" OnClick="btnEliminarUser_Click"/>
                   <asp:Label ID="lblSeguroBorrar" runat="server" Text="Estas Seguro?"></asp:Label>
                   <asp:Button ID="btnYes" runat="server" Text="Borrar definitivamente" OnClick="btnYes_Click" />
                   <asp:Button ID="btnNo" runat="server" Text="Me arrepiento" />
            </div>

          <asp:Label ID="lblChangeUser" runat="server" Text="Cambios Guardados!"></asp:Label>

   </div>
    <div class="updateUser">




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
        .container2 input[type="text"]:focus,
        .container2 input[type="password"]:focus {
            color:forestgreen;
            border: 2px solid green;
            z-index:10;
        }

        .btnContent{
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 15px;
            text-decoration:none;
        }

        .btnErase{
            background-color: darkred;
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

        .eraseButtons{
            display:block;
            padding: 10px;
        }

        .lblWrong{
            color:red;        
            margin-bottom: 10px;
        }

        .lblWrongUs{
            color:red;        
        }

        .active{
            color:forestgreen;
            border: 2px solid green;
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
        
        .userErased{
            font-size:30px;
        }

    </style>




</asp:Content>
