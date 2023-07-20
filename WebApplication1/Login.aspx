<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="account-login">
        <div class="rowT">
            <div class="col-2T">
                <img src="\Images\imgProductosNew.png" alt="Alternate Text" />
            </div>
            <div class="col-2T">
                <div class="form-container">
                    <h2>Inicio de Sesión</h2>
                     <hr id="indicator"/>
                     <asp:Label runat="server" ID="lblUsername" Text="Usuario:" CssClass="lblForm"></asp:Label>
                     <asp:TextBox runat="server" ID="txtUsername" AutoComplete="off" PlaceHolder="Nombre de usuario" Text=""></asp:TextBox>                  
                     
                     <asp:Label runat="server" ID="lblPassword" Text="Contraseña:" CssClass="lblForm"></asp:Label>
                     <asp:TextBox runat="server" ID="txtPassword" AutoComplete="off" TextMode="Password" PlaceHolder="Ingrese su contraseña" Text="1234"></asp:TextBox>

                     <asp:Button runat="server" ID="btnEnter" Text="Ingresar" OnClick="btnEnter_Click" ></asp:Button>
                     <label>No tenes cuenta? </label><a href="Registro.aspx">Registrate</a>
                     <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <style>
        .account-login{
            padding:50px 0;
            background: linear-gradient(to bottom, var(--newBg) 5%, #ffffff 95%);
            height:90vh;
        }

        .form-container{
            background:var(--textColorWhite);
            width:400px;
            height:500px;
            position:relative;
            text-align:center;
            padding:20px 0; 
            margin:auto;
            box-shadow: 0 0 20px 0 rgba(0,0,0,0.1);
            border-radius: 10px;
            display:inline-grid;
            justify-content:center;
            align-items:center;
        }

        .form-container h2{
            font-weight:bold;
            padding: 0 10px;
            color:var(--textColorBlack);
            cursor:pointer;
        }

        .rowT{
            display:flex;
            flex-wrap: wrap;
            justify-content:space-around;
        }

        .col-2T {
            color:var(--textColorWhite);
            text-shadow: 1px 1px 1px var(--textColorBlack);
            flex-basis: 50%;
            min-width: 300px;
            padding: 100px;
        }

        .col-2T img{
            max-width:100%;
            padding: 50px 0;
        }

        .col-2T h1{
            font-size:70px;
            line-height: 60px;
            margin: 25px 0;
        }

        .col-2T p{
            font-size:20px;
        }

        #indicator{
            border:none;
            background:var(--bgColor);
            height: 3px;
            margin-top: 8px;
            width:250px;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .lblForm{
            color: var(--textColorBlack);
        }

        .form-container input[type="text"]:focus,
        .form-container input[type="password"]:focus {
            border-color: green;
        }

        .form-container input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color:var(--otherColor);
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

    </style>



<%--        <div class="container-wrapper">
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
    </style>--%>
</asp:Content>
