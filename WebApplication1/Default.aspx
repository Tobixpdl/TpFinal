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
   <header class="header">
    <section class="nav-bar">
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
        <>--%>
                         <div class="container text-center btnCarrito " id="count">
                           <div class="row">
                               <div class="col">
                                  <asp:Button ID="btnCarro" runat="server" CssClass="btn btn-primary "  OnClick="btnCarro_Click" type="button" Text="Carrito " />
                               </div>
                               <div class="col">
                                   <div>           
                                       <asp:Label ID="lblCompra"  runat="server" CssClass="count" ></asp:Label>
                                  </div>  
                               </div>
                            </div>
                       </div>
    </section>
  </header>
        

    <section class="articulos">
        <div class="mega-main">
                <div class="main">
                    <asp:Repeater ID="rprCards" runat="server">
                        <ItemTemplate>
                                     <div class="flip-card">
                                        <div class="flip-card-inner">
                                            <div class="flip-card-front">
                                               <img id="img-flip-card" src="<%#Eval("imagenes[0].Url") %>" alt="NO IMAGE">                                            
                                                <p class="title"><%#Eval("Titulo")%></p>
                                                    <p>$<%#Eval("Precio") %></p>
                                                    <div class="d-grid gap-2 d-md-block">              
                                                    </div>
                                            </div>
                                            <div class="flip-card-back">
                                               <h5 class="card-title"><%#Eval("Titulo") %></h5>
                                                <div class="btns">
                                                        <asp:Button ID="btnAdd" runat="server"  CssClass="btn-botones" OnClick="btnAdd_Click" type="button" Text=" Agregar " 
                                                            CommandArgument='<% #Eval("Id")%>' CommandName="artId" />
                                                      <a href="DetallesArticulos.aspx?Id=<%#Eval("Id") %>" class="btn-botones">Detalles</a>                                                      
                                              </div>
                                           </div>
                                        </div>
                                    </div>    
                        </ItemTemplate>
                    </asp:Repeater>
                 </div>
            </div>
        </section>

    <style>



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
  flex: 1;
  padding: 10px;
  margin-left:10px;
}

 .FiltroPrecio {
float:right;    
margin:5px;
padding:5px;
 }
        

    </style>

</asp:Content>

