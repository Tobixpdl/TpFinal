<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Comprar.aspx.cs" Inherits="WebApplication1.Comprar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-6" style="padding: 10px">
             <div class="container">
                <h2>Datos de contacto</h2>
                    <div class="form-group">
                        <label for="email">Correo electrónico:</label>
                        <input type="email" id="email" name="email" required />
                    </div>
                <h2>Entrega</h2>
                <div class="radio-group">
                    <label>
                        <input type="radio" name="entrega" value="coordinar" checked />
                        A coordinar con el vendedor
                    </label>
                    <label>
                        <input type="radio" name="entrega" value="retirar" />
                        Retirar en X
                    </label>
                </div>              
            </div>
        </div>
    <div class="col-6 col-md-4" style="padding: 10px">
        <div class="container">
            <div class="card">
                <h2>Nombre del artículo</h2>
                <p>Precio: $100</p>
                <img src="ruta_de_la_imagen.jpg" alt="Imagen del artículo" />
                <p>Total de compra: $100</p>
            </div>

            <div class="discount-code">
                <label for="codigo-descuento">Código de descuento:</label>
                <input type="text" id="codigo-descuento" name="codigo-descuento" />
            </div>

            <input type="submit" value="Confirmar compra" />
       </div>
        </div>
        </div>
      <style>

        .container {
            max-width:500px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #f9f9f9;
            margin-bottom: 20px;
        }

        .container h2 {
            margin-top: 0;
        }

        .form-group {
            margin-bottom: 10px;
        }

        .form-group label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        .form-group input[type="text"],
        .form-group input[type="email"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .form-group input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .radio-group {
            margin-bottom: 10px;
        }

        .radio-group label {
            display: block;
            margin-bottom: 5px;
        }

        .card {
            border: 1px solid #ccc;
            padding: 10px;
            margin-bottom: 10px;
            background-color: #fff;
        }

        .card h2 {
            margin-top: 0;
        }

        .card p {
            margin-bottom: 10px;
        }

        .card img {
            max-width: 100%;
        }

        .discount-code {
            margin-top: 10px;
        }
    </style>
</asp:Content>
