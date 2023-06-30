<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Publicaciones.aspx.cs" Inherits="WebApplication1.Publicaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click"  CssClass="btn btn-primary me-md-2" type="button" Text="Volver" />  
<div class="container">
  <div class="row border border-dark-subtle">
  <div class="col-12 " style="background:#0094ff;text-align:center;">
      
   
      <%if (contador == 0)
        {
%>
    <h1>No has publicado nada aún</h1>
       
      <asp:Button ID="btnIrADefault" runat="server" OnClick="btnCrear_Click"  CssClass="btn btn-primary me-md-2" type="button" Text="Crear Publicacion" />  
    <% }
        else
        {  %>
      <h1>Mis Publicaciones</h1>
     <div class="row">
       <div class="col-8" style="text-align:center">

         
             <h1></h1>
              
           <asp:GridView ID="dgvPublicaciones" runat="server" OnRowCommand="dgvPublicaciones_RowCommand" CssClass="table" DataKeyNames="Id" AutoGenerateColumns="false" >
               
               <Columns>
                   <asp:BoundField  HeaderText="Foto" />
                   <asp:BoundField  HeaderText="Producto" DataField="Titulo" />
                   <asp:BoundField  HeaderText="Precio" DataField="Precio" />
                    <asp:BoundField  HeaderText="Vendidos" DataField="Stock" />
                    <asp:ButtonField   ButtonType="Button"
            commandname="Modify" 
            headertext="Acciones" 
                       
            text="Modificar"   />
                   <asp:ButtonField  ButtonType="Button"
            commandname="Erase" 
            headertext="Acciones" 
            text="Eliminar"  />


                    
                  
               </Columns>




                </asp:GridView>
           
            <div class="nueva publicacion" >
               <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click"  CssClass="btn btn-primary me-md-2" type="button" Text="Crear Publicación" /> 
           </div>
       </div>


        
     </div>
    
       




  </div>
      

    <%} %>
  </div>
 
  </div>
</div> 


    


 
  

    
</asp:Content>


