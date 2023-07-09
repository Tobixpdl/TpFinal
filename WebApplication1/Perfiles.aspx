<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfiles.aspx.cs" Inherits="WebApplication1.Perfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1>Todos los usuarios</h1>
     <div class="row ">
       <div class="col-12" >
             <h1></h1>
              <div class="cp">

     <asp:GridView ID="dgvPerfiles" runat="server" OnRowCommand="dgvPerfiles_RowCommand" CssClass="table " DataKeyNames="Id" AutoGenerateColumns="false" >
               <Columns>

                   <%--<asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />--%>
                   <asp:BoundField  HeaderText="Usuario" DataField="usuario" />
                   <asp:BoundField  HeaderText="Nombre" DataField="nombre" />
                   <asp:BoundField  HeaderText="Apellido" DataField="apellido" />
                   <asp:BoundField  HeaderText="Mail" DataField="mail" />

                   <asp:ButtonField  ButtonType="Button"
            commandname="Erase" 
            headertext="Acciones" 
            text="Eliminar"  />

               </Columns>
                </asp:GridView>
              </div>
       </div>
     </div>
    <style>
        body {
            background: linear-gradient(to top, var(--bgColor) 5%, #ffffff 95%);
            background-repeat: no-repeat;
            width: 1920px;
            height: 1080px;
        }

    </style>
  
    
    
    
    <%--<section class="articulosXPerfil">
        <div class="mega-main">
                <div class="main">

<asp:Repeater ID="rptUsuarios" runat="server">
    <ItemTemplate>
        <div id="DivNombre">
            <asp:Label id="Link" runat="server" CssClass="card-user" OnClick="Label_Click"><%#Eval("usuario") %></asp:Label>

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
    --%>
</asp:Content>
