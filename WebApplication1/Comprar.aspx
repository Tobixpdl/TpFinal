<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Comprar.aspx.cs" Inherits="WebApplication1.Comprar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script>
    $(document).ready(function() {
        $('.stockBox').on('input', function() {
            var value = $(this).val();
            if (value < 1) {
                $(this).val(1);
            }
        });
    });
    </script>

    <div class="row">
        <div class="col-6" style="padding: 10px">
             <div class="container">
                <h2>Datos de contacto</h2>
                    <div class="form-group">
                        <label for="email">Correo electrónico:</label>
                        <asp:TextBox ID="txtMail" runat="server" AutoPostBack="true" AutoComplete="off" PlaceHolder="Mail" TextMode="Email"></asp:TextBox>
                        <label for="name">Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" AutoPostBack="true" AutoComplete="off" PlaceHolder="Nombre"></asp:TextBox>
                    </div>
                <h2>Entrega</h2>
                <div class="radio-group">
                    <asp:RadioButton ID="rbCoordinar" runat="server" Text="Coordinar con vendedor" TextAlign="Right" GroupName="opcion" />
                    <asp:RadioButton ID="rbRetirar" runat="server" Text="Retirar en x" TextAlign="Right" GroupName="opcion" />
                </div>               
            </div>
        </div>
    <div class="col-6 col-md-4" style="padding: 10px">
        <div class="container">
            <div class="card">
                        <div class="card">
                            <div class="img-container">
                              <asp:Image ID="imgPublicacion" runat="server" 
                              CssClass="card-img"  ImageUrl=<%#ReturnUrl(listaDeCompras)%>/> 
                            </div>
                            <div>
                               <h2><%:listaDeCompras.Titulo%></h2>
                               <p>Precio: $<%:listaDeCompras.Precio%></p>
                                <div class="stock-container">
                                    <p>Cantidad:</p>
                                    <asp:TextBox ID="txtStock" runat="server" type="number" CssClass="stockBox"></asp:TextBox>
                                </div> 
                           </div>
                       </div>
                <p>Total de compra: $<asp:Literal ID="TotalLiteral" runat="server" /></p>
            </div>

            <div class="discount-code">
                <label for="codigo-descuento">Código de descuento:</label>
                <input type="text" id="codigo-descuento" name="codigo-descuento" />
            </div>

            <asp:Button ID="btnComprar" runat="server" CssClass="btn-info" Text="Confirmar Compra" OnClick="btnComprar_Click"/>
       </div>
        </div>
        </div>
      <style>

        .container {
            max-width: 500px;
            margin: 0 auto;
            padding: 20px;
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
            display: flex;
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
            display: flex;
            align-items: center;
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

        .card .img-container {
            flex-shrink: 0;
            margin-left: 10px;
        }

        .card .card-img {
            max-width: 100%;
            height: auto;
            max-height: 50px;
        }

        .discount-code {
            margin-top: 10px;
        }

        .stock-container{
            display: flex;
            align-items: center;
        }

        .stockBox{
            max-width: 35px;
        }
    </style>
</asp:Content>
