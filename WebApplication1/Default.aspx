    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>       

      <%--    <%
  <div id="search-container">
         <input type="text" id="search-box" placeholder="Buscar">
         </div>
    <>--%>

     <%--    <%
           <div id="search-container">
                      <asp:TextBox runat="server" ID="txtBusqueda" CssClass="search-box" AutoPostBack="true" OnTextChanged="Busqueda_TextChanged" AutoComplete="off" PlaceHolder="Búsqueda"/>
                      <asp:CheckBox runat="server" ID="chBusqueda" Text="Filtrar" OnCheckedChanged="chBusqueda_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
   <asp:Button runat="server" Text="Button"></asp:Button>                   <asp:Label runat="server" ID="BusquedaNull" Text="No se encontraron resultados" CssClass="lblBusqueda"></asp:Label>
                      <asp:CheckBox runat="server" CssClass="FiltroPrecio" ID="chMenorPrecio" Text="Menor precio" OnCheckedChanged="chMenorPrecio_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                      <asp:CheckBox runat="server" CssClass="FiltroPrecio" ID="chMayorPrecio" Text="Mayor precio" OnCheckedChanged="chMayorPrecio_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
           </div>        

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
                            <div class="row">
                               <div class="col">
                                  <asp:Button ID="btnCarro" runat="server" CssClass="btn btn-primary "  OnClick="btnCarro_Click" type="button" Text="Carrito " />
                               </div>
                               <div class="col">
                                   <div>           
                                       <asp:Label ID="lblCompra"  runat="server" CssClass="contador" ></asp:Label>
                                  </div>  
                               </div>
                            </div>
                         <%--  </div><>--%>

    

    <section class="articulos">
        <div class="mega-main">
                <div class="main">
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
                                        <asp:Button ID="btnAdd" runat="server"  CssClass="btn-info" OnClick="btnAdd_Click" type="button" Text="Agregar" 
                                        CommandArgument ='<% #Eval("Id")%>' CommandName="artId" />
                                        <a href="DetallesArticulos.aspx?Id=<%#Eval("Id") %>" class="btn-info">Detalles</a>					                    
                                    </div>
			                   </div>
                           
                      </ItemTemplate>
                    </asp:Repeater>
                  </div>
                 </div>
            </div>
        </section>

    <style>

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
            background:black;
            color:white;
            padding:15px 10px;
            cursor:pointer;
            text-align:center;
            transition: all 0.5s;
        }

        .info-product .btn-info:hover{
            background:grey;
        }
        

 #search-box {
        width: 200px;
        padding: 5px;
        border: none;
        border-radius: 0,5px;
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
.contador{
  flex: 0;
  padding: 5px;
  align-content:space-around;
      color: #ffffff;
    background-color: #ff0000;
    border-radius: 10px;
    height: 23px;
    align-items: center;
    position: relative;
    display: flex;
    max-width: none;

}
 .FiltroPrecio {
float:right;    
margin:5px;
padding:5px;
 }
        

    </style>

</asp:Content>

