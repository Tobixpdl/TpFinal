<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallesArticulos.aspx.cs" Inherits="WebApplication1.DetallesArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="detalles">
         <div class="card-detalle">
                  <div class="card-body">
                        <h3 class="card-title"><%:art.Titulo %></h3>
                        <h5 class="card-text">Descripcion: <%:art.Descripcion %></h5>
                        <h5 class="card-text">Precio: <%:art.Precio %></h5>
                        <h5 class="card-text">Categoria : <%:art.Categoria %></h5>
                        <asp:Button ID="Btn_volver" OnClick="Btn_volver_Click" runat="server" Text="Volver" />
                  </div>
            </div>
    </section>
    <style>
        .div-img{
            display:flex;
            justify-content:center;
            gap: 5px;
        }

        .card-detalle{
            width: 100rem;
            padding: 20px;
            justify-content:center;
            text-align:center;
        }
    </style>

</asp:Content>
