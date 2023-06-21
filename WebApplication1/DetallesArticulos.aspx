<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallesArticulos.aspx.cs" Inherits="WebApplication1.DetallesArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
    <section class="detalles">
        <div class="card-detalle">
            <img src="data:image/png;base64,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" alt="Alternate Text" />
        </div>
         <div class="card-detalle">
               <div class="card">
                  <h3 class="card-title"><%:art.Titulo %></h3>
                  <h5 class="card-desc">Descripcion: <%:art.Descripcion %></h5>
                  <h5 class="card-precio">Precio: <%:art.Precio %></h5>
                  <h5 class="card-cat">Categoria : <%:art.Categoria.Nombre %></h5>
                  <h5 class="card-stock">Stock : <%:art.Stock %></h5>
                  <asp:Button ID="Btn_volver" OnClick="Btn_volver_Click" runat="server" Text="Volver" CssClass="btnBack" />
               </div>
          </div>  
    </section>

    <style>
        .card-detalle{
            display:flex;
            justify-content:center;
            text-align:center;
            align-items:center;
            padding:2rem;
        }
        .card-detalle img{
            max-width:500px;
            height:auto;
            border: 2px solid black;
        }        

        .detalles{
            display:flex;
            justify-content:space-evenly;
        }
        
        /* Card container */
        .card {
          width: 400px;
          background-color: #fff;
          box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
          border-radius: 8px;
          padding: 20px;
          margin-bottom: 20px;
        }

        /* Card title */
        .card .card-title {
          font-size: 24px;
          font-weight: bold;
          margin-bottom: 10px;
        }

        /* Card description */
        .card .card-desc {
          font-size: 16px;
          color: #666;
          margin-bottom: 10px;
        }

        /* Card price */
        .card .card-precio {
          font-size: 20px;
          color: #00c853;
          font-weight: bold;
          margin-bottom: 10px;
        }

        /* Card stock */
        .card .card-stock {
          font-size: 14px;
          color: #666;
        }

        /* Button style */
        .card .btnBack {
          display: inline-block;
          padding: 8px 16px;
          background-color: #00c853;
          color: #fff;
          border-radius: 4px;
          text-decoration: none;
          font-weight: bold;
        }

        .card .btnBack:hover {
          background-color: #00a64d;
        }

        .card .btnBack:focus {
          outline: none;
        }
    </style>

</asp:Content>
