﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="WebApplication1.MisCompras" %>
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
      <h1>Mis Ventas</h1>
     <div class="row ">
       <div class="col-12 " >

         
             <h1></h1>
              <div class="cp">
                  <asp:GridView ID="dvgCompras" runat="server" OnRowCommand="dvgCompras_RowCommand" CssClass="table" DataKeyNames="Id" AutoGenerateColumns="false">

               <Columns>
                   
                   <asp:BoundField  HeaderText="Producto" DataField="Titulo" />
                    <asp:BoundField  HeaderText="Cantidad" DataField="Cantidad" />
                   <asp:BoundField  HeaderText="Precio Final" DataField="PrecioFinal" />
                      <asp:templatefield headertext="Vendedor">
            <itemtemplate>
               <a class="nav-linkT" href="Contacto.aspx?Usuario=<%#Eval("Usuario")%>" id="lblVendedor"><%#Eval("Usuario")%></a>
            </itemtemplate>
          </asp:templatefield>
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
    </style>


</asp:Content>
