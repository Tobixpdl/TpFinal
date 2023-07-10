<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Publicaciones.aspx.cs" Inherits="WebApplication1.Publicaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click"  CssClass="btn-botones2" type="button" Text="Volver" />  
<div class="container">
    <div class="mp">

         <div class="row ">
  <div class="col-12 ">
      
   
      <%if (contador == 0)
        {
%>
    <h1>No has publicado nada aún</h1>
        
    <% }
        else
        {  %>
      <%  if (this.Session["activeUser"] != null && this.Session["activeUser"].ToString() == "usuario0")
          {%>
                <h1>Publicaciones</h1>
       <%  }
           else
           {  %>
      <h1>Mis Publicaciones</h1>
      <% }%>
     <div class="row ">
       <div class="col-12 " >

         
             <h1></h1>
              <div class="cp">

     <asp:GridView ID="dgvPublicaciones" runat="server" OnRowCommand="dgvPublicaciones_RowCommand" CssClass="table " DataKeyNames="Id" AutoGenerateColumns="false" >
               <Columns>
                     <asp:templatefield headertext="">
            <itemtemplate>
              <asp:Image ID="imgPublicacion" runat="server" Height="40" Width="40"
                                     CssClass="fp" ImageUrl=<%#RUrl(Container.DataItem)%>/>     
            </itemtemplate>
          </asp:templatefield>

                   <%--<asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />--%>
                   <asp:BoundField  HeaderText="Producto" DataField="Titulo" />
                   <asp:BoundField  HeaderText="Precio" DataField="Precio" />
                
                    <asp:ButtonField   ButtonType="Button"
            commandname="Modify" 
            headertext="Acciones" 
                       
            text="Modificar"   />

                       
                  

       
                   <asp:ButtonField  ButtonType="Button"
            commandname="Request" 
            headertext="Acciones" 
            text="Eliminar"  />
                    <asp:ButtonField  ButtonType="Button" 
            commandname="Erase" 
            headertext="Acciones" 
            text="Confirmar"  />
                      <asp:ButtonField  ButtonType="Button"
            commandname="Cancelar" 
            headertext="Acciones" 
            text="Cancelar"  />
                    
                  
               </Columns>




                </asp:GridView>
              </div>
        
           
       </div>


        
     </div>
       




  </div>
      

    <%} %>
  </div>
 
     <div class="nueva publicacion" >
               <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click"  CssClass="btn-botones" type="button" Text="Crear Publicación" /> 
           </div>

           
    </div>
 
  </div>



    


 
  
    <style>


body{
    background: linear-gradient(to top, var(--bgColor) 5%, #ffffff 95%);
        background-repeat: no-repeat;
    
        width: 1920px;
    height: 1080px;
   

}

  .btn-botones{
    width: 15%;
    padding: 1px;
    background-color: var(--otherColor);
    color: #fff;
    border: none;
    border-radius: 2px;
    cursor: pointer;
    margin:20px;
  }
    .btn-botones2{
    width: 5%;
    padding: 3px;
    background-color: var(--otherColor);
    color: #fff;
    border: none;
    border-radius: 2px;
    cursor: pointer;
    margin-left: 3px;
    margin-right: 3px;
    margin:20px;
  }

    </style>
    
</asp:Content>

