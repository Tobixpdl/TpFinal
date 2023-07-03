<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="WebApplication1.PerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
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
    <h2>Perfil de Usuario</h2>
    <div>
        <div>
<p><strong> Usuario:</strong></p>
<asp:Label ID="UsuarioNombre" runat="server"></asp:Label>
        </div>        
        <div>
<p><strong>Correo Electrónico:</strong></p>
<asp:Label ID="EMail" runat="server"></asp:Label>

        </div>
        <div>
<p><strong>Teléfono:</strong></p>
<asp:Label ID="Tel" runat="server"></asp:Label>

        </div>
        

    </div>

    <hr />

    <h3>Publicaciones</h3>

     <section class="articulos">
        <div class="mega-main">
                <div class="main">
                    <h2 class="titleT">Mas productos de <%:SelectedUser.usuario %></h2>
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
                                        <asp:Button ID="btnAdd" runat="server"  CssClass="btn-info" OnClick="btnAdd_Click" type="button" Text="Agregar al carrito" 
                                        CommandArgument ='<% #Eval("Id")%>' CommandName="artId" />
                                        <a href="DetallesArticulos.aspx?Id=<%#Eval("Id") %>" class="btn-info">Ver detalles</a>
                                    </div>
			                   </div>
                      </ItemTemplate>
                    </asp:Repeater>
                  </div>
                 </div>
            </div>
        </section>


</asp:Content>
