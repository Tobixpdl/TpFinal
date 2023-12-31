﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallesArticulos.aspx.cs" Inherits="WebApplication1.DetallesArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--<div class="container text-center">
          <div class="row">
            <div class="col-6 col-sm-3">.col-6 .col-sm-3</div>
            <div class="col-6 col-sm-3">.col-6 .col-sm-3</div>

            <!-- Force next columns to break to new line -->
            <div class="w-100"></div>

            <div class="col-6 col-sm-3">.col-6 .col-sm-3</div>
            <div class="col-6 col-sm-3">.col-6 .col-sm-3</div>
          </div>
        </div>--%>
 
    <section class="detalles">
         <div class="card-imgs">
                   <asp:Image ID="imgPublicacion" runat="server" CssClass="img1" />
                   <div class="grilla">
                      <div class="grid-items">
                          <asp:Image ID="imgP2" runat="server" CssClass="img1" />
                      </div>
                      <div class="grid-items">
                          <asp:Image ID="imgP3" runat="server" CssClass="img1" />
                      </div>
                       <div class="grid-items">
                          <asp:Image ID="imgP4" runat="server" CssClass="img1" />
                      </div>
                  </div>
         </div>

        <div class="card-detalle">
               <div class="card">  
                  <h3 class="card-title"><%:artADetallar.Titulo%></h3>
                  <h5 class="card-desc">Descripcion: <%:artADetallar.Descripcion %></h5>
                  <h5 class="card-precio">Precio: <%:artADetallar.Precio %></h5>
                   <h5 class="card-cat">Categoria : <%:artADetallar.Categoria.Nombre %></h5>                 
                  <a href="PerfilUsuario.aspx?User=<%:userDetalle.usuario%>" class="card-user">Creador: <%: userDetalle.usuario%> </a>

                  <h5 class="card-stock">Stock : <%:artADetallar.Stock %></h5>
                  <asp:Button ID="Button2" OnClick="Btn_volver_Click" runat="server" Text="Volver" CssClass="btnBack" />
               </div>
          </div>   
    </section>

    <style>

        .card-imgs {
            display: flex;
            flex-direction: column;
            align-items: center;
            text-align: center;
            max-width: 700px;
            background-color: #fff;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            max-height: 500px;
        }

        .img1 {
            width: 100%;
            max-width: 100%;
            transition:  transform 1s ease;
        }

            .img1:first-child {
                max-width: 300px; 
                max-height:auto;
            }

        .grilla {
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            gap: 10px;
            justify-items:center;
            transition: transform 1s ease;
        }

        .grid-items {
            flex-grow: 1;
            max-width:50%;
        }
            .grid-items:hover {
                transform: scale(2);
                border: 2px solid black;
            }


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
            height:100vh;
            display:flex;
            justify-content:space-evenly;
            align-items: flex-start;
            margin-top: 50px;
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
