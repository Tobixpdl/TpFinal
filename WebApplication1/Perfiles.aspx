<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfiles.aspx.cs" Inherits="WebApplication1.Perfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <nav class="navbar">
        <ul>
            <li>
                 <a href="Mi_Perfil.aspx">
                   <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 448 512"><path d="M304 128a80 80 0 1 0 -160 0 80 80 0 1 0 160 0zM96 128a128 128 0 1 1 256 0A128 128 0 1 1 96 128zM49.3 464H398.7c-8.9-63.3-63.3-112-129-112H178.3c-65.7 0-120.1 48.7-129 112zM0 482.3C0 383.8 79.8 304 178.3 304h91.4C368.2 304 448 383.8 448 482.3c0 16.4-13.3 29.7-29.7 29.7H29.7C13.3 512 0 498.7 0 482.3z"/></svg>
                   <span class="nav-item">Perfil</span>
                 </a>
            </li>     
             <li>
                 <a href="Publicaciones.aspx">
                    <asp:Button ID="btnPublicaciones" runat="server" CssClass="btn btn-primary "  OnClick="btnPublicaciones_Click" type="button" Text="Mis Publicaciones " />
                   <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 576 512"><path d="M0 24C0 10.7 10.7 0 24 0H69.5c22 0 41.5 12.8 50.6 32h411c26.3 0 45.5 25 38.6 50.4l-41 152.3c-8.5 31.4-37 53.3-69.5 53.3H170.7l5.4 28.5c2.2 11.3 12.1 19.5 23.6 19.5H488c13.3 0 24 10.7 24 24s-10.7 24-24 24H199.7c-34.6 0-64.3-24.6-70.7-58.5L77.4 54.5c-.7-3.8-4-6.5-7.9-6.5H24C10.7 48 0 37.3 0 24zM128 464a48 48 0 1 1 96 0 48 48 0 1 1 -96 0zm336-48a48 48 0 1 1 0 96 48 48 0 1 1 0-96z"/></svg>
                   <span class="nav-item">Mis Productos</span>
                </a>
           </li>    
            

        </ul>
    </nav>

     <section class="articulosXPerfil">
<asp:Label ID="lblNombre1" runat="server"></asp:Label>

        <div class="mega-main">
                <div class="main">
                    <asp:Repeater ID="rprCards1" runat="server">
                        <ItemTemplate>
                                     <div class="flip-card">
                                        <div class="flip-card-inner">
                                            <div class="flip-card-front">
<%--                                                   <img id="img-flip-card" src="<%#Eval("Url_Imagen") %>" alt="NO IMAGE">--%>
                                                   
                                                <p class="title"><%#Eval("Titulo")%></p>
                                                    <p><%#Eval("Precio") %></p>
                                                    <div class="d-grid gap-2 d-md-block">              
                                                    </div>
                                            </div>
                                            <div class="flip-card-back">
                                               <h5 class="card-title"><%#Eval("Titulo") %></h5>
                                                <p class="card-text"><small class="text-body-secondary"><%#Eval("Descripcion")%></small></p>
                                                <div class="btns">
                                                        <asp:Button ID="btnAdd" runat="server"  CssClass="btn-botones" OnClick="btnAdd_Click" type="button" Text=" Agregar " 
                                                            CommandArgument='<% #Eval("Id")%>' CommandName="artId" />
                                                      <a href="DetallesArticulos.aspx?Titulo=<%#Eval("Titulo") %>" class="btn-botones">Detalles</a>                                                      
                                              </div>
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
                                   <asp:Label ID="lblNombre2" runat="server"></asp:Label>

        <div class="mega-main">
                <div class="main">
                   <asp:Repeater ID="rprCards2" runat="server">
                        <ItemTemplate>
                                     <div class="flip-card">
                                        <div class="flip-card-inner">
                                            <div class="flip-card-front">
<%--                                                   <img id="img-flip-card" src="<%#Eval("Url_Imagen") %>" alt="NO IMAGE">--%>
                                                   
                                                <p class="title"><%#Eval("Titulo")%></p>
                                                    <p><%#Eval("Precio") %></p>
                                                    <div class="d-grid gap-2 d-md-block">              
                                                    </div>
                                            </div>
                                            <div class="flip-card-back">
                                               <h5 class="card-title"><%#Eval("Titulo") %></h5>
                                                <p class="card-text"><small class="text-body-secondary"><%#Eval("Descripcion")%></small></p>
                                                <div class="btns">
                                                        <asp:Button ID="btnAdd" runat="server"  CssClass="btn-botones" OnClick="btnAdd_Click" type="button" Text=" Agregar " 
                                                            CommandArgument='<% #Eval("Id")%>' CommandName="artId" />
                                                      <a href="DetallesArticulos.aspx?Titulo=<%#Eval("Titulo") %>" class="btn-botones">Detalles</a>                                                      
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
<%--                                                   <img id="img-flip-card" src="<%#Eval("Url_Imagen") %>" alt="NO IMAGE">--%>
                                                   
                                                <p class="title"><%#Eval("Titulo")%></p>
                                                    <p><%#Eval("Precio") %></p>
                                                    <div class="d-grid gap-2 d-md-block">              
                                                    </div>
                                            </div>
                                            <div class="flip-card-back">
                                               <h5 class="card-title"><%#Eval("Titulo") %></h5>
                                                <p class="card-text"><small class="text-body-secondary"><%#Eval("Descripcion")%></small></p>
                                                <div class="btns">
                                                        <asp:Button ID="btnAdd" runat="server"  CssClass="btn-botones" OnClick="btnAdd_Click" type="button" Text=" Agregar " 
                                                            CommandArgument='<% #Eval("Id")%>' CommandName="artId" />
                                                      <a href="DetallesArticulos.aspx?Titulo=<%#Eval("Titulo") %>" class="btn-botones">Detalles</a>                                                      
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
