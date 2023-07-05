<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfiles.aspx.cs" Inherits="WebApplication1.Perfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section class="articulosXPerfil">
        <div class="mega-main">
                <div class="main">

<asp:Repeater ID="rptUsuarios" runat="server">
    <ItemTemplate>
        <div id="DivNombre">
           <a id="Link" href='PerfilUsuario.aspx?User=<%#Eval("usuario")%>' class="card-user"><%#Eval("usuario") %> </a>
        </div>
        <div class="container-items">
            <asp:Repeater ID="rprCards" runat="server">
                <ItemTemplate>
                    <div class="item">
                        <figure>
                            <asp:Image ID="imgPublicacion" runat="server" CssClass="img-" OnPreRender="imgPublicacion_PreRender" ImageUrl='<%#ReturnUrl(Container.DataItem)%>'/>
                        </figure>
                        <div class="info-product">
                            <h2 class="info-title"><%#Eval("Titulo")%></h2>
                            <p class="price">$<%#Eval("Precio")%></p>
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn-info" OnClick="btnAdd_Click" type="button" Text="Agregar" CommandArgument='<% #Eval("Id")%>' CommandName="artId" />
                            <a href='DetallesArticulos.aspx?Id=<%#Eval("Id") %>' class="btn-info">Detalles</a>					                    
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </ItemTemplate>
</asp:Repeater>

                    
                        </div>
            </div>
        </section>

    <style>

   #Link {
  display: inline-block;
  font-weight: bold;
  margin: 10px 0; /* Margen superior e inferior */
  text-decoration: none; /* Eliminar subrayado del enlace */
  color: inherit; /* Heredar el color del texto del padre */
}

#Link:hover {
  color: #00aaff; /* Color celeste al pasar el mouse */
}
#DivNombre{
 padding: 30px;
 box-shadow: 0px -4px 6px -2px rgba(0, 0, 0, 0.2);
}
 
</style>
</asp:Content>
