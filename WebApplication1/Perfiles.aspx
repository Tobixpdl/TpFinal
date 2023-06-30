<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfiles.aspx.cs" Inherits="WebApplication1.Perfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section class="articulosXPerfil">
<asp:Label ID="lblNombre1" runat="server"></asp:Label>

        <div class="mega-main">
                <div class="main">
                    <div class="container-items">
                    <asp:Repeater ID="rprCards1" runat="server">
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

 
     <section class="articulosXPerfil">
                                   <asp:Label ID="lblNombre2" runat="server"></asp:Label>
        <div class="mega-main">
                <div class="main">
                    <asp:Repeater ID="rprCards2" runat="server">
                        <ItemTemplate>
                                     <div class="flip-card">
                                        <div class="flip-card-inner">
                                            <div class="flip-card-front">
                                              <asp:Image ID="imgPublicacion" runat="server" 
                           CssClass="img-fluid mb-3" OnPreRender="imgPublicacion_PreRender" ImageUrl=<%#ReturnUrl(Container.DataItem)%>/>                                        
                                                <p class="title"><%#Eval("Titulo")%></p>
                                                    <p>$<%#Eval("Precio") %></p>
                                                    <div class="d-grid gap-2 d-md-block">              
                                                    </div>
                                            </div>
                                            <div class="flip-card-back">
                                               <h5 class="card-title"><%#Eval("Titulo") %></h5>
                                                <p><%#Eval("Descripcion") %></p>
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
                        

     <section class="articulosXPerfil">
                                   <asp:Label ID="lblNombre3" runat="server"></asp:Label>

        <div class="mega-main">
                <div class="main">
                    <asp:Repeater ID="rprCards3" runat="server">
                        <ItemTemplate>
                                     <div class="flip-card">
                                        <div class="flip-card-inner">
                                            <div class="flip-card-front">
                                              <asp:Image ID="imgPublicacion" runat="server" 
                           CssClass="img-fluid mb-3" OnPreRender="imgPublicacion_PreRender" ImageUrl=<%#ReturnUrl(Container.DataItem)%>/>                                        
                                                <p class="title"><%#Eval("Titulo")%></p>
                                                    <p>$<%#Eval("Precio") %></p>
                                                    <div class="d-grid gap-2 d-md-block">              
                                                    </div>
                                            </div>
                                            <div class="flip-card-back">
                                               <h5 class="card-title"><%#Eval("Titulo") %></h5>
                                                <p><%#Eval("Descripcion") %></p>
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



    </style>

</asp:Content>
