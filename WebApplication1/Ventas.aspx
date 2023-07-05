<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebApplication1.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="mp">


          <div class="row ">
  <div class="col-12 ">
      
   
      <%if (contador == 0)
        {
%>
    <h1>No tienes ventas.</h1>
        
    <% }
        else
        {  %>
      <h1>Mis Ventas</h1>
     <div class="row ">
       <div class="col-14 " >

         
             <h1></h1>
              <div class="cp">

                     <asp:GridView ID="dgvVentas" runat="server" OnRowCommand="dgvVentas_RowCommand" CssClass="table" DataKeyNames="Id" AutoGenerateColumns="false" >
               
               <Columns>
                    
                    <asp:templatefield headertext="Ver Detalles">
            <itemtemplate>
               <a class="nav-linkT" href="Contacto.aspx?Usuario=<%#Eval("Usuario")%>&Id=<%#Eval("Id")%>" id="lblId">Click Acá</a>
            </itemtemplate>
          </asp:templatefield>
                   <asp:BoundField  HeaderText="Producto" DataField="Titulo" />
                    <asp:BoundField  HeaderText="Cantidad" DataField="Cantidad" />
                   <asp:BoundField  HeaderText="Precio Final" DataField="PrecioFinal" />
                    <asp:BoundField  HeaderText="Comprador" DataField="Usuario" />
                 <asp:BoundField  HeaderText="Fecha de Compra" DataField="FechaCompra" />
                   <asp:BoundField  HeaderText="Estado" DataField="Estado" />
                   <asp:BoundField  HeaderText="Fecha de Entrega" DataField="FechaEntrega" />
                   <asp:BoundField  HeaderText="Metodo de Pago" DataField="metodo" />
                    
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
    </style>

</asp:Content>
