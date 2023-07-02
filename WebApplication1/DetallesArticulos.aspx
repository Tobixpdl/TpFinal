<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallesArticulos.aspx.cs" Inherits="WebApplication1.DetallesArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
    <section class="detalles">
         <div class="card-detalle">
                   <asp:Image ID="imgPublicacion" runat="server" 
                           CssClass="img-fluid mb-3" />
         </div>
        <div class="card-detalle">
               <div class="card">  
                  <h3 class="card-title"><%:artADetallar.Titulo%></h3>
                  <h5 class="card-desc">Descripcion: <%:artADetallar.Descripcion %></h5>
                  <h5 class="card-precio">Precio: <%:artADetallar.Precio %></h5>
                   <h5 class="card-cat">Categoria : <%:artADetallar.Categoria.Nombre %></h5>                 
                  <a href="PerfilUsuario.aspx?User=<%#Eval(userDetalle.usuario)%>" class="card-user">Creador: <%: userDetalle.usuario%> </a>

                  <h5 class="card-stock">Stock : <%:artADetallar.Stock %></h5>
                  <asp:Button ID="Button2" OnClick="Btn_volver_Click" runat="server" Text="Volver" CssClass="btnBack" />
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
