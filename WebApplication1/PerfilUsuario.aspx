<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="WebApplication1.PerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
    <h2>Perfil de Usuario</h2>
    <div>
        <div>
<p><strong> Usuario:</strong></p>
<asp:Label ID="UsuarioNombre" runat="server"></asp:Label>

            <p><strong> Reputacion: <%:reputacion%></strong></p>
<asp:Label ID="lblRep" runat="server"></asp:Label>
        </div>        

    </div>


         <div class="container-commits">
       <asp:Repeater id="rprComentarios" runat="server">
            <ItemTemplate>

                   <div class="card-detalle">
               <div class="card">  
                  <h3 class="card-title"> <%#Eval("Remitente")%></h3>
                  <h5 class="card-desc"><%#Eval("Mensaje")%> </h5>
                  <h5 class="card-precio"><%#Eval("Reputacion")%> </h5>
                 
               </div>
          </div>   


            </ItemTemplate>
        </asp:Repeater>
        </div>

    <hr />

     <section class="articulos">
        <div class="mega-main">
                <div class="main">
                    <h2 class="titleProductos">Productos de <%:SelectedUser.usuario %></h2>
                    <div class="container-items">
                    <asp:Repeater ID="rprCards" runat="server">
                     <ItemTemplate>
			                    <div class="item">
				                    <figure>
					                     <asp:Image ID="imgPublicacion" runat="server" 
                                         CssClass="img-" OnPreRender="imgPublicacion_PreRender" ImageUrl=<%#ReturnUrl(Container.DataItem)%>/>                                                                          
				                    </figure>
				                    <div class="info-product">
                                        <h2 class="info-title"><%#Eval("Titulo")%></h2>
					                    <p class="price">$<%#Eval("Precio")%></p>
                                       <%if (this.Session["activeUser"] != null)
                                        {%>
                                            <asp:Button ID="Button1" runat="server"  CssClass="btn-info" OnClick="btnAdd_Click" type="button" Text="Agregar a favoritos" 
                                            CommandArgument ='<% #Eval("Id")%>' CommandName="artId" /> 
                                        <%}%>
                                        <a href="DetallesArticulos.aspx?Id=<%#Eval("Id") %>" class="btn-info">Ver detalles</a>
                                    </div>
			                   </div>
                      </ItemTemplate>
                    </asp:Repeater>
                  </div>
                 </div>
            </div>
        </section>


    <style>
        .container-commits {
            display: grid;
            grid-template-columns: repeat(3,1fr);
            gap: 1px;
            align-items: baseline;
            justify-content: start;
            align-content: center;
        }

        .grilla {
            display: grid;
            grid-template-columns: repeat(10, 1fr);
            gap: 1px;
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
            text-align:justify;
            align-items:center;
            padding:0.5rem;
            max-width:100%;
        }
              

        .detalles{
            display:flex;
            justify-content:space-evenly;
        }
        
        /* Card container */
        .card {
          width: 600px;
          background-color: #fff;
          box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
          border-radius: 8px;
          padding: 20px;
          margin-bottom: 1px;
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
          margin-bottom: 1px;
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
         .titleProductos{
            text-align: center;
            position:relative;
            line-height:60px;
            color:var(--textColorBlack);
            padding-top: 20px;
            margin: 0 auto 80px;
        }

        .titleProductos::after{
            content:'';
            background: var(--bgColor);
            width:80px;
            height:5px;
            border-radius:5px;
            position:absolute;
            bottom:0;
            left:50%;
            transform: translateX(-50%);
        }
    </style>


</asp:Content>
