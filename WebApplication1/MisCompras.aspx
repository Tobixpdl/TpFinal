<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="WebApplication1.MisCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  
    <div class="mp">


          <div class="row ">
  <div class="col-12 ">
      
   
      <%if (contador == 0)
        {
%>
    <h1>No tienes compras.</h1>
        
    <% }
        else
        {  %>
      <h1>Mis Compras</h1>
     <div class="row ">
       <div class="col-12 " >

             <h1></h1>
              <div class="cp">
                  <asp:GridView ID="dvgCompras" runat="server" OnRowCommand="dvgCompras_RowCommand" 
                      OnSelectedIndexChanged="dvgCompras_SelectedIndexChanged" 
                      OnPageIndexChanging="dvgCompras_PageIndexChanging" AllowPaging="true" PageSize="10"
                      CssClass="table" DataKeyNames="Id" AutoGenerateColumns="false">

               <Columns>
                     <asp:templatefield headertext="Ver Detalles">
            <itemtemplate>
                    <a href="Contacto.aspx?UsuarioReceptor=<%#Eval("UsuarioVendedor")%>&Id=<%#Eval("Id")%>&UsuarioEmisor=<%#Eval("UsuarioComprador")%>&PaginaOrigen=MisCompras">Click aca</a>
            </itemtemplate>
          </asp:templatefield>
                   <asp:BoundField  HeaderText="Producto" DataField="Titulo" />
                    <asp:BoundField  HeaderText="Cantidad" DataField="Cantidad" />
                   <asp:BoundField  HeaderText="Precio Final" DataField="PrecioFinal" />
                    <asp:BoundField  HeaderText="Vendedor" DataField="UsuarioVendedor" />
                 <asp:BoundField  HeaderText="Fecha de Compra" DataField="FechaCompra" />
                   <asp:BoundField  HeaderText="Estado" DataField="Estado" />
                   <asp:BoundField  HeaderText="Fecha de Entrega" DataField="FechaEntrega" />
                    
                        
               </Columns>


                </asp:GridView>
              </div>
        
           
       </div>


        
     </div>
       




  </div>
      

    <%} %>
  </div>


    </div>


      
<style>

body{
    background: linear-gradient(to top, var(--bgColor) 5%, #ffffff 95%);
        background-repeat: no-repeat;
    
        width: 1920px;
    height: 1080px;
}
.row{
    justify-content:center;
}

.col-12 {
    max-width:90%;
    padding: 40px;
}
    </style>


</asp:Content>
