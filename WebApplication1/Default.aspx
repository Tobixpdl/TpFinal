    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>       
 
    <script type="text/javascript">
        function bloquearEnter(event) {
            if (event.keyCode === 13) {
                event.preventDefault();
                return false;
            }
        }
    </script>
      <%--    <%
  <div id="search-container">
         <input type="text" id="search-box" placeholder="Buscar">
         </div>
    <>--%>

     <%--    <%
        

            <%if (FiltroAvanzado) {%> 
            <div class="BusquedaAvanzadaContenido">
            <div class="row">
                    <div class="col">
                            <div class="BusAvanzado">
                                <asp:Label Text="Categoria" runat="server" />
                                <asp:DropDownList runat="server" ID="ddlCategoria" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>    
                    </div>
                    <div class="col">
                            <div class="BusAvanzado">
                                <asp:Label Text="Marca" runat="server"/>
                                <asp:DropDownList runat="server" ID="ddlMarca" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>    
                    </div>
                    <div class="col">
                            <div class="BusAvanzado">
                                <asp:Label Text="Filtro" runat="server" />
                                <asp:TextBox runat="server" ID="txtBusAvanzada" CssClass="search-box" AutoPostBack="true" OnTextChanged="txtBusAvanzada_TextChanged" AutoComplete="off" Enabled="false"/>
                            </div>    
                    </div>
            </div>
                </div>
            <% } %>
        <>--%>      <%--    <%--    <%

                         <div class="container text-center btnCarrito " id="count">
                           <>--%>
    <div class="headerT">
        <div class="rowT">
            <div class="col-2T">
                <h1>Compra todo <br/>en un mismo lugar!</h1>
                <p>Descubre un mundo de compras ilimitadas donde tus deseos se hacen realidad.<br/> Encuentra todo lo que necesitas aquí.</p>
            </div>
            <div class="col-2T">
                <%-- ACA VA UNA IMAGEN PARA LA DEFAULT --%>
                <img src="\Images\imgProductos.png" alt="Alternate Text" />
            </div>
        </div>
    </div>
          <%-- Buscador --%>
          <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>              
                        <section id="search-box">
                             <asp:TextBox runat="server" ID="txtBusqueda" CssClass="search-box" AutoComplete="off" PlaceHolder="Búsqueda" onkeydown="return bloquearEnter(event)"/>
                             <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn-Enter" OnClick="BtnBuscar_Click" />                                          
                             <asp:Label runat="server" ID="BusquedaNull" Text="No se encontraron resultados" CssClass="lblBusqueda"></asp:Label>
                        </section>           

    <%-- TODOS LOS ARTICULOS y filtro --%>

    <section class="articulos">
        <div class="mega-main">
                <div class="main">

                    <h2 class="titleT">Todos los productos</h2>
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
                                            <asp:Button ID="Button1" runat="server"  CssClass="btn-info" OnClick="btnAdd_Click" type="button" Text="Agregar" 
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
            </ContentTemplate>
</asp:UpdatePanel>

              <%-- ARTICULOS TOP --%>

    

        </section>

    <style>

        .headerT{
            /*background: var(--bgColor);*/
            background: linear-gradient(to top, var(--bgColor) 5%, #ffffff 95%);
            height: 25vh;
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
            padding: 20px;
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

        .titleT{
            text-align: center;
            position:relative;
            line-height:60px;
            color:var(--textColorBlack);
            padding-top: 5px;
            margin: 0 auto 10px;
        }

        .titleT::after{
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

        .container-items2{
            flex-basis:25%;
            display:grid;
            grid-template-columns:repeat(3,1fr);
            margin: 0 150px;
            gap: 100px;
        }

        .container-items2 .item{
        }

        .img-{
            max-width:100%;
        }
        .container-items{
            display:grid;
            grid-template-columns:repeat(4,1fr);
            gap:100px;
        }

        .item{
            border-radius:10px;
        }

        .item:hover{
            box-shadow:0 10px 20px rgba(0,0,0,0.20);
        }

        .info-product{
            padding: 15px 30px;
            line-height:2;
            display:flex;
            flex-direction:column;
            gap:20px;
        }

        .info-product .info-title{
            height:70px;
        }

        .item .img-{
            width:100%;
            height:300px;
            object-fit:cover;
            border-radius:10px 10px 0 0;
            transition: all .5s;
        }

        .item figure{
            overflow:hidden;
        }

        .item .img-:hover{
            transform:scale(1.2);
        }

        .price{
            font-size:28px;
            font-weight:900;
        }

        .info-product .btn-info{
            border:none;
            background:none;
            text-decoration:none;
            background:var(--textColorBlack);
            color:var(--textColorWhite);
            padding:15px 10px;
            cursor:pointer;
            text-align:center;
            transition: all 0.5s;
        }

        .info-product .btn-info:hover{
            background:grey;
        }

        .btn-favs {
            max-width: 30px;
            max-height: 30px;
            background-color: transparent;
            border: 2px solid red;
            color: black;
            transition: background-color 0.3s ease;
        }

        .btn-favs.clicked {
            background-color: red;
            border: none;
            color: white;
        }
        
        

 #search-box {
        width: 350px;
        padding: 20px;
        border: none;
        border-radius: 0,5px;
        align-content:center;
        margin:25px;
  } 
 .lblBusqueda {
   
     margin-left:50px;
        }
 .BusquedaAvanzadaContenido{
     
  display: flex;
  justify-content: space-around;
  margin: 0 10px;
 }
.row{
  display: flex;
  width: 100%;

}
.col{
  flex: 0;
  margin-left:50px;
  padding: 10px;
  align-content:space-around;
}

 .FiltroPrecio {
float:right;    
margin:5px;
padding:5px;
 }
  .btn-Enter{
    width: 25%;
    padding: 3px;
    background-color: var(--otherColor);
    color: #fff;
    border: none;
    border-radius: 2px;
    cursor: pointer;
    margin-left: 3px;
    margin-right: 3px;
}
  }     

    </style>

</asp:Content>

