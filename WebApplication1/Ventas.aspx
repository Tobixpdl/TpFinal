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

      <%if (this.Session["activeUser"] != null && this.Session["activeUser"].ToString() == "usuario0")
          {%>
      <h1>Todas las ventas</h1>
<%                }%>
      <%else
          {  %>
      <h1>Mis Ventas</h1>
      <%} %>
     <div class="row ">
       <div class="col-14 " >

         
             <h1></h1>
              <div class="cp">   
               
                     <asp:DropDownList ID="ddlEstados" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstados_SelectedIndexChanged"></asp:DropDownList>

                     <asp:GridView ID="dgvVentas" runat="server" OnRowCommand="dgvVentas_RowCommand"
                           OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged1" OnPageIndexChanging="dgvVentas_PageIndexChanging"
                          AllowPaging="true" PageSize="10"
                         CssClass="table" DataKeyNames="Id" AutoGenerateColumns="false" >
               
               <Columns>
                    
                    <asp:templatefield headertext="Ver Detalles">
            <itemtemplate>
               <a href="Contacto.aspx?UsuarioReceptor=<%#Eval("UsuarioComprador")%>&Id=<%#Eval("Id")%>&UsuarioEmisor=<%#Eval("UsuarioVendedor")%>&PaginaOrigen=Ventas" id="lblVendedor">Click Acá</a>
            </itemtemplate>
          </asp:templatefield>
                   <asp:BoundField  HeaderText="Producto" DataField="Titulo" />
                    <asp:BoundField  HeaderText="Cantidad" DataField="Cantidad" />
                   <asp:BoundField  HeaderText="Precio Final" DataField="PrecioFinal" />
                    <asp:BoundField  HeaderText="Comprador" DataField="UsuarioComprador" />
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

.row{
    justify-content:center;
}

.col-12 {
    max-width:90%;
    padding: 40px;
}
    </style>

</asp:Content>
