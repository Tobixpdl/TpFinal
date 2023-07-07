<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="favorito.aspx.cs" Inherits="WebApplication1.favorito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

      <%if (contador == 0 && this.Session["activeUser"] != null )
       {
%>
            <h1 class="titleT">No hay elementos favoritos</h1>
            <asp:Button ID="btnIrADefault" runat="server" OnClick="btnBack_Click"  CssClass="btn btn-primary me-md-2" type="button" Text="Continuar Comprando" />  
    <% }
       else if(this.Session["activeUser"] == null)
       {%>
            <h1 class="titleT">Logueate para ver tus articulos favoritos!</h1>
            <a class="btn-info" runat="server" href="Login.aspx" id="liLogin">Login</a>
     <%}
        
       else
       {  %>
             <section class="articulos">
                <div class="mega-main">
                        <div class="main">
                            <h2 class="titleT">Mis favoritos</h2>
                            <div class="container-items">
                            <asp:Repeater ID="rprCards" runat="server">
                             <ItemTemplate>
			                            <div class="item">
				                            <figure>
					                             <asp:Image ID="imgPublicacion" runat="server" 
                                                 CssClass="img-" ImageUrl=<%#ReturnUrl(Container.DataItem)%>/>                                                                          
				                            </figure>
				                            <div class="info-product">
                                                <h2 class="info-title"><%#Eval("Titulo")%></h2>
					                            <p class="price">$<%#Eval("Precio")%></p>
                                                <a href="Comprar.aspx?Id=<%#Eval("Id") %>" class="btn-info">Comprar</a>
                                                <a href="DetallesArticulos.aspx?Id=<%#Eval("Id") %>" class="btn-info">Ver detalles</a>                     
                                                <asp:Button ID="btnEliminarFav" OnClick="btnEliminarFav_Click" runat="server" CssClass="btn-info" Text="Quitar" />
                                           </div>
			                           </div>
                              </ItemTemplate>
                            </asp:Repeater>
                          </div>
                         </div>
                    </div>
                </section>
    <%} %>


</asp:Content>
